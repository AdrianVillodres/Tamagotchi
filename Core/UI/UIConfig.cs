using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.UI
{
    static class UIConfig
    {
        public static void Draw()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Clear();

            Console.WriteLine("╔════════════════════════════════╗");
            Console.WriteLine("║          TAMAGOTCHI            ║");
            Console.WriteLine($"║    DateOfBirth: {new DateTime(1987, 01, 15):dd/MM/yyyy}     ║");
            Console.WriteLine($"║\t   Type: Cat             ║");
            Console.WriteLine("╚════════════════════════════════╝");

            Console.WriteLine(GetPetArt("Happy"));

            Console.WriteLine("Name: Mametchi ");
            Console.WriteLine("Emotional State: Happy 😊 \n");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Hunger:{DrawBar(20)}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Energy:{DrawBar(80)}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Health:{DrawBar(60)}");
            Console.ResetColor();


            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("1 - Eat");
            Console.WriteLine("2 - Sleep");
            Console.WriteLine("3 - Play");
            Console.WriteLine("4 - Exit");
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
        public static string GetPetArt(string state)
        {
            return state switch
            {
                "Happy" => @"
      /\_/\      
     ( ^‿^ )     
     /       \    
    |         |   
     \__/\___/    
",

                "Sad" => @"
      /\_/\      
     ( ╥﹏╥ )     
     /       \    
    |         |   
     \__/\___/    
",

                "Angry" => @"
      /\_/\      
     ( ಠ_ಠ )     
     /       \    
    |         |   
     \__/\___/    
",

                "Tired" => @"
      /\_/\      
     ( -_- ) zZ  
     /       \    
    |         |   
     \__/\___/    
",

                "Sick" => @"
      /\_/\      
     ( x_x )     
     /       \    
    |   +--+     |   
     \__/\___/    
",

                _ => ""
            };
        }
    }

}
