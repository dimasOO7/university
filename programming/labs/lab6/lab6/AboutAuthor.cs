using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class AboutAuthor : Form
    {

        private Form mainMenu;
        public AboutAuthor(Form menu)
        {
            InitializeComponent();
            mainMenu = menu;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            Close();
        }
    }
}
