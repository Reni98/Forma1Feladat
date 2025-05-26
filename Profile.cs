using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forma1Projekt
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            string nev = Session.felnev;
            label1.Text = ($"Üdv {nev}");
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }
    }
}
