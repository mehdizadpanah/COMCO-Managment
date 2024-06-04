namespace DL___Web_Api.TokenAuthentication
{
    public interface ITokenManager
    {
        bool Authenticate(string userName, string password);
        Token NewToken(string userId);
        bool VerifyToken(string token);
    }
}