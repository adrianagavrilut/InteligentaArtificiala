﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02C_10_13
{
    public class Eco
    {
        public List<Sol> population;
        public List<Sol> parents;

        public Eco()
        {
            population = new List<Sol>();
            parents = new List<Sol>();
            for (int i = 0; i < Ag.N; i++)
                population.Add(new Sol());
        }

        public void Ord()
        {
            population.Sort(delegate (Sol A, Sol B) { return A.fadec().CompareTo(B.fadec()); });
        }

        public void Transfer()
        {
            parents.Clear();
            for (int i = 0; i < Ag.k; i++)
                parents.Add(population[i]);
        }

        public void Update()
        {
            int x, y;
            population.Clear();
            for (int i = 0; i < Ag.N; i++)
            {
                do
                {
                    x = Ag.rnd.Next(Ag.k);
                    y = Ag.rnd.Next(Ag.k);
                } while (x == y);
                population.Add(Ag.mutate(Ag.crossOver(parents[x], parents[y])));
            }

        }

        public string View()
        {
            return population[0].View();
        }
    }
}
