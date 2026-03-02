using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Dog : APet
    {
        public Dog(string name, Emotions emotion, Stats stats) : base(name, emotion, stats)
        {

        }
    }
}
