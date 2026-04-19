using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabWork2._1
{
    public partial class DeleteAt : Form
    {
        CycleDoubleLinkedList current;
        CycleDoubleLinkedList f1;
        CycleDoubleLinkedList f2;
        CycleDoubleLinkedList f3;
        internal DeleteAt(CycleDoubleLinkedList F1, CycleDoubleLinkedList F2, CycleDoubleLinkedList F3)
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
            if (current.DeleteAt((int)NumberNumericUpDown.Value))
            {
                current.DisplayInListBox(listBox1);
            }
            else
            {
                if(current.Count() == 0)
                    MessageBox.Show($"Список пустой, удаление невозможно.", "Ошибка Удаления");
                else
                    MessageBox.Show($"Выход за пределы списка.\nВыберите позицию не превышающую {current.Count()}.", "Ошибка Удаления");
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
