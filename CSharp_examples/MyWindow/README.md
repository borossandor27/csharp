# WinForm ablak sablon

## `managed` erőforrások
A `Controls.Clear()` és az egyes kontrollok (`Control`) manuális eltávolítása (`Dispose`) fontos, mivel a két művelet különböző célokat szolgál, és nem mindig elegendő csak az egyiket használni.

## **Miért kell egyenként eltávolítani a kontrollokat (`control.Dispose()`)?**
Amikor egy kontrollt *(pl. `Button`, `Label`, `TextBox`)* hozzáadsz egy `Form`-hoz vagy más tárolóhoz *(pl. `Panel`)*, a kontroll erőforrásokat foglal le *(pl. memória, grafikus erőforrások, eseménykezelők)*. Ezeket az erőforrásokat explicit módon fel kell szabadítani, amikor a kontrollra már nincs szükség.

Összefoglalva a `control.Dispose()` metódus:
- Felszabadítja a kontroll által lefoglalt erőforrásokat.
- Megszünteti az eseménykezelőket *(pl. `Click`, `TextChanged`)*, hogy ne maradjanak fenn felesleges hivatkozások.
- Biztosítja, hogy az unmanaged erőforrások (pl. GDI+ objektumok) is helyesen felszabadulnak.

Ha nem hívjuk meg a `Dispose()` metódust, akkor:
- Az erőforrások szivárgása (`resource leak`) léphet fel.
- Az alkalmazás memóriafogyasztása növekedhet.
- Az eseménykezelők továbbra is aktívak maradhatnak, ami váratlan viselkedést okozhat.

## **Miért kell a `Controls.Clear()` meghívása?**
A `Controls.Clear()` metódus eltávolítja az összes kontrollt a `Controls` gyűjteményből, de **nem szabadítja fel az erőforrásokat**. Ez csak a gyűjteményből távolítja el a hivatkozásokat, de maguk a kontrollok továbbra is léteznek és erőforrásokat foglalnak.

Ha csak a `Controls.Clear()`-t hívod meg:
- A kontrollok továbbra is léteznek a memóriában.
- Az erőforrások nem szabadulnak fel.
- Az eseménykezelők továbbra is aktívak maradnak.


Példa:
```csharp
foreach (Control control in this.Controls)
{
    control.Dispose(); // Felszabadítjuk az erőforrásokat
}
this.Controls.Clear(); // Töröljük a gyűjteményt
```

### Összefoglalás
- A `control.Dispose()` felszabadítja az erőforrásokat és megszünteti az eseménykezelőket.
- A `Controls.Clear()` eltávolítja a kontrollokat a gyűjteményből.
- Mindkét lépésre szükség van, hogy az erőforrások helyesen felszabaduljanak, és a gyűjtemény üres legyen.
- A helyes sorrend: először `Dispose()`, majd `Clear()`.


## Az `unmanaged` erőforrások közé tartoznak például:

**Fájlkezelés**:
- Fájlok (FileStream, StreamReader, StreamWriter stb.).
- Hálózati kapcsolatok (Socket, TcpClient, HttpClient stb.).

**Adatbázis-kapcsolatok**:
- ADO.NET kapcsolatok (SqlConnection, SqlCommand stb.).

**Grafikus erőforrások**:
- GDI+ objektumok (Bitmap, Pen, Brush stb.).

**Memóriakezelés**:
- Unmanaged memória (pl. IntPtr, SafeHandle használatával).

**Külső könyvtárak**:
- COM objektumok (pl. Excel, Word automatikus objektumai).
- Native könyvtárak (pl. P/Invoke segítségével használt függvények).



