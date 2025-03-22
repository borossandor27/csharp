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
        static void Main(string[] args)
        {
            //-- létrehozunk egy új szálat és elindítjuk
            Thread thread= new Thread(Szamolgato);
            thread.Start();
            //-- Folytatódik a fő szál
            for (int i = 0; i < lepesekSzama; i++)
            {
                Console.WriteLine($"Első szál: {i}");
                Thread.Sleep(1000);
            }
            //-- fő szál vége
            Console.WriteLine("Az első szál befejezte a futását");
            //-- Várakoztatjuk a fő szálat, hogy a második szál befejezze a futását
            thread.Join();
            Console.WriteLine("A második szál befejezte a futását");
            Console.WriteLine("\n\nProgram vége!");
            Console.ReadLine();
        }

        private static void Szamolgato()
        {
            for (int i = 0; i < lepesekSzama; i++)
            {
                Console.WriteLine($"Második szál: {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
