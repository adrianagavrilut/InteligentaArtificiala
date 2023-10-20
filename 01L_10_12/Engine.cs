using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01L_10_12
{
    public static class Engine
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color[] pall = new Color[] { Color.Black, Color.Red, Color.Green, Color.Blue, Color.Purple };
        public static int[] ponderi;
        public static int sum;

        internal static void InitCircle(PictureBox p)
        {
            display = p;
            bmp = new Bitmap(p.Width, p.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.BlanchedAlmond);
            grp.DrawRectangle(Pens.Gray, 50, 50, p.Width - 100, p.Height - 100);
            grp.DrawEllipse(Pens.Black, 50, 50, p.Width - 100, p.Height - 100);
        }

        internal static void LoadFromFile(string fileName, TextBox textBox1)
        {
            TextReader load = new StreamReader(fileName);
            int n = int.Parse(load.ReadLine());
            ponderi = new int[n];
            sum = 0;
            string[] data = load.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                ponderi[i] = int.Parse(data[i]);
                sum += ponderi[i];
                textBox1.Text += $"{ponderi[i]} ";
            }

        }

        internal static void SplitCircle(PictureBox p)
        {
            /*for (int i = 0; i < sum; i++)
            {
                grp.DrawLine(Pens.Black, p.Width / 2, p.Height / 2, 105, 105);
                //drawArc sau drawsector, sau parse, pie
                //sp = 2pi
                //p = x
            }*/
            Pen[] pens = new Pen[pall.Length];
            for (int i = 0; i < pall.Length; i++)
                pens[i] = new Pen(pall[i], 2);
            float[] angles = new float[ponderi.Length];
            //float startAngle = currentAngle;
        }

        internal static void Refresh()
        {
            display.Image = bmp;
        }
    }
}
