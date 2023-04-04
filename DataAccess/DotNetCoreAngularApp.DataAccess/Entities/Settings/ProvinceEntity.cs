using DotNetCoreAngularApp.DataAccess.Entities.User;

namespace DotNetCoreAngularApp.DataAccess.Entities.Settings
{
    public class ProvinceEntity
    {
        public int ProvinceId { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public virtual CountryEntity Country { get; set; }
        public virtual IEnumerable<UserEntity> Users { get; set; }
    }
}
