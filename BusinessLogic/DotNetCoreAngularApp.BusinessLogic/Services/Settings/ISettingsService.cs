using DotNetCoreAngularApp.BusinessLogic.Models.Settings;

namespace DotNetCoreAngularApp.BusinessLogic.Services.Settings;

public interface ISettingsService
{
    Task<IReadOnlyList<Country>> GetCountries();
    Task<IReadOnlyList<Province>> GetProvinces(string countryCode);
}