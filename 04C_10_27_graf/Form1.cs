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
        /// Dispersia unui graf: Reprezentarea unui graf astfel incat lungimea muchiilor
        /// sa fie cat mai aproape de ponderi / costuri.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        Ag demoDG;
        Graph demoG;

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGraph(pictureBox1);
            demoDG = new Ag();
            demoDG.initPopulation();
            demoDG.Selection();
            demoDG.Draw(Engine.grp, listBox1);
            /*demoG = new Graph();
            demoG.LoadFromFile(@"..\..\TextFile1.txt");
            demoG.View(listBox1);
            demoG.Draw(Engine.grp);*/

            Engine.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Engine.Refresh();
        }
    }
}
