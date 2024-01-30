using System;
using System.Windows.Forms;

namespace AOP_simulation
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
            Engine.InitializeGraphics(pictureBox1);
            Engine.InitializeMap(Engine.grp);
            Engine.Refresh();
        }

        private void buttonExplorer_Click(object sender, EventArgs e)
        {
            Engine.agents.Add(new Explorer());
            Engine.agents.Add(new Explorer());
            Engine.agents.Add(new Explorer());
            Engine.SetAgents(Engine.grp);
            Engine.Refresh();
        }

        private void buttonExploiter_Click(object sender, EventArgs e)
        {
            Engine.agents.Add(new Exploiter());
            Engine.agents.Add(new Exploiter());
            Engine.agents.Add(new Exploiter());
            Engine.SetAgents(Engine.grp);
            Engine.Refresh();
        }

        private void buttonTransporter_Click(object sender, EventArgs e)
        {
            Engine.agents.Add(new Transporter());
            Engine.agents.Add(new Transporter());
            Engine.agents.Add(new Transporter());
            Engine.SetAgents(Engine.grp);
            Engine.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*Engine.Clear();
            Engine.InitializeMap(Engine.grp);
            Engine.DrawAgents(Engine.grp);*/

            Engine.MoveAgents();

            //check collision
            crtTime++;
            label1.Text = crtTime.ToString();
            Engine.Refresh();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }

        private void buttonSpawn_Click(object sender, EventArgs e)
        {
            Engine.SpawnResources(Engine.grp);
            Engine.Refresh();
        }
    }
}
