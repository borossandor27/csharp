## **1. WinForms példa**

```csharp
public partial class MainForm : Form
{
    private TextBox textBoxName;
    private Button buttonGreet;
    private Label labelResult;

    public MainForm()
    {
        InitializeComponent();

        textBoxName = new TextBox { Location = new Point(20, 20), Width = 200 };
        buttonGreet = new Button { Location = new Point(20, 60), Text = "Köszöntés" };
        labelResult = new Label { Location = new Point(20, 100), AutoSize = true };

        buttonGreet.Click += (s, e) =>
        {
            labelResult.Text = $"Üdvözöllek, {textBoxName.Text}!";
        };

        Controls.Add(textBoxName);
        Controls.Add(buttonGreet);
        Controls.Add(labelResult);
    }
}
```

**Jellemzők:**
- Kézi elrendezés (`Location`, `Width`)
- Egyszerű `event handler`
- Kód vezérli a UI-t


| Jellemző                 | WinForms                          | WPF                                    |
|--------------------------|------------------------------------|-----------------------------------------|
| UI leírás                | Kódban (imperatív)                | XAML-ben (deklaratív)                  |
| Elrendezés               | Pontos pozíciók, kézi méretezés   | Layout panelek (pl. `StackPanel`)      |
| UI + logika szétválasztása | Nehézkes                         | Természetesen megoldható                |
| Bővíthetőség             | Korlátozott                       | Könnyű sablonozás, stílusok, MVVM      |
