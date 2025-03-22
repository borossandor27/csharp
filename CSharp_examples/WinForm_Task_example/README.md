# **WinForms példa: hosszú számítás háttérben (`Task` használatával)**
A felhasználó megnyom egy gombot, és elindul egy **háttérszámítás** (pl. számolás 1-től 1.000.000-ig). A program **nem fagy le**, mert a művelet **egy másik szálon** fut — és mi a `Task`-ot fogjuk használni, mivel kényelmes és modern megoldás.


## 1. **Form1.cs**
```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void buttonStart_Click(object sender, EventArgs e)
    {
        labelStatus.Text = "Számítás folyamatban...";
        buttonStart.Enabled = false;

        int eredmeny = await Task.Run(() => HosszuSzamitas());

        labelStatus.Text = $"Számítás vége: {eredmeny}";
        buttonStart.Enabled = true;
    }

    private int HosszuSzamitas()
    {
        int osszeg = 0;
        for (int i = 1; i <= 1_000_000; i++)
        {
            osszeg += i;
        }
        return osszeg;
    }
}
```

## 2. **Form design *(pl. a Designer.cs-ben vagy kézzel)*:**

- `Button` neve: `buttonStart`, szövege: **Indítás**
- `Label` neve: `labelStatus`, szövege kezdetben: **Várakozás...**

```csharp
private void InitializeComponent()
{
    this.buttonStart = new System.Windows.Forms.Button();
    this.labelStatus = new System.Windows.Forms.Label();

    this.SuspendLayout();

    // buttonStart
    this.buttonStart.Location = new System.Drawing.Point(30, 30);
    this.buttonStart.Name = "buttonStart";
    this.buttonStart.Size = new System.Drawing.Size(100, 30);
    this.buttonStart.Text = "Indítás";
    this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);

    // labelStatus
    this.labelStatus.Location = new System.Drawing.Point(30, 80);
    this.labelStatus.Size = new System.Drawing.Size(300, 25);
    this.labelStatus.Text = "Várakozás...";

    // Form1
    this.ClientSize = new System.Drawing.Size(400, 150);
    this.Controls.Add(this.buttonStart);
    this.Controls.Add(this.labelStatus);
    this.Name = "Form1";
    this.Text = "Task példa";

    this.ResumeLayout(false);
}
```

- A `Task.Run()` segítségével a hosszú művelet **külön szálon fut**, nem blokkolja a UI-t.
- Az `await` miatt a vezérlés visszatér a felhasználói felülethez, és **nem fagy le az ablak**.
- A gomb **le van tiltva a számítás alatt**, majd újra engedélyezve lesz.
