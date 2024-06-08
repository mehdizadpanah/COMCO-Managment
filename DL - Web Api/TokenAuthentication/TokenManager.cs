using System.DirectoryServices;
using SH.Data.ModelVM.Authentication;
using DL___Web_Api.Repository;

namespace DL___Web_Api.TokenAuthentication
{

    public class TokenManager : ITokenManager
    {

        private readonly List<LoginResultVM> listTokens;
       
        //private readonly ComcoMContext _context;

        //public TokenManager(ComcoMContext context)
        //{
        //    _context = context;
        //}

        public TokenManager()
        {
            listTokens = new List<LoginResultVM>();
        }
        
        
        public  bool Authenticate(string userName, string password)
        {
            
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
       
        public async Task<LoginResultVM> NewToken(string username,Boolean rememberme)

        {
            var _userRepository = new UserRepository();
            var a = await  _userRepository.GetUserByDCUname(username);
            var token = new LoginResultVM
            {
                Token = Guid.NewGuid().ToString(),
                ExpiryDate = rememberme ? DateTime.Now.AddMonths(1) : DateTime.Now.AddMinutes(30),
                UserName = a.DcUsername,
                Family = a.LastName,
                Name = a.FirstName

            };
            listTokens.Add(token);
            
            return token;
        }
        public bool VerifyToken(string token)
        {
            if (listTokens.Any(x => x.Token == token
                && x.ExpiryDate > DateTime.Now))
            {
                return true;
            }
            return false;
        }

    }
}
