using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWindow
{
    public abstract class MyWindow : Form
    {
        public MyWindow()
        {
            this.Load += (s, e) =>
            {
                BeallitFejlec();
                BeallitLablec();
                InicializalTartalom(); // legyen itt!
            };
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

        public abstract void InicializalTartalom();
    }
}

