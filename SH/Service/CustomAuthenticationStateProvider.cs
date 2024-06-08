using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using SH.Data.ModelVM.Authentication;
using System.Text.Json;


namespace SH.Service
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider

    {
        public ILocalStorageService LocalStorageService { get; set; }
        public NavigationManager NavigationManager { get; set; }
        private readonly ApiService _apiService;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, NavigationManager navigationManager,
            ApiService apiService)
        {
            LocalStorageService = localStorageService;
            NavigationManager = navigationManager;
            _apiService = apiService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var identity = new ClaimsIdentity();
                var user = new ClaimsPrincipal(identity);
                var loginCookies = await ReadLoginCookies();
                if (loginCookies.ExpiryDate > DateTime.UtcNow)
                {
                    identity = SetIdentity(loginCookies);
                    user = new ClaimsPrincipal(identity);
                }
                else
                {
                    await Logout();
                }
                return await Task.FromResult(new AuthenticationState(user));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            

        }

        public async Task<bool> Login(string username, string password, bool rememberMe)
        {

            try
            {
                var validate = false;
                var loginCookies = new LoginCookiesVM();
                var messageBody = new LoginRequestVM { Username = username, Password = password, IsRememberMe = rememberMe };
                var resp = await _apiService.PostValuesAsync("/Authenticate", messageBody);


                if (resp.IsSuccessStatusCode)
                {
                    validate = true;
                    var content = await resp.Content.ReadAsStringAsync();
                    var loginResult = JsonSerializer.Deserialize<LoginResultVM>(content);

                    // Write cookies
                    if (loginResult != null)
                    {
                        loginCookies = new LoginCookiesVM
                        {
                            Username = username,
                            ExpiryDate = loginResult.ExpiryDate,
                            Token = loginResult.Token,
                            FirstName = loginResult.Name,
                            LastName = loginResult.Family

                        };
                        WriteLoginCookies(loginCookies);
                    }

                    // Make identity
                    var identity = SetIdentity(loginCookies);
                    var user = new ClaimsPrincipal(identity);

                    // Login user
                    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
                }

                return validate;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Logout()
        {
            RemoveLoginCookies();
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            NavigationManager.NavigateTo("/Login");

        }

        private async void WriteLoginCookies(LoginCookiesVM loginCookies)
        {
            try
            {
                await LocalStorageService.SetItemAsync("userName", loginCookies.Username);
                await LocalStorageService.SetItemAsync("expireTime", loginCookies.ExpiryDate);
                if (loginCookies.Token != null)
                    await LocalStorageService.SetItemAsync("value", EncryptionHelper.Encrypt(loginCookies.Token));
                await LocalStorageService.SetItemAsync("firstName", loginCookies.FirstName);
                await LocalStorageService.SetItemAsync("lastName", loginCookies.LastName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<LoginCookiesVM> ReadLoginCookies()
        {
            try
            {
                var loginCookies = new LoginCookiesVM
                {
                    Username = await LocalStorageService.GetItemAsync<string>("userName"),
                    ExpiryDate = await LocalStorageService.GetItemAsync<DateTime>("expireTime"),
                    FirstName = await LocalStorageService.GetItemAsync<string>("firstName"),
                    LastName = await LocalStorageService.GetItemAsync<string>("lastName")
                };
                
                //get encrypted token and decrypt it 
                var encryptedToken = await LocalStorageService.GetItemAsync<string>("value");
                if (encryptedToken != null)
                    loginCookies.Token = EncryptionHelper.Decrypt(encryptedToken);

                return loginCookies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async void RemoveLoginCookies()
        {
            try
            {
                await LocalStorageService.RemoveItemAsync("userName");
                await LocalStorageService.RemoveItemAsync("expireTime");
                await LocalStorageService.RemoveItemAsync("value");
                await LocalStorageService.RemoveItemAsync("firstName");
                await LocalStorageService.RemoveItemAsync("lastName");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private ClaimsIdentity SetIdentity(LoginCookiesVM loginCookies)
        {
            try
            {
                var identity = new ClaimsIdentity("custom");
                if (loginCookies.FirstName != null)
                    identity.AddClaim(new Claim(ClaimTypes.Name, loginCookies.FirstName));
                if (loginCookies.Username != null)
                    identity.AddClaim(new Claim("UserName", loginCookies.Username));
                if (loginCookies.LastName != null)
                    identity.AddClaim(new Claim(ClaimTypes.Surname, loginCookies.LastName));

                return identity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
