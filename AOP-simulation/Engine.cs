using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AOP_simulation
{
    public static class Engine
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color color = Color.Black;
        public static Map map;
        public static Random rnd = new Random();
        public static int deltaX = 20, deltaY = 20;
        public static List<Agent> agents = new List<Agent>();

        public static void InitializeGraphics(PictureBox T)
        {
            display = T;
            bmp = new Bitmap(T.Width, T.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(color);
        }

        public static void InitializeMap(Graphics handler)
        {
            map = new Map();
            map.Init(50, 30);
            map.Draw(handler);
        }

        public static void Refresh()
        {
            display.Image = bmp;
        }

        public static void Clear()
        {
            grp.Clear(color);
        }

        internal static void SetAgents(Graphics handler)
        {
            foreach (Agent agent in agents)
            {
                SetAgentOnMap(agent, map.n / 2, map.m / 2);
                agent.Draw(handler);
            }
        }

        public static void SetAgentOnMap(Agent T, int x, int y)
        {
            T.location = new Point(x, y);
        }

        internal static void MoveAgents()
        {
            foreach (Agent agent in agents)
                agent.Move(map);
        }

        internal static void DrawAgents(Graphics grp)
        {
            foreach (Agent agent in agents)
                agent.Draw(grp);
        }

        internal static void SpawnResources(Graphics handler)
        {
            for (int i = 0; i < 4; i++)
                map.DrawResources(handler, rnd.Next(50), rnd.Next(30));
            //set a value for each resource
            //adding  it to a lit of targets
        }
    }
}
