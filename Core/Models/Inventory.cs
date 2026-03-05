using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Inventory
    {
        public Item[] items = new Item[5];

        public Inventory()
        {
           
        }
        public Inventory(Item[] items)
        {
            this.items = items;
        }

    }
}
