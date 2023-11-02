using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04C_10_27_graf
{
    public class Vertex
    {
        public string name;
        public Point location;
        public int idx;

        public Vertex(string name)
        {
            this.name = name;
            //this.location = Eco.GetPoint();
            this.location = new Point(Eco.rnd.Next(50, Engine.display.Width - 50), Eco.rnd.Next(50, Engine.display.Height - 50));
            idx = -1;
        }

        public Vertex(string name, Point location)
        {
            this.name = name;
            this.location = location;
            idx = -1;
        }

        public void Mutate()
        {
            location = Eco.GetPoint();
        }

        public void Draw(Graphics h)
        {
            h.DrawEllipse(new Pen(Color.DarkBlue, 3), location.X - 12, location.Y - 12, 24, 24);
            h.FillEllipse(new SolidBrush(Color.Ivory), location.X - 12, location.Y - 12, 24, 24);
            h.DrawString(name, new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Crimson), location.X - 7, location.Y - 8);
        }

        //mutatie (sa duci mai incolo punctul)
    }
}
