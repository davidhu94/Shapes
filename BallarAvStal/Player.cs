using System.Windows.Media;
using System.Windows.Shapes;


namespace BallarAvStal
{
    public class Player
    {
        public string PlayerName { get; set; }

        public string SelectedShape { get; set; }
        
        //Generate shape based on player choice
        public Shape GetPlayerShape()
        {
            switch (SelectedShape)
            {
                case "Ellipse":
                    return new Ellipse { Width = 40, Height = 40, Fill = Brushes.Blue };
                case "Rectangle":
                    return new Rectangle { Width = 40, Height = 40, Fill = Brushes.Blue };
                //case "Polygon":
                //    Polygon polygon = new Polygon
                //    {
                //        Fill = Brushes.Blue,
                //        Stroke = Brushes.Black,
                //        StrokeThickness = 1
                //    };
                //    polygon.Points = new PointCollection(new List<System.Windows.Point>
                //    {
                //        new System.Windows.Point(0, 20), // Vänster 
                //        new System.Windows.Point(20, 0), // Topp
                //        new System.Windows.Point(40, 20), // Höger
                //    });
                //    return polygon;
                default:
                    throw new InvalidOperationException("Invalid shape selected");
            }
        }
    }
}
