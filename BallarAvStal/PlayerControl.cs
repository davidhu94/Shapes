using System.Windows.Controls;
using System.Windows.Shapes;

namespace BallarAvStal
{
    public class PlayerControl
    {
        public bool GoLeft { get; set; }
        public bool GoRight { get; set; }
        public bool GoUp { get; set; }
        public bool GoDown { get; set; }

        private Shape playerShape;
        public Shape PlayerShape => playerShape;

        private Canvas gameCanvas;

        private const int Speed = 5;

        public PlayerControl(Canvas canvas, Shape shape)
        {
            gameCanvas = canvas;
            playerShape = shape;
        }

        public void MovePlayer()
        {
            double newX = Canvas.GetLeft(playerShape) + (GoLeft ? -Speed : 0) + (GoRight ? Speed : 0);
            double newY = Canvas.GetTop(playerShape) + (GoUp ? -Speed : 0) + (GoDown ? Speed : 0);

            if (GoLeft) newX -= Speed;
            if (GoRight) newX += Speed;
            if (GoUp) newY -= Speed;
            if (GoDown) newY += Speed;

            newX = Math.Max(0, Math.Min(gameCanvas.ActualWidth - playerShape.Width, newX));
            newY = Math.Max(0, Math.Min(gameCanvas.ActualHeight - playerShape.Height, newY));

            Canvas.SetLeft(playerShape, newX);
            Canvas.SetTop(playerShape, newY);
        }
    }
}
