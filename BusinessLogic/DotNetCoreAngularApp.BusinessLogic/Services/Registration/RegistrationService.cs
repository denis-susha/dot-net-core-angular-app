using DotNetCoreAngularApp.BusinessLogic.Factories.User;
using DotNetCoreAngularApp.BusinessLogic.Models.User;
using DotNetCoreAngularApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreAngularApp.BusinessLogic.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserFactory _userFactory;
        private readonly IDbContextFactory<DotNetCoreAngularAppDbContext> _dbContextFactory;

        public RegistrationService(IDbContextFactory<DotNetCoreAngularAppDbContext> dbContextFactory,
            IUserFactory userFactory)
        {
            _dbContextFactory = dbContextFactory;
            _userFactory = userFactory;
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var isUnique = !await dbContext.Users.AnyAsync(u => u.Email == email.ToLower());

            return isUnique;
        }

        public async Task RegisterUser(User user)
        {
            var userEntity = _userFactory.MapToEntityModel(user);

            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            dbContext.Users.Add(userEntity);
            await dbContext.SaveChangesAsync();
        }
    }
}
