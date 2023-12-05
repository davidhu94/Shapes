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
        public NewGame()
        {
            InitializeComponent();

            
        }
        MainWindow mainWindow;
        Player player = new Player();

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectShape.SelectedItem != null && NameTextBox.Text != null) 
            {
                player.CreatePlayer();
                
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Select a shape to begin.");
            }
        }
    }
}
