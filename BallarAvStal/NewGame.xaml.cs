using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace BallarAvStal
{
    /// <summary>
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        private User user;

        public NewGame()
        {
            InitializeComponent();
            user = new User();
            LoadPlayerNames();
        }

        //Validate inputs,create player and open the Game
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectShape.SelectedItem != null && nameListBox.SelectedItem != null) 
            {
                ComboBoxItem selectedItem = (ComboBoxItem)SelectShape.SelectedItem;
                //string selectedShape = selectedItem.Content.ToString();

                string playerName = nameListBox.SelectedItem.ToString();

                Player existingPlayer = user.GetPlayerByName(playerName);

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


                //Player player = new Player
                //{
                //    SelectedShape = selectedShape
                //};

                //GameWindow mainWindow = new GameWindow(player);
                //mainWindow.Show();
                //this.Hide();
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

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameListBox.SelectedItem != null)
            {
                string playerNameToRemove = nameListBox.SelectedItem.ToString();

                nameListBox.Items.Remove(playerNameToRemove);

                user.RemovePlayerFromCsv(playerNameToRemove);
            }
            else
            {
                MessageBox.Show("Select a name to remove.");
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
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> playerNames = nameListBox.Items.OfType<string>().ToList();



            foreach (string playerName in playerNames)
            {
                string selectedShape = GetSelectedShape();
                int highScore = 0;
                user.SaveToCsv(playerName, selectedShape, highScore);
            }
            MessageBox.Show("Players saved!");
        }

        private void LoadPlayerNames()
        {
            nameListBox.Items.Clear();
            List<Player> loadedPlayers = user.LoadFromCsv();
            foreach (Player player in loadedPlayers)
            {
                nameListBox.Items.Add(player.PlayerName);
            }
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
