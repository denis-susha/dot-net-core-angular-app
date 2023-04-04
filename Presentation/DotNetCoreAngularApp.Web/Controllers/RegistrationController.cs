using DotNetCoreAngularApp.BusinessLogic.Models.User;
using DotNetCoreAngularApp.BusinessLogic.Services.Registration;
using DotNetCoreAngularApp.Web.Models.Registration;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DotNetCoreAngularApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IValidator<RegistrationModel> _registrationModelValidator;
        private readonly IRegistrationService _registrationService;

        public RegistrationController(ILogger<RegistrationController> logger,
            IValidator<RegistrationModel> registrationModelValidator,
            IRegistrationService registrationService)
        {
            _logger = logger;
            _registrationModelValidator = registrationModelValidator;
            _registrationService = registrationService;
        }

        /// <summary>
        /// Register new User.
        /// </summary>
        /// <param name="registrationInfo">The information about new User.</param>
        /// <returns>The HTTP status code.</returns>
        /// <response code="200">User has been registered</response>
        /// <response code="400">Error in the body request</response>
        /// <response code="500">An unknown error occurred</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> RegisterUser([FromBody] RegistrationModel registrationInfo)
        {
            try
            {
                var validationResult = await _registrationModelValidator.ValidateAsync(registrationInfo);
                if (!validationResult.IsValid)
                {
                    _logger.LogInformation("Request is not valid: {0}", JsonSerializer.Serialize(registrationInfo));
                    return StatusCode(StatusCodes.Status400BadRequest, "Error in the body request.");
                }

                var user = new User
                {
                    Email = registrationInfo.LoginInfo.Email,
                    Password = registrationInfo.LoginInfo.Password,
                    AcceptTerms = registrationInfo.LoginInfo.AcceptTerms,
                    ProvinceId = registrationInfo.ProvinceId
                };

                await _registrationService.RegisterUser(user);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User hasn't registered. Request: {0}", registrationInfo);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}