using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Item
    {
        public string Name { get; }
        public Food Type { get;  }

        public Item(string name, Food type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
