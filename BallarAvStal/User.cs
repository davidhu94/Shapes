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
        public User()
        {

        }
        public Player GetPlayerByName(string playerName)
        {
            List<Player> players = LoadFromCsv();
            return players.FirstOrDefault(p => p.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase));
        }

        public void SaveToCsv(string playerName, string selectedShape, int highScore)
        {
            string filePath = "players.csv";

            List<Player> players = LoadFromCsv();


            Player existingPlayer = players.FirstOrDefault(p => p.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase));

            if (existingPlayer != null)
            {
                existingPlayer.SelectedShape = selectedShape;
                existingPlayer.PlayerName = playerName;
            }
            else
            {
                players.Add(new Player
                {
                    PlayerName = playerName,
                    SelectedShape = selectedShape,
                    HighScore = highScore
                });
            }

            WritePlayersToCsv(filePath, players);


        }
        public void WritePlayersToCsv(string filePath, List<Player> players)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine("PlayerName,SelectedShape,HighScore");
                foreach (Player player in players)
                {
                    sw.WriteLine($"{player.PlayerName},{player.SelectedShape},{player.HighScore}");
                }
            }
        }



        public List<Player> LoadFromCsv()
        {
            List<Player> players = new List<Player>();
            string filePath = "players.csv";

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] fields = line.Split(',');

                        if (fields.Length == 3)
                        {
                            Player player = new Player()
                            {
                                PlayerName = fields[0],
                                SelectedShape = fields[1],
                                HighScore = int.Parse(fields[2])
                            };

                            players.Add(player);
                        }
                    }
                }
            }
            return players;
        }
        public void RemovePlayerFromCsv(string playerName)
        {
            string filePath = "players.csv";

            List<Player> players = LoadFromCsv();
            Player playerToRemove = players.FirstOrDefault(p => p.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase));

            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);


                WritePlayersToCsv(filePath, players);
            }
        }
    }
}
