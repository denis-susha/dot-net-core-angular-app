using DotNetCoreAngularApp.DataAccess.Entities.Settings;

namespace DotNetCoreAngularApp.DataAccess.Entities.User
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AcceptTerms { get; set; }
        public int ProvinceId { get; set; }
        public virtual ProvinceEntity Province { get; set; }
    }
}
