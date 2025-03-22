using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Denever : Allat, IRepulo
    {
        public override void HangotAd()
        {
            Console.WriteLine("Csipogás!");
        }

        public void Repul()
        {
            Console.WriteLine("A denevér suhan a levegőben.");
        }
    }

}
