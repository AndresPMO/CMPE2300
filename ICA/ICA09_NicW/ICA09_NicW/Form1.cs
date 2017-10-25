using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA09_NicW
{
    public partial class Form1 : Form
    {
        Stack<Sheeple> stackSheeple;
        List<Queue<Sheeple>> ListQueue;
        CDrawer canvas;
        const int scale = 20;
        int Processed;
        bool running;

        public Form1()
        {
            InitializeComponent();
        }



        private void ThreadProcess()
        {

        }
    }
}
