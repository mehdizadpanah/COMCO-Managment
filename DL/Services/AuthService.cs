using System.DirectoryServices;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;
using SearchResult = System.DirectoryServices.SearchResult;



namespace DL.Services
{
    public class AuthService
    {
        public bool LdapAuthenticate(string username, string password,string ldapDomain)
        {
            var ldapPath = "LDAP://" + ldapDomain;

            string domainAndUsername = $"{ldapDomain}\\{username}";
            try
            {
                using (DirectoryEntry entry = new DirectoryEntry(ldapPath, domainAndUsername, password))
                {
                    // Bind to the native AdsObject to force authentication.
                    object obj = entry.NativeObject;

                    using (DirectorySearcher search = new DirectorySearcher(entry))
                    {
                        search.Filter = $"(sAMAccountName={username})";
                        search.PropertiesToLoad.Add("cn");

                        SearchResult result = search.FindOne();

                        if (result == null)
                        {
                            return false;
                        }

                        // User authenticated successfully.
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception details (ex.Message) for debugging purposes.
                Console.WriteLine($"Authentication failed: {ex.Message}");
                return false;
            }
        }
    }


}
