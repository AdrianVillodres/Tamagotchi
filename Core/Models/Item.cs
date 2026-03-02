using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Item
    {
        private string name { get; }
        private Food type { get;  }

        public Item(string name, Food type)
        {
            this.name = name;
            this.type = type;
        }
    }
}
