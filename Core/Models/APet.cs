using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public abstract class APet
    {
        protected string Name { get; set; }
        protected Emotions Emotion { get; }
        protected Stats Stats { get; }

        protected APet(string name, Emotions emotion, Stats stats)
        {
            Name = name;
            Emotion = emotion;
            Stats = stats;
        }
    }
}
