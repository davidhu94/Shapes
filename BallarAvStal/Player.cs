using System.Windows.Media;
using System.Windows.Shapes;


namespace BallarAvStal
{
    public class Player
    {
        public string PlayerName { get; set; }

        public string SelectedShape { get; set; }

        public int HighScore { get; set; }

        //Generate shape based on player choice
        public Shape GetPlayerShape()
        {
            switch (SelectedShape)
            {
                case "Ellipse":
                    return new Ellipse { Width = 40, Height = 40, Fill = Brushes.Blue };
                case "Rectangle":
                    return new Rectangle { Width = 40, Height = 40, Fill = Brushes.Blue };
                default:
                    throw new InvalidOperationException("Invalid shape selected");
            }
        }
    }
}
