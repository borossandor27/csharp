using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    abstract class Allat
    {
        public void Mozog()
        {
            Console.WriteLine("Az állat mozog.");
        }

        public void Eszik()
        {
            Console.WriteLine("Az állat eszik.");
        }

        public abstract void HangotAd();
    }

}
