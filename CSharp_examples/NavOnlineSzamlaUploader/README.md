# Számlák beküldése, a `NAV Online Számla rendszerén` keresztül. 

## 🔧 1. NAV Online Számla regisztráció
- A [https://onlineszamla.nav.gov.hu](https://onlineszamla.nav.gov.hu) oldalon regisztrálni kell a céget.
- Ott generálni lehet **technikai felhasználót**, **kulcsokat**, és megkapod az **XML aláírásához szükséges adatokat**.

## 💡 2. XML számlaadatok előállítása
- A beküldendő számlaadatokat **NAV által meghatározott XML séma** szerint kell létrehozni.
- A [NAV oldalán](https://onlineszamla.nav.gov.hu/dokumentaciok) minden XSD fájl és példadokumentáció megtalálható: https://onlineszamla.nav.gov.hu/dokumentaciok

## 🧪 3. Tesztelés (sandbox környezet)
- A NAV biztosít **tesztkörnyezetet**, ahol próbálkozhatsz a beküldéssel éles adatok nélkül.

## 🔐 4. XML digitális aláírás és titkosítás
- A NAV elvárja az **aláírt és titkosított XML-eket**.
- Ez C#-ban megoldható a `System.Security.Cryptography.Xml` vagy egy külső lib segítségével.

## 🌐 5. Beküldés Web Service-en keresztül
A NAV SOAP webszolgáltatást használ, például:
- `ManageInvoice` – számlák beküldése
- `QueryTransactionList` – lekérdezések

A hivatalos WSDL elérhető:  [https://api.onlineszamla.nav.gov.hu/invoiceService?wsdl](https://api.onlineszamla.nav.gov.hu/invoiceService?wsdl)

## ✅ Elérhető C# könyvtárak
Léteznek már **nyílt forráskódú C# megvalósítások**, például:
- [nav-gov-hu/Online-Invoice](https://github.com/nav-gov-hu/Online-Invoice) (a NAV hivatalos példái)
- [hunyadi-dev/NavOnline](https://github.com/hunyadi-dev/NavOnline) – egy C# wrapper a NAV Online Számla API-hoz

## Példakód C#-ban (egyszerűsített)

```csharp
var client = new InvoiceServicePortTypeClient();
var request = new ManageInvoiceRequest
{
    header = new Header(),
    user = new User(),
    software = new Software(),
    // számla XML itt jön
};

var response = client.manageInvoice(request);
Console.WriteLine(response.result.message);
```
### Segítség dokumentációhoz:
- [NAV technikai dokumentációk](https://onlineszamla.nav.gov.hu/dokumentaciok)
- [WSDL és XSD fájlok](https://onlineszamla.nav.gov.hu/api-doc/rest/index.html)

---

# Alap **C# NAV Online Számla** projekt

1. Felépíti a SOAP klienst  
2. Hitelesíti a technikai felhasználóval  
3. Előkészíti a számla XML-t  
4. Feltölti a NAV tesztkörnyezetébe  


## 🔧 A projekt alapjai

### 📁 Projekt neve: `NavOnlineSzamlaUploader`

### 🧰 Szükséges csomagok:
- `SoapCore` vagy WSDL generálás Visual Studio-ból
- `System.Security.Cryptography.Xml` (XML aláíráshoz)
- `System.Net.Http`

## 1. NAV API WSDL importálása

1. Töltsd le a WSDL-t innen:
   ```
   https://api-test.onlineszamla.nav.gov.hu/invoiceService?wsdl
   ```

2. Generálj C# proxy osztályokat:
   - Visual Studio: jobb klikk a projektre → *Add* → *Connected Service* → *WCF Web Service Reference Provider*
   - URL: NAV tesztkörnyezet `?wsdl` linkje
   - Namespace: `NavOnlineInvoice`

Ez létrehozza a szükséges osztályokat (ManageInvoice, Header, Software, stb.)

## 2. Bejelentkezés és számla beküldése

```csharp
using System;
using NavOnlineSzamlaUploader.NavOnlineInvoice;

class Program
{
    static void Main()
    {
        var client = new ManageInvoiceServicePortTypeClient();

        var header = new Header
        {
            requestId = Guid.NewGuid().ToString(),
            timestamp = DateTime.Now,
            // egyéb mezők
        };

        var user = new User
        {
            login = "technikai_felhasznalo",
            passwordHash = "jelszó_hasha_SHA512",
            taxNumber = "12345678"
        };

        var software = new Software
        {
            softwareId = "SW123",
            softwareName = "TesztUploader",
            softwareOperation = SoftwareOperation.LOCAL_SOFTWARE,
            softwareMainVersion = "1.0",
            developerName = "Fejlesztő Bt.",
            developerContact = "info@fejleszto.hu"
        };

        var request = new ManageInvoiceRequest
        {
            header = header,
            user = user,
            software = software,
            exchangeToken = null, // ha van tokened
            invoiceOperations = new InvoiceOperations
            {
                compressedContent = false,
                invoiceOperation = new[]
                {
                    new InvoiceOperationType
                    {
                        index = 1,
                        invoiceData = new InvoiceDataType
                        {
                            base64Content = Convert.ToBase64String(
                                System.IO.File.ReadAllBytes("szamla.xml")
                            ),
                            technicalAnnulment = false
                        },
                        operation = ManageInvoiceOperationType.CREATE
                    }
                }
            }
        };

        var response = client.manageInvoice(request);
        Console.WriteLine("Válasz: " + response.processingResults[0]?.message);
    }
}
```

## 3. Aláírt XML számlák létrehozása

A NAV XML XSD fájljait le kell töltened, és az XML-t ezek alapján kell létrehozni (vagy XML serializálással, vagy sablon alapján). Aláírás:  
- `XmlDocument` + `SignedXml` használata
- SHA512 algoritmussal, NAV által elfogadott formátumban

## 4. Sandbox URL

Használat előtt állítsd be a klienst a teszt URL-re:

```csharp
var client = new ManageInvoiceServicePortTypeClient(
    ManageInvoiceServicePortTypeClient.EndpointConfiguration.ManageInvoiceServicePort,
    "https://api-test.onlineszamla.nav.gov.hu/invoiceService"
);
```

---

## ➕ Extra: JSON token lekérés (ManageToken)

# 🧪 `SOAP` vagy `REST API` a NAV esetén**

| Tulajdonság | **SOAP** | **REST** |
|------------|----------|----------|
| Technológia | XML-alapú webszolgáltatás (WSDL alapján) | JSON-alapú HTTP API |
| Adatformátum | XML | JSON |
| NAV támogatás | Teljes, elsődleges | Alternatív, de hivatalosan támogatott |
| Komplexitás | Bonyolultabb, sok boilerplate | Egyszerűbb, olvashatóbb |
| Sebesség | Lassabb, nagyobb XML | Gyorsabb, kevesebb overhead |
| Fejlesztés | Visual Studio-val könnyen generálható kliens | Kézzel vagy HTTP klienssel kell dolgozni |
| Dokumentáció | Részletes WSDL és XSD alapján | Swagger/OpenAPI dokumentáció is van |
| Használhatóság mobilról | Nehezebb | Egyszerűbb, főleg mobilos backend esetén |

## 🔧 NAV REST API példák

- **POST** `/tokenExchange` – token lekérés
- **POST** `/manageInvoice` – számlák beküldése
- **GET** `/queryTransactionStatus` – státusz lekérdezése

Dokumentáció itt:  
📄 [NAV REST API dokumentáció](https://onlineszamla.nav.gov.hu/api-doc/rest/index.html)

---

## ☑️ Melyiket válaszd?

| Használat | Ajánlott API |
|----------|----------------|
| Ha NAV hivatalos példáit követed | **SOAP** |
| Ha gyorsabb, modernebb megközelítést keresel | **REST** |
| Ha C#-ban WSDL generálás kényelmes | **SOAP** |
| Ha pl. Node.js / Python backendet használnál | **REST** |

---

## 🎯 Összegzés

A **REST API modernebb, egyszerűbb, gyorsabb**, de a **SOAP részletesebb dokumentációval és példákkal rendelkezik**. Ha C#-ot használsz és nem zavar az XML-kezelés, **SOAP jó választás**. Ha inkább JSON és egyszerű HTTP hívások, akkor **REST**.

---

Ha szeretnéd, készíthetek egy REST-alapú C# projekt sablont is, például `HttpClient` használatával. Érdekelne?