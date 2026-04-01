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
        SingleLinkedList List;
        public CreateList(string name, SingleLinkedList list)
        {
            InitializeComponent();
            List = list;
            Text = "создание " + name;
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

        private void Ok_Click(object sender, EventArgs e)
        {
            string[] items = InputBox.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] resultArray = new int[items.Length];
            bool isSuccess = true;

            for (int i = 0; i < items.Length; i++)
            {
                if (!int.TryParse(items[i].Trim(), out resultArray[i]))
                {
                    MessageBox.Show($"Ошибка: '{items[i]}' не является целым числом.");
                    isSuccess = false;
                    break;
                }
            }
            if (isSuccess && resultArray.Length > 0)
            {
                List.Create(resultArray);
            }
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
