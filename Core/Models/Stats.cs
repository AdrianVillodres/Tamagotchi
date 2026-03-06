using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Stats
    {
        public int Starve { get; set; }
        public int Energy { get; set; }
        public int Health{ get { return (Energy + Starve) / 2; }
        }


        public Stats(int starve, int energy)
        {
            Energy = energy;
            Starve = starve;
        }
    }
}
