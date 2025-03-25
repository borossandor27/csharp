Szuper! Akkor lépésről lépésre végigmegyünk mindhárom lehetőségen. Kezdjük az elsővel:

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