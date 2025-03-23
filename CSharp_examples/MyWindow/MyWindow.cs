using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWindow
{
    public class MyWindow : Form, IDisposable
    {
        private bool _disposed = false; // Segít nyomon követni, hogy az erőforrások már felszabadultak-e
    

        
        public MyWindow()
        {
            this.Load += (sendObject, args) =>
            {
                BeallitFejlec();
                BeallitLablec();
                InicializalTartalom();
            };
            this.FormClosed += (sendObject, args) =>
            {
                //-- eltávolítjuk a lehetséges hivatkozásokat a Form1 objektumra
                Dispose(true); // lefoglalt erőforrások felszabadítása
                GC.SuppressFinalize(this);
            };
        }
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Itt szabadítsuk fel a managed erőforrásokat
                    foreach (Control control in this.Controls)
                    {
                        control.Dispose();
                    }
                    // A Controls.Clear() metódus eltávolítja az összes kontrollt a Controls gyűjteményből, de nem szabadítja fel az erőforrásokat.
                    this.Controls.Clear();
                }

                // Itt szabadítsuk fel az unmanaged erőforrásokat (ha vannak) README.md!
                // Például: Marshal.FreeHGlobal(unmanagedResource);
                _disposed = true;
            }
            base.Dispose(disposing); // Meghívjuk az ősosztály Dispose metódusát
        }
        // Finalizáló (destruktor)
        ~MyWindow()
        {
            Dispose(false);
        }
        private void BeallitFejlec()
        {
            this.Text = "Cég neve - " + this.GetType().Name;
        }

        private void BeallitLablec()
        {
            Label lbl = new Label();
            lbl.Text = "© 2025 Cég Védjegy";
            lbl.Dock = DockStyle.Bottom;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Height = 25;
            this.Controls.Add(lbl);
        }

        public virtual void InicializalTartalom()
        {
            Console.WriteLine("elindult");
        }
    }
}

