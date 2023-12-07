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

namespace BallarAvStalTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class PlayWindow : Window
    {
        private GameWindow gameWindow;
        public PlayWindow()
        {
            InitializeComponent();

            gameWindow = new GameWindow();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.Show();
            this.Close();
        }

        private void selectShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gameWindow != null)
            {
                //Hämta vald Shape i Comboboxen.
                ComboBoxItem selectedShape = (ComboBoxItem)selectShapeComboBox.SelectedItem;

                //Hämta Shapens namn.
                string selectedShapeName = selectedShape.Content.ToString();

                gameWindow.HandleShapeSelection(selectedShapeName);
            }
        }
    }
}