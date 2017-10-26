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

        public void ShowSheeple(CDrawer canvas, Sheeple sheep, int XPos, int YPos)
        {  
            //Draw a sheeple
            canvas.AddRectangle(XPos, YPos, sheep.TotalItems, 1, sheep.Colour);
            if(XPos == 0)
                canvas.AddText(sheep.CurrentItems.ToString(), 10, XPos, YPos, sheep.TotalItems, 1, Color.Black);
        }
    }
}
