using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class SnakeSettings : Form
    {
        Form mainMenu;

        const int MaxSpeed = 50;
        const int MinSpeed = 1000;

        private static (int size, int walls, int speed) easy = (10, 10, 10);
        private static (int size, int walls, int speed) medium = (20, 40, 12);
        private static (int size, int walls, int speed) hard = (30, 75, 14);

        Random rnd = new Random();

        public SnakeSettings(Form mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            this.FormClosing += OnClosing;
            MediumButton_Click(this, new EventArgs());
            SeedButton_Click(this, new EventArgs());
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            mainMenu.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int GetGameSpeed()
        {
            int speed = MinSpeed - (((int)GameSpeedNumeric.Value - 1) * (MinSpeed - MaxSpeed) / 20);
            return speed;
        }

        private void SeedButton_Click(object sender, EventArgs e)
        {
            SeedNumeric.Value = rnd.Next();
        }

        private void SizeNumeric_ValueChanged(object sender, EventArgs e)
        {
            WallsNumeric.Maximum = (int)Math.Pow((int)SizeNumeric.Value, 1.4);
        }

        private void EasyButton_Click(object sender, EventArgs e)
        {
            SizeNumeric.Value = easy.size;
            WallsNumeric.Value = easy.walls;
            GameSpeedNumeric.Value = easy.speed;
        }

        private void MediumButton_Click(object sender, EventArgs e)
        {
            SizeNumeric.Value = medium.size;
            WallsNumeric.Value = medium.walls;
            GameSpeedNumeric.Value = medium.speed;
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            SizeNumeric.Value = hard.size;
            WallsNumeric.Value = hard.walls;
            GameSpeedNumeric.Value = hard.speed;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            SnakeGameForm game = new SnakeGameForm(this,(int)SeedNumeric.Value, (int)SizeNumeric.Value,(int)WallsNumeric.Value,GetGameSpeed());
            game.Show();
            Hide();
        }
    }
}
