using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BallarAvStal
{
    public class Player
    {
        public string PlayerName { get; set; }

        NewGame newGame;

        private Canvas gameCanvas;

        MainWindow mainWindow;

        public void CreatePlayer()
        {
            if (newGame.SelectShape.SelectedItem == newGame.playerRectangle)
            {
                var rectangle = new Rectangle
                {
                    Width = 40,
                    Height = 40,
                    Fill = Brushes.Blue
                };
            }
            else if (newGame.SelectShape.SelectedItem == newGame.playerEllipse)
            {
                var ellipse = new Ellipse
                {
                    Width = 40,
                    Height = 40,
                    Fill = Brushes.Blue
                };
            }
            else if (newGame.SelectShape.SelectedItem == newGame.playerPolygon)
            {
                var polygon = new Polygon
                {
                    Width = 40,
                    Height = 40,
                    Fill = Brushes.Blue
                };

                gameCanvas.Children.Add(polygon);
                mainWindow.Show();
            }
        }
    }
}
