using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA7_NicW
{
    class Block
    {
        //static variables
        public static CDrawer canvas { get; private set; }
        public static int height { get; private set; }
        private static Random randNum = new Random(1);

        //instance variables
        public int width { get;  private set; }
        public bool Highlight { get; private set; }
        private Color colour;
    }
}
