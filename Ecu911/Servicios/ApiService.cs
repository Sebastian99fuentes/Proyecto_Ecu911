using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;

namespace Ecu911.Servicios
{
    public class ApiService
    {
        private readonly ISessionStorageService _sessionStorageService;
        public HttpClient HttpClient { get; private set; }
        public ApiService(IHttpClientFactory httpClientFactory, ISessionStorageService lss)
        {
            _sessionStorageService = lss;
            HttpClient = httpClientFactory.CreateClient("api");
        }
        public async Task SetAuthHeaders()
        {
            var token = await _sessionStorageService.GetItemAsync<string>("Access-Token");
            if (token != null)
            {
                HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _sessionStorageService.GetItemAsync<string>("Access-Token"));
                // HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            }
        }
    }
}
