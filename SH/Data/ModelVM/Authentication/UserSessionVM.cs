namespace SH.Data.ModelVM.Authentication
{
    public class UserSessionVM
    {
        public Guid ID { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
        public string BarInfo { get; set; }


    }
}
