using Tamagotchi.Core.Models;

namespace Tamagotchi.Core.UI
{
    public class Program
    {
        public static void Main()
        {
            Stats stat = new Stats(100, 100, 100);
            Cat taiga = new Cat("Taiga", Emotions.happy, stat);
            Food healthyBar = new Food("HealthyBar", Types.Snack);
            Food animalFood = new Food("AnimalFood", Types.Meal);
            Item healtyBarI = new Item("HealtyBar", healthyBar);
            Item animalFoodI = new Item("AnimalFood", animalFood);
            Inventory inventory = new Inventory([]);
            Player player = new Player(inventory, taiga);


        }
    }
}
