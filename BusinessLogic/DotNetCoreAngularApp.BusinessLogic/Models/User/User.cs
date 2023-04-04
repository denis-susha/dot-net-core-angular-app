namespace DotNetCoreAngularApp.BusinessLogic.Models.User
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AcceptTerms { get; set; }
        public int ProvinceId { get; set; }
    }
}
