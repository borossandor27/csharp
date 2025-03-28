# NavInvoiceApiClient
Egy C# .NET példakód, amely a NAV Online Számla API-ján keresztül beküld egy vagy több számlát XML formátumban. A kód tartalmazza a hitelesítést (OAuth2 token lekérést), a számla beküldését és a válasz feldolgozását.

## Szoftver feltételek
- .NET 6+ projekt szükséges.
- Szükséges NuGet csomagok:
	- `System.Net.Http.Json` *(HTTP kérésekhez)*
	- `System.Xml.Serialization` *(XML kezeléshez)*
	- `Newtonsoft.Json` *(ha JSON-t is használsz)*
	