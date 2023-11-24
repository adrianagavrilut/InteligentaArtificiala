using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06C_11_17_AOP
{
    public abstract class Agent
    {
        public Point location;
        public int ID;
        public List<Point> path;
        Point startPoint;
        Point target;

        public virtual void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Black, location.X * Engine.deltaX - 5, location.Y * Engine.deltaY - 5, 11, 11);
        }

        public virtual void DeterminePath()
        {
            startPoint = location;
            target = new Point(Engine.n - 1, Engine.m - 1);
            path = GetPathLee(target);
        }

        public virtual List<Point> GetPathLee(Point target)
        {
            List<Point> pathLee = new List<Point>();
            int[,] matrixCpy = getMatrixForPathLee(startPoint);
            Demo demo = new Demo(target.X, target.Y, matrixCpy[target.X, target.Y]);
            pathLee.Add(target);
            while (demo.v > 1)
            {
                if (demo.l - 1 >= 0 && matrixCpy[demo.l - 1, demo.c] == demo.v - 1)
                {
                    pathLee.Add(new Point(demo.l - 1, demo.c));
                    demo.l--;
                }
                else if (demo.l + 1 < Engine.n && matrixCpy[demo.l + 1, demo.c] == demo.v - 1)
                {
                    pathLee.Add(new Point(demo.l + 1, demo.c));
                    demo.l++;
                }
                else if (demo.c - 1 >= 0 && matrixCpy[demo.l, demo.c - 1] == demo.v - 1)
                {
                    pathLee.Add(new Point(demo.l, demo.c - 1));
                    demo.c--;
                }
                else if (demo.c + 1 < Engine.m && matrixCpy[demo.l, demo.c + 1] == demo.v - 1)
                {
                    pathLee.Add(new Point(demo.l, demo.c + 1));
                    demo.c++;
                }
                demo.v--;
            }
            return pathLee;
        }
        public static int[,] getMatrixForPathLee(Point startPoint)
        {
            int[,] matrixCopy = GetMatrixCopy(Engine.matrix);
            MyQueue<Demo> A = new MyQueue<Demo>();
            A.Push(new Demo(startPoint.X, startPoint.Y, 1));
            matrixCopy[startPoint.X, startPoint.Y] = 1;

            while (!A.IsEmpty())
            {
                Demo t = A.Pop();
                if (t.l - 1 >= 0 && matrixCopy[t.l - 1, t.c] == 0)//N
                {
                    A.Push(new Demo(t.l - 1, t.c, t.v + 1));
                    matrixCopy[t.l - 1, t.c] = t.v + 1;
                }
                if (t.l + 1 < Engine.n && matrixCopy[t.l + 1, t.c] == 0)//S
                {
                    A.Push(new Demo(t.l + 1, t.c, t.v + 1));
                    matrixCopy[t.l + 1, t.c] = t.v + 1;
                }
                if (t.c - 1 >= 0 && matrixCopy[t.l, t.c - 1] == 0)//V
                {
                    A.Push(new Demo(t.l, t.c - 1, t.v + 1));
                    matrixCopy[t.l, t.c - 1] = t.v + 1;
                }
                if (t.c + 1 < Engine.m && matrixCopy[t.l, t.c + 1] == 0)//E
                {
                    A.Push(new Demo(t.l, t.c + 1, t.v + 1));
                    matrixCopy[t.l, t.c + 1] = t.v + 1;
                }
            }
            return matrixCopy;
        }


        public static int[,] GetMatrixCopy(int[,] mtrx)
        {
            int[,] cpy = new int[Engine.n, Engine.m];
            for (int i = 0; i < Engine.n; i++)
            {
                for (int j = 0; j < Engine.m; j++)
                {
                    cpy[i, j] = mtrx[i, j];
                }
            }
            return cpy;
        }
    }

    public class Explorer : Agent
    {
        public int radius;

        public override void Draw(Graphics handler)
        {
            base.Draw(handler);
            handler.DrawString("explorer", new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Blue), new PointF(location.X * Engine.deltaX, location.Y * Engine.deltaY));
        }
    }

    public class Exploiter : Agent
    {
        public int pRate; //process rate

        public override void Draw(Graphics handler)
        {
            base.Draw(handler);
            handler.DrawString("exploiter", new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Red), new PointF(location.X * Engine.deltaX, location.Y * Engine.deltaY));
        }
    }

    public class Transporter : Agent
    {
        public int capacity;
        public int luRate; // loading, unloading rate
        public int crtCapacity;

        public override void Draw(Graphics handler)
        {
            base.Draw(handler);
            handler.DrawString("transporter", new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Green), new PointF(location.X * Engine.deltaX, location.Y * Engine.deltaY));
        }
    }
}
