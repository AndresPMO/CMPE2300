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

namespace ICA10_NicW
{
    public partial class Form1 : Form
    {
        static Random randNum = new Random();
        List<Point> list = new List<Point>();
        LinkedList<Point> Linked = new LinkedList<Point>();
        CDrawer canvas = new CDrawer();

        public Form1()
        {
            InitializeComponent();
        }
    }
}
