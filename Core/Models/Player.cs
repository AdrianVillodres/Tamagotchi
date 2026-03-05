using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Player
    {
        public Inventory Inventory { get; }
        public APet Pet { get; set; }

        public Player(APet pet)
        {
            this.Pet = pet;
            Inventory = new Inventory();
        }

        void InventoryAdd()
        {

        }

        void InventoryUse()
        {

        }

        void InventoryDelete()
        {

        }


    }
}
