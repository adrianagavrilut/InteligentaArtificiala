using System;
using System.Windows.Forms;

namespace Dispersie_graf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGraphics(pictureBox1);
            Engine.Refresh();
            Engine.Run(listBox1, labelGeneration, labelPenalty, labelBestPenalty);
        }
    }
}
