namespace SH.Data.ModelVM.Authentication
{
    public class LoginRequestByUsernameVM
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public bool IsRememberMe { get; set; } = false;
        


    }
}
