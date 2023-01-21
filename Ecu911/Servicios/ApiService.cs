using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;

namespace Ecu911.Servicios
{
    public class ApiService
    {
        private readonly ILocalStorageService _localStorageService;
        public HttpClient HttpClient { get; private set; }
        public ApiService(IHttpClientFactory httpClientFactory, ILocalStorageService lss)
        {
            _localStorageService = lss;
            HttpClient = httpClientFactory.CreateClient("api");
        }
        public async Task SetAuthHeaders()
        {
            var accessToken = await _localStorageService.GetItemAsync<string>("Access-Token");
            if (accessToken != null)
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorageService.GetItemAsync<string>("Access-Token"));

            }
        }
    }
}
