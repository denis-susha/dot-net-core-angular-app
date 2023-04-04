using DotNetCoreAngularApp.BusinessLogic.Services.Registration;
using DotNetCoreAngularApp.Web.Models.Registration;
using FluentValidation;

namespace DotNetCoreAngularApp.Web.Validators.Registration
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationModelValidator(IRegistrationService registrationService)
        {
            RuleFor(x => x.LoginInfo).NotNull();
            RuleFor(x => x.LoginInfo.Email).NotEmpty().EmailAddress().MaximumLength(230).MustAsync(
                async (email, cancellation) => await registrationService.IsEmailUnique(email));
            RuleFor(x => x.LoginInfo.Password).MaximumLength(50).MinimumLength(2).Matches(@"[a-zA-Z]+")
                .Matches(@"\d");
            RuleFor(x => x.LoginInfo.ConfirmPassword).Equal(x => x.LoginInfo.Password);
            RuleFor(x => x.LoginInfo.AcceptTerms).Equal(true);
            RuleFor(x => x.ProvinceId).GreaterThan(0);
        }
    }
}
