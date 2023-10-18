namespace DL___Web_Api.TokenAuthentication
{
    public interface ITokenManager
    {
        bool Authenticate(string userName, string password);
        Token NewToken();
        bool VerifyToken(string token);
    }
}