using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07C_11_24
{
    public class Demo
    {
        public static Random rnd = new Random();
        public int l, c, v;

        public Demo()
        {
            l = rnd.Next(10);
            c = rnd.Next(10);
            v = rnd.Next(10);
        }

        public Demo(int l, int c, int v)
        {
            this.l = l;
            this.c = c;
            this.v = v;
        }

        public override string ToString()
        {
            return " (" + l + " " + c + " " + v + ") ";
        }
    }
}
