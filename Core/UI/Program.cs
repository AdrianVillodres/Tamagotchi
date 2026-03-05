using Tamagotchi.Core.Models;

namespace Tamagotchi.Core.UI
{
    public class Program
    {
        public static void Main()
        {
            Stats stats = new Stats(100, 100, 0);
            Cat taiga = new Cat("Taiga", Emotions.Happy, stats);
            Food healthyBar = new Food("HealthyBar", TypeFood.Snack);
            Food animalFood = new Food("AnimalFood", TypeFood.Meal);
            Item healtyBar = new Item("HealtyBar", healthyBar);
            Item animalFoodI = new Item("AnimalFood", animalFood);
            Player player = new Player(taiga);


            UIConfig.Draw(taiga);
        }
    }
}
