using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Hal : Allat, IUszo
    {
        public override void HangotAd()
        {
            Console.WriteLine("Buborék...");
        }

        public void Uszik()
        {
            Console.WriteLine("A hal úszik a vízben.");
        }
    }

}
