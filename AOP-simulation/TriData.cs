using System;

namespace AOP_simulation
{
    public class TriData
    {
        public static Random rnd = new Random();
        public int l, c, v;

        public TriData()
        {
            l = rnd.Next(10);
            c = rnd.Next(10);
            v = rnd.Next(10);
        }

        public TriData(int l, int c, int v)
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
