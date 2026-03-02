using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Cat : APet
    {
        public Cat (string name, Emotions emotion, Stats stats) : base(name, emotion, stats)
        {

        }
    }
}
