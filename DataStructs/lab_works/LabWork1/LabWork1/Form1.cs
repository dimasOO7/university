using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LabWork1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutPanel.Visible = true;
            MainPanel.Visible = false;
        }

        private void TaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutPanel.Visible = false;
            MainPanel.Visible = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы действительно хотите выйти из программы?",
            "Подтверждение выхода",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != ',' &&
            e.KeyChar != ' ' &&
            !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            string input = InputTextBox.Text;
            int[] A;
            if (Parse(input,out A))
            {
                int[] output = RecursionFunction.F(A);

                OutLabel.Text = "Выход: " + string.Join(", ", output);
            }
            else 
            {
                MessageBox.Show("Ошибка! Введите натуральные числа через запятую.");
                errorProvider1.SetError(InputTextBox, "Ошибка! Введите натуральные числа через запятую.");
            }
            errorProvider1.SetError(InputTextBox, null);
        }

        private bool Parse(string input,out int[] result)
        {
            bool isValid = true;

            string[] parts = input.Split(',')
                              .Select(p => p.Trim())
                              .ToArray();
            result = new int[parts.Length];
            if (parts.Length == 0) isValid = false;
            else
            {
                for(int i = 0; i < parts.Length && isValid; i++)
                {
                    int parsed = 0;
                    if (int.TryParse(parts[i], out parsed) && parsed > 0)
                    {
                        result[i] = parsed; 
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;

        }
    }
}
