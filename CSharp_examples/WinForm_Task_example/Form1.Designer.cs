using System.Drawing;
using System;

namespace WinForm_Task_example
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // buttonStart
            this.buttonStart.Location = new Point(30, 30);
            this.buttonStart.Size = new Size(100, 30);
            this.buttonStart.Text = "Indítás";
            this.buttonStart.Click += new EventHandler(this.buttonStart_Click);

            // progressBar
            this.progressBar.Location = new Point(30, 70);
            this.progressBar.Size = new Size(300, 25);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;

            // labelStatus
            this.labelStatus.Location = new Point(30, 105);
            this.labelStatus.Size = new Size(300, 25);
            this.labelStatus.Text = "Várakozás...";

            // Form1
            this.ClientSize = new Size(380, 160);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelStatus);
            this.Text = "Progress példa";

            this.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

