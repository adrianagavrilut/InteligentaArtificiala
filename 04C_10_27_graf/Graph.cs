using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04C_10_27_graf
{
    public class Graph
    {
        public List<Vertex> Vertices;
        public List<Edge> Edges;
        public int n;
        public int[,] matrix;

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public void LoadFromFile(string filename)
        {
            TextReader load = new StreamReader(filename);
            n = int.Parse(load.ReadLine());
            matrix = new int[n, n];
            string buffer;
            for (int i = 0; i < n; i++)
            {
                buffer = load.ReadLine();
                Vertex local = new Vertex(buffer);
                local.idx = i;
                Vertices.Add(local);
            }
            while ((buffer = load.ReadLine()) != null)
            {
                Edge edge = new Edge(buffer);
                Edges.Add(edge);
            }
            load.Close();
            foreach (Edge edge in Edges)
            {
                matrix[edge.start.idx, edge.end.idx] = (int)edge.cost;
                matrix[edge.end.idx, edge.start.idx] = (int)edge.cost;
            }
        }

        public void Draw(Graphics h)
        {
            foreach (Vertex v in Vertices)
            {
                v.Draw(h);
            }
            foreach (Edge e in Edges)
            {
                e.Draw(h);
            }
        }

        public List<string> View(System.Windows.Forms.ListBox A)
        {
            List<string> t = new List<string>();
            string b;
            for (int i = 0; i < n; i++)
            {
                b = "";
                for (int j = 0; j < n; j++)
                {
                    b += matrix[i, j];
                    b += " ";
                }
                t.Add(b);
                A.Items.Add(b);
            }
            return t;
        }
    }
}
