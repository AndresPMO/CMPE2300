using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using MyDrawers;

namespace ICA16_NicW
{
    class Snake : BaseShape, IMortal
    {
        private LinkedList<Point> segments = new LinkedList<Point>();
        private int length;
        private int lives;

        public Snake(Point location, int inLength) : base(location, Color.Red)
        {
            length = inLength;
            lives = length * 10;
        }

        protected override Point VirtualMove()
        {
            //Get the base to do the move
            //Add it to the front of our snake
            segments.AddFirst(base.VirtualMove());
            //If the snake is too long, remove the tail
            if(segments.Count > length)
            {
                segments.RemoveLast();
            }
            //Return the new head point
            return segments.First.Value;
        }

        protected override void VirtualPaint()
        {
            float countdown = length;
            _canvas.AddCenteredEllipse(segments.First.Value, 3, 3, Color.Red);
            for(LinkedListNode<Point> node = segments.First; node.Next != null; node = node.Next)
            {
                _canvas.AddLine(node.Value.X, node.Value.Y, node.Next.Value.X, node.Next.Value.Y, Color.FromArgb((int)(_color.A * (countdown / length)), _color));
                countdown--;
            }
        }

        public bool Step()
        {
            //Check if lives is greater than 0 after decrementing
            return --lives > 0;
        }
    }
}
