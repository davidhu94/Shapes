using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Shapes
{
    /// <summary>
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        private FileManager fileManager;
      
        public NewGame()
        {
            InitializeComponent();
            fileManager = new FileManager();
            LoadPlayerNames();
            ShowMessageBoxWithDelay();
        }

        private async void ShowMessageBoxWithDelay()
        {
            await Task.Delay(500);
            MessageBox.Show("To start: Choose a name, form, add and then save.");
        }

        //Validate inputs,create player and open the Game
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectShape.SelectedItem != null && nameListBox.SelectedItem != null) 
            {
                MessageBox.Show("Your goal is to not be hit by the balls. Use W-A-S-D to move. The longer you last, the more xp you get.");

                ComboBoxItem selectedItem = (ComboBoxItem)SelectShape.SelectedItem;

                string playerName = nameListBox.SelectedItem.ToString();

                Player existingPlayer = fileManager.GetPlayerByName(playerName);

                if (existingPlayer != null)
                {
                    GameWindow gameWindow = new GameWindow(existingPlayer);
                    gameWindow.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Player with the selected name doesn't exist! You need to save first!");
                }
            }
            else
            {
                MessageBox.Show("Enter your name and select a shape to begin.");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private string GetSelectedShape()
        {
            if (SelectShape.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content != null)
            {
                return selectedItem.Content.ToString();
            }
            return "";
        }

        private void LoadPlayerNames()
        {
            nameListBox.Items.Clear();
            List<Player> loadedPlayers = fileManager.LoadFromCsv();
            foreach (Player player in loadedPlayers)
            {
                nameListBox.Items.Add(player.PlayerName);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameListBox.SelectedItem != null)
            {
                string playerNameToRemove = nameListBox.SelectedItem.ToString();

                nameListBox.Items.Remove(playerNameToRemove);

                fileManager.RemovePlayerFromCsv(playerNameToRemove);
            }
            else
            {
                MessageBox.Show("Select a name to remove.");
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> playerNames = nameListBox.Items.OfType<string>().ToList();

            foreach (string playerName in playerNames)
            {
                string selectedShape = GetSelectedShape();
                int highScore = 0;
                fileManager.SaveToCsv(playerName, selectedShape, highScore);
            }
            MessageBox.Show("Players saved!");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = NameTextBox.Text.Trim();
            string selectedShape = GetSelectedShape();

            if (string.IsNullOrEmpty(selectedShape))
            {
                MessageBox.Show("You need to select a shape!");
                return;
            }

            if (!string.IsNullOrEmpty(newName) && !nameListBox.Items.Contains(newName))
            {
                nameListBox.Items.Add(newName);
            }
        }
    }
}
