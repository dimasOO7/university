using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab6
{
    public partial class GuessAnswerSettings : Form
    {
        private Form mainMenu;
        public GuessAnswerSettings(Form menu)
        {
            InitializeComponent();
            mainMenu = menu;
            this.FormClosing += OnClosing;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            mainMenu.Show();
        }

        private void IncorrectInput()
        {
            MessageBox.Show("Некоректный ввод");
        }

        private void ATextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (char.IsDigit(ch) || ch == (char)Keys.Back)
                return;

            if (ch == ',' && !ATextBox.Text.Contains(","))
                return;

            e.Handled = true; e.Handled = true;
        }
        private void BTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (char.IsDigit(ch) || ch == (char)Keys.Back)
                return;

            if (ch == ',' && !BTextBox.Text.Contains(","))
                return;

            e.Handled = true; e.Handled = true;
        }

        private void GameStartButton_Click(object sender, EventArgs e)
        {
            double a;
            if (!double.TryParse(ATextBox.Text, out a))
            {
                IncorrectInput();
                return;
            }

            double b;
            if (!double.TryParse(BTextBox.Text, out b))
            {
                IncorrectInput();
                return;
            }

            GuesAnswer guesAnswer = new GuesAnswer(a, b);
            if (guesAnswer.Result != 1.0 / 0.0)
            {
                GuesAnswerForm guesAnswerForm = new GuesAnswerForm(this, guesAnswer);
                guesAnswerForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("используйте другие значения A и B");
            }
        }

        private void ErrorLablel_Click(object sender, EventArgs e)
        {

        }
    }
}
