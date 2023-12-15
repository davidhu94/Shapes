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
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectShapeComboBox.SelectedItem != null && !string.IsNullOrEmpty(nameTextBox.Text)) 
            {
                ComboBoxItem selectedItem = (ComboBoxItem)selectShapeComboBox.SelectedItem;
                string playerName = nameTextBox.Text;

                Player existingPlayer = fileManager.GetPlayerByName(playerName);
                if (existingPlayer != null)
                {
                    MessageBox.Show($"A player with the name '{playerName}' already exists. Please choose a different name.");
                    return; 
                }

                int highscore = 0;

                Player newPlayer = new Player
                {
                    PlayerName = playerName,
                    SelectedShape = selectedItem.Content.ToString(),
                    HighScore = highscore
                };

                fileManager.SaveToCsv(playerName,selectedItem.Content.ToString(),highscore);

                MessageBox.Show("Your goal is to not be hit by the balls. Use W-A-S-D to move.");

                GameWindow gameWindow = new GameWindow(newPlayer);
                gameWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Please enter your name and select a shape.");
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
