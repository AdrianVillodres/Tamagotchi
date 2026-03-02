using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Stats
    {
        private int Starve { get; set; }
        private int Energy { get; set; }
        private int Health { get; set; }

        public Stats(int starve, int energy, int health)
        {
           Health = energy + starve / 2;
        }
    }
}
