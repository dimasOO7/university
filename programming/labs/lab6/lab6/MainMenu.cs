using System;

namespace lab6;

public partial class MainMenu : Form
{
    public MainMenu()
    {
        InitializeComponent();
        this.FormClosing += FormClosingEventArgs;
    }

    public static void FormClosingEventArgs(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти из приложения?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void About_click(object sender, EventArgs e)
    {
        AboutAuthor aboutAuthor = new AboutAuthor(this);
        aboutAuthor.Show();
        Hide();
    }

    private void ExitButton_click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти из приложения?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
        if (result == DialogResult.Yes)
        {
            Application.Exit();
        }
    }

    private void GuessAnswerButton_click(object sender, EventArgs e)
    {

        GuessAnswerSettings guesAnswer = new GuessAnswerSettings(this);
        guesAnswer.Show();
        Hide();
    }

    private void ArraySortButton_Click(object sender, EventArgs e)
    {
        ArraySorterForm arrSorterForm = new ArraySorterForm(this);
        arrSorterForm.Show();
        Hide();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        SnakeSettings snake = new SnakeSettings(this);
        snake.Show();
        Hide();
    }
}
