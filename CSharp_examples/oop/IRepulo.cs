using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    interface IRepulo
    {
        /* 
         * Nem minden állat tud repülni. Ezért a repülés képességét NEM az Allat osztályba tesszük, 
         * hanem külön interfészként definiáljuk
         */
        void Repul();
    }
}
