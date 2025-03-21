using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    abstract class Allat
    {
        /*
         * Az összes állat mozog és eszik – ezeket itt definiáljuk.
         * De hogy milyen hangot adnak, azt az alosztályokra bízzuk.
         */
        public void Mozog()
        {
            Console.WriteLine("Az állat mozog.");
        }

        public void Eszik()
        {
            Console.WriteLine("Az állat eszik.");
        }

        public abstract void HangotAd();
    }
}
