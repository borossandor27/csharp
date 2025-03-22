using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hello_WinForm
{
    public partial class Form1: Form
    {
        private TextBox textBoxName;
        private Button buttonGreet;
        private Label labelResult;
        public Form1()
        {
            InitializeComponent();
            textBoxName = new TextBox { Location = new Point(20, 20), Width = 200 };
            buttonGreet = new Button { Location = new Point(20, 60), Text = "Köszöntés" };
            labelResult = new Label { Location = new Point(20, 100), AutoSize = true };

            buttonGreet.Click += (s, e) =>
            {
                labelResult.Text = $"Üdvözöllek, {textBoxName.Text}!";
            };

            Controls.Add(textBoxName);
            Controls.Add(buttonGreet);
            Controls.Add(labelResult);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
