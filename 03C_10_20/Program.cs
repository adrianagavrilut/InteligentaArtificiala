using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03C_10_20
{
    class Program
    {
        public static Eco demo;

        static void Main(string[] args)
        {
            Ag.LoadFromFile(@"..\..\TextFile1.txt");
            Ag.N = 1000;
            Ag.k = 20;

            /*demo = new Eco();

            for (int i = 0; i < 100; i++)
            {
                demo.Ord();
                demo.Transfer();
                demo.Update();
            }
            demo.Ord();
            Console.WriteLine(demo.View());*/

            Sol test = new Sol();
            test.setTest();
            Console.WriteLine(test.View());

            Console.ReadKey();
        }
    }
}
