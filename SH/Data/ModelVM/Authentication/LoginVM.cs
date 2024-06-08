namespace SH.Data.ModelVM.Authentication
{
    public class LoginVM
    {
        public required string Username { get; set; }
        public string? Password { get; set; }
        public bool IsRememberMe { get; set; } = false;
        public string? Token { get; set; } 

    }
}
