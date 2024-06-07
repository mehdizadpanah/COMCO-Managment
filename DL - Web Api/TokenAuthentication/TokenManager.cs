﻿using DL___Web_Api.Controllers;
using DL___Web_Api.Data;
using Microsoft.EntityFrameworkCore;
using SH.Pages.Identity;
using System.DirectoryServices;
using SH.Data.ModelVM.Authentication;
using DL___Web_Api.Repository;
using NuGet.Protocol;

namespace DL___Web_Api.TokenAuthentication
{

    public class TokenManager : ITokenManager
    {

        private List<LoginResult> listTokens;
       
        public TokenManager()
        {
            listTokens = new List<LoginResult>();
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
       
        public async Task<LoginResult> NewToken(string username,Boolean rememberme)

        {
            var _userRepository = new UserRepository();
            var a = await  _userRepository.GetUserByDCUname(username);
            var token = new LoginResult
            {
                Token = Guid.NewGuid().ToString(),
                ExpiryDate = rememberme ? DateTime.Now.AddMonths(1) : DateTime.Now.AddMinutes(30),
                UserName = a.DcUsername.ToString(),
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
