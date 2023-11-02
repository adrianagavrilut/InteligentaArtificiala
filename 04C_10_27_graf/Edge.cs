using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04C_10_27_graf
{
    public class Edge
    {
        public Vertex start;
        public Vertex end;
        public float cost;
        public string data;

        public Edge(string data)//, List<Vertex> vertices, dar eu am Search
        {
            string[] buffer = data.Split(' ');
            start = Engine.Search(buffer[0], Engine.demo);
            end = Engine.Search(buffer[1], Engine.demo);
            cost = float.Parse(buffer[2]);
            this.data = data;
        }

        public void Draw(Graphics h)
        {
            h.DrawLine(Pens.Red, start.location, end.location);
            Point mij = new Point((start.location.X + end.location.X) / 2, (start.location.Y + end.location.Y) / 2);
            h.DrawString(cost.ToString(), new Font("Arial", 11, FontStyle.Bold), new SolidBrush(Color.DarkGreen), mij);

        }
    }

}
