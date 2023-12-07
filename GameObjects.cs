using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace BallarAvStalTest
{
    public class GameObjects
    {
        //public Vector2 Position {  get; set; }
        //public Shape Shape { get; set; }

        //public void Move(Vector2 direction, float speed)
        //{
        //        Canvas.SetLeft(Shape, Position.X);
        //        Canvas.SetTop(Shape, Position.Y);

        //    Position += direction * speed;
        //}

        public List<UIElement> gameObjectsList = new List<UIElement>();

        public List<UIElement> GetGameObjects()
        {
            return gameObjectsList;   
        }

        public void CreateRectangle(Canvas gameCanvas, Vector2 position, Vector2 size)
        {
            Rectangle rectangle = new Rectangle()
            {
                Width = size.X,
                Height = size.Y,
                Fill = Brushes.DarkBlue
            };

            Canvas.SetLeft(rectangle, position.X);
            Canvas.SetTop(rectangle, position.Y);

            gameCanvas.Children.Add(rectangle);
            gameObjectsList.Add(rectangle);
        }

        public void CreateEllipse(Canvas gameCanvas, Vector2 position, Vector2 size)
        {
            Ellipse ellipse = new Ellipse()
            {
                Width = size.X,
                Height = size.Y,
                Fill = Brushes.DarkOrange
            };

            Canvas.SetLeft(ellipse, position.X);
            Canvas.SetTop(ellipse, position.Y);

            gameCanvas.Children.Add(ellipse);
            gameObjectsList.Add(ellipse);
        }

        public void CreatePolygon(Canvas gameCanvas, Vector2 position, Vector2 size)
        {
            Polygon polygon = new Polygon()
            {
                Fill = Brushes.DarkGoldenrod,
                Points = new PointCollection()
                {
                    new System.Windows.Point(position.X, position.Y),
                    new System.Windows.Point(position.X + size.X, position.Y + size.Y),
                    new System.Windows.Point(position.X + size.X / 6, position.Y + size.Y)
                }
            };

            Canvas.SetLeft(polygon, position.X);
            Canvas.SetTop(polygon, position.Y);

            gameCanvas.Children.Add(polygon);
            gameObjectsList.Add(polygon);
        }

        //public void CreateRectangle(Canvas gameCanvas, Vector2 position, Vector2 size)
        //{
        //    Rectangle rectangle = new Rectangle();
        //    Position = position;
        //    rectangle.Width = size.X;
        //    rectangle.Height = size.Y;
        //    Canvas.SetLeft(rectangle, Position.X);
        //    Canvas.SetTop(rectangle, Position.Y);
        //    gameCanvas.Children.Add(rectangle);
        //    shapesList.Add(rectangle);
        //}

        //public void CreateEllipse(Canvas gameCanvas, Vector2 position, Vector2 size)
        //{
        //    Ellipse ellipse = new Ellipse();
        //    Position = position;
        //    ellipse.Width = size.X;
        //    ellipse.Height = size.Y;
        //    Canvas.SetLeft(ellipse, Position.X);
        //    Canvas.SetTop(ellipse, Position.Y);
        //    gameCanvas.Children.Add(ellipse);
        //    shapesList.Add(ellipse);
        //}

        //public void CreatePolygon(Canvas gameCanvas, Vector2 position, Vector2 size)
        //{
        //    Polygon polygon = new Polygon();
        //    Position = position;
        //    polygon.Width = size.X;
        //    polygon.Height = size.Y;
        //    Canvas.SetLeft(polygon, Position.X);
        //    Canvas.SetTop(polygon, Position.Y);
        //    gameCanvas.Children.Add(polygon);
        //    shapesList.Add(polygon);
        //}
    }
}
