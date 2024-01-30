using System;
using System.Windows.Forms;

namespace AOP_project
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
            buttonExplorer.Enabled = false;
            buttonExploiter.Enabled = false;
            buttonTransporter.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time += 0.2;
            label1.Text = Math.Round(time).ToString();

            foreach (int value in Engine.explorerFlaggedValues)
                textBox1.Text = value.ToString();
            foreach (int value in Engine.exploiterFlaggedValues)
                textBox2.Text = value.ToString();
            foreach (int value in Engine.transporterFlaggedValues)
                textBox3.Text = value.ToString();
            textBox4.Text = Engine.winnings.ToString();

            foreach (Agent agent in Engine.agents)
                agent.Move();
            Engine.DrawMap();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonExplorer.Enabled = true;
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
            buttonExploiter.Enabled = true;
        }

        private void buttonExploiter_Click(object sender, EventArgs e)
        {
            Engine.agents.Add(new Exploiter());
            Engine.agents.Add(new Exploiter());
            Engine.SetAgents();
            buttonTransporter.Enabled = true;
        }

        private void buttonTransporter_Click(object sender, EventArgs e)
        {
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
