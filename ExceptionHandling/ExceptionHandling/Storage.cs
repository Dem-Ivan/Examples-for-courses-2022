using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{  
    public class Storage
    {
        public readonly List<Player> players = new List<Player>();

        public void AddClient(Player player)
        {
            //if (player.Name == null)//3
            //{
            //    throw new ArgumentNullException("Имя игрока обязательно для заполнения");
            //}

            if (player.Number == 0)
            {
                throw new NumberRestrictionException("Номер игрока обязательен для заполнения");
            }

            players.Add(player);
        }
    }
}
