using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabWork2._1
{
    public partial class ShowList : Form
    {
        internal ShowList(string text, CycleDoubleLinkedList list)
        {
            InitializeComponent();
            list.DisplayInListBox(listBox1);
            Text = text;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
