using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Program
    {
        static ConsoleColor defaultColor = Console.ForegroundColor;
        static ConsoleColor allatSzin = ConsoleColor.Green;
        static void Main()
        {
            List<Allat> allatok = new List<Allat>
        {
            new Denever(),
            new Hal(),
            new Kacsa()
        };

            foreach (var allat in allatok)
            {
                Console.ForegroundColor = allatSzin;
                Console.WriteLine($"--- {allat.GetType().Name} ---");
                Console.ForegroundColor = defaultColor;
                allat.Mozog();
                allat.Eszik();
                allat.HangotAd();

                if (allat is IRepulo repulo)
                {
                    repulo.Repul();
                }

                if (allat is IUszo uszo)
                {
                    uszo.Uszik();
                }

                Console.WriteLine();
            }
        }
    }

}
