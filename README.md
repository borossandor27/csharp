# C# keletkezése, története

A C# nyelvet a Microsoft fejlesztette ki, és először 2000-ben mutatták be. A nyelv kidolgozása Anders Hejlsberg nevéhez köthető, aki korábban a Turbo Pascal és a Delphi nyelvek fejlesztésében is részt vett. A C# a .NET keretrendszer része, és eredetileg a Java nyelvre adott válaszként született, bár mára önálló, erősen fejlett nyelvvé vált.

# C# és Visual FoxPro

A Visual FoxPro (VFP) adatbázis-központú programozási nyelv és fejlesztői környezet, amelyet főleg üzleti alkalmazások fejlesztésére használtak. A Visual FoxPro és a C# nagyon eltérő paradigmákon alapul.

| **Tulajdonság**   | **C#**                       | **Visual FoxPro** |
|-------------------|------------------------------|-------------------|
| **Paradigma**     | Objektumorientált (OOP) és típusbiztos nyelv | Objektumorientált, de dinamikus és laza típuskezelés |
| **Használat**     | Modern alkalmazások fejlesztése (*web, mobil, asztali, játékok, cloud, AI, stb.*) | Adatbázis-központú alkalmazások fejlesztése |
| **Típusosság**    | Erősen típusos (*statikus*) | Gyengén típusos (*dinamikus adattípusokkal*) |

## Objektum-orientált paradigmára való áttérés

| **Tulajdonság**   | **C#**                       | **Visual FoxPro** |
|-------------------|------------------------------|-------------------|
| **OOP támogatás** | Teljes OOP (*osztályok, öröklődés, polimorfizmus, interfészek, absztrakt osztályok*) | OOP-t támogat, de korlátozott |
| **Metódusok túlterhelése** | Igen | Nem |
| **Interfészek és absztrakt osztályok** | Igen | Nem |

## Eltérések adatbázis-kezelésben

A C#-ban nincs beépített adatbázis-kezelés, de a .NET keretrendszer széleskörű támogatást nyújt különböző adatbázisokhoz (*pl. SQL Server, MySQL, SQLite*) az **ADO.NET**, **Entity Framework** vagy **Dapper** segítségével.

| **Tulajdonság**       | **C#**                      | **Visual FoxPro** |
|-----------------------|-----------------------------|-------------------|
| **Adatbázis-motor**   | Külső adatbázisokkal (*SQL Server, MySQL, PostgreSQL, SQLite, stb.*) működik | Beépített adatbázis (DBF fájlok), SQL támogatás korlátozott |
| **Kapcsolat adatbázishoz** | ADO.NET, Entity Framework, Dapper | Beépített SQL Pass-Through, Cursor, DBF táblák |
| **Többfelhasználós támogatás** | SQL szerverekkel skálázható | Többfelhasználós, de fájlalapú DBF szerkezet miatt sérülékeny |

## ORM (*Object-Relational Mapping*) használata

Az ORM automatikusan leképezi az adatbázis tábláit **C# osztályokra**, így nem kell SQL lekérdezéseket írnod minden egyes adatkezelési művelethez.

**Két fő ORM lehetőség C#-ban:**

| **ORM**             | **Leírás** |
|---------------------|------------|
| **Entity Framework (EF) Core** | A Microsoft hivatalos ORM-je, erősen integrált a .NET ökoszisztémába. |
| **Dapper**          | "Micro ORM", amely kevesebb absztrakciót tartalmaz és gyorsabb, mint az EF Core. |

**ORM előnyei**

- **Kevesebb kód** → Automatikusan kezeli az adatbázis műveleteket (DbContext, DbSet).
- **Egyszerűbb karbantartás** → Nem kell kézzel írni minden SQL lekérdezést.
- **Típusbiztos** → Az adatok automatikusan leképeződnek C# osztályokra.
- **Automatikus migrációk** → Az adatbázis szerkezete programból kezelhető.
- **Kapcsolatok támogatása** → Pl. One-to-Many, Many-to-Many kapcsolatok kezelése könnyebb.

**ORM hátrányai**

- **Lassabb lehet nagy lekérdezések esetén**, mert túl sok absztrakciót tartalmaz.
- **Nem mindig hatékony SQL-t generál**, ami teljesítményveszteséget okozhat.
- **Tanulási görbe** → Az ORM-ek működését és az optimalizálásukat meg kell tanulni.

**Sebesség-összehasonlítás ORM és ADO.NET között**

| **Művelet**             | **Entity Framework Core** | **Dapper**        | **ADO.NET** |
|-------------------------|--------------------------|-------------------|-------------|
| **Egyszerű SELECT (1 rekord)** | 🔴 Lassúbb       | 🟡 Közepesen gyors | 🟢 Leggyorsabb |
| **Több rekord lekérdezése (10,000+ rekord)** | 🔴 Lassabb | 🟢 Gyors | 🟢 Gyors |
| **Adat beszúrása (INSERT)** | 🟡 Közepes | 🟢 Gyors | 🟢 Gyors |
| **Összetett SQL lekérdezés (JOIN, GROUP BY, stb.)** | 🔴 Lassabb | 🟡 Közepes | 🟢 Gyors |
| **Tanulási görbe** | 🟢 Könnyű | 🟡 Közepes | 🔴 Nehéz |

**Mikor érdemes ORM-et használni?**

- Ha **gyors fejlesztést** szeretnél, és nem akarsz SQL-lekérdezésekkel foglalkozni.
- Ha **kis vagy közepes méretű adatbázist** kezelsz.
- Ha **több fejlesztő dolgozik a projekten**, mert az ORM strukturáltabb kódot biztosít.

## Felhasználói felület (UI)

| **Tulajdonság**   | **C#**                       | **Visual FoxPro** |
|-------------------|------------------------------|-------------------|
| **UI keretrendszer** | WinForms, WPF, Blazor, MAUI, ASP.NET, Unity | Beépített UI komponensek |
| **Webes támogatás** | Igen (ASP.NET, Blazor) | Nem (csak asztali alkalmazások) |
| **Korszerű UI támogatás** | Modern UI/UX lehetőségek | Elavult felület, korlátozott lehetőségek |

# **Elemi adattípusok**

| **Típus** | **Típusnév másképpen (egyenértékű)** | **Helyigény (bit)** | **Példa** |
|-----------|-------------------------------------|---------------------|-----------|
| **Logikai változó** | **bool** | Boolean | 8 (!) | true, false |
| **Egész szám (előjel nélküli)** | **sbyte, byte** | SByte, Byte | 8 | - |
| | **short, ushort** | Int16, UInt16 | 16 | - |
| | **int, uint** | Int32, UInt32 | 32 | 12, 12u |
| | **long, ulong** | Int64, UInt64 | 64 | 12l, 12ul |
| **Lebegőpontos szám** | **float** | Single | 32 | 6.5f |
| | **double** | Double | 64 | 6.5 |
| | **decimal** | Decimal | 128 | 12m |
| **Karakter** | **char** | Char | 8 | 'c' |
| **Szöveg** | **string** | String | változó | "szöveg" |


# Operátorok
C#-ban az **operátorok** olyan speciális szimbólumok, amelyek műveleteket hajtanak végre az operándusokon. Az operátorokat különböző kategóriákba sorolhatjuk.

## **Aritmetikai operátorok**
Ezek az alapvető matematikai műveletek végrehajtására szolgálnak.

| Operátor | Leírás | Példa | Eredmény |
|----------|--------|--------|---------|
| `+` | Összeadás | `5 + 3` | `8` |
| `-` | Kivonás | `5 - 3` | `2` |
| `*` | Szorzás | `5 * 3` | `15` |
| `/` | Osztás | `5 / 3` | `1` (egész osztás esetén) |
| `%` | Maradékos osztás | `5 % 3` | `2` |

> [!IMPORTANT]
> Ha egész számokat (`int`) osztasz, az eredmény **egész szám** lesz. Ha lebegőpontos eredményt szeretnél, használj `double` vagy `float` típusokat:
```csharp
double result = 5.0 / 3; // 1.6667
```

## **Összehasonlító (relációs) operátorok**
Logikai értéket (`true` vagy `false`) adnak vissza két érték összehasonlításakor.

| Operátor | Leírás | Példa | Eredmény |
|----------|--------|--------|---------|
| `==` | Egyenlőség | `5 == 3` | `false` |
| `!=` | Nem egyenlő | `5 != 3` | `true` |
| `>` | Nagyobb mint | `5 > 3` | `true` |
| `<` | Kisebb mint | `5 < 3` | `false` |
| `>=` | Nagyobb vagy egyenlő | `5 >= 3` | `true` |
| `<=` | Kisebb vagy egyenlő | `5 <= 3` | `false` |

## **Logikai operátorok**
Logikai műveleteket végeznek, és `true` vagy `false` értéket adnak vissza.

| Operátor | Leírás | Példa | Eredmény |
|----------|--------|--------|---------|
| `&&` | Logikai ÉS | `(true && false)` | `false` |
| `||` | Logikai VAGY | `(true || false)` | `true` |
| `!` | Logikai NEM | `!true` | `false` |

```csharp
bool a = true;
bool b = false;
Console.WriteLine(a && b); // false
Console.WriteLine(a || b); // true
Console.WriteLine(!a);     // false
```

## **Értékadás operátorok**
Értékadásra és módosításra szolgálnak.

| Operátor | Leírás | Példa | Ugyanaz, mint... |
|----------|--------|--------|------------------|
| `=` | Egyszerű értékadás | `x = 5` | – |
| `+=` | Összeadás és értékadás | `x += 5` | `x = x + 5` |
| `-=` | Kivonás és értékadás | `x -= 5` | `x = x - 5` |
| `*=` | Szorzás és értékadás | `x *= 5` | `x = x * 5` |
| `/=` | Osztás és értékadás | `x /= 5` | `x = x / 5` |
| `%=` | Maradékos osztás és értékadás | `x %= 5` | `x = x % 5` |

```csharp
int x = 10;
x += 5; // x most 15
x *= 2; // x most 30
```

## **Bitműveleti operátorok**
Ezek bináris szinten végeznek műveleteket az egész számokon.

| Operátor | Leírás | Példa (bináris) | Eredmény |
|----------|--------|-----------------|---------|
| `&` | Bitenkénti ÉS | `5 & 3` (`101 & 011`) | `1` (`001`) |
| `|` | Bitenkénti VAGY | `5 | 3` (`101 | 011`) | `7` (`111`) |
| `^` | Bitenkénti kizáró VAGY (XOR) | `5 ^ 3` (`101 ^ 011`) | `6` (`110`) |
| `~` | Bitenkénti negálás | `~5` (`~00000101`) | `-6` |
| `<<` | Bitenkénti balra tolás | `5 << 1` (`101 << 1`) | `10` (`1010`) |
| `>>` | Bitenkénti jobbra tolás | `5 >> 1` (`101 >> 1`) | `2` (`010`) |

```csharp
int a = 5; // 101 binárisan
int b = 3; // 011 binárisan
Console.WriteLine(a & b); // 1 (001)
Console.WriteLine(a | b); // 7 (111)
Console.WriteLine(a ^ b); // 6 (110)
```

---

## **6️⃣ Növelés és csökkentés operátorok**
Ezek az operátorok az adott változó értékét módosítják **1-gyel**.

| Operátor | Leírás | Példa | Eredmény |
|----------|--------|--------|---------|
| `++` | Növelés (előtte) | `++x` | `x` egyel nő, az új értéket adja vissza |
| `++` | Növelés (utána) | `x++` | `x` egyel nő, de az eredeti értéket adja vissza |
| `--` | Csökkentés (előtte) | `--x` | `x` egyel csökken, az új értéket adja vissza |
| `--` | Csökkentés (utána) | `x--` | `x` egyel csökken, de az eredeti értéket adja vissza |

```csharp
int x = 5;
Console.WriteLine(x++); // 5 (először kiírja az eredeti értéket, majd növeli)
Console.WriteLine(++x); // 7 (először növeli, majd kiírja)
```

## **Feltételes (ternary) operátor**
Egyszerű feltételes értékadást tesz lehetővé egy sorban.

| Operátor | Leírás | Példa | Eredmény |
|----------|--------|--------|---------|
| `? :` | Ha igaz, akkor egyik érték, ha hamis, akkor másik | `(5 > 3) ? "Igaz" : "Hamis"` | `"Igaz"` |

```csharp
int a = 10, b = 20;
string eredmeny = (a > b) ? "A nagyobb" : "B nagyobb";
Console.WriteLine(eredmeny); // "B nagyobb"
```

---

## **Null-kezelő operátorok**
Speciális operátorok a `null` értékek kezelésére.

| Operátor | Leírás | Példa | Eredmény |
|----------|--------|--------|---------|
| `??` | Ha `null`, akkor másik értéket ad | `string s = null; s ?? "Alapérték"` | `"Alapérték"` |
| `?.` | Null-előrehaladó operátor | `obj?.Property` | Ha `obj` null, nem dob hibát |


```csharp
string? nev = null;
Console.WriteLine(nev ?? "Nincs név megadva"); // "Nincs név megadva"
```



1. **Összetett adatszerkezetek** -- Például tömbök, listák (List\<T\>), szótárak (Dictionary\<K,V\>), halmazok (HashSet\<T\>), valamint saját osztályok és struktúrák.
2. **Vezérlési szerkezetek** -- Feltételes elágazások (if, switch), ciklusok (for, while, foreach), kivételkezelés (try-catch).
3. **Metódusok és függvények** -- Hogyan szervezd a kódot újrafelhasználható egységekké, paraméterátadás, visszatérési értékek.
4. **OOP (Objektumorientált programozás)** -- Osztályok, öröklődés, interfészek, absztrakt osztályok, polimorfizmus.
5. **Fájlkezelés és adatbázis kapcsolat** -- Hogyan olvashatsz és írhatsz fájlokat (StreamReader, StreamWriter), illetve használhatsz adatbázisokat (pl. SQL kapcsolat Entity Framework segítségével).
6. **Aszinkron programozás** -- async és await, párhuzamos végrehajtás (Task, Thread).
