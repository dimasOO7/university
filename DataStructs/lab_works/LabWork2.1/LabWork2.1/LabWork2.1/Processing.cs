using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabWork2._1
{
    public partial class Processing : Form
    {
        internal Processing(CycleDoubleLinkedList F1, CycleDoubleLinkedList F2, CycleDoubleLinkedList F3)
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
