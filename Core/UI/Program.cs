using Tamagotchi.Core.Models;

namespace Tamagotchi.Core.UI
{
    public class Program
    {
        public static void Main()
        {
            Stats stats = new Stats(50, 50);
            Cat taiga = new Cat("Taiga", stats);
            Food healthyBar = new Food("HealthyBar", TypeFood.Snack);
            Food animalFood = new Food("AnimalFood", TypeFood.Meal);
            Item healtyBar = new Item("HealtyBar", healthyBar);
            Item animalFoodI = new Item("AnimalFood", animalFood);
            Player player = new Player(taiga);
            int op = 0;
            player.Inventory.items[0] = healtyBar;
            player.Inventory.items[1] = healtyBar;
            player.Inventory.items[2] = healtyBar;
            player.Inventory.items[3] = animalFoodI;
            player.Inventory.items[4] = animalFoodI;
            while (op != 4)
            {
                UIConfig.Draw(taiga);
                op = UIConfig.ShowMenu();
                UIConfig.OptionSelection(op, player);
            }
            
        }
    }
}
