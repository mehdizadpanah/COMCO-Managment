﻿using SH.Data.ModelVM.Authentication;

namespace DL___Web_Api.TokenAuthentication;

public interface ITokenManager
{
    bool Authenticate(string userName, string password);
    Task<LoginResultVM> NewToken(string username, Boolean rememberme);
    bool VerifyToken(string token);
}
