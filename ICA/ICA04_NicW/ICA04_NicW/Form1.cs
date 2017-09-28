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

namespace ICA04_NicW
{
    public partial class Form1 : Form
    {
        private int blockSize = 80;
        private List<Block> blockList = new List<Block>();

        public Form1()
        {
            InitializeComponent();
            MouseWheel += Form1_MouseWheel;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            //Scrolling the mouse wheel makes the blocks bigger
            if (e.Delta > 0)
                blockSize++;
            else
                blockSize--;

            //Reflect this change on the add button
            UI_button_Add.Text = "Add Blocks: Size - " + blockSize.ToString();
        }

        private void UI_button_Add_Click(object sender, EventArgs e)
        {
            //How many blocks were added or removed from the list
            int blocksAdded = 0;
            int blocksRemoved = 0;
            //Block to check if we can add it
            Block temp;

            while(blocksAdded < 25 && blocksRemoved < 1000)
            {
                //make a new block
                temp = new Block(blockSize);
                
                //Found an overlap
                if (blockList.IndexOf(temp) >= 0)
                {
                    //Didn't add a block, counts as removed
                    blocksRemoved++;
                }
                //No overlapping
                else
                {
                    //Add the block to the list
                    blockList.Add(temp);
                    blocksAdded++;
                }
            }
            
            //Clear the canvas and then render the blocks
            Block.Load = true;
            for(int i = 0; i < blockList.Count; i++)
            {
                blockList[i].ShowBlock();
            }
            Block.Load = false;

            //Display the blocks removed on the progress bar
            UI_progressBar_Discard.Value = blocksRemoved;
            //Display how succesful we were on the form title
            Text = "Loaded " + blocksAdded.ToString() + " unique blocks, with " + blocksRemoved.ToString() + " discards";
        }
    }
}
