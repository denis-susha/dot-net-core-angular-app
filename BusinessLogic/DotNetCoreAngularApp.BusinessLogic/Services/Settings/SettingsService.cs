using DotNetCoreAngularApp.BusinessLogic.Factories.Settings;
using DotNetCoreAngularApp.BusinessLogic.Models.Settings;
using DotNetCoreAngularApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreAngularApp.BusinessLogic.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly IDbContextFactory<DotNetCoreAngularAppDbContext> _dbContextFactory;
        private readonly ICountryFactory _countryFactory;
        private readonly IProvinceFactory _provinceFactory;

        public SettingsService(IDbContextFactory<DotNetCoreAngularAppDbContext> dbContextFactory,
            ICountryFactory countryFactory, IProvinceFactory provinceFactory)
        {
            _dbContextFactory = dbContextFactory;
            _countryFactory = countryFactory;
            _provinceFactory = provinceFactory;
        }

        public async Task<IReadOnlyList<Country>> GetCountries()
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var countryEntities = await dbContext.Countries.AsNoTracking().ToListAsync();
            var countries = countryEntities.Select(_countryFactory.MapToBusinessModel).ToList();

            return countries;
        }

        public async Task<IReadOnlyList<Province>> GetProvinces(string countryCode)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var provinceEntities = await dbContext.Provinces.Where(p => p.CountryCode == countryCode).AsNoTracking()
                .ToListAsync();
            var provinces = provinceEntities.Select(_provinceFactory.MapToBusinessModel).ToList();

            return provinces;
        }
    }
}
