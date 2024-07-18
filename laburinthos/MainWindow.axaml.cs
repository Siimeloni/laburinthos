using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Input;
using laburinthos.ViewModels;
using System;


namespace laburinthos;

public partial class MainWindow : Window {

    static MainViewModel context;

    public MainWindow() {
        InitializeComponent();
        DataContext = new MainViewModel();
        context = (MainViewModel)DataContext;
        context.UpdateImage(GameManager.DefaultFilePath);
        
        this.KeyDown += OnKeyDown;
    }

    /// <summary>
    /// Event that opens an additional window with information.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HelpClick(object sender, RoutedEventArgs e) {
        var window = new HelpWindow();
        window.Show();
    }
    
    /// <summary>
    /// Event that checks the input and calls the GameManager to initialize the labyrinth and the player.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RunClick(object sender, RoutedEventArgs e) {
        try {
            ErrorMessage.Background=Brush.Parse("#20283d");
            ErrorMessage.Text="";

            int method = MethodeComboBox.SelectedIndex;
            int modus = ModiComboBox.SelectedIndex;

            if (5 <= Int32.Parse(SizeTextBox.Text) && Int32.Parse(SizeTextBox.Text) <= 50 ) {
                byte size = byte.Parse(SizeTextBox.Text);

                //here the call to the GameManager class (with passing of the parameters)
                GameManager.LabyrinthInit(method, modus, size);
                GameManager.PlayerInit();

                context.UpdateImage(GameManager.FilePath);
            } else {
                ErrorMessage.Background=Brush.Parse("#953131");
                ErrorMessage.Text = "! Fehler ! Eingabe zwischen 5 und 50 !";
            }
        }
        catch {
            ErrorMessage.Background=Brush.Parse("#953131");
            ErrorMessage.Text = "! Fehler ! Eingabe nicht korrekt !";
        }
    }

    /// <summary>
    /// Event that registers the keyboard input (hotkey) and passes it on to GameManager.Moving.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnKeyDown(object sender, KeyEventArgs e) {
        switch (e.Key) {
            case Key.Up:
            case Key.W:
                GameManager.Moving(Direction.Up, context);
                break;
            case Key.Left:
            case Key.A:
                GameManager.Moving(Direction.Left, context);
                break;
            case Key.Down:
            case Key.S:
                GameManager.Moving(Direction.Down, context);
                break;
            case Key.Right:
            case Key.D:
                GameManager.Moving(Direction.Right, context);
                break;
            case Key.N:
                RunClick(this, new RoutedEventArgs(Button.ClickEvent));
                break;
            default:
                break;
        }
        if (!GameManager.isActive) { EndMessage(); }
    }

    /// <summary>
    /// Info for users about won game on GUI
    /// </summary>
    public void EndMessage() {
        ErrorMessage.Background=Brush.Parse("#426e5d");
        ErrorMessage.Text = "You Won - Congratulations!";
    }
    
}
