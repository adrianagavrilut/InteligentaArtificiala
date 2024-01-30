using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Roboti
{
    public static class Utils
    {
        public static List<Point> GetPathLee(int[,] m, Point start, Point final)
        {
            List<Point> path = new List<Point>();
            //m are doar 0 si -1

            MyQueue<TriData> A = new MyQueue<TriData>();
            A.Push(new TriData(start.X, start.Y, 1));
            m[start.X, start.Y] = 1;

            //get matrix for path lee
            while (!A.IsEmpty())
            {
                TriData crt = A.Pop();
                if (crt.l - 1 >= 0 && m[crt.l - 1, crt.c] == 0)
                {
                    A.Push(new TriData(crt.l - 1, crt.c, crt.value + 1));
                    m[crt.l - 1, crt.c] = crt.value + 1;
                }
                if (crt.l + 1 < Engine.n && m[crt.l + 1, crt.c] == 0)
                {
                    A.Push(new TriData(crt.l + 1, crt.c, crt.value + 1));
                    m[crt.l + 1, crt.c] = crt.value + 1;
                }
                if (crt.c - 1 >= 0 && m[crt.l, crt.c - 1] == 0)
                {
                    A.Push(new TriData(crt.l, crt.c - 1, crt.value + 1));
                    m[crt.l, crt.c - 1] = crt.value + 1;
                }
                if (crt.c + 1 < Engine.m && m[crt.l, crt.c + 1] == 0)
                {
                    A.Push(new TriData(crt.l, crt.c + 1, crt.value + 1));
                    m[crt.l, crt.c + 1] = crt.value + 1;
                }
            }

            if (m[final.X, final.Y] == 0)
                return null;
            TriData current = new TriData(final.X, final.Y, m[final.X, final.Y]);
            path.Add(final);

            //get path
            while (current.value > 1)
            {
                if (current.l - 1 >= 0 && m[current.l - 1, current.c] == current.value - 1)
                {
                    path.Add(new Point(current.l - 1, current.c));
                    current.l--;
                }
                else if (current.l + 1 < Engine.n && m[current.l + 1, current.c] == current.value - 1)
                {
                    path.Add(new Point(current.l + 1, current.c));
                    current.l++;
                }
                else if (current.c - 1 >= 0 && m[current.l, current.c - 1] == current.value - 1)
                {
                    path.Add(new Point(current.l, current.c - 1));
                    current.c--;
                }
                else if (current.c + 1 < Engine.m && m[current.l, current.c + 1] == current.value - 1)
                {
                    path.Add(new Point(current.l, current.c + 1));
                    current.c++;
                }
                current.value--;
            }

            return path;
        }
    }
}
