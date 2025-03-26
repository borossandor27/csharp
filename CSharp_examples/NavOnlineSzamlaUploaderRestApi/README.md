# A NAV számára elektronikus számlák beküldése
[NAV hivatalos dokumentációja](https://onlineszamla.nav.gov.hu/dokumentaciok)
[Az online számlaadat-szolgáltatás gyakori hibái](https://nav.gov.hu/ugyfeliranytu/nezzen-utana/tudjon_rola/Az_online_szamlaadat-szolgaltatas_gyakori_hibai)

## 🔧 1. NAV Online Számla regisztráció
- A https://onlineszamla.nav.gov.hu oldalon regisztrálnod kell cégedet.
- Ott generálni tudsz **technikai felhasználót**, **kulcsokat**, és megkapod a **XML aláírásához szükséges adatokat**.

## 💡 2. XML számlaadatok előállítása
- A beküldendő számlaadatokat **NAV által meghatározott XML séma** szerint kell létrehozni.
- A [NAV oldalán](https://onlineszamla.nav.gov.hu/dokumentaciok) minden XSD fájl és példadokumentáció megtalálható

## 🧪 3. Tesztelés *(sandbox környezet)*
- A NAV biztosít **tesztkörnyezetet**, ahol próbálkozhatsz a beküldéssel éles adatok nélkül.

## 🔐 4. XML digitális aláírás és titkosítás
- A NAV elvárja az **aláírt és titkosított XML-eket**.
- Ez C#-ban megoldható a `System.Security.Cryptography.Xml` vagy egy külső lib segítségével.

## 🌐 5. Beküldés Web Service-en keresztül
A NAV SOAP webszolgáltatást használ, például:
- `ManageInvoice` – számlák beküldése
- `QueryTransactionList` – lekérdezések

A hivatalos WSDL elérhető:  
https://api.onlineszamla.nav.gov.hu/invoiceService?wsdl

---

## ✅ 6. Elérhető C# könyvtárak
Léteznek már **nyílt forráskódú C# megvalósítások**, például:
- [nav-gov-hu/Online-Invoice](https://github.com/nav-gov-hu/Online-Invoice) (a NAV hivatalos példái)
- [hunyadi-dev/NavOnline](https://github.com/hunyadi-dev/NavOnline) – egy C# wrapper a NAV Online Számla API-hoz


### Példakód C#-ban (egyszerűsített)

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

### 📚 Segítség dokumentációhoz:
- [NAV technikai dokumentációk](https://onlineszamla.nav.gov.hu/dokumentaciok)
- [WSDL és XSD fájlok](https://onlineszamla.nav.gov.hu/api-doc/rest/index.html)

---

Ha szeretnéd, segíthetek egy **C# projekt sablont** is összerakni NAV beküldéshez (SOAP kliens, XML aláírás, sandbox támogatás). Érdekelne?
---

## 🔐 1. SHA3-512 aláírás kiszámítása (signature)

A NAV REST API-nál az `exchangeToken` kéréshez kötelező mező a `signature`. Ez a következőképpen épül fel:

### 🔣 Aláírás formátuma:
```
signature = SHA3-512(user + requestId + timestamp + kulcs)
```

A `kulcs` a NAV portálon generált **technikai felhasználói kulcs**.

---

### ✅ Példa C# metódusra:

```csharp
using Org.BouncyCastle.Crypto.Digests;
using System.Text;

public static class SignatureHelper
{
    public static string CalculateSignature(string user, string requestId, string timestamp, string signatureKey)
    {
        string data = user + requestId + timestamp + signatureKey;
        byte[] bytes = Encoding.UTF8.GetBytes(data);

        var digest = new Sha3Digest(512);
        digest.BlockUpdate(bytes, 0, bytes.Length);

        byte[] result = new byte[digest.GetDigestSize()];
        digest.DoFinal(result, 0);

        return BitConverter.ToString(result).Replace("-", "").ToLowerInvariant();
    }
}
```

### 🔧 Követelmény:  
- Telepítsd a [BouncyCastle](https://www.nuget.org/packages/BouncyCastle) csomagot:
```
dotnet add package BouncyCastle
```

---

Szeretnéd, hogy ezt beépítsem a meglévő `NavRestClient` projektbe, vagy inkább küldjem külön fájlban?  
Utána jön az **XSD validálás**, majd a **teszt automatizálás**.