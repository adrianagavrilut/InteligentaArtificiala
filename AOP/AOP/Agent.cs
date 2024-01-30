using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public abstract class Agent
    {
        public Point location, target;
        public List<Point> path;

        public Agent()
        {
            //location = new Point(0, 0);
            path = new List<Point>();
        }

        public void Move()
        {
            if (location == target)
                ReachTarget(location);
            if (path.Count == 0)
                GetTarget();
            else
            {
                location.X = path[path.Count - 1].X;
                location.Y = path[path.Count - 1].Y;
                path.RemoveAt(path.Count - 1);
            }
        }

        public abstract void GetTarget();

        public abstract void ReachTarget(Point target);

        public abstract void Draw();
    }

    
    public class Explorer : Agent
    {
        public override void Draw()
        {
            Engine.grp.FillEllipse(Brushes.DarkGreen, location.X * Engine.length, location.Y * Engine.length, Engine.length, Engine.length);
            Engine.grp.DrawString("exr", new Font("Calisto MT", 10, FontStyle.Regular), new SolidBrush(Color.White), new PointF(location.X * Engine.length, location.Y * Engine.length));
            Engine.display.Image = Engine.bmp;
        }

        public override void GetTarget()
        {
            float[] pounds = new float[Engine.targets.Count];
            for(int i=0; i< Engine.targets.Count; i++)
            {
                pounds[i] = Engine.map[Engine.targets[i].X, Engine.targets[i].Y] / (Engine.DistManhatan(location, Engine.targets[i]));
            }
            int targetIndex = Engine.AMC(pounds);
            target = Engine.targets[targetIndex];

            int[,] local = new int[Engine.n, Engine.m];
            for (int i = 0; i < Engine.n; i++)
                for (int j = 0; j < Engine.m; j++)
                {
                    if (Engine.map[i, j] <=0)
                        local[i, j] = Engine.map[i, j];
                    //robotii sunt si ei ziduri
                }
            //path.Clear();
            path = Engine.GetPathLee(local, location, target);
            Engine.targetsForExploiter.Add(target);
        }

        public override void ReachTarget(Point location)
        {
            Engine.SetCell(target.X, target.Y, ResourceType.Explorer);
            Engine.targets.Remove(target);
        }
    }

    public class Exploiter : Agent
    {
        public override void Draw()
        {
            Engine.grp.FillEllipse(Brushes.Maroon, location.X * Engine.length, location.Y * Engine.length, Engine.length, Engine.length);
            Engine.grp.DrawString("ext", new Font("Calisto MT", 10, FontStyle.Regular), new SolidBrush(Color.White), new PointF(location.X * Engine.length, location.Y * Engine.length));
            Engine.display.Image = Engine.bmp;
        }

        public override void GetTarget()
        {
            //should use the list from engine.targets and when check collision i=with the point to change color for string
            // Create a copy of the targets list
            /*List<Point> exploitTargets = new List<Point>();

            foreach (Point itemTarget in Engine.targets)
            {
                if (Engine.cells[itemTarget.X, itemTarget.Y] == ResourceType.Explorer)
                {
                    exploitTargets.Add(itemTarget);
                }
            }*/

            // Shuffle the list using Fisher-Yates algorithm
            int i = Engine.targetsForExploiter.Count;
            while (i > 1)
            {
                i--;
                int k = Engine.rnd.Next(i + 1);
                Point temp = Engine.targetsForExploiter[k];
                Engine.targetsForExploiter[k] = Engine.targetsForExploiter[i];
                Engine.targetsForExploiter[i] = temp;
            }

            // Select the first target from the shuffled list
            target = Engine.targetsForExploiter[0];

            //path.Clear();
            path = Engine.GetPathLee(Engine.map, location, target);
            Engine.targetsForTransporter.Add(target);
        }

        public override void ReachTarget(Point location)
        {
            /*Engine.colorPollution = Color.SpringGreen;
            Engine.targetValue = Engine.map[location.X, location.Y];*/
            /*Engine.grp.DrawString(Engine.map[target.X, target.Y].ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Gold), target.X * Engine.length + 3, target.Y * Engine.length + 5);
            Engine.display.Image = Engine.bmp;*/
            Engine.SetCell(target.X, target.Y, ResourceType.Exploiter);
            //Engine.targets.Remove(target);

        }
    }

    public class Transporter : Agent
    {

        public override void Draw()
        {
            Engine.grp.FillEllipse(Brushes.Indigo, location.X * Engine.length, location.Y * Engine.length, Engine.length, Engine.length);
            Engine.grp.DrawString("trp", new Font("Calisto MT", 10, FontStyle.Regular), new SolidBrush(Color.White), new PointF(location.X * Engine.length, location.Y * Engine.length));
            Engine.display.Image = Engine.bmp;
        }

        public override void GetTarget()
        {
            int i = Engine.targetsForTransporter.Count;
            while (i > 1)
            {
                i--;
                int k = Engine.rnd.Next(i + 1);
                Point temp = Engine.targetsForExploiter[k];
                Engine.targetsForExploiter[k] = Engine.targetsForExploiter[i];
                Engine.targetsForExploiter[i] = temp;
            }

            // Select the first target from the shuffled list
            target = Engine.targetsForExploiter[0];

            //path.Clear();
            path = Engine.GetPathLee(Engine.map, location, target);
        }

        public override void ReachTarget(Point target)
        {
            Engine.SetCell(target.X, target.Y, ResourceType.Transporter);
            //Engine.targets.Remove(target);
        }
    }
}
