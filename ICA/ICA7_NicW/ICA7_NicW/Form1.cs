using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA7_NicW
{
    public partial class Form1 : Form
    {
        List<Block> blockList = new List<Block>();
        public Form1()
        {
            InitializeComponent();
        }

        private void UI_trackBar_Length_Scroll(object sender, EventArgs e)
        {
            UI_button_Length.Text = $"Longer than {UI_trackBar_Length.Value}";
        }

        private void UI_button_Populate_Click(object sender, EventArgs e)
        {
            int runningWidth = 0;
            //Empty the list for new blocks to be added
            blockList.Clear();
            Block temp;

            //Only go up to 80% of the area
            while(runningWidth < ((Block.canvas.ScaledHeight * Block.canvas.ScaledWidth) / Block.height) * 0.8)
            {
                temp = new Block();
                //Make sure this block isn't in the list already
                if (blockList.IndexOf(temp) < 0)
                {
                    runningWidth += temp.width;
                    blockList.Add(temp);
                }
            }
            //Render all the blocks
            ShowBlocks();
        }

        private void ShowBlocks()
        {
            Point location = new Point(0, 0);
            Block.canvas.Clear();

            for(int i = 0; i < blockList.Count; i++)
            {
                //If the block would go off the canvas
                if(blockList[i].width + location.X > Block.canvas.ScaledWidth)
                {
                    //Reset the X for a new row
                    location.X = 0;
                    //Go down by the height of the block
                    location.Y += Block.height;
                }
                blockList[i].ShowBlock(location);
                location.X += blockList[i].width;
            }

            Block.canvas.Render();
        }
    }
}
