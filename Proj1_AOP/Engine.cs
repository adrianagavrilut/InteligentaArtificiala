using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AOP_project
{
    public enum ResourceType { None, Explorer, Exploiter, Transporter }

    public static class Engine
    {
        public static int[,] map;
        public static int[,] originalMap;
        public static Tile[,] tiles;
        public static int n, m, length = 25;
        public static ResourceType[,] cells;
        public static bool[,] visitedByExplorer;
        public static bool[,] visitedByExploiter;
        public static bool[,] visitedByTransporter;

        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color color = Color.Black;

        public static Random rnd = new Random();

        public static List<Agent> agents = new List<Agent>();
        public static List<Point> targets = new List<Point>();
        public static List<Point> targetsForExploiter = new List<Point>();
        public static List<Point> targetsForTransporter = new List<Point>();

        public static List<int> explorerFlaggedValues = new List<int>();
        public static List<int> exploiterFlaggedValues = new List<int>();
        public static List<int> transporterFlaggedValues = new List<int>();
        public static int winnings = 0;

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
            visitedByExplorer = new bool[n, m];
            visitedByExploiter = new bool[n, m];
            visitedByTransporter = new bool[n, m];

            for (int i=0; i<n; i++)
                for(int j=0; j<m; j++)
                    tiles[i, j] = new Tile(i, j);

            for(int i=0; i<200; i++)
            {
                int x = rnd.Next(n), y = rnd.Next(m);
                map[x, y] = -1;
            }
        }

        public static void DrawMap()
        {
            grp.Clear(color);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    tiles[i, j].DrawTile();
            foreach (Agent agent in agents)
                agent.Draw();
            display.Image = bmp;
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
            for (int i = 0; i < 70; i++)
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

        public static int ManhattanDistance(Point a, Point b)
        {
            int distance = Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
            if (distance == 0)
                return 100;
            return distance;
        }

        public static int MonteCarlo(float[] weights)
        {
            float totalWeight = 0;
            for (int i = 0; i < weights.Length; i++)
                totalWeight += weights[i];
            if (totalWeight <= 0)
                return rnd.Next(weights.Length);
            float randomValue = (float)rnd.NextDouble() * totalWeight;
            float cumulativeWeight = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                cumulativeWeight += weights[i];
                if (randomValue <= cumulativeWeight)
                    return i;
            }
            return weights.Length - 1;
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

        public static Point FindClosestTarget(Point location, List<Point> unvisitedTargets)
        {
            Point closestTarget = targets[0];
            int minDistance = ManhattanDistance(location, closestTarget);
            foreach (Point target in unvisitedTargets)
            {
                int distance = ManhattanDistance(location, target);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTarget = target;
                }
            }
            return closestTarget;
        }
    }
}
