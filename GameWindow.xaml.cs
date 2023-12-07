using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BallarAvStalTest
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private GameObjects gameObject;
        private PlayerControls playerControls;
        private DispatcherTimer gameLoopTimer;

        public GameWindow()
        {
            InitializeComponent();

            gameObject = new GameObjects();
            playerControls = new PlayerControls();

            this.KeyDown += GameWindow_KeyDown;
            this.KeyUp += GameWindow_KeyUp;

            gameLoopTimer = new DispatcherTimer();
            gameLoopTimer.Tick += GameLoopTimer_Tick;
            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameLoopTimer.Start();
        }

        private void GameLoopTimer_Tick(object sender, EventArgs e)
        {
            PlayerMovement();
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            PlayerControls(e.Key, true);
        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            PlayerControls(e.Key, false);
        }

        private void PlayerControls(Key key, bool isKeyDown)
        {
            switch (key)
            {
                case Key.Left:
                    playerControls.goLeft = isKeyDown; 
                    break;
                case Key.Right:
                    playerControls.goRight = isKeyDown;
                    break;
                case Key.Up:
                    playerControls.goUp = isKeyDown;
                    break;
                case Key.Down:
                    playerControls.goDown = isKeyDown;
                    break;
            }
        }

        private void PlayerMovement()
        {
            int speed = 10;
            int moveX = 0;
            int moveY = 0;

            if (playerControls.goLeft)
            {
                moveX -= speed;
            }
            if (playerControls.goRight)
            {
                moveX += speed;
            }
            if (playerControls.goUp)
            {
                moveY -= speed;
            }
            if (playerControls.goDown)
            {
                moveY += speed;
            }

            MoveGameObjects(moveX, moveY);
        }

        private void MoveGameObjects(int moveX, int moveY)
        {
            foreach (var gameObjects in gameObject.GetGameObjects())
            {
                double currentLeft = Canvas.GetLeft(gameObjects);
                double currentTop = Canvas.GetTop(gameObjects);

                Canvas.SetLeft(gameObjects, currentLeft + moveX);
                Canvas.SetTop(gameObjects, currentTop + moveY);
            }
        }

        public void HandleShapeSelection(string selectedShapeName)
        {
            if (selectedShapeName == "Rectangle")
            {
                gameObject.CreateRectangle(gameCanvas, new Vector2(100, 100), new Vector2(40, 40));
            }
            else if (selectedShapeName == "Ellipse")
            {
                gameObject.CreateEllipse(gameCanvas, new Vector2(100, 100), new Vector2(40, 40));
            }
            else if (selectedShapeName == "Polygon")
            {
                gameObject.CreatePolygon(gameCanvas, new Vector2(100, 100), new Vector2(40, 40));
            }
        }
    }
}
