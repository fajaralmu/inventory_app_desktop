using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Windows
{
    public partial class Welcoming : Form
    {
        private Home home;
        public Welcoming( )
        {
            InitializeComponent();
            home = new Home(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void start(object sender, EventArgs e)
        {
            home.ShowPage();
        }
       
    }
}
