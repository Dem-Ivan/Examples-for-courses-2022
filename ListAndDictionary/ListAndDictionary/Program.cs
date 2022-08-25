using System;
using System.Collections.Generic;
using System.Linq;

namespace ListAndDictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1) List_______________
            var playersList = GetPlayersList();

            var zerroPlayer = playersList.FirstOrDefault(p => p.Number == 0);
            var notZerroPlayers = playersList.Where(p => p.Number != 0).ToList();

            var player = new Player
            {
                Number = 10,
                Name = "Oleg"
            };

            playersList.Add(player);

            player.Name = "Semen";

            playersList.Remove(player);

            // 2) Dictionary________
            var playersDyctionar = GetPlayersDyctionar();

            var playersCount = playersDyctionar.Count;

            var secondPlayer = playersDyctionar[1];

            playersDyctionar.Add(10, player);

            player.Name = "Marina";

            playersDyctionar.Remove(10);           
        }

        public static List<Player> GetPlayersList()
        {
            var players = new List<Player>();

            for (int i = 0; i < 10; i++)
            {
                players.Add(new Player
                {
                    Name = "Name_" + i,
                    Number = i
                });
            }

            return players;
        }

        public static Dictionary<int, Player> GetPlayersDyctionar()
        {
            var players = new Dictionary<int, Player>();

            for (int i = 0; i < 10; i++)
            {
                players.Add( 
                i,
                new Player
                {
                    Name = "Name_" + i,
                    Number = i
                });
            }

            return players;
        }
    }   
}
