using DotNetCoreAngularApp.BusinessLogic.Factories.User;
using DotNetCoreAngularApp.BusinessLogic.Models.User;
using DotNetCoreAngularApp.BusinessLogic.Services.Registration;
using DotNetCoreAngularApp.DataAccess;
using DotNetCoreAngularApp.DataAccess.Entities.User;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace DotNetCoreAngularApp.BusinessLogic.Tests
{
    [TestFixture]
    public class RegistrationServiceTests
    {
        private RegistrationService _registrationService;
        private List<UserEntity> _users = new(FakeData.GetUsersEntities());

        [SetUp]
        public void Setup()
        {
            var mockDbFactory = new Mock<IDbContextFactory<DotNetCoreAngularAppDbContext>>();
            mockDbFactory.Setup(f => f.CreateDbContextAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    var mockDbContext = new Mock<DotNetCoreAngularAppDbContext>();
                    mockDbContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
                        .ReturnsAsync(() => 1).Verifiable();
                    mockDbContext.Setup(x => x.Users).ReturnsDbSet(_users);
                    mockDbContext.Setup(x => x.Users.Add(It.IsAny<UserEntity>()))
                        .Callback<UserEntity>(user => _users.Add(user));
                    return mockDbContext.Object;
                });

            _registrationService = new RegistrationService(mockDbFactory.Object, new UserFactory());
        }

        [Test]
        public async Task NotUniqueEmailTest()
        {
            // Arrange
            const string email = "example@email.com";

            // Act
            var isEmailUnique = await _registrationService.IsEmailUnique(email);

            // Assert
            Assert.IsFalse(isEmailUnique);
        }

        [Test]
        public async Task UniqueEmailTest()
        {
            // Arrange
            const string email = "fkm4@email.com";

            // Act
            var isEmailUnique = await _registrationService.IsEmailUnique(email);

            // Assert
            Assert.IsTrue(isEmailUnique);
        }

        [Test]
        public async Task GetProvincesTest()
        {
            // Arrange
            var newUser = new User
                { Email = "sfdfd@email.com", Password = "1q", ProvinceId = 4, AcceptTerms = true };

            // Act
            await _registrationService.RegisterUser(newUser);

            // Assert
            Assert.IsTrue(_users.Any(u => u.Email == newUser.Email));
        }
    }
}
