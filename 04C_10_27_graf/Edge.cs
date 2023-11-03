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

       /* public Edge(string data, Graph T)//, List<Vertex> vertices, dar eu am Search
        {
            string[] buffer = data.Split(' ');
            start = Engine.Search(buffer[0], T); // start = Vertices[int.Parse(buffer[0])];
            end = Engine.Search(buffer[1], T);
            cost = float.Parse(buffer[2]);
            this.data = data;
        }*/

        public Edge(string data, Graph T)
        {
            string[] buffer = data.Split(' ');
            start = T.Vertices[int.Parse(buffer[0])];
            end = T.Vertices[int.Parse(buffer[1])];
            cost = float.Parse(buffer[2]);
            this.data = data;
        }

        public void Draw(Graphics h)
        {
            h.DrawLine(new Pen(Color.Black, 1.6f), start.location, end.location);
            Point mij = new Point((start.location.X + end.location.X) / 2, (start.location.Y + end.location.Y) / 2);
            h.DrawString(cost.ToString(), new Font("Arial", 11, FontStyle.Bold), new SolidBrush(Color.DarkOliveGreen), mij);

        }
    }

}
