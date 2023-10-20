using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03C_10_20
{
    public class Sol
    {
        public float[] x;

        public Sol()
        {
            x = new float[Ag.n];
            for (int i = 0; i < Ag.n; i++)
                x[i] = Ag.random();
        }

        public void setTest()
        {
            //x = new float[] { -2, -1, 0, 1, 2, 3, 4};
            x = new float[] { -2, -1.2f, 0.4f, 1, 2, 3, 4 };
        }

        public float fadec()
        {
            float sumGlobal = 0;
            for (int j = 0; j < Ag.n; j++)
            {
                Console.Write("");
                float sumLocal = 0;
                for (int i = 0; i < Ag.n; i++)
                    sumLocal += Ag.A[j, i] * x[i];
                sumLocal -= Ag.T[j];
                sumGlobal += Math.Abs(sumLocal);
            }
            return sumGlobal;
        }

        public string View()
        {
            string toReturn = "";
            for (int i = 0; i < Ag.n; i++)
                toReturn += x[i] + " ";
            toReturn += "fadec: " + fadec();
            return toReturn;
        }
    }
}
