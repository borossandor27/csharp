using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace NavRestClient.Services
{
    public class NavApiService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl = "https://api-test.onlineszamla.nav.gov.hu";

        public NavApiService()
        {
            _http = new HttpClient();
        }

        public async Task<string> GetExchangeTokenAsync()
        {
            var requestId = Guid.NewGuid().ToString();
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

            var request = new
            {
                user = "tech_user",
                password = "sha512-password",
                taxNumber = "12345678",
                requestId = requestId,
                timestamp = timestamp,
                signature = "signature_here"
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            content.Headers.Add("X-Request-ID", requestId);
            content.Headers.Add("X-Software-ID", "SW123");

            var response = await _http.PostAsync($"{_baseUrl}/tokenExchange", content);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<JsonElement>(json);
            return result.GetProperty("token").GetString();
        }

        public async Task UploadInvoiceAsync(string token, string base64InvoiceXml)
        {
            var request = new
            {
                exchangeToken = token,
                invoiceOperations = new
                {
                    compressedContent = false,
                    invoiceOperation = new[]
                    {
                        new {
                            index = 1,
                            operation = "CREATE",
                            invoiceData = new {
                                base64Content = base64InvoiceXml,
                                technicalAnnulment = false
                            }
                        }
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            content.Headers.Add("X-Request-ID", Guid.NewGuid().ToString());
            content.Headers.Add("X-Software-ID", "SW123");

            var response = await _http.PostAsync($"{_baseUrl}/manageInvoice", content);
            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine("NAV válasz: " + json);
        }
    }
}