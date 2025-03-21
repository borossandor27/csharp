using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    class Kutya:Allat
    {
        // Kutya: nem repül, de hangot ad
        public override void HangotAd()
        {
            Console.WriteLine("Vau-vau!");
        }
    }
}
