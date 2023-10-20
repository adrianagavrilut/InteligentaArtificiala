using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01L_10_12_rez
{
    public partial class Form1 : Form
    {
        private float currentAngle = 0;
        private int[] proportions;
        private int sumProport = 0;
        private bool isSpinning = false;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            LoadFromFile(@"..\..\TextFile1.txt");
            timer.Interval = 70; 
            timer.Tick += Timer_Tick;
        }

        private void LoadFromFile(string fileName)
        {
            TextReader load = new StreamReader(fileName);
            int n = int.Parse(load.ReadLine());
            proportions = new int[n];
            sumProport = 0;
            string[] data = load.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                proportions[i] = int.Parse(data[i]);
                sumProport += proportions[i];
                textBox1.Text += $"{proportions[i]} ";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the current angle and refresh the form to trigger the Paint event
            currentAngle += 5; // Adjust the rotation speed
            if (currentAngle >= 360)
            {
                currentAngle = 0; // Reset to 0 when one full rotation is completed
            }
            panel1.Invalidate(); // Force a repaint
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int centerX = panel1.Width / 2;
            int centerY = panel1.Height / 2;
            int radius = Math.Min(panel1.Width, panel1.Height) / 2;

            Color[] colors = new Color[]
            {
                Color.PaleTurquoise,//0
                Color.ForestGreen,//1
                Color.DarkSlateGray,//2
                Color.Teal,//3
                Color.LemonChiffon,//4
                Color.MidnightBlue,//5
                Color.BurlyWood,//6
                Color.Orange,//7
                Color.OrangeRed,//8
                Color.Gold//9
            };

            Pen[] pens = new Pen[colors.Length];

            for (int i = 0; i < colors.Length; i++)
                pens[i] = new Pen(colors[i], 2);

            float[] angles = new float[proportions.Length];

            float startAngle = currentAngle;

            for (int i = 0; i < proportions.Length; i++)
            {
                angles[i] = (float)(360 * proportions[i] / (float)sumProport);
                float sweepAngle = angles[i];

                g.FillPie(new SolidBrush(colors[proportions[i]]), centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, sweepAngle);

                g.DrawPie(new Pen(Color.Black, 2), centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, sweepAngle);
                startAngle += sweepAngle;

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (isSpinning)
            {
                // Stop the spinning animation
                timer.Stop();
                isSpinning = false;
            }
            else
            {
                // Start the spinning animation
                timer.Start();
                isSpinning = true;
            }
        }
    }
}
