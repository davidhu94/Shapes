using System.Windows;
using System.Windows.Controls;


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

                MainWindow mainWindow = new MainWindow(player);
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter your name and select a shape to begin.");
            }
        }
    }
}
