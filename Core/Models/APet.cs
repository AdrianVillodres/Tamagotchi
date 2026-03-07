using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Core.Interfaces;

namespace Tamagotchi.Core.Models
{
    public abstract class APet : IEat, IPlay, ISleep
    {
        const int StatsConsumed = 10;
        const int EnergyHealed = 10;
        public string Name { get; set; }
        public Emotions Emotion { get; set; }
        public Stats Stats { get; }

        public int SnackCount { get; set; }

        public bool needsVaccine { get; set; }

        protected APet(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
            SnackCount = 0;
            needsVaccine = false;
        }

        public void Eat(Item item)
        {
            Stats.Starve += (int)item.Type.TypeFood;
            UpdateEmotion();
        }

        public void Play()
        {
            Stats.Energy -= StatsConsumed;
            Stats.Starve -= StatsConsumed;
            Emotion = Emotions.Happy;
            UpdateEmotion();
        }

        public void Sleep()
        {
            Stats.Energy += EnergyHealed;
            UpdateEmotion();
        }
        private void UpdateEmotion()
        {
            if (Stats.Health <= 20)
            {
                Emotion = Emotions.Sick;
            }
            else if (Stats.Energy <= 30)
            {
                Emotion = Emotions.Tired;
            }
            else if (Stats.Starve <= 50)
            {
                Emotion = Emotions.Angry;
            }
            else
            {
                Emotion = Emotions.Happy;
            }
        }
    }
}
    

