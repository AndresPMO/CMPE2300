using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_NicW
{
    public partial class Form1 : Form
    {
        //The three lists for all three types of view
        List<Package> plLoaded = new List<Package>();
        List<Package> plInstalled = new List<Package>();
        List<Package> plUnInstalled = new List<Package>();

        public Form1()
        {
            InitializeComponent();
        }
    }
}
