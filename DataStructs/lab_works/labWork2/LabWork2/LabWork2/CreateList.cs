using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabWork2
{
    public partial class CreateList : Form
    {
        public CreateList()
        {
            InitializeComponent();
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && (sender as TextBox).Text.EndsWith(","))
            {
                e.Handled = true;
            }
        }
    }
}
