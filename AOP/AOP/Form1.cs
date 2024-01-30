using System;
using System.Windows.Forms;

namespace Roboti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double time = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(pictureBox1);
            Engine.DrawMap();
            buttonStart.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time += 0.2;
            label1.Text = Math.Round(time).ToString();
            //listBox1.Items.Add(Engine.explorer.path.Count());
            foreach (Agent agent in Engine.agents)
            {
                agent.Move();
                //here  i should check the collision with the target
            }
            Engine.DrawMap();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }

        private void buttonExplorer_Click(object sender, EventArgs e)
        {
            Engine.agents.Add(new Explorer());
            Engine.agents.Add(new Explorer());
            Engine.agents.Add(new Explorer());
            Engine.SetAgents();
        }

        private void buttonExploiter_Click(object sender, EventArgs e)
        {
            Engine.agents.Add(new Exploiter());
            Engine.SetAgents();
        }

        private void buttonTransporter_Click(object sender, EventArgs e)
        {
            Engine.agents.Add(new Transporter());
            Engine.agents.Add(new Transporter());
            Engine.SetAgents();
        }

        private void buttonSpawn_Click(object sender, EventArgs e)
        {
            Engine.AddPollution();
            Engine.DrawMap();
            buttonStart.Enabled = true;
        }
    }
}
