using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabWork2
{
    public partial class InsertFirst : Form
    {
        SingleLinkedList current;
        SingleLinkedList f1;
        SingleLinkedList f2;
        SingleLinkedList f3;
        public InsertFirst(SingleLinkedList F1, SingleLinkedList F2, SingleLinkedList F3)
        {
            InitializeComponent();
            f1 = F1;
            f2 = F2;
            f3 = F3;
            current = F1;
            comboBox1.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            current.InsertBeforeFirst((int)NumberNumericUpDown.Value);
            current.DisplayInListBox(listBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    current = f1;
                    break;
                case 1:
                    current = f2;
                    break;
                case 2:
                    current = f3;
                    break;
            }

            current.DisplayInListBox(listBox1);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
