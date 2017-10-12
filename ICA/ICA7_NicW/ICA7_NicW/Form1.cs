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
            MouseMove += Form1_MouseMove;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            blockList.ForEach(arg => arg.Highlight = false);
            blockList.FindAll(arg => (arg.width + 10 > e.X && arg.width - 10 < e.X) ).ForEach(arg => arg.Highlight = true);
            ShowBlocks();
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
            trackBarMinMax();
            Text = $"Blocks added: {blockList.Count}";
        }

        private void ShowBlocks()
        {
            //Start in the top left corner
            Point location = new Point(0, 0);

            Block.canvas.Clear();

            //Go through the whole list of blocks
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
                //Put the block on the canvas and move to it's edge
                blockList[i].ShowBlock(location);
                location.X += blockList[i].width;
            }

            Block.canvas.Render();
        }

        //Sorts
        private void UI_button_Colour_Click(object sender, EventArgs e)
        {
            blockList.Sort();
            ShowBlocks();
        }

        private void UI_button_Width_Click(object sender, EventArgs e)
        {
            blockList.Sort(Block.CompareWidth);
            ShowBlocks();
        }

        private void UI_button_WidthDesc_Click(object sender, EventArgs e)
        {
            blockList.Sort((arg1, arg2) => arg1.width.CompareTo(arg2.width) * -1);
            ShowBlocks();
        }

        private void UI_button_WidthColour_Click(object sender, EventArgs e)
        {
            blockList.Sort(Block.CompareWidthColour);
            ShowBlocks();
        }

        //Removal
        private void UI_button_Bright_Click(object sender, EventArgs e)
        {
            blockList.RemoveAll(Block.Brightness);
            ShowBlocks();
            trackBarMinMax();
        }

        private void UI_button_Length_Click(object sender, EventArgs e)
        {
            Text = $"Blocks removed: {blockList.RemoveAll(arg => arg.width > UI_trackBar_Length.Value)}";
            ShowBlocks();
            trackBarMinMax();
        }

        //track bar shizzle
        private void trackBarMinMax()
        {
            UI_trackBar_Length.Minimum = blockList.Min(arg => arg.width);
            UI_trackBar_Length.Maximum = blockList.Max(arg => arg.width);
            UI_trackBar_Length.Value = (UI_trackBar_Length.Maximum + UI_trackBar_Length.Minimum) / 2;
            UI_button_Length.Text = $"Longer than {UI_trackBar_Length.Value}";
        }
    }
}
