using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06C_11_17_AOP
{
    public static class Engine
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color color = Color.Ivory;
        public static MyStack<Demo> demoStack = new MyStack<Demo>();
        public static MyStack<int> demoStack2 = new MyStack<int>();

        public static void InitGraph(PictureBox T)
        {
            display = T;
            bmp = new Bitmap(T.Width, T.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(color);
        }

        public static void Refresh()
        {
            display.Image = bmp;
        }

        public static int deltaX = 20, deltaY = 20;
        public static Map demoMap;
        public static Random rnd = new Random();
        public static List<Agent> agents = new List<Agent>();
        public static int[,] matrix;
        public static int n;
        public static int m;

        public static void InitDemo()
        {
            demoMap = new Map();
            demoMap.Init(40, 60);

            for (int i = 0; i < 30; i++)
            {
                demoMap.SpawnResources(rnd.Next(40), rnd.Next(60), rnd.Next(5, 100));
                demoMap.SpawnDeadZone(rnd.Next(40), rnd.Next(60));
            }

            agents.Add(new Explorer());
            agents.Add(new Explorer());
            agents.Add(new Exploiter());
            agents.Add(new Transporter());

            foreach (Agent agent in agents)
                SetAgentOnMap(agent, rnd.Next(40), rnd.Next(60));
        }

        public static void SetAgentOnMap(Agent T, int x, int y)
        {
            T.location = new Point(x, y);
        }

        public static void Draw(Graphics handler)
        {
            demoMap.Draw(handler);
            foreach (Agent agent in agents)
                agent.Draw(handler);
        }

        /*public static void InitLee()
        {
            matrix = demoMap.ConvertToMatrix(demoMap);
            n = matrix.GetLength(0);
            m = matrix.GetLength(1);
            foreach (Agent agent in agents)
                agent.DeterminePath();
        }

        public static List<Point> GetPathLee(Point start, Point end)
        {
            GetMatrixForPathLee(start);
            List<Point> pathLee = new List<Point>();
            TriData crnt = new TriData(end.X, end.Y, matrix[end.X, end.Y]);
            pathLee.Add(end);
            while (crnt.v > 1)
            {
                if (crnt.l - 1 >= 0 && matrix[crnt.l - 1, crnt.c] == crnt.v - 1)
                {
                    pathLee.Add(new Point(crnt.l - 1, crnt.c));
                    crnt.l--;
                }
                else if (crnt.l + 1 < Engine.n && matrix[crnt.l + 1, crnt.c] == crnt.v - 1)
                {
                    pathLee.Add(new Point(crnt.l + 1, crnt.c));
                    crnt.l++;
                }
                else if (crnt.c - 1 >= 0 && matrix[crnt.l, crnt.c - 1] == crnt.v - 1)
                {
                    pathLee.Add(new Point(crnt.l, crnt.c - 1));
                    crnt.c--;
                }
                else if (crnt.c + 1 < Engine.m && matrix[crnt.l, crnt.c + 1] == crnt.v - 1)
                {
                    pathLee.Add(new Point(crnt.l, crnt.c + 1));
                    crnt.c++;
                }
                crnt.v--;
            }
            return pathLee;
        }

        public static void GetMatrixForPathLee(Point start)
        {
            Queue A = new Queue();
            A.Push(new TriData(start.X, start.Y, 1));
            matrix[start.X, start.Y] = 1;

            while (!A.IsEmpty())
            {
                TriData t = A.Pop();
                if (t.l - 1 >= 0 && matrix[t.l - 1, t.c] == 0)//N
                {
                    A.Push(new TriData(t.l - 1, t.c, t.v + 1));
                    matrix[t.l - 1, t.c] = t.v + 1;
                }
                if (t.l + 1 < n && matrix[t.l + 1, t.c] == 0)//S
                {
                    A.Push(new TriData(t.l + 1, t.c, t.v + 1));
                    matrix[t.l + 1, t.c] = t.v + 1;
                }
                if (t.c - 1 >= 0 && matrix[t.l, t.c - 1] == 0)//V
                {
                    A.Push(new TriData(t.l, t.c - 1, t.v + 1));
                    matrix[t.l, t.c - 1] = t.v + 1;
                }
                if (t.c + 1 < m && matrix[t.l, t.c + 1] == 0)//E
                {
                    A.Push(new TriData(t.l, t.c + 1, t.v + 1));
                    matrix[t.l, t.c + 1] = t.v + 1;
                }
            }
        }*/
    }
}
