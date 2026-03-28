namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutPanel.Visible = true;
            //TaskPanel.Visible = false;
        }

        private void TaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutPanel.Visible = false;
            //TaskPanel.Visible = true;
        }
    }
}
