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
    public partial class SnakeGameForm : Form
    {
        Form mainMenu;

        Snake game;

        private const int tileSize = 48;

        int result = 0;

        private Image appleImage;

        public SnakeGameForm(Form mainMenu, int seed,int wordsize, int walls, int frameDelay)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            this.FormClosing += OnClosing;
            GameTimer.Interval = frameDelay;
            GameTimer.Start();
            world.Height = wordsize * tileSize;
            world.Width = wordsize * tileSize;

            game = new Snake(seed, wordsize, walls);

            this.KeyPreview = true;
            this.KeyDown += OnKeyDown;

            appleImage = Image.FromFile("C:\\Users\\REDMI\\university\\programming\\labs\\lab6\\lab6\\icons8-apple-inc-48.png");
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            InputKeys key = InputKeys.NONE;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    key = InputKeys.UP;
                    break;
                case Keys.Down:
                    key = InputKeys.DOWN;
                    break;
                case Keys.Left:
                    key = InputKeys.LEFT;
                    break;
                case Keys.Right:
                    key = InputKeys.RIGHT;
                    break;
            }

            if (key != InputKeys.NONE)
            {
                game.SetMoveDirection(key);
               
                e.Handled = true;
            }
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            mainMenu.Show();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            int r = game.GameTick();

            if (r > 0)
            {
                ResultLabel.Text = $"Результат: {r}";
                result = r;
                if (result >= game.freeCells)
                {
                    SoundOut.PlayWavFile(@"sounds\zelda-2---fanfare-nintendo-game-music.wav");
                    MessageBox.Show($"Победа\n Результат: {result}");
                }
                SoundOut.PlayWavFile(@"sounds\eating-a-bite-of-an-apple.wav");
            }
            else if(r < 0)
            {
                GameTimer.Stop();
                Close();
                SoundOut.PlayWavFile(@"sounds\gta-v-mission-failed-made-with-Voicemod.wav");
                MessageBox.Show($"Потрачено\n Результат: {result}");
                return;
            }
            world.Invalidate();
        }

        private void world_Paint(object sender, PaintEventArgs e)
        {
            char[,] worldState = game.World;

            Graphics g = e.Graphics;

            SolidBrush greenBrush = new SolidBrush(Color.LimeGreen);
            SolidBrush grayBrush = new SolidBrush(Color.LightGray);
            SolidBrush darkMagentaBrush = new SolidBrush(Color.DarkMagenta);
            SolidBrush magentaBrush = new SolidBrush(Color.Magenta);
            for (int x = 0; x < worldState.GetLength(0); x++)
            {
                for (int y = 0; y < worldState.GetLength(1); y++)
                {
                    Rectangle rect = new Rectangle(
                        x * tileSize,
                        y * tileSize,
                        tileSize,
                        tileSize
                    );

                    SolidBrush tileBrush;
                    string appleChar = "●";

                    switch (worldState[x, y])
                    {
                        case 'g':
                            tileBrush = greenBrush;
                            g.FillRectangle(tileBrush, rect);
                            break;

                        case 'w':
                            tileBrush = grayBrush;
                            g.FillRectangle(tileBrush, rect);
                            break;

                        case 'h':
                            tileBrush = darkMagentaBrush;
                            g.FillRectangle(tileBrush, rect);
                            break;

                        case 's':
                            tileBrush = magentaBrush;
                            g.FillRectangle(tileBrush, rect);
                            break;

                        case 'a':
                            g.FillRectangle(greenBrush, rect);
                            if (appleImage != null)
                            {
                                g.DrawImage(appleImage, rect);
                            }
                            break;

                        default:
                            g.FillRectangle(new SolidBrush(Color.Black), rect);
                            break;
                    }
                }


            }
            greenBrush.Dispose();
            grayBrush.Dispose();
            darkMagentaBrush.Dispose();
            magentaBrush.Dispose();
        }
    }
}
