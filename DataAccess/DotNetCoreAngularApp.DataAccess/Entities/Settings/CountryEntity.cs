namespace DotNetCoreAngularApp.DataAccess.Entities.Settings
{
    public class CountryEntity
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<ProvinceEntity> Provinces { get; set; }
    }
}
