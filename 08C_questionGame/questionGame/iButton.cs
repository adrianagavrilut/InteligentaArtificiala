using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace questionGame
{
    class iButton : Button
    {
        public bool selected;
        public int idx;
        public iButton () : base ()
        {
            selected = false;
            idx = -1;
        }
    }
}
