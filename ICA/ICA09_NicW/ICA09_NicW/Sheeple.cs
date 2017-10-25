using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA09_NicW
{
    class Sheeple
    {
        //Static Variables
        static private Random randNum = new Random();

        //Instance Variables
        public int TotalItems { get; private set; }
        public int CurrentItems { get; private set; }
        public Color Colour { get; private set; }
        public bool Done { get { return CurrentItems == 0; } }

        
        //Instance Constructor
        public Sheeple()
        {
            TotalItems = randNum.Next(2, 8);
            CurrentItems = TotalItems;
            Colour = RandColor.GetColor();
        }

        //Methods
        public void Process()
        {
            CurrentItems--;
        }

        public void ShowSheeple(this CDrawer canvas, List<Queue<Sheeple>> inList)
        {
            //Used for the starting x of the sheeple
            int XPos = 0;
            int YPos = 0;

            foreach(Queue<Sheeple> q in inList)
            {
                //Make sure the queue has something in it 
                if(q.Count > 0)
                {
                    //Go through every sheeple
                    foreach(Sheeple sheep in q)
                    {
                        //Draw a sheeple and move the x to the end of it
                        canvas.AddRectangle(XPos, YPos, sheep.TotalItems, 1, sheep.Colour);
                        XPos += sheep.TotalItems;
                    }
                    //Draw text over the first sheeple in the list
                    canvas.AddText(q.First().CurrentItems.ToString(), 10, 0, YPos, q.First().TotalItems, 1, Color.Black);
                }
                //Move a line down
                YPos++;
                //Reset the x
                XPos = 0;
            }

        }
    }
}
