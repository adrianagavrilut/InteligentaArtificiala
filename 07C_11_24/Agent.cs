using System.Collections.Generic;
using System.Drawing;

namespace _07C_11_24
{
    public abstract class Agent
    {
        public Point location;
        Point target;
        public int ID;
        public List<Point> path;

        public Agent()
        {
            path = new List<Point>();
        }

        public virtual void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Black, location.X * Engine.deltaX - 5, location.Y * Engine.deltaY - 5, 11, 11);
        }

        public virtual void Tick(Map map)
        {
            if (path.Count != 0)
            {
                if (CanMove())
                {
                    location = new Point(path[0].X, path[0].Y);
                    path.RemoveAt(0);
                }
            }
            else
                Update(map);
        }

        public bool CanMove()//ToDo matrix update
        {
            return true;
        }

        public virtual void Update(Map map)
        {
            if (path.Count == 0)
            {
                SetTarget(map);
            }
        }

        public void SetTarget(Map map)
        {
            int[,] matrix = map.ConvertToMatrix();
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            target = new Point(Engine.rnd.Next(n), Engine.rnd.Next(m));
            path = GetPathLee(map, target);
        }

        public virtual List<Point> GetPathLee(Map map, Point target)
        {
            List<Point> pathLee = new List<Point>();
            int[,] matrixCpy = GetMatrixForPathLee(map, location);
            Demo demo = new Demo(target.X, target.Y, matrixCpy[target.X, target.Y]);
            pathLee.Add(target);
            while (demo.v > 1)
            {
                if (demo.l - 1 >= 0 && matrixCpy[demo.l - 1, demo.c] == demo.v - 1)
                {
                    pathLee.Add(new Point(demo.l - 1, demo.c));
                    demo.l--;
                }
                else if (demo.l + 1 < map.n && matrixCpy[demo.l + 1, demo.c] == demo.v - 1)
                {
                    pathLee.Add(new Point(demo.l + 1, demo.c));
                    demo.l++;
                }
                else if (demo.c - 1 >= 0 && matrixCpy[demo.l, demo.c - 1] == demo.v - 1)
                {
                    pathLee.Add(new Point(demo.l, demo.c - 1));
                    demo.c--;
                }
                else if (demo.c + 1 < map.m && matrixCpy[demo.l, demo.c + 1] == demo.v - 1)
                {
                    pathLee.Add(new Point(demo.l, demo.c + 1));
                    demo.c++;
                }
                demo.v--;
            }
            return pathLee;
        }
        public static int[,] GetMatrixForPathLee(Map map, Point startPoint)
        {
            int[,] matrixCopy = GetMatrixCopy(map);
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
                if (t.l + 1 < map.n && matrixCopy[t.l + 1, t.c] == 0)//S
                {
                    A.Push(new Demo(t.l + 1, t.c, t.v + 1));
                    matrixCopy[t.l + 1, t.c] = t.v + 1;
                }
                if (t.c - 1 >= 0 && matrixCopy[t.l, t.c - 1] == 0)//V
                {
                    A.Push(new Demo(t.l, t.c - 1, t.v + 1));
                    matrixCopy[t.l, t.c - 1] = t.v + 1;
                }
                if (t.c + 1 < map.m && matrixCopy[t.l, t.c + 1] == 0)//E
                {
                    A.Push(new Demo(t.l, t.c + 1, t.v + 1));
                    matrixCopy[t.l, t.c + 1] = t.v + 1;
                }
            }
            return matrixCopy;
        }


        public static int[,] GetMatrixCopy(Map map)
        {
            int[,] tmp = map.ConvertToMatrix();
            int[,] cpy = new int[map.n, map.m];
            for (int i = 0; i < map.n; i++)
            {
                for (int j = 0; j < map.m; j++)
                {
                    cpy[i, j] = tmp[i, j];
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
            handler.DrawString("explorer", new Font("Arial", 9, FontStyle.Bold), new SolidBrush(Color.Blue), new PointF(location.X * Engine.deltaX, location.Y * Engine.deltaY));
        }
    }

    public class Exploiter : Agent
    {
        public int pRate; //process rate

        public override void Draw(Graphics handler)
        {
            base.Draw(handler);
            handler.DrawString("exploiter", new Font("Arial", 9, FontStyle.Bold), new SolidBrush(Color.Purple), new PointF(location.X * Engine.deltaX, location.Y * Engine.deltaY));
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
            handler.DrawString("transporter", new Font("Arial", 9, FontStyle.Bold), new SolidBrush(Color.Green), new PointF(location.X * Engine.deltaX, location.Y * Engine.deltaY));
        }
    }
}
