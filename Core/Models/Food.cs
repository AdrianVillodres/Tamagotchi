using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core.Models
{
    public class Food
    {
        public string Name { get; }
        public TypeFood TypeFood { get; }


        public Food(string name, TypeFood type)
        {
            this.Name = name;
            this.TypeFood = type;
        }
    }
}
