using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    class Madar:Allat, IRepulo
    {
        // Madár: repül és csiripel
        public override void HangotAd()
        {
            Console.WriteLine("Csirip-csirip!");
        }

        public void Repul()
        {
            Console.WriteLine("A madár repül.");
        }
    }
}
