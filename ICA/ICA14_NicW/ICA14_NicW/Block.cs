using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ICA14_NicW
{
    class Block
    {
        protected RectangleF rect;
        public bool Outside { get; private set; }

        protected static Random randNum = new Random();

        public Block(PointF location)
        {
            rect = new RectangleF(location, );
        }
    }
}
