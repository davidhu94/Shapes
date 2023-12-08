using System.IO;

namespace BallarAvStal
{
    public class FileManager
    {
        Player player;

        public FileManager(Player player)
        {
            this.player = player;
        }

        public void SaveToCsv(string playerName, string selectedShape, int highScore)
        {
            string filePath = "players.csv";

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "PlayerName,SelectedShape,HighScore\n");
            }

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{playerName},{selectedShape},{highScore}");
            }
        }




        ////CSV hantering som fanns i "NewGame" klassen

        //private void PlayButton_Click(object sender, RoutedEventArgs e)
        //{

        //    if (SelectShape.SelectedItem != null && !string.IsNullOrEmpty(NameTextBox.Text))
        //    {
        //        ComboBoxItem selectedItem = (ComboBoxItem)SelectShape.SelectedItem;
        //        string selectedShape = selectedItem.Content.ToString();

        //        //int highScore = mainWindow.GetIncrement();

        //        Player player = new Player
        //        {
        //            PlayerName = NameTextBox.Text,
        //            SelectedShape = selectedShape,
        //            //HighScore = highScore
        //        };
        //        User user = new User(player);

        //        user.SaveToCsv(player.PlayerName, player.SelectedShape, player.HighScore);

        //        GameWindow gameWindow = new GameWindow(player);
        //        gameWindow.Show();
        //        this.Hide();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Enter your name and select a shape to begin.");
        //    }
        //}
    }
}
