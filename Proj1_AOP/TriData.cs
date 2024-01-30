using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP_project
{
    public class TriData
    {
        public int l, c, value;

        public TriData() { }
        public TriData(int i, int j, int value)
        {
            this.l = i;
            this.c = j;
            this.value = value;
        }

        public override string ToString()
        {
            return "(" + l + ", " + c + ", " + value + ")";
        }
    }
}
