using DotNetCoreAngularApp.BusinessLogic.Factories.Settings;
using DotNetCoreAngularApp.BusinessLogic.Models.Settings;
using DotNetCoreAngularApp.BusinessLogic.Services.Settings;
using DotNetCoreAngularApp.DataAccess;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace DotNetCoreAngularApp.BusinessLogic.Tests
{
    [TestFixture]
    public class SettingsServiceTests
    {
        private SettingsService _settingsService;

        [SetUp]
        public void Setup()
        {
            var mockDbFactory = new Mock<IDbContextFactory<DotNetCoreAngularAppDbContext>>();
            mockDbFactory.Setup(f => f.CreateDbContextAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    var mockDbContext = new Mock<DotNetCoreAngularAppDbContext>();
                    mockDbContext.Setup(x => x.Countries).ReturnsDbSet(FakeData.GetCountryEntities());
                    mockDbContext.Setup(x => x.Provinces).ReturnsDbSet(FakeData.GetProvinceEntities());

                    return mockDbContext.Object;
                });

            _settingsService = new SettingsService(mockDbFactory.Object, new CountryFactory(), new ProvinceFactory());
        }

        [Test]
        public async Task GetCountriesTest()
        {
            // Arrange
            var fakeData = new List<Country>
            {
                new() { CountryCode = "C1", Name = "Country 1" },
                new() { CountryCode = "C2", Name = "Country 2" }
            };

            // Act
            var countries = await _settingsService.GetCountries();

            // Assert
            countries.Should().BeEquivalentTo(fakeData);
        }

        [Test]
        public async Task GetProvincesTest()
        {
            // Arrange
            const string countryCode = "C1";
            var dataToCompare = new List<Province>
            {
                new () { ProvinceId = 1, CountryCode = "C1", Name = "Province 1.1" },
                new () { ProvinceId = 2, CountryCode = "C1", Name = "Province 1.2" },
            };

            // Act
            var provinces = await _settingsService.GetProvinces(countryCode);

            // Assert
            provinces.Should().BeEquivalentTo(dataToCompare);
        }

        [Test]
        public async Task GetProvincesWithWrongCountryCodeTest()
        {
            // Arrange
            const string countryCode = "dko94ffk";

            // Act
            var provinces = await _settingsService.GetProvinces(countryCode);

            // Assert
            Assert.IsEmpty(provinces);
        }
    }
}
