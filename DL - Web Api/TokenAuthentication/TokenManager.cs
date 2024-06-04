using DL___Web_Api.Controllers;
using DL___Web_Api.Data;
using DL___Web_Api.Model.ViewModels;
using Microsoft.EntityFrameworkCore;
using SH.Pages.Identity;
using System.DirectoryServices;


namespace DL___Web_Api.TokenAuthentication
{

    public class TokenManager : ITokenManager
    {

        //private readonly ComcoMContext _context;

        //public TokenManager(ComcoMContext context)
        //{
        //    _context = context;
        //}
        private List<Token> listTokens;
        public TokenManager()
        {
            listTokens = new List<Token>();
        }
        public  bool Authenticate(string userName, string password)
        {
            //if (!string.IsNullOrWhiteSpace(userName) &&
            //   !string.IsNullOrWhiteSpace(password) &&
            //   userName.ToLower() == "admin" &&
            //   password == "password")
            //    return true;
            //else
            //    return false;
            try
            {
                
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://DC=persianpadana,DC=local", userName, password, AuthenticationTypes.Secure);
                DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
                searcher.Filter = "(sAMAccountName=" + userName + ")";
                SearchResult result = searcher.FindOne();
                if (result != null)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The user name or password is incorrect")) return false;
                else return false;
            }
        }
        public Token NewToken(string userId,Boolean rememberme)

        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpiryDate = rememberme ? DateTime.Now.AddMonths(1): DateTime.Now.AddMinutes(30),
                UserID = userId
            };
            listTokens.Add(token);
            return token;
        }
        public bool VerifyToken(string token)
        {
            if (listTokens.Any(x => x.Value == token
                && x.ExpiryDate > DateTime.Now))
            {
                return true;
            }
            return false;
        }

    }
}
