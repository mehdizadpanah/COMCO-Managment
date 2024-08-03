using Microsoft.OpenApi.Services;
using System.DirectoryServices;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;
using SearchResult = System.DirectoryServices.SearchResult;



namespace DL.Services
{
    public class AuthService
    {
        public Boolean ValidateUser(string username, string password)
        {
            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://DC=persianpadana,DC=local", username, password, AuthenticationTypes.Secure);
                DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
                searcher.Filter = "(sAMAccountName=" + username + ")";
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

    }
}
