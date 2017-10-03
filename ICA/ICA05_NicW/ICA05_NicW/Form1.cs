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

namespace ICA05_NicW
{
    
    public partial class Form1 : Form
    {
        private List<Ball> ballList;
        private int radius = -50;

        public Form1()
        {
            InitializeComponent();
            MouseWheel += Form1_MouseWheel;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            //Scrolling the mouse wheel makes the blocks bigger
            if (e.Delta > 0)
                radius++;
            else
                radius--;

            //Reflect this change on the add button
            UI_button_AddBalls.Text = $"Add exclusive balls ({radius.ToString()})";
        }
    }
}
