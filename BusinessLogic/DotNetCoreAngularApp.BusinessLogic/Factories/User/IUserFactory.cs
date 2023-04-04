using DotNetCoreAngularApp.DataAccess.Entities.User;

namespace DotNetCoreAngularApp.BusinessLogic.Factories.User;

public interface IUserFactory
{
    UserEntity MapToEntityModel(Models.User.User user);
}