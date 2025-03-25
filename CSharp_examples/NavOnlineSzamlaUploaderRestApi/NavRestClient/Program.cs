using NavRestClient.Services;

var nav = new NavApiService();

string token = await nav.GetExchangeTokenAsync();
Console.WriteLine("Token: " + token);

// Számla XML betöltése és base64 kódolása
var xmlBytes = File.ReadAllBytes("szamla.xml");
var base64Invoice = Convert.ToBase64String(xmlBytes);

await nav.UploadInvoiceAsync(token, base64Invoice);