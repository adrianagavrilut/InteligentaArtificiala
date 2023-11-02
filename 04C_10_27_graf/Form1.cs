using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04C_10_27_graf
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Dispersia unui graf: Reprezentarea unui graf astfel incat lungimea muchiilor (distanta dintre noduri)
        /// sa fie cat mai aproape de ponderi / costuri.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGraph(pictureBox1);
            Engine.demo = new Graph();
            Engine.demo.LoadFromFile(@"../../TextFile1.txt");
            Engine.demo.View(listBox1);
            Engine.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.demo.Draw(Engine.grp);
            Engine.Refresh();
        }
    }
}
