namespace SH.Data.ModelVM.Authentication
{
    public class LoginResult
    {
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
