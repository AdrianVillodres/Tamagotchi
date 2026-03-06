using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Core.Models;

namespace Tamagotchi.Core.UI
{
    static class UIConfig
    {
        const string Option_ErrorMSG = "Error, must be a natural number between {0} and {1}";
        const string Exit_MSG = "Bye, exiting game...";
        const string Eat_MSG = "Waht do you want to feed the pet?: 1-Meal, 2-Snack";
        const int MinMenuValue = 1;
        const int MaxMenuValue = 4;
        const int MinEatValue = 1;
        const int MaxEatValue = 2;

        public static void Draw(Cat cat)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Clear();

            Console.WriteLine("╔════════════════════════════════╗");
            Console.WriteLine("║          TAMAGOTCHI            ║");
            Console.WriteLine($"║    DateOfBirth: {new DateTime(1987, 01, 15):dd/MM/yyyy}     ║");
            Console.WriteLine($"║\t   Type: Cat             ║");
            Console.WriteLine("╚════════════════════════════════╝");

            Console.WriteLine(GetPetArt(cat.Emotion));

            Console.WriteLine($"Name: {cat.Name} ");
            Console.WriteLine($"Emotional State:{cat.Emotion.ToString()}  \n");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Hunger:{DrawBar(cat.Stats.Starve)}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Energy:{DrawBar(cat.Stats.Energy)}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Health:{DrawBar(cat.Stats.Health)}");
            Console.ResetColor();
        }
        private static string DrawBar(int value)
        {
            int totalBlocks = 20;
            int filledBlocks = value * totalBlocks / 100;

            return "[" +
                   new string('#', filledBlocks) +
                   new string('-', totalBlocks - filledBlocks) +
                   $"] {value}%";
        }
        /*Must be adapt to Enum list*/
        public static string GetPetArt(Emotions state)
        {
            return state switch
            {
                Emotions.Happy => @"
      /\_/\      
     ( ^‿^ )     
     /       \    
    |         |   
     \__/\___/    
",

                Emotions.Sad => @"
      /\_/\      
     ( ╥﹏╥ )     
     /       \    
    |         |   
     \__/\___/    
",

                Emotions.Angry => @"
      /\_/\      
     ( ಠ_ಠ )     
     /       \    
    |         |   
     \__/\___/    
",

                Emotions.Tired => @"
      /\_/\      
     ( -_- ) zZ  
     /       \    
    |         |   
     \__/\___/    
",

                Emotions.Sick => @"
      /\_/\      
     ( x_x )     
     /       \    
    |   +--+     |   
     \__/\___/    
",

                _ => ""
            };
        }

        public static bool ValidateNumber(int op, int minValue, int maxValue)
        {
            return op >= minValue && op <= maxValue;
        }

        public static int ShowMenu()
        {
            int option = 0;
            bool validInput = false;

            do
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("1 - Eat");
                Console.WriteLine("2 - Sleep");
                Console.WriteLine("3 - Play");
                Console.WriteLine("4 - Exit");
                Console.Write("\nSelect an option(1-4): ");

                try
                {
                    option = int.Parse(Console.ReadLine());

                    if (ValidateNumber(option, MinMenuValue, MaxMenuValue))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine(Option_ErrorMSG, MinMenuValue, MaxMenuValue);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(Option_ErrorMSG, MinMenuValue, MaxMenuValue);
                }
                catch (OverflowException)
                {
                    Console.WriteLine(Option_ErrorMSG, MinMenuValue, MaxMenuValue);
                }

            } while (!validInput);

            return option;
        }

        public static void OptionSelection(int op, Player player)
        {
            switch (op)
            {
                case 1:
                    Eat(player);
                    return;
                case 2:
                    //Sleep
                    return;
                case 3:
                    //Play
                    return;
                case 4:
                    Console.WriteLine(Exit_MSG);
                    return;
            }
        }

        public static void Eat(Player player)
        {
            int option = 0;
            bool validInput = false;
            do
            {
                Console.WriteLine(Eat_MSG);
                try
                {
                    option = int.Parse(Console.ReadLine());

                    if (ValidateNumber(option, MinEatValue, MaxEatValue))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine(Option_ErrorMSG, MinEatValue, MaxEatValue);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(Option_ErrorMSG, MinEatValue, MaxEatValue);
                }
                catch (OverflowException)
                {
                    Console.WriteLine(Option_ErrorMSG, MinEatValue, MaxEatValue);
                }

            } while (!validInput);

            switch (option)
            {
                case 1: 
                    bool foundMeal = false;
                    for (int i = 0; i < player.Inventory.items.Length; i++)
                    {
                        Item item = player.Inventory.items[i];
                        if (item != null && item.Type.TypeFood == TypeFood.Meal)
                        {
                            player.Pet.Eat(item);
                            player.Inventory.items[i] = null;
                            player.Pet.SnackCount = 0;
                            Console.WriteLine($"{item.Name} given to pet!");
                            foundMeal = true;
                            break;
                        }
                    }
                    if (!foundMeal)
                        Console.WriteLine("No Meal available in inventory!");
                    return;

                case 2: 
                    bool foundSnack = false;
                    for (int i = 0; i < player.Inventory.items.Length; i++)
                    {
                        Item item = player.Inventory.items[i];
                        if (item != null && item.Type.TypeFood == TypeFood.Snack)
                        {
                            player.Pet.Eat(item);
                            player.Pet.SnackCount += 1;
                            if(player.Pet.SnackCount <= 3)
                            {
                                player.Pet.Emotion = Emotions.Happy;
                            }
                            else
                            {
                                player.Pet.Emotion = Emotions.Sick;
                            }
                            player.Inventory.items[i] = null;
                            Console.WriteLine($"{item.Name} given to pet!");
                            foundSnack = true;
                            break;
                        }
                    }
                    if (!foundSnack)
                        Console.WriteLine("No Snack available in inventory!");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }
        }
    }


}