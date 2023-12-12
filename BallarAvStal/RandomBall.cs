using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BallarAvStal
{
    public class RandomBall
    {
        private Canvas gameCanvas;

        private List<Ellipse> movingBalls = new List<Ellipse>();

        public Random random = new Random();

        public DispatcherTimer ballCreationTimer = new DispatcherTimer();

        //Control generated balls/second here (TimeSpan)
        public RandomBall(Canvas canvas)
        {
            this.gameCanvas = canvas;
            ballCreationTimer.Tick += BallCreationTimerEvent;
            ballCreationTimer.Interval = TimeSpan.FromSeconds(2);  
            ballCreationTimer.Start();
        }

        //Control amount of generated balls here
        private void BallCreationTimerEvent(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++) 
            {
                CreateRandomBall();
            }
        }

        //Generate balls from random sides, 0 = Left, 1 = Right, 2 = Top, 3 = Bott
        //Set the speed and start value of the balls
        //Save speed in ball.tag (Point) and set positon on canvas
        public void CreateRandomBall()
        {
            var ball = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Red
            };

            int side = random.Next(0, 4);

            double xVelocity, yVelocity, startX, startY;

            switch (side)
            {
                case 0:
                    xVelocity = 5; 
                    yVelocity = random.Next(-3, 4); 
                    startX = 0; 
                    startY = random.Next(0, (int)gameCanvas.ActualHeight - (int)ball.Height); 
                    break;
                case 1:
                    xVelocity = -5; 
                    yVelocity = random.Next(-3, 4); 
                    startX = gameCanvas.ActualWidth - ball.Width; 
                    startY = random.Next(0, (int)gameCanvas.ActualHeight - (int)ball.Height); 
                    break;
                case 2:
                    xVelocity = random.Next(-3, 4); 
                    yVelocity = 5; 
                    startX = random.Next(0, (int)gameCanvas.ActualWidth - (int)ball.Width); 
                    startY = 0; 
                    break;
                case 3:
                    xVelocity = random.Next(-3, 4); 
                    yVelocity = -5; 
                    startX = random.Next(0, (int)gameCanvas.ActualWidth - (int)ball.Width); 
                    startY = gameCanvas.ActualHeight - ball.Height; 
                    break;
                default:
                    throw new InvalidOperationException("Invalid side");
            }
          
            ball.Tag = new Point(xVelocity, yVelocity);
            Canvas.SetLeft(ball, startX); 
            Canvas.SetTop(ball, startY); 

            movingBalls.Add(ball);
            gameCanvas.Children.Add(ball); 
        }

        //Speed from .Tag (Point) into dx,dy
        //Balls new position = current position + speed
        //Ball hits left/right wall, invert horizontal speed (dx)
        //Ball hits top/bott wall, invert vertical speed (dy)
        //After bounce update .Tag with new speed and set new positon
        public void MoveRandomBall()
        {
            foreach (var ball in movingBalls)
            {
                var velocity = (Point)ball.Tag; 
                double dx = velocity.X; 
                double dy = velocity.Y;

                var newX = Canvas.GetLeft(ball) + dx; 
                var newY = Canvas.GetTop(ball) + dy; 

   
                if (newX <= 0 || newX >= gameCanvas.ActualWidth - ball.Width)
                {
                    dx = -dx;
                }
                if (newY <= 0 || newY >= gameCanvas.ActualHeight - ball.Height)
                {
                    dy = -dy;
                }

                ball.Tag = new Point(dx, dy); 
                Canvas.SetLeft(ball, newX);
                Canvas.SetTop(ball, newY);
            }
        }

        //playerRect represent area (Rect) of player shape by current position
        //ballRect represent area (Rect) of ball shape by current position
        //Collision true when player and ball intersects
        public bool CheckForCollision(Shape playerShape)
        {
            Rect playerRect = new Rect(Canvas.GetLeft(playerShape), Canvas.GetTop(playerShape), playerShape.Width, playerShape.Height);

            foreach (Ellipse ball in movingBalls)
            {
                Rect ballRect = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);
                if (playerRect.IntersectsWith(ballRect))
                {
                    return true;
                }
            }
            return false;
        }

        public void ResetBalls()
        {
            movingBalls.Clear();
            gameCanvas.Children.Clear();
        }       
    }
}
