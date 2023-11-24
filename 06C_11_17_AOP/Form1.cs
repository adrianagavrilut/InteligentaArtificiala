using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06C_11_17_AOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGraph(pictureBox1);
            Engine.InitDemo();
            Engine.Draw(Engine.grp);

            /*MyStack<int> S = new MyStack<int>();
            for (int i = 1; i < 27; i++)
            {
                S.Push(i);
                listBox1.Items.Add(S.Debug());
            }
            for (int i = 0; i < 15; i++)
            {
                S.Pop();
                listBox1.Items.Add(S.Debug());
            }*/

            MyQueue<int> Q = new MyQueue<int>();
            for (int i = 1; i < 27; i++)
            {
                Q.Push(i);
                listBox1.Items.Add(Q.Debug());
            }
            for (int i = 0; i < 15; i++)
            {
                Q.Pop();
                listBox1.Items.Add(Q.Debug());
            }

            Engine.Refresh();
        }
    }
}
