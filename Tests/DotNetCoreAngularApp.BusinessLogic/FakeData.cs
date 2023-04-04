using DotNetCoreAngularApp.DataAccess.Entities.Settings;
using DotNetCoreAngularApp.DataAccess.Entities.User;

namespace DotNetCoreAngularApp.BusinessLogic.Tests
{
    public static class FakeData
    {
        public static IEnumerable<CountryEntity> GetCountryEntities()
        {
            return new List<CountryEntity>
            {
                new() { CountryCode = "C1", Name = "Country 1" },
                new() { CountryCode = "C2", Name = "Country 2" }
            };
        }

        public static IEnumerable<ProvinceEntity> GetProvinceEntities()
        {
            return new List<ProvinceEntity>
            {
                new () { ProvinceId = 1, CountryCode = "C1", Name = "Province 1.1" },
                new () { ProvinceId = 2, CountryCode = "C1", Name = "Province 1.2" },
                new () { ProvinceId = 3, CountryCode = "C2", Name = "Province 2.1" },
                new () { ProvinceId = 4, CountryCode = "C2", Name = "Province 2.2" }
            };
        }

        public static IEnumerable<UserEntity> GetUsersEntities()
        {
            return new List<UserEntity>
            {
                new () { UserId = 1, Email = "example@email.com", Password = "MXE=", ProvinceId = 1, AcceptTerms = true },
                new () { UserId = 2, Email = "example2@email.com", Password = "MXE=", ProvinceId = 3, AcceptTerms = true }
            };
        }
    }
}
