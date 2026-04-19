namespace LabWork2._1
{
    public partial class Form1 : Form
    {
        internal CycleDoubleLinkedList F1;
        internal CycleDoubleLinkedList F2;
        internal CycleDoubleLinkedList F3;

        public Form1()
        {
            InitializeComponent();
            F1 = new CycleDoubleLinkedList();
            F2 = new CycleDoubleLinkedList();
            F3 = new CycleDoubleLinkedList();
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
            InsertLast form = new InsertLast(F1, F2, F3);
            form.Show();
        }

        private void InsertBeforeFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertFirst form = new InsertFirst(F1, F2, F3);
            form.Show();
        }

        private void DeleteFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFirst form = new DeleteFirst(F1, F2, F3);
            form.Show();
        }

        private void DeleteLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteLast form = new DeleteLast(F1, F2, F3);
            form.Show();
        }

        private void DeleteAtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAt form = new DeleteAt(F1, F2, F3);
            form.Show();
        }

        private void ProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Processing form = new Processing(F1, F2, F3))
            {
                form.ShowDialog();
            }
        }


        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertAt form = new InsertAt(F1, F2, F3);
            form.Show();
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowList form = new ShowList("F1", F1);
            form.Show();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowList form = new ShowList("F2", F2);
            form.Show();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowList form = new ShowList("F3", F3);
            form.Show();
        }

        private void f1CreateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateList form = new CreateList("F1", F1);
            form.Show();
        }

        private void f2CreateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateList form = new CreateList("F2", F2);
            form.Show();
        }

        private void f3CreateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateList form = new CreateList("F3", F3);
            form.Show();
        }

        private void f1DestroyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы уверены, что хотите очистить список F1",
            "Подтверждение очистки F1",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                F1.Clear();
            }
        }

        private void f2DestroyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы уверены, что хотите очистить список F2",
            "Подтверждение очистки F2",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                F2.Clear();
            }
        }

        private void f3DestroyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы уверены, что хотите очистить список F3",
            "Подтверждение очистки F3",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                F3.Clear();
            }
        }
    }
}

