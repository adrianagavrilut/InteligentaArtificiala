using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04C_10_27_graf
{
    public class Solution // solutia va fi un graf
    {
        public Point[] values;

        public float fadec()
        {
            float toReturn = 0;
            foreach (Edge edge in Engine.demo.Edges)
            {
                float local = (float)Eco.GetDistance(edge.start.location, edge.end.location);
                toReturn += (local - edge.cost) * (local - edge.cost);
            }
            return toReturn;

            /*float sum = 0;
            for (int i = 0; i < Engine.demo.n; i++)
            {
                for (int j = 0; j < Engine.demo.n; j++)
                {
                    if (Engine.demo.matrix[i, j] != 0)
                    {
                        // vf daca i,j muchie
                       // sum += Math.Abs(Engine.GetDistance(i, j) - Engine.demo.matrix[i, j]);
                       //Engine.Search(i, Engine.demo), Engine.Search(j, Engine.demo);
                    }
                }
            }
            return sum;*/
        }
    }
}
