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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBallarAvStalStoreTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> playerList = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
            //OneAtATime();
            Player player = new Player("Vilhelm", 1, 1, 1, 0, 10);
            Player player2 = new Player("Josef", 1, 1, 1, 0, 10);
            Player player3 = new Player("David", 1, 1, 1, 0, 10);
            Player player4 = new Player("Johan", 1, 1, 4, 0, 10);

            playerList.Add(player);
            playerList.Add(player2);
            playerList.Add(player3);
            playerList.Add(player4);

            foreach (Player p in playerList)
            {
                PlayersListbox.Items.Add(p.Name + ": " + p.Exp + " Exp");
            }
            
        }
        private void OneAtATime()
        {
            if (SpeedBostListbox.SelectedItem != null)
            {
                ShapeListbox.SelectedItem = null;
                ColourListbox.SelectedItem = null;
                
            }
            if (ShapeListbox.SelectedItem != null)
            {
                SpeedBostListbox.SelectedItem = null;
                ColourListbox.SelectedItem = null;
            }
            if (ColourListbox.SelectedItem != null)
            {
                SpeedBostListbox.SelectedItem = null;
                ShapeListbox.SelectedItem = null;
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersListbox.SelectedItem != null)
            {
                int index = PlayersListbox.SelectedIndex;
                Player player = playerList[index];

                if (SpeedBostListbox.SelectedItem != null)
                {
                    int speedindex = SpeedBostListbox.SelectedIndex;
                    
                    if (speedindex == 0)
                    {
                        player.Speed *= 1.1;
                    }
                    if (speedindex == 1)
                    {
                        player.Speed *= 1.25;
                    }
                    if (speedindex == 2)
                    {
                        player.Speed *= 1.5;
                    }
                    if (speedindex == 3)
                    {
                        player.Speed *= 2;
                    }
                }
                if (ShapeListbox.SelectedItem != null)
                {
                    int shapeindex = ShapeListbox.SelectedIndex;

                    if (shapeindex == 0)
                    {
                        player.Shape = 0;
                    }
                    if (shapeindex == 1)
                    {
                        player.Shape = 1;
                    }
                }
                if (ColourListbox.SelectedItem != null)
                {
                    int colourindex = ColourListbox.SelectedIndex;
                    if (colourindex == 0)
                    {
                        player.Color = 0;
                    }
                    if (colourindex == 1)
                    {
                        player.Color = 1;
                    }
                    if (colourindex == 2)
                    {
                        player.Color = 2;
                    }
                    if (colourindex == 3)
                    {
                        player.Color = 3;
                    }
                }
                player.ShowPlayerInfo();
                PlayersListbox.SelectedItem = null;
                SpeedBostListbox.SelectedItem = null;
                ShapeListbox.SelectedItem = null;
                ColourListbox.SelectedItem = null;
            }
        }
    }
}
