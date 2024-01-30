using System;
using System.Collections.Generic;
using System.Drawing;

namespace Dispersie_graf
{
    public class Sol
    {
        public List<Point> points;

        public Sol()
        {
            points = new List<Point>();
            for (int i = 0; i < Engine.n; i++)
                points.Add(new Point(Engine.rnd.Next(10, Engine.pctBx.Width - 10), Engine.rnd.Next(10, Engine.pctBx.Height - 10)));
        }

        public Sol(List<Point> points)
        {
            this.points = points;
        }

        public double CalculateFitness()
        {
            double result = 0;
            for (int i = 0; i < Engine.n - 1; i++)
                for (int j = i + 1; j < Engine.n; j++)
                    if (Engine.matrix[i, j] != 0)
                        result += Math.Abs(Engine.GetDistance(points[i], points[j]) - Engine.matrix[i, j] * Engine.zoom);
            return result;
        }

        public Sol Crossover(Sol parent)
        {
            int cut = Engine.rnd.Next(1, Engine.n - 1);
            List<Point> temp = new List<Point>();

            for (int i = 0; i < cut; i++)
                temp.Add(points[i]);

            for (int i = cut; i < Engine.n; i++)
                temp.Add(parent.points[i]);

            return new Sol(temp);
        }

        public void Mutate()
        {
            int i = Engine.rnd.Next(Engine.n);
            points[i] = new Point(Engine.rnd.Next(12, Engine.pctBx.Width - 12), Engine.rnd.Next(12, Engine.pctBx.Height - 12));
        }

        public void View()
        {
            for (int i = 0; i < Engine.n - 1; i++)
                for (int j = i + 1; j < Engine.n; j++)
                    if (Engine.matrix[i, j] != 0)
                    {
                        double distance = Math.Round(Engine.GetDistance(points[i], points[j]), 2) / Engine.zoom;
                        Engine.grp.DrawLine(new Pen(Color.Black, 2), points[i], points[j]);
                        Engine.grp.DrawString(distance.ToString(), new Font("Arial", 9), new SolidBrush(Color.Black), (points[i].X + points[j].X) / 2, (points[i].Y + points[j].Y) / 2);
                    }

            for (int i = 0; i < Engine.n; i++)
            {
                Engine.grp.DrawEllipse(new Pen(Color.Black, 4), points[i].X - 10, points[i].Y - 10, 20, 20);
                Engine.grp.FillEllipse(new SolidBrush(Color.White), points[i].X - 10, points[i].Y - 10, 20, 20);
                Engine.grp.DrawString(i.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), points[i].X - 7, points[i].Y - 8);
            }
        }
    }
}
