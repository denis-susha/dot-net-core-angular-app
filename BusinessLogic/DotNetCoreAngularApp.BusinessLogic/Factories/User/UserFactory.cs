using System.Text;
using DotNetCoreAngularApp.DataAccess.Entities.User;

namespace DotNetCoreAngularApp.BusinessLogic.Factories.User
{
    public class UserFactory : IUserFactory
    {
        public UserEntity MapToEntityModel(Models.User.User user)
        {
            return new UserEntity
            {
                Email = user.Email.ToLower(),
                Password = EncodePassword(user.Password),
                AcceptTerms = user.AcceptTerms,
                ProvinceId = user.ProvinceId
            };
        }

        private string EncodePassword(string password)
        {
            var passwordAsBytes = Encoding.ASCII.GetBytes(password);
            var result = Convert.ToBase64String(passwordAsBytes);

            return result;
        }
    }
}
