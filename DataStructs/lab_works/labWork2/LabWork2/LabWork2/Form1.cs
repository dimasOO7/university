namespace LabWork2
{
    public partial class Form1 : Form
    {
        public SingleLinkedList F1;
        public SingleLinkedList F2;
        public SingleLinkedList F3;
        public SingleLinkedList currentList;

        public Form1()
        {
            InitializeComponent();
            F1 = new SingleLinkedList();
            F2 = new SingleLinkedList();
            F3 = new SingleLinkedList();
            currentList = F1;
            currentList.DisplayInListBox(listBox1);
            f1ToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentList = F1;
            currentList.DisplayInListBox(listBox1);

            f1ToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            f2ToolStripMenuItem.BackColor = SystemColors.Control;
            f3ToolStripMenuItem.BackColor = SystemColors.Control;
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentList = F2;
            currentList.DisplayInListBox(listBox1);

            f1ToolStripMenuItem.BackColor = SystemColors.Control;
            f2ToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            f3ToolStripMenuItem.BackColor = SystemColors.Control;
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentList = F3;
            currentList.DisplayInListBox(listBox1);

            f1ToolStripMenuItem.BackColor = SystemColors.Control;
            f2ToolStripMenuItem.BackColor = SystemColors.Control;
            f3ToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
        }

        private void DestroyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы уверены, что хотите разрушить этот список?",
            "Подтверждение удаления",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                currentList.Destroy();
                currentList.DisplayInListBox(listBox1);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Выйти из программы?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void InsertInEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InputNumber form = new InputNumber("Добавление в конец"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    currentList.InsertAfterLast((int)form.numericUpDown.Value);
                    currentList.DisplayInListBox(listBox1);
                }
            }
        }

        private void InsertBeforeFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InputNumber form = new InputNumber("Добавление в начало"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    currentList.InsertBeforeFirst((int)form.numericUpDown.Value);
                    currentList.DisplayInListBox(listBox1);
                }
            }
        }

        private void DeleteFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentList.DeleteFirst();
            currentList.DisplayInListBox(listBox1);
        }

        private void DeleteLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentList.DeleteLast();
            currentList.DisplayInListBox(listBox1);
        }

        private void DeleteAtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InputNumber form = new InputNumber("удаление по индексу"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    currentList.DeleteAt((int)form.numericUpDown.Value);
                    currentList.DisplayInListBox(listBox1);
                }
            }
        }

        private void ProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Processing form = new Processing(F1, F2, F3))
            {
                form.ShowDialog();
                currentList = F1;
                currentList.DisplayInListBox(listBox1);

                f1ToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
                f2ToolStripMenuItem.BackColor = SystemColors.Control;
                f3ToolStripMenuItem.BackColor = SystemColors.Control;
            }
        }

        private void CreateListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateList form = new CreateList())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string[] items = form.InputBox.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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
                        currentList.Create(resultArray);
                        currentList.DisplayInListBox(listBox1);
                    }
                }
            }
        }

        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InsertAt form = new InsertAt())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    currentList.InsertAt((int)form.TargetNumericUpDown.Value, (int)form.NumberNumericUpDown.Value);
                    currentList.DisplayInListBox(listBox1);
                }
            }
        }
    }
}

