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
        public int Health { get; set; }

        public Stats(int starve, int energy, int health)
        {
            Energy = energy;
            Starve = starve;
            Health = (energy + starve) / 2;
        }
    }
}
