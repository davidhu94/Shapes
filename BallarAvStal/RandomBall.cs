using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private int ballsToCreate = 10;

        private int totalBalls = 0;

        public DispatcherTimer ballCreationTimer = new DispatcherTimer();

        public RandomBall(Canvas canvas)
        {
            this.gameCanvas = canvas;
            ballCreationTimer.Tick += BallCreationTimerEvent;
            ballCreationTimer.Interval = TimeSpan.FromSeconds(10);
            ballCreationTimer.Start();
        }

        private void BallCreationTimerEvent(object sender, EventArgs e)
        {
            if (ballsToCreate > 0)
            {
                CreateRandomBall();
                ballsToCreate--;
            }
            else
            {
                ballCreationTimer.Stop();
            }
        }

        //Skapa bollarna och kasta ut dem ifrån sidorna
        public void CreateRandomBall()
        {
            if (totalBalls >= ballsToCreate)
            {
                return;
            }

            var ball = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Red
            };

            //Genereras från sidorna, 0=vänster, 1=höger, 2=topp, 3=bott 
            int side = random.Next(0, 4);

            //Hastighet på bollarna
            double xVelocity, yVelocity, startX, startY;

            switch (side)
            {
                case 0:
                    xVelocity = 3; //fast hastighet åt höger (positiv x axel)
                    yVelocity = random.Next(-3, 4); //Slump hastighet upp/ner (positiv y axel nedåt negativ uppåt)
                    startX = 0; //startpunkt vid vänster kant
                    startY = random.Next(0, (int)gameCanvas.ActualHeight - (int)ball.Height); //Random startpunkt (Y)
                    break;
                case 1:
                    xVelocity = -3; //Fast Hastighet åt vänster (negativ x axel)
                    yVelocity = random.Next(-3, 4); // Slump hastighet upp/ner (positiv y axel nedåt negativ uppåt)
                    startX = gameCanvas.ActualWidth - ball.Width; //Placering höger kant
                    startY = random.Next(0, (int)gameCanvas.ActualHeight - (int)ball.Height); //Random startpunkt (Y)
                    break;
                case 2:
                    xVelocity = random.Next(-3, 4); // Slump Hastighet horisontell vänster/höger
                    yVelocity = 3; // fast hastighet nedåt
                    startX = random.Next(0, (int)gameCanvas.ActualWidth - (int)ball.Width); //Random placering x position 
                    startY = 0; //Placering topp
                    break;
                case 3:
                    xVelocity = random.Next(-3, 4); //Slump Hastighet horisontell vänster/höger
                    yVelocity = -3; //Fast Hastighet uppåt
                    startX = random.Next(0, (int)gameCanvas.ActualWidth - (int)ball.Width); //Placering höger kant
                    startY = gameCanvas.ActualHeight - ball.Height; //Placering botten
                    break;
                default:
                    throw new InvalidOperationException("Ogiltig sida");
            }
          
            ball.Tag = new Point(xVelocity, yVelocity); //Point lagras i .tag med bollens hastighet X/Y
            Canvas.SetLeft(ball, startX); //Horisontell position av ball i canvas
            Canvas.SetTop(ball, startY); //Horisontell position av ball i canvas

            movingBalls.Add(ball);
            gameCanvas.Children.Add(ball); //Lägger till bollen i canvas så att den blir synlig
            totalBalls++;
        }

        //Rörelse/studs för bollarna
        public void MoveRandomBall()
        {
            foreach (var ball in movingBalls)
            {
                //Hastigheten kopieras från .tag till dx,dy
                var velocity = (Point)ball.Tag; 
                double dx = velocity.X; 
                double dy = velocity.Y;

                //Bollens nya position (nuvarande position + hastighet )
                var newX = Canvas.GetLeft(ball) + dx; 
                var newY = Canvas.GetTop(ball) + dy; 

                //Träffar bollen en kant blir hastigheten inverterad och bollen gör en "studs"
                if (newX <= 0 || newX >= gameCanvas.ActualWidth - ball.Width)
                {
                    dx = -dx;
                }
                if (newY <= 0 || newY >= gameCanvas.ActualHeight - ball.Height)
                {
                    dy = -dy;
                }

                //nya hastigheten efter studs sparas till .tag
                ball.Tag = new Point(dx, dy); 
                Canvas.SetLeft(ball, newX);
                Canvas.SetTop(ball, newY);
            }
        }

        //Kollision med Spelare och bollarna
        public bool CheckForCollision(Rect playerRect)
        {
            foreach (var ball in movingBalls)
            {
                Rect ballRect = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);
                if (playerRect.IntersectsWith(ballRect))
                {
                    return true;
                }
            }
            return false;
        }

        public void GameOver()
        {
            ballCreationTimer.Stop();
            MessageBoxResult result = MessageBox.Show("Game Over! Play again?", "Game Over", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {


                //Metod för att starta om spelet
            }
            else
            {
                //Återgå till Main window när vi skapat det?
            }
        }
    }
}
