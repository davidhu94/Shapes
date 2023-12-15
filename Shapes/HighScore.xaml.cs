using System.Windows;
using System.Windows.Input;

namespace Shapes
{
    public partial class Highscore : Window
    {
        FileManager fileManager;

        public Highscore()
        {
            InitializeComponent();
            fileManager = new FileManager();
            LoadPlayerNames();
        }

        private void LoadPlayerNames()
        {
            List<Player> loadedPlayers = fileManager.LoadFromCsv();
            foreach (Player player in loadedPlayers)
            {
                highscoreListBox.Items.Add($"{player.PlayerName}     |     {player.HighScore}");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Close();
        }  
    }
}
