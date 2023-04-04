using DotNetCoreAngularApp.BusinessLogic.Models.User;

namespace DotNetCoreAngularApp.BusinessLogic.Services.Registration;

public interface IRegistrationService
{
    Task<bool> IsEmailUnique(string email);
    Task RegisterUser(User user);
}