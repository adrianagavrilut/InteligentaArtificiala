using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06C_11_17_AOP
{
    public class Demo
    {
        public static Random rnd = new Random();
        int x, y, z;

        public Demo()
        {
            x = rnd.Next(10);
            y = rnd.Next(10);
            z = rnd.Next(10);
        }

        public override string ToString()
        {
            return " (" + x + " " + y + " " + z + ") ";
        }
    }
}
