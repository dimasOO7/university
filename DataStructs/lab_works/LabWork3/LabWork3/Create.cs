using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace LabWork3
{
    //((((3*a)+(f+c))*((3*a)+(t+1)))*(((3*a)+(f+c))*((3*a)+(t+1))))
    public partial class Create : Form
    {
        private ArTree tree;
        public Create(ArTree tree)
        {
            InitializeComponent();
            this.tree = tree;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string f = textBox1.Text;
            f = f.Replace(" ", "");
            int braketLevel = 0;
            if (string.IsNullOrWhiteSpace(f))
            {
                MessageBox.Show("Выражение не может быть пустым.");
            }
            else
            {
                for (int i = 0; i < f.Length; i++)
                {
                    if (f[i] == '(')
                    {
                        braketLevel++;
                    }
                    else if (f[i] == ')')
                    {
                        braketLevel--;
                    }
                }
                if (braketLevel > 0)
                {
                    MessageBox.Show("В выражении не хватает закрывающих скобок");
                }
                else
                {
                    tree.Root = tree.Create(f);
                }
            }
            pictureBox1.Invalidate();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float startX = pictureBox1.ClientSize.Width / 2f;

            float dY = 40f;

            float dX = pictureBox1.ClientSize.Width / 4f;

            using (Font font = new Font("Arial", 16, FontStyle.Regular))
            using (SolidBrush brush = new SolidBrush(Color.DarkBlue))
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                tree.Show(tree.Root,startX,dY,dX,dY,g,font,brush,format);
            }
        }
    }
}
