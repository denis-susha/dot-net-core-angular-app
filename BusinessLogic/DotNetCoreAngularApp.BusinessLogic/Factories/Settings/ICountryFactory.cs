using DotNetCoreAngularApp.BusinessLogic.Models.Settings;
using DotNetCoreAngularApp.DataAccess.Entities.Settings;

namespace DotNetCoreAngularApp.BusinessLogic.Factories.Settings;

public interface ICountryFactory
{
    Country MapToBusinessModel(CountryEntity countryEntity);
}