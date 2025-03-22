using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Task
{
    class Program
    {
        static int lepesekSzama = 5;
        static int varakozasElso = 1000;
        static int varakozasMasodik = 600;
        // Eredeti szín mentése
        static ConsoleColor eredetiSzin = Console.ForegroundColor;
        static ConsoleColor elsoSzalSzine = ConsoleColor.Yellow;
        static ConsoleColor masodikSzalSzine = ConsoleColor.Magenta;
        static void Main(string[] args)
        {
            Console.WriteLine("Szálak indítása");
            //-- létrehozunk egy új szálat és elindítjuk
            Thread thread= new Thread(Szamolgato);
            thread.Start();
            //-- Folytatódik a fő szál
                        for (int i = 0; i < lepesekSzama; i++)
            {
                // Szál színének beállítása
                Console.ForegroundColor = elsoSzalSzine;
                Console.WriteLine($"Első szál: {i}",elsoSzalSzine);
                Thread.Sleep(varakozasElso);
            }
            //-- fő szál vége
            Console.ForegroundColor = eredetiSzin;
            Console.WriteLine("Az első szál befejezte a futását");
            //-- Várakoztatjuk a fő szálat, hogy a második szál befejezze a futását
            thread.Join();
            Console.WriteLine("Mindkét szál befejezte a futását");
            Console.WriteLine("\n\nProgram vége!");
            Console.ReadLine();
        }

        private static void Szamolgato()
        {
            for (int i = 0; i < lepesekSzama; i++)
            {
                Console.ForegroundColor = masodikSzalSzine;

                Console.WriteLine($"Második szál: {i}");
                Thread.Sleep(varakozasMasodik);
            }
            Console.ForegroundColor = eredetiSzin;
            Console.WriteLine("A második szál befejezte a futását");
        }
    }
}
