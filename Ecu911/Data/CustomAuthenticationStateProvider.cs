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


namespace Ecu911.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly HttpClient _http;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, JwtTokenGenerator jtg, HttpClient http)
        {
            _localStorageService = localStorageService;
            _jwtTokenGenerator = jtg;
            _http = http;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var accessToken = await _localStorageService.GetItemAsync<string>("Access-Token");
                ClaimsIdentity identity;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    var claims = _jwtTokenGenerator.GetTokenClaims(accessToken);
                    identity = new ClaimsIdentity(claims, "appToken");

                    //aqui le seteo para coger el roll y el nombre 

                  var claimsIdentity = new ClaimsIdentity(new[]
                  {
                     new Claim(ClaimTypes.Name,identity.Claims.ElementAt(0).Value),
                    new Claim(ClaimTypes.Role,identity.Claims.ElementAt(4).Value)
                  });

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    //var state = new AuthenticationState(claimsPrincipal);

                    //NotifyAuthenticationStateChanged(Task.FromResult(state));

                    //return state;


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
        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{


        //    try
        //    {
        //        var accesstoken = await _localStorageService.getitemasync<string>("access-token");
        //        claimsidentity identity;
        //        if (!string.isnullorempty(accesstoken))
        //        {
        //            var claims = _jwttokengenerator.gettokenclaims(accesstoken);
        //            identity = new claimsidentity(claims, "apptoken");
        //        }
        //        else
        //        {
        //            identity = new claimsidentity();
        //        }
        //        var claimprincipal = new claimsprincipal(identity);
        //        return await task.fromresult(new authenticationstate(claimprincipal));
        //    }
        //    catch (exception ex)
        //    {
        //        return await task.fromresult(new authenticationstate(new claimsprincipal(new claimsidentity())));
        //    }

        //    //string token2 = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVG9ueSBTdGFyayIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6Iklyb24gTWFuIiwiZXhwIjozMTY4NTQwMDAwfQ.IbVQa1lNYYOzwso69xYfsMOHnQfO3VLvVqV2SOXS7sTtyyZ8DEf5jmmwz2FGLJJvZnQKZuieHnmHkg7CGkDbvA";
        //    //string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJTZWJhc1BydWViYXMiLCJqdGkiOiJhNzVjMjJiOC01YWQwLTRmMGQtYTc0Ny05YWNiOTg2NTJmYTIiLCJpZCI6Ijk4NDZlZWQ5LTliNmYtNDY1OS05NTBlLTllOGQ0NGU0MmE0NyIsImlkQXJlYSI6IjE3ZmJlZjA4LTQ3ZGUtNGJhMC1iZmU2LTEwMmMxOGRhZjc4ZCIsInJvbGUiOiJTVVBFUkFETUlOSVNUUkFET1IiLCJuYmYiOjE2NzI3OTI5MTcsImV4cCI6MTY3Mjc5MzIxNywiaWF0IjoxNjcyNzkyOTE3fQ.-Xs9e-L0tk4DZloI5t9It7z9Ch_ugp-Ff9WzDHniGkM";
        //    //var identity = new ClaimsIdentity();
        //    //_http.DefaultRequestHeaders.Authorization = null;

        //    //if (!string.IsNullOrEmpty(token))
        //    //{
        //    //    identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
        //    //    _http.DefaultRequestHeaders.Authorization =
        //    //        new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
        //    //}

        //    //var user = new ClaimsPrincipal(identity);

        // var claimsIdentity = new ClaimsIdentity(new[]
        // {
        //     new Claim(ClaimTypes.Name,user.Claims.ElementAt(0).Value),
        //    new Claim(ClaimTypes.Role,user.Claims.ElementAt(4).Value)
        // });

        // var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        // var state = new AuthenticationState(claimsPrincipal);

        // NotifyAuthenticationStateChanged(Task.FromResult(state));

        //return state;


        //}

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
            await _localStorageService.SetItemAsync("Id-Area", claims.ElementAt(3).Value);
            await _localStorageService.SetItemAsync("Role", claims.ElementAt(4).Value);

            //var identity =GeetClaimsIdentity(user);
 
            //var claimsPrincipal = new ClaimsPrincipal(identity);

            //NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
            //var state = new AuthenticationState(claimsPrincipal);

            //    //NotifyAuthenticationStateChanged(Task.FromResult(state));

            //    //return state;
        }

        private ClaimsIdentity GeetClaimsIdentity(SuccessfulLogin user)
        {
            var claims = _jwtTokenGenerator.GetTokenClaims(user.token);

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,claims.ElementAt(0).Value),
                new Claim(ClaimTypes.Role,claims.ElementAt(4).Value)
            });


            return claimsIdentity;
        }


        public async Task SetUserAsAuLoggedOut()
        {
            await _localStorageService.ClearAsync();
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }



        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
