using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BallarAvStal
{
    /// <summary>
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        MainWindow mainWindow;

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

                //int highScore = mainWindow.GetIncrement();

                Player player = new Player
                {
                    PlayerName = NameTextBox.Text,
                    SelectedShape = selectedShape,
                    //HighScore = highScore
                };
                User user = new User(player);

                user.SaveToCsv(player.PlayerName, player.SelectedShape, player.HighScore);

                MainWindow mainWindow = new MainWindow(player);
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
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
