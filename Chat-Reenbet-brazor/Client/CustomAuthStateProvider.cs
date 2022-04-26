using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Security.Claims;

namespace Chat_Reenbet_brazor.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storage;

        public CustomAuthStateProvider(ILocalStorageService storage)
        {
            _storage = storage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());

            string userlogin = await _storage.GetItemAsStringAsync("user_login");

            if(!String.IsNullOrEmpty(userlogin))
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userlogin)
                }, "authentication");
                state = new AuthenticationState(new ClaimsPrincipal(identity));
            }
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}