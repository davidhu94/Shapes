using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace BallarAvStal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private DispatcherTimer gameLoopTimer;

        private PlayerControl playerControl;

        private RandomBall randomBall;

        private Player player;

        private User user;

        private int gameLoopTicks = 0;

        private int secondsPassed = 0;

        public GameWindow(Player player)
        {
            InitializeComponent();
            GameCanvas.Focus();

            this.player = player;

            Shape playerShape = player.GetPlayerShape();
            GameCanvas.Children.Add(playerShape);
            Canvas.SetLeft(playerShape, 56);
            Canvas.SetTop(playerShape, 200);

            playerControl = new PlayerControl(GameCanvas, playerShape);
            this.KeyDown += OnKeyDown;
            this.KeyUp += OnKeyUp;

            gameLoopTimer = new DispatcherTimer();
            gameLoopTimer.Tick += GameLoopTimer_Tick;
            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(20); 
            gameLoopTimer.Start();

            randomBall = new RandomBall(GameCanvas);

        }

        //Main loop of the game
        //Clock ticks 50 ticks * 20 ms = 1000 ms (1 second)
        private void GameLoopTimer_Tick(object sender, EventArgs e)
        {
            playerControl.MovePlayer();

            gameLoopTicks++;
            if (gameLoopTicks >= 50) 
            {
                UpdateTime();
                gameLoopTicks = 0;
            }

            randomBall.MoveRandomBall();

            if (randomBall.CheckForCollision(playerControl.PlayerShape))
            {
                GameOver();
            } 
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //Update player movement based on pressed keys
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    playerControl.GoLeft = true; 
                    break;
                case Key.D: 
                    playerControl.GoRight = true; 
                    break;
                case Key.W: 
                    playerControl.GoUp = true; 
                    break;
                case Key.S: 
                    playerControl.GoDown = true; 
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    playerControl.GoLeft = false; 
                    break;
                case Key.D: 
                    playerControl.GoRight = false; 
                    break;
                case Key.W: 
                    playerControl.GoUp = false; 
                    break;
                case Key.S: 
                    playerControl.GoDown = false; 
                    break;
            }
        }

        //Uppdate the clock by adding 1 second
        private void UpdateTime()
        {
            secondsPassed++;
            timeLbl.Content = secondsPassed.ToString(); 
        }

        private int UpdateHighScore()
        {
            int newHighScore = 0;

            player.HighScore = newHighScore + secondsPassed;

            return player.HighScore;
        }

        public void GameOver()
        {
            UpdateHighScore();
            //user.WritePlayersToCsv();

            randomBall.ballCreationTimer.Stop();

            gameLoopTimer.Stop();

            MessageBoxResult result = MessageBox.Show("Game Over! Play again?", "Game Over", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                RestartGame();
            }
            else
            {
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }

        public void RestartGame()
        {
            playerControl.PlayerShape.Visibility = Visibility.Visible;
            Canvas.SetLeft(playerControl.PlayerShape, 56);
            Canvas.SetTop(playerControl.PlayerShape, 200);

            secondsPassed = 0;
            UpdateTime();

            gameLoopTimer.Start();
            randomBall.ResetBalls();
            randomBall.ballCreationTimer.Start();
        }
    }
}