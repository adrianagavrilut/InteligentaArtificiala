using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07C_11_24
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

        public static void InitLee()
        {
            matrix = demoMap.ConvertToMatrix(demoMap);
            n = matrix.GetLength(0);
            m = matrix.GetLength(1);
            foreach (Agent agent in agents)
                agent.DeterminePath();
        }
    }
}
