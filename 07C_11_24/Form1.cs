using System;
using System.Windows.Forms;

namespace _07C_11_24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int crtTime = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGraph(pictureBox1);
            Engine.InitDemo();
            Engine.Draw(Engine.grp);
/*
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
*/
            Engine.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Clear();
            Engine.Draw(Engine.grp);
            Engine.Tick(Engine.demoMap);
            Engine.Refresh();
            crtTime++;
            label1.Text = crtTime.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }
    }
}
