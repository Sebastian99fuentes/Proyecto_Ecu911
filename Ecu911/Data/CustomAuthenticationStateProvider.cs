using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Ecu911.Interfaces;
using Ecu911.Modelos;
using Ecu911.ResponseModels;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Ecu911.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService, JwtTokenGenerator jwtTokenGenerator)
        {
            this._sessionStorageService = sessionStorageService;
            this._jwtTokenGenerator = jwtTokenGenerator;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var accessToken = await _sessionStorageService.GetItemAsync<string>("Access-Token");
                ClaimsIdentity identity;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    var claims = _jwtTokenGenerator.GetTokenClaims(accessToken);
                    identity = new ClaimsIdentity(claims, "appToken");
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

        public async Task SetUserAsAuthenticated(SuccessfulLogin user)
        {
            await _sessionStorageService.SetItemAsync("Access-Token", user.token);
            await _sessionStorageService.SetItemAsync("Refresh-Token", user.refreshedToken);
            var claims = _jwtTokenGenerator.GetTokenClaims(user.token);
            await _sessionStorageService.SetItemAsync("Id-Usuario", claims.ElementAt(2).Value);
            await _sessionStorageService.SetItemAsync("Id-Area", claims.ElementAt(3).Value);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            NotifyAuthenticationStateChanged(Task.FromResult( new AuthenticationState(claimsPrincipal)));
        }

        public void SetUserAsLoggedOut()
        {

            _sessionStorageService.RemoveItemAsync("Access-Token");
            _sessionStorageService.RemoveItemAsync("Refresh-Token");
            _sessionStorageService.RemoveItemAsync("Id-Usuario");
            _sessionStorageService.RemoveItemAsync("Id-Area");
            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
