using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04C_10_27_graf
{
    public class Ag
    {
        public List<Graph> population;
        public List<Graph> parents;

        public Ag()
        {
            population = new List<Graph>();
            parents = new List<Graph>();
        }

        public void initPopulation()
        {
            Graph base_ = new Graph();
            base_.LoadFromFile(@"..\..\TextFile1.txt");
            for (int i = 0; i < Eco.N; i++)
                population.Add(base_.Clone());
        }

        public void Draw (Graphics handler, ListBox T)
        {
            for (int i = 0; i < 10; i++)
                population[i].Draw(handler, T);
        }

        public void Selection()
        {
            population.Sort(delegate (Graph A, Graph B) { return B.fadec().CompareTo(A.fadec()); });
            parents.Clear();
            for (int i = 0; i < Eco.k; i++)
                parents.Add(population[i]);
            population.Clear();
        }

        public Graph crossOver()
        {
            int idx1, idx2;
            do
            {
                idx1 = Eco.rnd.Next(Eco.k);
                idx2 = Eco.rnd.Next(Eco.k);
            } while (idx1 == idx2);

            Graph toReturn = 
        }
    }
}
