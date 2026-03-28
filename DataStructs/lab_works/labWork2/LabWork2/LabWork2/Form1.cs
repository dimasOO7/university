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
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentList = F1;
            currentList.DisplayInListBox(listBox1);
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentList = F2;
            currentList.DisplayInListBox(listBox1);
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentList = F3;
            currentList.DisplayInListBox(listBox1);
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
    }
}
