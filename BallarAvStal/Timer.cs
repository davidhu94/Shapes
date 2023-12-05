//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;
//using System.Windows.Threading;
//using System.Windows.Controls;
//using System.Windows;

//namespace BallarAvStal
//{
//    public class Timer
//    {
//        MainWindow mainWindow;
//        private Canvas gameCanvas;
//        private DispatcherTimer timerTick = new DispatcherTimer();


//        public Timer(Canvas canvas)
//        {
//            this.gameCanvas = canvas;
//            timerTick.Interval = TimeSpan.FromSeconds(10);
//            timerTick.Tick += DispatcherTick;
//            timerTick.Start();


//        }

//        private int increment = 0;
//        public void DispatcherTick(object sender, RoutedEventArgs e)
//        {
//            increment++;
//            mainWindow.timeLbl.Content = increment.ToString();


//        }
//    }
