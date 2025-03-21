using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kutya");
            Allat kutya = new Kutya();
            kutya.Mozog();
            kutya.Eszik();
            kutya.HangotAd();

            Console.WriteLine("\n\nMadár - Állat");
            Allat madar = new Madar();
            madar.Mozog();
            madar.Eszik();
            madar.HangotAd();


            Console.WriteLine("\n\nMadár - Madár");
            Madar madar2 = new Madar();
            madar2.Mozog();
            madar2.Eszik();
            madar2.HangotAd();
            madar2.Repul();
            Console.WriteLine("\nProgram vége");
            Console.ReadLine();
        }
    }
}
