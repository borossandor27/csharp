# C# Jegyzet

## C# keletkezése, története
A C# nyelvet a Microsoft fejlesztette ki, és először 2000-ben mutatták be. A nyelv kidolgozása **Anders Hejlsberg** nevéhez köthető, aki korábban a Turbo Pascal és a Delphi nyelvek fejlesztésében is részt vett. A C# a **.NET keretrendszer** része, és eredetileg a Java nyelvre adott válaszként született, bár mára önálló, erősen fejlett nyelvvé vált.

---

## C# és Visual FoxPro összehasonlítása
### **Alapvető különbségek**
| Tulajdonság | C# | Visual FoxPro |
|-------------|----|--------------|
| **Paradigma** | Objektumorientált (OOP) és típusbiztos nyelv | Objektumorientált, de dinamikus és laza típuskezelés |
| **Használat** | Modern alkalmazások fejlesztése (web, mobil, asztali, játékok, cloud, AI, stb.) | Adatbázis-központú alkalmazások fejlesztése |
| **Típusosság** | Erősen típusos (statikus) | Gyengén típusos (dinamikus adattípusokkal) |

### **Objektumorientált támogatás**
| Tulajdonság | C# | Visual FoxPro |
|-------------|----|--------------|
| **OOP támogatás** | Teljes OOP (osztályok, öröklődés, polimorfizmus, interfészek, absztrakt osztályok) | OOP-t támogat, de korlátozott |
| **Metódusok túlterhelése** | Igen | Nem |
| **Interfészek és absztrakt osztályok** | Igen | Nem |

### **Adatbázis-kezelés különbségei**
| Tulajdonság | C# | Visual FoxPro |
|-------------|----|--------------|
| **Adatbázis-motor** | Külső adatbázisokkal (SQL Server, MySQL, PostgreSQL, SQLite, stb.) működik | Beépített adatbázis (DBF fájlok), SQL támogatás korlátozott |
| **Kapcsolat adatbázishoz** | ADO.NET, Entity Framework, Dapper | Beépített SQL Pass-Through, Cursor, DBF táblák |
| **Többfelhasználós támogatás** | SQL szerverekkel skálázható | Többfelhasználós, de fájlalapú DBF szerkezet miatt sérülékeny |

---

## ORM (Object-Relational Mapping) használata
Az ORM automatikusan leképezi az adatbázis tábláit **C# osztályokra**, így nem kell SQL lekérdezéseket írnod minden egyes adatkezelési művelethez.

### **Két fő ORM lehetőség C#-ban:**
| ORM | Leírás |
|-----|--------|
| **Entity Framework (EF) Core** | A Microsoft hivatalos ORM-je, erősen integrált a .NET ökoszisztémába. |
| **Dapper** | "Micro ORM", amely kevesebb absztrakciót tartalmaz és gyorsabb, mint az EF Core. |

### **Sebesség-összehasonlítás ORM és ADO.NET között**
| Művelet | Entity Framework Core | Dapper | ADO.NET |
|---------|----------------------|--------|--------|
| **Egyszerű SELECT (1 rekord)** | 🔴 Lassúbb | 🟡 Közepesen gyors | 🟢 Leggyorsabb |
| **Több rekord lekérdezése (10,000+ rekord)** | 🔴 Lassabb | 🟢 Gyors | 🟢 Gyors |
| **Adat beszúrása (INSERT)** | 🟡 Közepes | 🟢 Gyors | 🟢 Gyors |
| **Összetett SQL lekérdezés (JOIN, GROUP BY, stb.)** | 🔴 Lassabb | 🟡 Közepes | 🟢 Gyors |

---

## Elemi adattípusok C#-ban

| Típus | Típusnév másképpen | Helyigény (bit) | Példa |
|-------|---------------------|---------------|--------|
| **Logikai változó** | `bool` | 8 | `true`, `false` |
| **Egész számok** | `int`, `uint`, `long`, `short` | 16-64 | `12`, `12u` |
| **Lebegőpontos szám** | `float`, `double`, `decimal` | 32-128 | `6.5f`, `12m` |
| **Karakter** | `char` | 8 | `'c'` |
| **Szöveg** | `string` | változó | `"szöveg"` |

---

## Összetett adatszerkezetek
- **Tömbök**
- **Listák** (`List<T>`)
- **Szótárak** (`Dictionary<K,V>`)
- **Halmazok** (`HashSet<T>`)
- **Saját osztályok és struktúrák**

## Vezérlési szerkezetek
- **Feltételes elágazások** (`if`, `switch`)
- **Ciklusok** (`for`, `while`, `foreach`)
- **Kivételkezelés** (`try-catch`)

## Metódusok és függvények
- **Kód újrafelhasználhatóság**
- **Paraméterátadás**
- **Visszatérési értékek**

## Objektumorientált programozás (OOP)
- **Osztályok és objektumok**
- **Öröklődés**
- **Interfészek**
- **Absztrakt osztályok**
- **Polimorfizmus**

## Fájlkezelés és adatbázis kapcsolat
- **Fájlok olvasása és írása** (`StreamReader`, `StreamWriter`)
- **Adatbázis kapcsolat** (SQL kapcsolat **Entity Framework** segítségével)

## Aszinkron programozás
- `async` és `await`
- **Párhuzamos végrehajtás** (`Task`, `Thread`)


