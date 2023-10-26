using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03C_10_20
{
    class Program
    {
        public static Eco ecosystem;

        static void Main(string[] args)
        {
            Ag.LoadFromFile(@"..\..\TextFile1.txt");
            Ag.N = 1000;
            Ag.k = 20;
            Ag.crtTime = 0;
            Ag.maxTime = 10000;

            ecosystem = new Eco();
            foreach (string s in ecosystem.View())
                Console.WriteLine(s);
            Console.WriteLine();

            do
            {
                ecosystem.Ord();

                Console.WriteLine();
                foreach (string s in ecosystem.View())
                    Console.WriteLine(s);

                ecosystem.Transfer();
                ecosystem.Update();
                Ag.crtTime++;

            } while (Ag.crtTime < Ag.maxTime);

            Console.ReadKey();
        }
    }
}
