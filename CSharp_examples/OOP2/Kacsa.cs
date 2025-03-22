using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Kacsa : Allat, IRepulo, IUszo
    {
        public override void HangotAd()
        {
            Console.WriteLine("Háp-háp!");
        }

        public void Repul()
        {
            Console.WriteLine("A kacsa tovarepül.");
        }

        public void Uszik()
        {
            Console.WriteLine("A kacsa lebeg a tavon.");
        }
    }

}
