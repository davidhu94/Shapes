using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;




namespace BallarAvStal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer gameLoopTimer;

        private PlayerControl playerControl;

        private RandomBall randomBall;

        private Player player;

        private Timer timer;

        private int gameLoopTicks = 0;

        private int secondsPassed = 0;



        public MainWindow(Player player)
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

        private void GameLoopTimer_Tick(object sender, EventArgs e)
        {
            playerControl.MovePlayer();

            //Klockan som räknar och generera bollar
            gameLoopTicks++;
            if (gameLoopTicks >= 50) // 50 ticks * 20 ms = 1000 ms (1 sekund)
            {
                UpdateTime();
                gameLoopTicks = 0;
            }

            randomBall.CreateRandomBall();

            randomBall.MoveRandomBall();
            //kollision
            if (randomBall.CheckForCollision(playerControl.PlayerShape))
            {
                GameOver();
            }

            
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    playerControl.GoLeft = true; 
                    break;
                case Key.Right: 
                    playerControl.GoRight = true; 
                    break;
                case Key.Up: 
                    playerControl.GoUp = true; 
                    break;
                case Key.Down: 
                    playerControl.GoDown = true; 
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    playerControl.GoLeft = false; 
                    break;
                case Key.Right: 
                    playerControl.GoRight = false; 
                    break;
                case Key.Up: 
                    playerControl.GoUp = false; 
                    break;
                case Key.Down: 
                    playerControl.GoDown = false; 
                    break;
            }
        }

        private void UpdateTime()
        {
            secondsPassed++;
            timeLbl.Content = secondsPassed.ToString(); 
        }

        public void GameOver()
        {
            randomBall.ballCreationTimer.Stop();

            gameLoopTimer.Stop();

            MessageBoxResult result = MessageBox.Show("Game Over! Play again?", "Game Over", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                RestartGame();
            }
            else
            {
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }

        public void RestartGame()
        {
            Canvas.SetLeft(playerControl.PlayerShape, 56); 
            Canvas.SetTop(playerControl.PlayerShape, 200);

            randomBall.ResetBalls();

            gameLoopTimer.Start();
            randomBall.ballCreationTimer.Start(); 
        }
    }
}