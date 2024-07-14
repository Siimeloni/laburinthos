using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using laburinthos.ViewModels;
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Avalonia.Markup.Xaml;
using Avalonia.Input;
using System.Xml.Serialization;

namespace laburinthos;

public partial class MainWindow : Window
{
    static MainViewModel context;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
        context = (MainViewModel)DataContext;
        context.UpdateImage("Assets/default.bmp");
        
        this.KeyDown += OnKeyDown;
    }

    private void HelpClick(object sender, RoutedEventArgs e)
    {
        var window = new HelpWindow();
        window.Show();
    }
    
    private void RunClick(object sender, RoutedEventArgs e)
    {
        try {
            ErrorMessage.Background=Brush.Parse("#20283d");
            ErrorMessage.Text="";

            int methode = MethodeComboBox.SelectedIndex;
            int modus = ModiComboBox.SelectedIndex;
            if (5 <= Int32.Parse(SizeTextBox.Text) && Int32.Parse(SizeTextBox.Text) <= 50 ){
                ErrorMessage.Background=Brush.Parse("#20283d");
                ErrorMessage.Text="";
                byte size = byte.Parse(SizeTextBox.Text);
                //hier der aufruf der GameManager Klasse (mit übergabe der Parameter)
                GameManager.LabyrinthInit(methode, modus, size);

                //context.UpdateImage("Assets/labyrinth.bmp");
            }else {
                ErrorMessage.Background=Brushes.Red;
                ErrorMessage.Text = "! Fehler ! Eingabe zwischen 5 und 50 !";
            }
        }
        catch{
            ErrorMessage.Background=Brushes.Red;
            ErrorMessage.Text = "! Fehler ! Eingabe nicht korrekt !";
        }
    }

    private void OnKeyDown(object sender, KeyEventArgs e) {
        switch (e.Key) {
            case Key.Up:
            case Key.W:
                GameManager.Moving(Direction.Up);
                break;
            case Key.Left:
            case Key.A:
                GameManager.Moving(Direction.Left);
                break;
            case Key.Down:
            case Key.S:
                GameManager.Moving(Direction.Down);
                break;
            case Key.Right:
            case Key.D:
                GameManager.Moving(Direction.Right);
                break;
            case Key.N:
                RunClick(this, new RoutedEventArgs(Button.ClickEvent));
                break;
            default:
                break;
        }

    }
    
}
