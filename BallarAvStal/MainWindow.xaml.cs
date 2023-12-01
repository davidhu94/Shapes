using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace BallarAvStal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool goLeft, goRight, goUp, goDown;
        public bool goLeftLetter, goRightLetter, goUpLetter, goDownLetter;
        int playerSpeed = 10;

        

        DispatcherTimer gameTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            GameCanvas.Focus();

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
        }



        //private void playerRectangle_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Left)
        //    {
        //        goLeft = false;
        //    }
        //}
        
        private void GameTimerEvent(object sender, EventArgs e)
        {
            //pilar

            if (goLeft == true && Canvas.GetLeft(playerBall) > 5)
            {
                Canvas.SetLeft(playerBall, Canvas.GetLeft(playerBall) - playerSpeed);
            }
            if (goRight == true && Canvas.GetLeft(playerBall) + (playerBall.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(playerBall, Canvas.GetLeft(playerBall) + playerSpeed);
            }
            if (goUp == true && Canvas.GetTop(playerBall) > 5)
            {
                Canvas.SetTop(playerBall, Canvas.GetTop(playerBall) - playerSpeed);
            }
            if (goDown == true && Canvas.GetTop(playerBall) + (playerBall.Height + 40) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(playerBall, Canvas.GetTop(playerBall) + playerSpeed);
            }








            //WASD

            if (goLeftLetter == true && Canvas.GetLeft(playerRectangle) > 5)
            {
                Canvas.SetLeft(playerRectangle, Canvas.GetLeft(playerRectangle) - playerSpeed);
            }
            if (goRightLetter == true && Canvas.GetLeft(playerRectangle) + (playerRectangle.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(playerRectangle, Canvas.GetLeft(playerRectangle) + playerSpeed);
            }
            if (goUpLetter == true && Canvas.GetTop(playerRectangle) > 5)
            {
                Canvas.SetTop(playerRectangle, Canvas.GetTop(playerRectangle) - playerSpeed);
            }
            if (goDownLetter == true && Canvas.GetTop(playerRectangle) + (playerRectangle.Height + 40) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(playerRectangle, Canvas.GetTop(playerRectangle) + playerSpeed);
            }

        }
                
            
        

        private void GameCanvas_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down)
            {
                HandleArrowKey(e);
            }

            else if (e.Key == Key.A || e.Key == Key.D || e.Key == Key.W || e.Key == Key.S)
            {
                
                HandleWASDKey(e);
            }




            //if (e.Key == Key.A || e.Key == Key.Left)
            //{
            //    goLeft = true;
            //    goLeftLetter = true;
            //}
            //if (e.Key == Key.D || e.Key == Key.Right)
            //{
            //    goRight = true;
            //    goRightLetter = true;
            //}
            //if (e.Key == Key.W || e.Key == Key.Up)
            //{
            //    goUp = true;
            //    goUpLetter = true;
            //}
            //if (e.Key == Key.S || e.Key == Key.Down)
            //{
            //    goDown = true;
            //    goDownLetter = true;
            //}
            
        }

        

        private void GameCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down)
            {
                StopMovingArrowKey(e);
            }

            else if (e.Key == Key.A || e.Key == Key.D || e.Key == Key.W || e.Key == Key.S)
            {
                StopMovingWASDKey(e);
            }
            //if (e.Key == Key.A || e.Key == Key.Left)
            //{
            //    goLeft = false;
            //    goLeftLetter = false;
            //}
            //if (e.Key == Key.D || e.Key == Key.Right)
            //{
            //    goRight = false;
            //    goRightLetter = false;
            //}
            //if (e.Key == Key.W || e.Key == Key.Up)
            //{
            //    goUp = false;
            //    goUpLetter = false;
            //}
            //if (e.Key == Key.S || e.Key == Key.Down)
            //{
            //    goDown = false;
            //    goDownLetter = false;
            //}

        }

        private void StopMovingWASDKey(KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
               
                goLeftLetter = false;
            }
            else if (e.Key == Key.D )
            {
                
                goRightLetter = false;
            }
            else if (e.Key == Key.W )
            {
                
                goUpLetter = false;
            }
            else if (e.Key == Key.S )
            {
                
                goDownLetter = false;
            }
        }

        private void StopMovingArrowKey(KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
                
            }
            else if (e.Key == Key.Right)
            {
                goRight = false;
                
            }
            else if (e.Key == Key.Up)
            {
                goUp = false;
               
            }
            else if (e.Key == Key.Down)
            {
                goDown = false;
                
            }
        }

        private void HandleArrowKey(KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = true;

            }
            else if (e.Key == Key.Right)
            {
                goRight = true;

            }
            else if(e.Key == Key.Up)
            {
                goUp = true;

            }
            else if(e.Key == Key.Down)
            {
                goDown = true;

            }
        }
        private void HandleWASDKey(KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {

                goLeftLetter = true;
            }
            else if (e.Key == Key.D)
            {

                goRightLetter = true;
            }
            else if (e.Key == Key.W)
            {

                goUpLetter = true;
            }
            else if (e.Key == Key.S)
            {

                goDownLetter = true;
            }
        }



    }
}