using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Core.Models;

namespace Tamagotchi.Core.UI
{
    static class UIConfig
    {
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
            Console.WriteLine($"Hunger:{DrawBar(20)}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Energy:{DrawBar(80)}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Health:{DrawBar(60)}");
            Console.ResetColor();

            ShowMenu();
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

        public static int ShowMenu()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("1 - Eat");
            Console.WriteLine("2 - Sleep");
            Console.WriteLine("3 - Play");
            Console.WriteLine("4 - Exit");
            Console.Write("\nSelect an option(1-4): ");

            int option = Int32.Parse(Console.ReadLine());

            while (!ValidateMenu(op))
            {
                
            }

            return option;
        }

        public static bool ValidateMenu(int op)
        {
            if (op < 1 || op > 4) return false;

            else return true;
        }
    }


}