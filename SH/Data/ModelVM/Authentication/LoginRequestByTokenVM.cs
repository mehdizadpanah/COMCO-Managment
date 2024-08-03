namespace SH.Data.ModelVM.Authentication
{
    public class LoginRequestByTokenVM
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        


    }
}
