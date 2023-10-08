using System.DirectoryServices;

namespace DL___Web_Api.TokenAuthentication
{
    public class TokenManager : ITokenManager
    {
        private List<Token> listTokens;
        public TokenManager()
        {
            listTokens = new List<Token>();
        }
        public bool Authenticate(string userName, string password)
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
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://DC=persianpadana,DC=local", userName , password, AuthenticationTypes.Secure);
                DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
                searcher.Filter = "(sAMAccountName=" + userName + ")";
                SearchResult result = searcher.FindOne();
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The user name or password is incorrect")) return false;
                else return false;
            }
        }
        public Token NewToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddMinutes(1)
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
