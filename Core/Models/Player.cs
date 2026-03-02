using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Player
    {
        private Inventory inventory { get; }
        private APet pet { get; set; }

        public Player(Inventory inventory, APet pet)
        {
            this.pet = pet;
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
