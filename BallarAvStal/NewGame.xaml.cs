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
        public NewGame()
        {
            InitializeComponent();          
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectShape.SelectedItem != null && !string.IsNullOrEmpty(NameTextBox.Text)) 
            {
                ComboBoxItem selectedItem = (ComboBoxItem)SelectShape.SelectedItem;
                string selectedShape = selectedItem.Content.ToString();

                Player player = new Player
                {
                    PlayerName = NameTextBox.Text,
                    SelectedShape = selectedShape
                };

                GameWindow mainWindow = new GameWindow(player);
                mainWindow.Show();
                this.Hide();
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
    }
}
