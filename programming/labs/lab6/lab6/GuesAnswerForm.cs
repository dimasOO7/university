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
    public partial class GuesAnswerForm : Form
    {
        private Form menu;

        private GuesAnswer guessAnswer;

        private int ticksLeft = 3000; //1 тик - 10мс

        private int tryes = 3;
        public GuesAnswerForm(Form menu, GuesAnswer guessAnswer)
        {
            InitializeComponent();
            this.menu = menu;
            this.guessAnswer = guessAnswer;
            ALabel.Text = $"a: {this.guessAnswer.A:F2}";
            BLabel.Text = $"b: {this.guessAnswer.B:F2}";
            TimeBar.Maximum = ticksLeft;
            timer1.Start();
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (AnswerBox.Text.Length > 0)
            {
                double answer;
                if (double.TryParse(AnswerBox.Text, out answer))
                {
                    if (guessAnswer.Guess(answer))
                    {
                        SoundOut.PlayWavFile(@"sounds\music-with-completed-mission-from-gta-san-andreas.wav");
                        MessageBox.Show($"Твоя оценка: {2+tryes}");
                        menu.Show();
                        Close();
                        return;
                    }
                    else
                    {
                        tryes--;
                        if (tryes <= 0)
                        {
                            SoundOut.PlayWavFile(@"sounds\gta-v-mission-failed-made-with-Voicemod.wav");
                            MessageBox.Show("Незачёт");
                            menu.Show();
                            Close();
                            return;
                        }
                        TryesLabel.Text = $"Осталось попыток: {tryes}";
                        SoundOut.PlayWavFile(@"sounds\wrong-try-again.wav");
                    }
                }
            }
        }

        private void AnswerBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !InputValidation.ValidateDouble(e.KeyChar, AnswerBox.Text);
        }

        private void AnswerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AnswerButton_Click(this, e);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            menu.Show();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticksLeft--;

            if (ticksLeft <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Твоё время окончено");
                menu.Show();
                this.Close();
                return;
            }

            TimeBar.Value = ticksLeft;
            TimeLabel.Text = $"{(double)ticksLeft / 100.0:F2} C";
        }

        
    }
}
