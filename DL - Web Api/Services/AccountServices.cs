using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using Microsoft.Identity.Client;
namespace DL___Web_Api.Services
{
    public class AccountServices : IAccountService
    {
        //public Boolean GetAccountById(int id)
        //{
        //    if (id == 1) return true;
        //    else return false;

        //}
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
        //////public class ActiveDirectoryAuthentication
        //////{
        //////    public static bool AuthenticateUser(string username, string password)
        //////    {
        //////        // Create a DirectoryEntry object.
        //////        DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://DC=persianpadana,DC=local");

        //////        // Set the username and password properties.
        //////        directoryEntry.Username = username;
        //////        directoryEntry.Password = password;

        //////        // Try to find the user.
        //////        //SearchResult searchResult = directoryEntry.Findone();
        //////        DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
        //////        searcher.Filter = "(sAMAccountName=" + username + ")";
        //////        SearchResult result = searcher.FindOne();

        //////        if (result != null)
        //////        {
        //////            // Do something with the search result
        //////        }
        //////    // If the search result is not null, the user was authenticated.
        //////    //return searchResult != null;
        //////    return result !=null;
        //////    }
        //////}
    
            
        


    
}
