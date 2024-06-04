namespace DL___Web_Api.Model.ViewModels
{
    public class LoginVM
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public Boolean IsRememberMe { get; set; } = false;
        //public string Usernam { get; internal set; }
    }
}
