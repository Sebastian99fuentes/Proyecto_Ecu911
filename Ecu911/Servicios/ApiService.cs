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
            var token = await _localStorageService.GetItemAsync<string>("Access-Token");
            if (token != null)
            {
                HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _localStorageService.GetItemAsync<string>("Access-Token"));
                // HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            }
        }
    }
}
