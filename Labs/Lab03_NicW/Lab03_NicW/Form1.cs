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
using MyDrawers;

namespace Lab03_NicW
{
    public partial class Form1 : Form
    {

        PictDrawer canvas = new PictDrawer(Properties.Resources.Crash, false, false);
        public Form1()
        {
            InitializeComponent();
        }
    }
}
