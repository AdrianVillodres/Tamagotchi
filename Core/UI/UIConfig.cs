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
        const string Key_MSG = "Press a key to continue";
        const string NoMeal_MSG = "No meal available in inventory!";
        const string NoSnack_MSG = "No snack available in inventory!";
        const string ItemGive_MSG = "{0} given to pet!";
        const string Play_MSG = "{0} plays with you!";
        const string Angry_MSG = "{0} is angry and bites you";
        const string Sleep_MSG = "{0} is tired and falls asleep";
        const string Sad_MSG = "{0} is sad and doesn't want to play";
        const string Sick_MSG = "You need to vaccinate {0}";
        const string Vaccinate_MSG = "You want to vaccinate {0}?";
        const string Ignore_MSG = "{0}, is ignoring you";
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

        public static void OptionSelection(int op, Player player, Item meal, Item snack)
        {
            switch (op)
            {
                case 1:
                    Eat(player);
                    return;
                case 2:
                    Sleep(player);
                    return;
                case 3:
                    Play(player, meal, snack);
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
                    for (int j = 0; j < player.Inventory.items.Length; j++)
                    {
                        Item item = player.Inventory.items[j];
                        if (item != null && item.Type.TypeFood == TypeFood.Meal)
                        {
                            player.Pet.Eat(item);
                            player.Inventory.items[j] = null;
                            player.Pet.SnackCount = 0;
                            Console.WriteLine(ItemGive_MSG, item.Name);
                            foundMeal = true;
                            break;
                        }
                    }

                    if (!foundMeal)
                        Console.WriteLine(NoMeal_MSG);
                    break;

                case 2:
                    bool foundSnack = false;
                    int i = 0;

                    while (i < player.Inventory.items.Length && !foundSnack)
                    {
                        Item item = player.Inventory.items[i];

                        if (item != null && item.Type.TypeFood == TypeFood.Snack)
                        {
                            player.Pet.Eat(item);
                            player.Pet.SnackCount += 1;

                            if (player.Pet.SnackCount <= 3)
                                player.Pet.Emotion = Emotions.Happy;
                            else
                                player.Pet.Emotion = Emotions.Sick;

                            player.Inventory.items[i] = null;
                            Console.WriteLine(ItemGive_MSG, item.Name);
                            foundSnack = true;
                        }

                        i++;
                    }

                    if (!foundSnack)
                        Console.WriteLine(NoSnack_MSG);
                    break;

                default:
                    Console.WriteLine(Option_ErrorMSG, MinEatValue, MaxEatValue);
                    break;
            }

            Console.WriteLine(Key_MSG); // <-- I searched how to do this due to the screen cleaning when it returns to the menu, wich in fact, is a cleaner way to do the menu
            Console.ReadKey();
        }

        public static void Sleep(Player player)
        {
            player.Pet.Sleep();
        }

        public static void Play(Player player, Item meal, Item snack)
        {
            Random rand = new Random();
            int op;
            if(player.Pet.Emotion == Emotions.Happy)
            {
                op = rand.Next(1, 3);
                Console.WriteLine(Play_MSG, player.Pet.Name);
                player.Pet.Play();
                if(op == 1)
                {
                    player.InventoryAdd(meal);
                }
                else
                {
                    player.InventoryAdd(snack);
                }
                    Console.WriteLine(Key_MSG);
                Console.ReadKey();
            }
            else if (player.Pet.Emotion == Emotions.Angry)
            {
                op = rand.Next(1, 3);
                if(op == 1)
                {
                    Console.WriteLine(Angry_MSG, player.Pet.Name);             
                }
                else
                {
                    Console.WriteLine(Ignore_MSG, player.Pet.Name);
                }
                Console.WriteLine(Key_MSG);
                Console.ReadKey();
            }
            else if(player.Pet.Emotion == Emotions.Sad)
            {
                op = rand.Next(1, 3);
                if (op == 1)
                {
                    Console.WriteLine(Sad_MSG, player.Pet.Name);
                }
                else
                {
                    op = rand.Next(1, 3);
                    Console.WriteLine(Play_MSG, player.Pet.Name);
                    player.Pet.Play();
                    if (op == 1)
                    {
                        player.InventoryAdd(meal);
                    }
                    else
                    {
                        player.InventoryAdd(snack);
                    }
                }
                Console.WriteLine(Key_MSG);
                Console.ReadKey();
            }
            else if(player.Pet.Emotion == Emotions.Tired)
            {
                Console.WriteLine(Sleep_MSG, player.Pet.Name);
                player.Pet.Sleep();
            }
            else if (player.Pet.Emotion == Emotions.Sick)
            {
                Console.WriteLine(Sick_MSG, player.Pet.Name);
            }

        }
    }


}