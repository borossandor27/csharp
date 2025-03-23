using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWindow
{
    public partial class FormMain : MyWindow
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public override void InicializalTartalom()
        {
            Label tartalom = new Label()
            {
                Text = "Terméklista...",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(tartalom);
        }
    }
}
