﻿using System.Text;
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
using System.Collections.Generic;



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

        DispatcherTimer timerTick = new DispatcherTimer();


        private RandomBall randomBall;

        private Player player;

        //public int HighScore => increment;

        //public MainWindow()
        //{
        //    InitializeComponent();
        //    GameCanvas.Focus();

        //    gameTimer.Tick += GameTimerEvent;
        //    gameTimer.Interval = TimeSpan.FromMilliseconds(20);
        //    gameTimer.Start();

        //    //RANDOM BALLS instans
        //    randomBall = new RandomBall(GameCanvas);
        //}

        //Konstruktor för att hämta player, gick ej att lägga parametrarna i den andra konstruktorn
        public MainWindow(Player player)
        {
            InitializeComponent();
            GameCanvas.Focus();

            this.player = player;

            player.HighScore = 0;

            Shape playerShape = player.GetPlayerShape();
            GameCanvas.Children.Add(playerShape);
            //Ställ in starpositioner:

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();

            //RANDOM BALLS instans
            randomBall = new RandomBall(GameCanvas);
        }
        

        private int increment = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += dtTick;
            gameTimer.Start();
        }

        public void dtTick(object sender, EventArgs e)
        {
            increment++;
            timeLbl.Content = increment.ToString();


            player.HighScore++;


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

            //if (goLeft == true && Canvas.GetLeft(playerBall) > 5)
            //{
            //    Canvas.SetLeft(playerBall, Canvas.GetLeft(playerBall) - playerSpeed);
            //}
            //if (goRight == true && Canvas.GetLeft(playerBall) + (playerBall.Width + 20) < Application.Current.MainWindow.Width)
            //{
            //    Canvas.SetLeft(playerBall, Canvas.GetLeft(playerBall) + playerSpeed);
            //}
            //if (goUp == true && Canvas.GetTop(playerBall) > 5)
            //{
            //    Canvas.SetTop(playerBall, Canvas.GetTop(playerBall) - playerSpeed);
            //}
            //if (goDown == true && Canvas.GetTop(playerBall) + (playerBall.Height + 40) < Application.Current.MainWindow.Height)
            //{
            //    Canvas.SetTop(playerBall, Canvas.GetTop(playerBall) + playerSpeed);
            //}

            ////WASD

            //if (goLeftLetter == true && Canvas.GetLeft(playerRectangle) > 5)
            //{
            //    Canvas.SetLeft(playerRectangle, Canvas.GetLeft(playerRectangle) - playerSpeed);
            //}
            //if (goRightLetter == true && Canvas.GetLeft(playerRectangle) + (playerRectangle.Width + 20) < Application.Current.MainWindow.Width)
            //{
            //    Canvas.SetLeft(playerRectangle, Canvas.GetLeft(playerRectangle) + playerSpeed);
            //}
            //if (goUpLetter == true && Canvas.GetTop(playerRectangle) > 5)
            //{
            //    Canvas.SetTop(playerRectangle, Canvas.GetTop(playerRectangle) - playerSpeed);
            //}
            //if (goDownLetter == true && Canvas.GetTop(playerRectangle) + (playerRectangle.Height + 40) < Application.Current.MainWindow.Height)
            //{
            //    Canvas.SetTop(playerRectangle, Canvas.GetTop(playerRectangle) + playerSpeed);
            //}


            //Gå utanför skärmen och komma till andra sidan.
            
            if (goLeftLetter == true)
            {
                Canvas.SetLeft(playerRectangle, Canvas.GetLeft(playerRectangle) - playerSpeed);
            }
            if (goRightLetter == true)
            {
                Canvas.SetLeft(playerRectangle, Canvas.GetLeft(playerRectangle) + playerSpeed);
            }
            if (goUpLetter == true)
            {
                Canvas.SetTop(playerRectangle, Canvas.GetTop(playerRectangle) - playerSpeed);
            }
            if (goDownLetter == true)
            {
                Canvas.SetTop(playerRectangle, Canvas.GetTop(playerRectangle) + playerSpeed);
            }

            
            if (Canvas.GetLeft(playerRectangle) > Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(playerRectangle, -playerRectangle.ActualWidth);
            }
            else if (Canvas.GetLeft(playerRectangle) + playerRectangle.ActualWidth < 0)
            {
                Canvas.SetLeft(playerRectangle, Application.Current.MainWindow.Width);
            }

            if (Canvas.GetTop(playerRectangle) > Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(playerRectangle, -playerRectangle.ActualHeight);
            }
            else if (Canvas.GetTop(playerRectangle) + playerRectangle.ActualHeight < 0)
            {
                Canvas.SetTop(playerRectangle, Application.Current.MainWindow.Height);
            }





            //RANDOM BALLS
            randomBall.CreateRandomBall();
            randomBall.MoveRandomBall();

            //Krock med bollar avslutar spelet
            if (randomBall.CheckForCollision(new Rect (Canvas.GetLeft(playerRectangle), Canvas.GetTop(playerRectangle), playerRectangle.Width, playerRectangle.Height)))
            {
                randomBall.GameOver();
                gameTimer.Stop();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
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