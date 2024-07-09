using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace laburinthos;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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
                int size = Int32.Parse(SizeTextBox.Text);
                //hier der aufruf der GameManager Klasse (mit übergabe der Parameter)
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
}