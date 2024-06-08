using System.Reflection.Metadata.Ecma335;

namespace SH.Data.ModelVM.Authentication
{
    public class LoginCookiesVM
    {
        public string? Username { get; set; } 
        public DateTime ExpiryDate { get; set; }
        public string? Token{ get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
