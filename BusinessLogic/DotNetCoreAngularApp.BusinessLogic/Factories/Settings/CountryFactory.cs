using DotNetCoreAngularApp.BusinessLogic.Models.Settings;
using DotNetCoreAngularApp.DataAccess.Entities.Settings;

namespace DotNetCoreAngularApp.BusinessLogic.Factories.Settings
{
    public class CountryFactory : ICountryFactory
    {
        public Country MapToBusinessModel(CountryEntity countryEntity)
        {
            return new Country
            {
                CountryCode = countryEntity.CountryCode,
                Name = countryEntity.Name,
            };
        }
    }
}
