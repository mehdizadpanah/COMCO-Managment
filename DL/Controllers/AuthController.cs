using DL.Settings;
using Microsoft.AspNetCore.Mvc;
using SH.Data.ModelVM.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using DL.Services;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly AuthService _authService;


    public AuthController(TokenService tokenService, ApplicationDbContext context, IConfiguration configuration,
        AuthService authService)
    {
        _tokenService = tokenService;
        _context = context;
        _configuration = configuration;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestByUsernameVM userLogin)
    {
        if (_authService.ValidateUser(userLogin.Username,userLogin.Password))
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userLogin.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, userLogin.Username),
                //new Claim("role", "admin"),
                //new Claim("email", "test@example.com"),
                //new Claim("name", "Test User")
            };

            var userSessionVM = new UserSessionVM
            {
                AccessToken = _tokenService.GenerateAccessToken(claims),
                RefreshToken = _tokenService.GenerateRefreshToken(),
                AccessTokenExpiration = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:AccessTokenExpirationMinutes"])),
                RefreshTokenExpiration = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:RefreshTokenExpirationDays"]))

            };

            await _tokenService.SaveTokenAsync(userSessionVM);

            return Ok(new LoginResultVMv2
            {
                AccessToken = userSessionVM.AccessToken,
                RefreshToken = userSessionVM.RefreshToken
            });
        }

        return Unauthorized();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] LoginRequestByTokenVM loginRequestVM)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(loginRequestVM.AccessToken);
        var username = principal.Identity.Name;

        if (username == null)
        {
            return Unauthorized();
        }

        var userToken = await _tokenService.GetTokenAsync(username, loginRequestVM.RefreshToken);

        if (userToken == null || userToken.RefreshTokenExpiration < DateTime.Now)
        {
            return Unauthorized();
        }

        var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
        var newRefreshToken = _tokenService.GenerateRefreshToken();
        var newAccessTokenExpiration = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:AccessTokenExpirationMinutes"]));
        var newRefreshTokenExpiration = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:RefreshTokenExpirationDays"]));

        userToken.AccessToken = newAccessToken;
        userToken.RefreshToken = newRefreshToken;
        userToken.AccessTokenExpiration = newAccessTokenExpiration;
        userToken.RefreshTokenExpiration = newRefreshTokenExpiration;

        await _context.SaveChangesAsync();

        return Ok(new LoginResultVMv2
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken

        });
    }
}
