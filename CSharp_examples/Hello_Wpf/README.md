# **WPF példa (XAML + C#)**

## **MainWindow.xaml**
```xml
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        Title="Köszöntés" Height="200" Width="300">
    <StackPanel Margin="20">
        <TextBox x:Name="NameBox" />
        <Button Content="Köszöntés" Click="Greet_Click" Margin="0,10,0,0"/>
        <TextBlock x:Name="GreetingText" FontWeight="Bold" Margin="0,10,0,0"/>
    </StackPanel>
</Window>
```

## **MainWindow.xaml.cs**
```csharp
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Greet_Click(object sender, RoutedEventArgs e)
    {
        GreetingText.Text = $"Üdvözöllek, {NameBox.Text}!";
    }
}
```

**Jellemzők:**
- Elrendezés **XAML-ben**, könnyen átlátható
- `StackPanel` automatikusan rendezi az elemeket
- Elkülönül a UI és a logika
- Később [MVVM (*Model-View-ViewModel*)](https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm) -re is könnyen átalakítható


| Jellemző                 | WinForms                          | WPF                                    |
|--------------------------|------------------------------------|-----------------------------------------|
| UI leírás                | Kódban (imperatív)                | XAML-ben (deklaratív)                  |
| Elrendezés               | Pontos pozíciók, kézi méretezés   | Layout panelek (pl. `StackPanel`)      |
| UI + logika szétválasztása | Nehézkes                         | Természetesen megoldható                |
| Bővíthetőség             | Korlátozott                       | Könnyű sablonozás, stílusok, MVVM      |
