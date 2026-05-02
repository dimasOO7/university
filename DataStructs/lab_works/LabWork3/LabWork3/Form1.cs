namespace LabWork3
{
    public partial class Form1 : Form
    {
        private ArTree tree;
        public Form1()
        {
            InitializeComponent();
            tree = new ArTree();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create form = new Create(tree);
            form.Show();
        }

        private void DestroyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Выйти из программы?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
