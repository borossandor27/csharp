using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NavInvoiceApiClient
{
    

    class NavInvoiceApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _baseUrl = "https://api-test.onlineszamla.nav.gov.hu"; // Teszt URL

        public NavInvoiceApiClient(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _httpClient = new HttpClient();
        }

        // 1. OAuth2 token lekérése
        public async Task<string> GetAccessTokenAsync()
        {
            var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);

            var requestBody = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("scope", "invoice")
        });

            var response = await _httpClient.PostAsync($"{_baseUrl}/oauth2/token", requestBody);
            response.EnsureSuccessStatusCode();

            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
            return tokenResponse.Access_token;
        }

        // 2. Számla beküldése XML formátumban
        public async Task<string> SendInvoicesAsync(string xmlInvoiceData)
        {
            var accessToken = await GetAccessTokenAsync();
            var requestId = Guid.NewGuid().ToString();
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/api/v1/invoice");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            request.Headers.Add("X-Request-ID", requestId);
            request.Headers.Add("X-Timestamp", timestamp);
            request.Content = new StringContent(xmlInvoiceData, Encoding.UTF8, "application/xml");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // 3. Számla állapot lekérdezése
        public async Task<InvoiceStatusResponse> CheckInvoiceStatusAsync(string transactionId)
        {
            var accessToken = await GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/v1/invoice/status/{transactionId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<InvoiceStatusResponse>();
        }
    }
}
