using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA01_NicWasylyshyn
{
    class TrekLamp
    {
        private Color _lampColour;
        private byte _byToggle;
        private byte _byTick;
        private int _border;
        
        public TrekLamp(Color lampColour, byte Toggle, int border = 2)
        {
            Random rand = new Random();

            //Colour of the lamp
            _lampColour = lampColour;
            //The value at which the rectangle is displayed
            _byToggle = Toggle;
            //Increasing value to compare to toggle
            _byTick = (byte)rand.Next(0, 256);
            //Black border around the lamp
            _border = border;
        }

        public TrekLamp() : this(RandColor.GetColor(), 64, 6)
        {
        }

        public void Tick()
        {
            _byTick += 3;
        }

        public void RenderLamp(CDrawer canvas, int lamp)
        {
            //X is determined by the number % scaledWidth
            //Y is determined by the number / scaledWidth
            if(this._byTick > this._byToggle)
            {
                canvas.AddRectangle(lamp % (canvas.ScaledWidth), lamp / (canvas.ScaledWidth), 1, 1, this._lampColour, this._border, Color.Black);
            }
        }
    }
}
