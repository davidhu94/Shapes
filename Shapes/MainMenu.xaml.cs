using System.Windows;
using System.Windows.Input;

namespace Shapes
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void NewPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame newGame = new NewGame();
            newGame.Show();
            this.Hide();
        }

        private void SavedPlayersButton_Click(object sender, RoutedEventArgs e)
        {
            SavedPlayers savedPlayers = new SavedPlayers();
            savedPlayers.Show();
            this.Close();
        }

        private void HighscoreButton_Click(object sender, RoutedEventArgs e)
        {
            Highscore highscore = new Highscore();
            highscore.Show();
            this.Hide();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}