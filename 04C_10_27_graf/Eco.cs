using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04C_10_27_graf
{
    public static class Eco
    {
        public static int maxX = 700, maxY = 550, N = 1000, k = 10; //N-dimensiunea populatiei, k-dimensiunea populatiei intermediare
        public static Random rnd = new Random();

        public static Point GetPoint()
        {
            return new Point(rnd.Next(maxX), rnd.Next(maxY));
        }

        public static double GetDistance(Point a, Point b)
        {
            return Math.Sqrt((Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)));
        }

        public static float GetAngle()
        {
            return (float)(rnd.NextDouble() * 2 * Math.PI);
        }
    }
}
