using DotNetCoreAngularApp.BusinessLogic.Models.Settings;
using DotNetCoreAngularApp.DataAccess.Entities.Settings;

namespace DotNetCoreAngularApp.BusinessLogic.Factories.Settings;

public interface IProvinceFactory
{
    Province MapToBusinessModel(ProvinceEntity provinceEntity);
}