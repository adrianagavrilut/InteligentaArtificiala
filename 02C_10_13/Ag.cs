using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02C_10_13
{
    public static class Ag
    {
        public static int N, n, k;
        public static int[] T;
        public static int[,] A;
        public static Random rnd = new Random();

        public static void LoadFromFile(string fileName)
        {
            TextReader load = new StreamReader(fileName);
            n = int.Parse(load.ReadLine());
            A = new int[n, n];
            T = new int[n];
            for (int i = 0; i < n; i++)
            {
                string[] data = load.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                    A[i, j] = int.Parse(data[j]);
            }
            for (int i = 0; i < n; i++)
                T[i] = int.Parse(load.ReadLine());
        }

        public static Sol mutate(Sol par)
        {
            Sol toReturn = new Sol();
            for (int i = 0; i < Ag.n; i++)
                toReturn.x[i] = par.x[i];
            int idx = Ag.rnd.Next(Ag.n);
            toReturn.x[idx] = Ag.random();
            return toReturn;
        }

        public static Sol crossOver(Sol par1, Sol par2)
        {
            Sol toReturn = new Sol();
            int x = Ag.rnd.Next(1, Ag.n - 1);
            for (int i = 0; i < x; i++)
                toReturn.x[i] = par1.x[i];
            for (int i = x; i < Ag.n; i++)
                toReturn.x[i] = par2.x[i];
            return toReturn;
        }

        public static float random()
        {
            return (float)rnd.NextDouble();
        }
    }
}
