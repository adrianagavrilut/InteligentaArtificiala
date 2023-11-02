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
                Edges.Add(new Edge(buffer));
            load.Close();
            foreach (Edge edge in Edges)
            {
                matrix[edge.start.idx, edge.end.idx] = (int)edge.cost;
                matrix[edge.end.idx, edge.start.idx] = (int)edge.cost;
            }
        }

        //o functie care spameaza un graf dupa un graf dat (clone) unde doar vertices se schimba

        public Graph Clone() //pt initializarea populatiei
        {
            Graph toReturn = new Graph();
            foreach (Vertex vertex in Vertices)
            {
                toReturn.Vertices.Add(new Vertex(vertex.name));
            }
            foreach (Edge edge in Edges)
            {
                toReturn.Edges.Add(new Edge(edge.data));//,toReturn.Vertices));
            }
            return toReturn;
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

        public void Mutate() //mutatie bruta
        {
            int t = Eco.rnd.Next(Vertices.Count);
            Vertices[t].Mutate();
        }

        public void MutateA(int R) //mutatie adaptiva, cu disc (R = raza)
        {
            float angle = Eco.GetAngle();
            float Rn = (float)Eco.rnd.Next(R);
            int t = Eco.rnd.Next(Vertices.Count);
            float x = (float)Vertices[t].location.X + Rn * (float)Math.Cos(angle);
            float y = (float)Vertices[t].location.Y + Rn * (float)Math.Sin(angle);
            Vertices[t].location = new Point((int)x, (int)y);
        }

        //mai urmeaza Selectia ponderata
    }
}
