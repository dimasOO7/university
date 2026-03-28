using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabWork2
{
    public partial class Processing : Form
    {
        public Processing(SingleLinkedList F1, SingleLinkedList F2, SingleLinkedList F3)
        {
            InitializeComponent();
            F1.DisplayInListBox(BeforeProcessing);
            F1.Processing(F2, F3);
            F1.DisplayInListBox(AfterProcessing);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
