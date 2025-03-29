# NavInvoiceApiClient
Egy C# .NET példakód, amely a NAV Online Számla API-ján keresztül beküld egy vagy több számlát XML formátumban. A kód tartalmazza a hitelesítést (OAuth2 token lekérést), a számla beküldését és a válasz feldolgozását.

## Szoftver feltételek
- .NET 6+ projekt szükséges.
- Szükséges NuGet csomagok:
	- `System.Net.Http.Json` *(HTTP kérésekhez)*
	- `System.Xml.Serialization` *(XML kezeléshez)*
	- `Newtonsoft.Json` *(ha JSON-t is használsz)*

```bash
dotnet add package System.Net.Http.Json
dotnet add package System.Xml.Serialization
```
	
```sql
	CREATE TABLE Invoices (
    Id INT PRIMARY KEY IDENTITY,
    InvoiceNumber VARCHAR(50) NOT NULL,
    TaxNumber VARCHAR(20) NOT NULL,
    IssueDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    IsSentToNav BIT DEFAULT 0,
    -- További mezők...
);
```

# Helyi `xsd` használata a NAV API helyett
| **Szempont**               | **XSD helyi validálás**                          | **NAV API validálás**                     |
|----------------------------|-----------------------------------------------|-----------------------------------------|
| **Sebesség**               | Azonnali (nincs hálózati hívás)               | Lassú (API roundtrip + feldolgozási idő) |
| **Hibakeresés**            | Pontos hibaüzenetek a séma megszegéséről      | Általános hibakódok (pl. `NVALID_XML`) |
| **Offline működés**        | Igen (nincs internetkapcsolat szükséges)      | Nem                                     |
| **Terhelés a NAV-nál**     | Nincs                                         | Igen                                    |

