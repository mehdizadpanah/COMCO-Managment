using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.VisualBasic;
using System.Security.Principal;
using Microsoft.AspNetCore.Components;



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

            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            var username = await LocalStorageService.GetItemAsync<string>("user");
            var expireTime = await LocalStorageService.GetItemAsync<DateTime>("expireTime");
            if (username != null && expireTime > DateTime.UtcNow)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                }, "custom");
                user = new ClaimsPrincipal(identity);
            }
            else
            {
                await Logout();
            }
            return await Task.FromResult(new AuthenticationState(user));

        }

        public async Task<bool> Login(string username, string password, bool rememberMe)
        {
            var validate = false;
            var values = new { UserName = username, Password = password };
            var resp = await _apiService.PostValuesAsync("/Authenticate", values);
            if (resp.IsSuccessStatusCode)
            {
                validate = true;
                var content = await resp.Content.ReadAsStringAsync();

            }

            //var validate = false || username == "mi" && password == "1234";

            if (!validate) return validate;

            var expireTime = rememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddMinutes(30);
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
            }, "custom");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            await LocalStorageService.SetItemAsync("user", username);
            await LocalStorageService.SetItemAsync("expireTime", expireTime);

            return validate;
        }

        public async Task Logout()
        {
            await LocalStorageService.RemoveItemAsync("user");
            await LocalStorageService.RemoveItemAsync("expireTime");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            NavigationManager.NavigateTo("/Login");

        }
    }
}
