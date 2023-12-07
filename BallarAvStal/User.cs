using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallarAvStal
{
    public class User
    {
        Player player;

        public User(Player player)
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
    }
}
