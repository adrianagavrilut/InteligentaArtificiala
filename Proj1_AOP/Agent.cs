using System.Collections.Generic;
using System.Drawing;

namespace AOP_project
{
    public abstract class Agent
    {
        public Point location, target;
        public List<Point> path;

        public Agent()
        {
            path = new List<Point>();
        }

        public void Move()
        {
            if (location == target)
            {
                path.Clear();
                ReachTarget(location);
            }
            if (path.Count == 0 || path == null)
                GetTarget();
            else
            {
                location = path[path.Count - 1];
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

        public override void GetTarget() // Calculate weights for each target based on value / distance
        {
            List<Point> unvisitedTargets = new List<Point>();
            foreach (Point targetPoint in Engine.targets)
                if (!Engine.visitedByExplorer[targetPoint.X, targetPoint.Y])
                    unvisitedTargets.Add(targetPoint);
            /*if (unvisitedTargets.Count == 0)
            {
                // No unvisited targets available, do something else or return
                return;
            }*/
            float[] weights = new float[unvisitedTargets.Count];
            for(int i=0; i< unvisitedTargets.Count; i++)
                weights[i] = Engine.map[unvisitedTargets[i].X, unvisitedTargets[i].Y] / (Engine.ManhattanDistance(location, unvisitedTargets[i]));

            int targetIndex = Engine.MonteCarlo(weights);
            target = unvisitedTargets[targetIndex];

            /*int[,] local = new int[Engine.n, Engine.m];
            for (int i = 0; i < Engine.n; i++)
                for (int j = 0; j < Engine.m; j++)
                {
                    if (Engine.map[i, j] <= 0)
                        local[i, j] = Engine.map[i, j];
                }*/
            //path.Clear();
            //path = Engine.GetPathLee(local, location, target);
            path = Engine.GetPathLee(Engine.map, location, target);
            Engine.targetsForExploiter.Add(target);
            Engine.visitedByExplorer[target.X, target.Y] = true;
        }

        public override void ReachTarget(Point location)
        {
            if(Engine.cells[target.X, target.Y] != ResourceType.Exploiter && Engine.cells[target.X, target.Y] != ResourceType.Transporter)
            {
                Engine.SetCell(target.X, target.Y, ResourceType.Explorer);
                Engine.explorerFlaggedValues.Add(Engine.map[target.X, target.Y]);
            }
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

        public override void GetTarget()  // Shuffle the list using Fisher-Yates algorithm
        {
            int i = Engine.targetsForExploiter.Count;
            while (i > 1)
            {
                i--;
                int k = Engine.rnd.Next(i + 1);
                Point temp = Engine.targetsForExploiter[k];
                Engine.targetsForExploiter[k] = Engine.targetsForExploiter[i];
                Engine.targetsForExploiter[i] = temp;
            }

            foreach (Point targetPoint in Engine.targetsForExploiter)
            {
                if (!Engine.visitedByExploiter[targetPoint.X, targetPoint.Y])
                {
                    target = targetPoint;
                    break;
                }
            }
            Engine.visitedByExploiter[target.X, target.Y] = true;
            //path.Clear();
            path = Engine.GetPathLee(Engine.map, location, target);
            Engine.targetsForTransporter.Add(target);
        }

        public override void ReachTarget(Point location)
        {
            if (Engine.cells[target.X, target.Y] != ResourceType.Transporter)
            {
                Engine.SetCell(target.X, target.Y, ResourceType.Exploiter);
                Engine.exploiterFlaggedValues.Add(Engine.map[target.X, target.Y]);
            }
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

        public override void GetTarget()  // Find the closest unvisited target
        {            
            //somehow the list targets for transporter contains targets for explorer
            List<Point> unvisitedTargets = new List<Point>();
            foreach (Point targetPoint in Engine.targetsForTransporter)
                if (!Engine.visitedByTransporter[targetPoint.X, targetPoint.Y])
                    unvisitedTargets.Add(targetPoint);

            Point closestTarget = Engine.FindClosestTarget(location, unvisitedTargets);
            target = closestTarget;

            Engine.visitedByTransporter[target.X, target.Y] = true;
            path = Engine.GetPathLee(Engine.map, location, target);
        }

        public override void ReachTarget(Point target)
        {

            if (Engine.cells[target.X, target.Y] != ResourceType.Explorer)
            {
                Engine.SetCell(target.X, target.Y, ResourceType.Transporter);
                Engine.transporterFlaggedValues.Add(Engine.map[target.X, target.Y]);
                Engine.winnings += Engine.map[target.X, target.Y];
            }
        }
    }
}
