using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Core.Interfaces;

namespace Tamagotchi.Core.Models
{
    public abstract class APet : IEat
    {
        public string Name { get; set; }
        public Emotions Emotion { get; }
        public Stats Stats { get; }

        protected APet(string name, Emotions emotion, Stats stats)
        {
            Name = name;
            Emotion = emotion;
            Stats = stats;
        }

        public void Eat(Item item)
        {
            Stats.Starve += (int)item.Type.TypeFood;
        }
    }
}
