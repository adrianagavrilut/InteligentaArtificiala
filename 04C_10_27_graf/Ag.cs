using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04C_10_27_graf
{
    public class Ag
    {
        public List<Graph> population;

        public Ag()
        {
            population = new List<Graph>();
        }

        public void initPopulation()
        {
            Graph base_ = new Graph();
            base_.LoadFromFile(@"..\..\TextFile1.txt");
            for (int i = 0; i < Eco.N; i++)
            {
                population.Add(base_.Clone());
            }
        }
    }
}
