using System.Windows;
using System.Windows.Input;

namespace Shapes
{
    /// <summary>
    /// Interaction logic for SavedPlayers.xaml
    /// </summary>
    public partial class SavedPlayers : Window
    {
        FileManager fileManager;

        public SavedPlayers()
        {
            InitializeComponent();
            fileManager = new FileManager();
            LoadPlayerNames();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (savedPlayersListBox.SelectedItem != null)
            {
                MessageBox.Show("Your goal is to not be hit by the balls. Use W-A-S-D to move.");

                string selectedText = savedPlayersListBox.SelectedItem.ToString();
                string playerName = ExtractPlayerName(selectedText);

                Player existingPlayer = fileManager.GetPlayerByName(playerName);

                if (existingPlayer != null)
                {
                    GameWindow gameWindow = new GameWindow(existingPlayer);
                    gameWindow.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Player with the selected name doesn't exist!");
                }
            }
            else
            {
                MessageBox.Show("Please select a player from the list.");
            }
        }

        private void LoadPlayerNames()
        {
            List<Player> loadedPlayers = fileManager.LoadFromCsv();
            foreach (Player player in loadedPlayers)
            {
                savedPlayersListBox.Items.Add($"{player.PlayerName}     |     {player.SelectedShape}"); 
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (savedPlayersListBox.SelectedItem != null)
            {
                string selectedText = savedPlayersListBox.SelectedItem.ToString();
                string playerNameToRemove = ExtractPlayerName(selectedText);

                fileManager.RemovePlayerFromCsv(playerNameToRemove);

                savedPlayersListBox.Items.Remove(savedPlayersListBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Select a name to remove.");
            }
        }

        private string ExtractPlayerName(string listBoxItemText)
        {
            int separatorIndex = listBoxItemText.IndexOf("     |     ");
            if (separatorIndex > 0)
            {
                return listBoxItemText.Substring(0, separatorIndex);
            }
            return listBoxItemText; 
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
