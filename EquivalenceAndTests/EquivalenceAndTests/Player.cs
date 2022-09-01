using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquivalenceAndTests
{
    public class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }

/*
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Player))
                return false;

            var player = (Player)obj;

            return player.Name == Name &&
                   player.Number == Number;
        }

        public override int GetHashCode()
        {
            var resultHash = Name.GetHashCode() + Number.GetHashCode();

            return resultHash;
        }
*/
    }
}
