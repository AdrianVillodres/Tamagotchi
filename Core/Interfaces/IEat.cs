using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Core.Models;

namespace Tamagotchi.Core.Interfaces
{
    public interface IEat
    {
        void Eat(Item item);
    }
}
