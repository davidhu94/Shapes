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
        bool goLeft, goRight, goUp, goDown;
        int playerSpeed = 8;

        public MainWindow()
        {
            InitializeComponent();
            GameCanvas.Focus();

            
        }

        private void GameCanvas_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void GameCanvas_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }