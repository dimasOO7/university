namespace LabWork3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        }

        private void ProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}
