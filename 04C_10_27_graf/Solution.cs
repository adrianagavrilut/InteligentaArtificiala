using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04C_10_27_graf
{
    class Solution
    {
        public float fadec()
        {
            float sum = 0;
            for (int i = 0; i < Engine.demo.n; i++)
            {
                for (int j = 0; j < Engine.demo.n; j++)
                {
                    if (Engine.demo.matrix[i, j] != 0)
                    {
                       // sum += Math.Abs(Engine.GetDistance(i, j) - Engine.demo.matrix[i, j]);
                    }
                }
            }
            return sum;
        }
    }
}
