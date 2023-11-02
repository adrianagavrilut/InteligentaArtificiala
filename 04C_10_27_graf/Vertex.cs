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
        public PointF location;
        public int idx;

        public Vertex(string name)
        {
            this.name = name;
            this.location = new PointF(Engine.rnd.Next(50, Engine.display.Width - 50), Engine.rnd.Next(50, Engine.display.Height - 50));
            idx = -1;
        }
        public Vertex(string name, PointF location)
        {
            this.name = name;
            this.location = location;
            idx = -1;
        }

        public void Draw(Graphics h)
        {
            h.DrawEllipse(Pens.Black, location.X - 5, location.Y - 5, 11, 11);
            h.DrawString(name, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.DarkBlue), location.X, location.Y);
        }
    }
}
