using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Food
    {
        private string name { get; }
        private Types type { get; }


        public Food(string name, Types type)
        {
            this.name = name;
            this.type = type;
        }
    }
}
