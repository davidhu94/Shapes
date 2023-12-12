using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfBallarAvStalStoreTest
{
    public class Player
    {
        public string Name { get; set; }
        public int Shape { get; set; }
        public int Color { get; set; }
        public double Speed { get; set; }
        public double Highscore { get; set; }
        public double Exp { get; set; }
        public Player(string name, int shape, int color, double speed, double highscore, double exp)
        {
            Name = name;
            Shape = shape;
            Color = color;
            Speed = speed;
            Highscore = highscore;
            Exp = exp;
        }
        public void ShowPlayerInfo()
        {
            string strShape;
            if (Shape > 0)
            {
                strShape = "Rectangle";
            }
            else { strShape = "Ellipse"; }

            string strColor = "";
            if (Color == 0)
            {
                strColor = "Red";
            }
            if (Color == 1)
            {
                strColor = "Green";
            }
            if (Color == 2)
            {
                strColor = "Yellow";
            }
            if (Color == 3)
            {
                strColor = "Blue";
            }
            MessageBox.Show($"{Name} \nShape: {strShape}. \nColor: {strColor}. \nSpeed: {Speed}. \nHighscore: {Highscore}. \nExp: {Exp}.");
        }
    }
}
