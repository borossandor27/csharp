using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Task_example
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            labelStatus.Text = "Számítás elindítva...";
            progressBar.Value = 0;

            // Progress példány: százalékos állapot frissítéshez
            var progress = new Progress<int>(percent =>
            {
                progressBar.Value = percent;
                labelStatus.Text = $"Folyamatban: {percent}%";
            });

            // Háttérfeladat
            int eredmeny = await Task.Run(() => HosszuSzamitas(progress));

            labelStatus.Text = $"Kész! Eredmény: {eredmeny}";
            buttonStart.Enabled = true;
        }

        private int HosszuSzamitas(IProgress<int> progress)
        {
            int osszeg = 0;
            int max = 1_000_000;
            int lepes = max / 100;

            for (int i = 1; i <= max; i++)
            {
                osszeg += i;

                // 1% lépésenként frissítünk
                if (i % lepes == 0)
                {
                    int szazalek = i / lepes;
                    progress.Report(szazalek);
                    Thread.Sleep(5); // szimulált lassítás
                }
            }

            return osszeg;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
