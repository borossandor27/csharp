using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{

    class Program
    {
        static void Main()
        {
            Auto auto1 = new Auto { Marka = "Toyota", Rendszam = "ABC-123" };
            Auto auto2 = new Auto { Marka = "BMW", Rendszam = "ABC-123" };
            Auto auto3 = new Auto { Marka = "Toyota", Rendszam = "XYZ-999" };

            Console.WriteLine(auto1.Equals(auto2)); // true – ugyanaz a rendszám
            Console.WriteLine(auto1.Equals(auto3)); // false – más rendszám
            Console.WriteLine(auto1.Equals(null));  // false
            Console.WriteLine("\nProgram vége!");
            Console.ReadLine();
        }
    }

}
