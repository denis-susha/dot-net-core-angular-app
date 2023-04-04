using DotNetCoreAngularApp.BusinessLogic.Models.Settings;
using DotNetCoreAngularApp.BusinessLogic.Services.Settings;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreAngularApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ISettingsService _settingsService;

        public SettingsController(ILogger<SettingsController> logger, ISettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
        }

        /// <summary>
        /// Gets the list of all Countries.
        /// </summary>
        /// <returns>The list of Countries.</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("getcountries")]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            try
            {
                var countries = await _settingsService.GetCountries();

                return countries;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw new Exception("An error occurred.");
            }
        }

        /// <summary>
        /// Gets the list of Provinces by a country code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>The list of Provinces.</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("getprovinces")]
        public async Task<IEnumerable<Province>> GetProvinces([FromQuery] string countryCode)
        {
            try
            {
                var provinces = await _settingsService.GetProvinces(countryCode);

                return provinces;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Request: {0}", countryCode);
                throw new Exception("An error occurred.");
            }
        }
    }
}