using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Stats
    {
        int Starve { get; set; }
        int Energy { get; set; }
        int Health { get; set; }

        public Stats(int starve, int energy, int health)
        {

        }
    }
}
