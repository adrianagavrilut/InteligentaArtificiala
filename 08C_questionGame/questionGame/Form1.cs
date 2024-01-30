using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace questionGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.initDemo();
            refresh();
        }

        iButton[] Answers;

        public void refresh() 
        {

            label1.Text = Engine.crtQuestion.Title;
            label2.Text = Engine.crtQuestion.Level.ToString();
            string buffer = "";
            foreach (string s in Engine.crtQuestion.Domain)
                buffer += s + ",";
            label3.Text = buffer;

            listBox1.Items.Clear();
            foreach (string s in Engine.crtQuestion.Body)
                listBox1.Items.Add(s);
            if (Engine.crtQuestion.Image != null)
            {
                panel4.Visible = true;
                pictureBox1.Image = Engine.crtQuestion.Image;
                label4.Text = Engine.crtQuestion.ImageSource;

            }
            else
                panel4.Visible = false;

            panel3.Controls.Clear();
            Answers = new iButton[Engine.crtQuestion.Answers.Count];
            for (int i = 0; i < Answers.Length; i++)
            {
                Answers[i] = new iButton();
                Answers[i].Parent = panel3;
                Answers[i].Size = new System.Drawing.Size(350, 38);
                Answers[i].Location = new Point(10, 10 + i * 40);
                Answers[i].Text = Engine.crtQuestion.Answers[i];
                Answers[i].idx = i;
                Answers[i].Click += Answer_Click;
                Answers[i].BackColor = Color.LightGray;
                Answers[i].ForeColor = Color.Black;
            }
        }

        void Answer_Click(object sender, EventArgs e)
        {
            iButton t = (sender as iButton);
            if (t.selected)
            {
                t.selected = false;
                t.BackColor = Color.LightGray;
                t.ForeColor = Color.Black;
            }
            else
            {
                t.selected = true;
                t.BackColor = Color.Yellow;
                t.ForeColor = Color.Green;
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.NextQuestion();
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userAnswer ="";
            foreach (iButton iB in Answers)
            {
                if (iB.selected)
                    userAnswer += iB.idx +" ";
            }
            MessageBox.Show(userAnswer);

            bool ok = false;
            foreach (Points p in Engine.crtQuestion.CorrectAnswers)
            {
                if (p.Answers.Trim() == userAnswer.Trim())
                {
                    ok = true;
                    MessageBox.Show(p.points.ToString());

                }
            }
            if (!ok)
                    MessageBox.Show("INVALID");
            }
        }
    }

