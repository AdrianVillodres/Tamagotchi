using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    abstract public class APet
    {
        private string Name { get; set; }
        private Emotions Emotion { get; }
        private Stats Stats { get; }

        protected APet(string name, Emotions emotion, Stats stats)
        {
            Name = name;
            Emotion = emotion;
            Stats = stats;
        }
    }
}
