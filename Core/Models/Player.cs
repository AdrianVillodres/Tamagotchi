using System;

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

        public void InventoryAdd(Item item)
        {
            for (int i = 0; i < Inventory.items.Length; i++)
            {
                if (Inventory.items[i] == null)
                {
                    Inventory.items[i] = item;
                    Console.WriteLine($"{item.Name} added to inventory.");
                    return;
                }
            }
            Console.WriteLine("Inventory full!");
        }

        public void InventoryUse()
        {
            Console.WriteLine("Select item number to use:");
            int index;
            bool valid = false;

            do
            {
                try
                {
                    index = int.Parse(Console.ReadLine()) - 1;

                    if (index >= 0 && index < Inventory.items.Length && Inventory.items[index] != null)
                    {
                        Pet.Eat(Inventory.items[index]);
                        Console.WriteLine($"{Inventory.items[index].Name} used!");
                        Inventory.items[index] = null;
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option, try again.");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            } while (!valid);
        }

        public void InventoryDelete()
        {
            for (int i = 0; i < Inventory.items.Length; i++)
            {
                if (Inventory.items[i] != null)
                {
                    Console.WriteLine($"{Inventory.items[i].Name} deleted from inventory.");
                    Inventory.items[i] = null;
                    return;
                }
            }

            Console.WriteLine("No items to delete.");
        }
    }
}