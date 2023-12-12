using System.Windows;
using System.Windows.Input;

namespace Shapes
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        FileManager fileManager;

        public MainMenu()
        {
            InitializeComponent();
            fileManager = new FileManager();
            LoadPlayerNames();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame newGame = new NewGame();
            newGame.Show();
            this.Hide();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void LoadPlayerNames()
        {
            List<Player> loadedPlayers = fileManager.LoadFromCsv();
            foreach (Player player in loadedPlayers)
            {
                HighScoreBoard.Items.Add($"{player.PlayerName} || Score: {player.HighScore}");
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
