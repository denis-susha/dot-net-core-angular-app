using DotNetCoreAngularApp.BusinessLogic.Models.Settings;
using DotNetCoreAngularApp.DataAccess.Entities.Settings;

namespace DotNetCoreAngularApp.BusinessLogic.Factories.Settings
{
    public class ProvinceFactory : IProvinceFactory
    {
        public Province MapToBusinessModel(ProvinceEntity provinceEntity)
        {
            return new Province
            {
                ProvinceId = provinceEntity.ProvinceId,
                CountryCode = provinceEntity.CountryCode,
                Name = provinceEntity.Name
            };
        }
    }
}
