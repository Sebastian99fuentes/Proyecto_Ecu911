using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Ecu911.ResponseModels;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using static System.Net.WebRequestMethods;
using Ecu911.Interfaces;
using System.Threading.Tasks;
using Ecu911.Modelos;
using Newtonsoft.Json.Linq;


namespace Ecu911.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;


        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, JwtTokenGenerator jtg)
        {
            _localStorageService = localStorageService;
            _jwtTokenGenerator = jtg;

        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            

            try
            {
                var accessToken = await _localStorageService.GetItemAsync<string>("Access-Token");
                ClaimsIdentity identity;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    //var claims = ParseClaimsFromJwt(accessToken);
                    var claims = _jwtTokenGenerator.GetTokenClaims(accessToken);
                    identity = new ClaimsIdentity(claims, "appToken");

                    //aqui le seteo para coger el roll y el nombre 

                    var claimsl = new List<Claim>
                       {
                   new Claim(ClaimTypes.Name,identity.Claims.ElementAt(0).Value),
                    new Claim(ClaimTypes.Role,identity.Claims.ElementAt(5).Value),
                     };
                    identity.AddClaims(claimsl);
                    //aqui le seteo para coger el roll y el nombre 
                }
                else
                {
                    identity = new ClaimsIdentity();
                }
                var claimPrincipal = new ClaimsPrincipal(identity);
                return await Task.FromResult(new AuthenticationState(claimPrincipal));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }
        }

        public async Task<string> GetAuthenticatedUserRole()
        {
            try
            {
                var accessToken = await _localStorageService.GetItemAsync<string>("Access-Token");
                string role;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    role = _jwtTokenGenerator.GetTokenRole(accessToken);
                }
                else
                {
                    role = null;
                }
                return role;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task SetUserAsAuthenticated(SuccessfulLogin user)
        {
            await _localStorageService.SetItemAsync("Access-Token", user.token);
            await _localStorageService.SetItemAsync("Refresh-Token", user.refreshedToken);
            var claims = _jwtTokenGenerator.GetTokenClaims(user.token);
            await _localStorageService.SetItemAsync("Id", claims.ElementAt(2).Value);
            await _localStorageService.SetItemAsync("Id-Area", claims.ElementAt(3).Value);
            await _localStorageService.SetItemAsync("Cambio", claims.ElementAt(4).Value);
            await _localStorageService.SetItemAsync("Role", claims.ElementAt(5).Value);

    
        }

      

        public async Task SetUserAsAuLoggedOut()
        {
            await _localStorageService.ClearAsync();
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }



       
    }
}
