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

namespace ICA12_NicW
{
    public partial class Form1 : Form
    {
        RectDrawer rectCanvas = new RectDrawer();
        PictDrawer pictCanvas = new PictDrawer();

        public Form1()
        {
            InitializeComponent();
        }
    }
}
