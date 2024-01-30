using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roboti
{
    public enum ResourceType { None, Explorer, Exploiter, Transporter }


    public static class Engine
    {
        public static int[,] map;
        public static int[,] originalMap;
        public static Tile[,] tiles;
        public static int n, m, length = 20;
        public static ResourceType[,] cells;

        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color color = Color.Black;

        public static Random rnd = new Random();

        public static List<Agent> agents = new List<Agent>();
        public static List<Point> targets = new List<Point>();
        public static List<Point> targetsForExploiter = new List<Point>();
        public static List<Point> targetsForTransporter = new List<Point>();

        public static void Init(PictureBox T)
        {
            display = T;
            n = T.Width / length;
            m = T.Height / length;
            bmp = new Bitmap(T.Width, T.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(color);

            map = new int[n, m];
            tiles = new Tile[n, m];
            cells = new ResourceType[n, m];

            for(int i=0; i<n; i++)
                for(int j=0; j<m; j++)
                    tiles[i, j] = new Tile(i, j);

            for(int i=0; i<200; i++)
            {
                int x = rnd.Next(n), y = rnd.Next(m);
                map[x, y] = -1;
            }
            //AddPollution();
        }

        public static void DrawMap()
        {
            grp.Clear(color);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    tiles[i, j].DrawTile();
            foreach (Agent agent in agents)
                agent.Draw();
            display.Image = bmp;//refresh
        }

        public static void SetAgents()
        {
            foreach (Agent agent in agents)
            {
                agent.location = new Point(n / 2, m / 2);
                agent.Draw();
            }
        }

        public static void AddPollution()
        {
            for (int i = 0; i < 150; i++)
            {
                int x = rnd.Next(n), y = rnd.Next(m);
                map[x, y] = rnd.Next(100);
                targets.Add(new Point(x, y));
            }
            originalMap = (int[,])map.Clone();
        }

        public static void SetCell(int x, int y, ResourceType type)
        {
            cells[x, y] = type;
        }

        public static int DistManhatan(Point a, Point b)
        {
            int dist = Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
            if (dist == 0)
                return 1000;
            return dist;
        }

        public static int AMC(float[] ponderi)
        {
            float suma = 0;
            for (int i = 0; i < length; i++)
                suma += ponderi[i];
            float t = (float)rnd.NextDouble() * suma;
            int poz = length - 1;
            do
            {
                t -= ponderi[poz];
                poz--;
            } while (t >= 0);
            return poz + 1;
        }

        public static List<Point> GetPathLee(int[,] map, Point start, Point final)
        {
            map = (int[,])originalMap.Clone(); // Create a copy of the original map
            List<Point> path = new List<Point>();
            //m are doar 0 si -1

            MyQueue<TriData> A = new MyQueue<TriData>();
            A.Push(new TriData(start.X, start.Y, 1));
            map[start.X, start.Y] = 1;

            //get matrix for path lee
            while (!A.IsEmpty())
            {
                TriData crt = A.Pop();
                if (crt.l - 1 >= 0 && map[crt.l - 1, crt.c] == 0)
                {
                    A.Push(new TriData(crt.l - 1, crt.c, crt.value + 1));
                    map[crt.l - 1, crt.c] = crt.value + 1;
                }
                if (crt.l + 1 < n && map[crt.l + 1, crt.c] == 0)
                {
                    A.Push(new TriData(crt.l + 1, crt.c, crt.value + 1));
                    map[crt.l + 1, crt.c] = crt.value + 1;
                }
                if (crt.c - 1 >= 0 && map[crt.l, crt.c - 1] == 0)
                {
                    A.Push(new TriData(crt.l, crt.c - 1, crt.value + 1));
                    map[crt.l, crt.c - 1] = crt.value + 1;
                }
                if (crt.c + 1 < m && map[crt.l, crt.c + 1] == 0)
                {
                    A.Push(new TriData(crt.l, crt.c + 1, crt.value + 1));
                    map[crt.l, crt.c + 1] = crt.value + 1;
                }
            }

            if (map[final.X, final.Y] == 0)
                return null;
            TriData current = new TriData(final.X, final.Y, map[final.X, final.Y]);
            path.Add(final);

            //get path
            while (current.value > 1)
            {
                if (current.l - 1 >= 0 && map[current.l - 1, current.c] == current.value - 1)
                {
                    path.Add(new Point(current.l - 1, current.c));
                    current.l--;
                }
                else if (current.l + 1 < n && map[current.l + 1, current.c] == current.value - 1)
                {
                    path.Add(new Point(current.l + 1, current.c));
                    current.l++;
                }
                else if (current.c - 1 >= 0 && map[current.l, current.c - 1] == current.value - 1)
                {
                    path.Add(new Point(current.l, current.c - 1));
                    current.c--;
                }
                else if (current.c + 1 < m && map[current.l, current.c + 1] == current.value - 1)
                {
                    path.Add(new Point(current.l, current.c + 1));
                    current.c++;
                }
                current.value--;
            }

            return path;
        }



        /*public static List<string> ShowMatrix(int[,] matrix)
        {
            List<string> s = new List<string>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                s.Add("");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        s[i] += "[] ";
                    else
                        s[i] += matrix[i, j].ToString("00") + " ";
                }
            }
            return s;
        }*/
    }
}
