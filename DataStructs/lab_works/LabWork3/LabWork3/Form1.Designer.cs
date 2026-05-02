namespace LabWork3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            заданиеToolStripMenuItem = new ToolStripMenuItem();
            CreateToolStripMenuItem = new ToolStripMenuItem();
            ProcessingToolStripMenuItem = new ToolStripMenuItem();
            DestroyToolStripMenuItem = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { заданиеToolStripMenuItem, AboutToolStripMenuItem, ExitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(674, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // заданиеToolStripMenuItem
            // 
            заданиеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CreateToolStripMenuItem, ProcessingToolStripMenuItem, DestroyToolStripMenuItem });
            заданиеToolStripMenuItem.Name = "заданиеToolStripMenuItem";
            заданиеToolStripMenuItem.Size = new Size(125, 38);
            заданиеToolStripMenuItem.Text = "Задание";
            // 
            // CreateToolStripMenuItem
            // 
            CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            CreateToolStripMenuItem.Size = new Size(359, 44);
            CreateToolStripMenuItem.Text = "Создание";
            CreateToolStripMenuItem.Click += CreateToolStripMenuItem_Click;
            // 
            // ProcessingToolStripMenuItem
            // 
            ProcessingToolStripMenuItem.Name = "ProcessingToolStripMenuItem";
            ProcessingToolStripMenuItem.Size = new Size(359, 44);
            ProcessingToolStripMenuItem.Text = "Обработка";
            ProcessingToolStripMenuItem.Click += ProcessingToolStripMenuItem_Click;
            // 
            // DestroyToolStripMenuItem
            // 
            DestroyToolStripMenuItem.Name = "DestroyToolStripMenuItem";
            DestroyToolStripMenuItem.Size = new Size(359, 44);
            DestroyToolStripMenuItem.Text = "Разрушение";
            DestroyToolStripMenuItem.Click += DestroyToolStripMenuItem_Click;
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(183, 38);
            AboutToolStripMenuItem.Text = "О программе";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(103, 38);
            ExitToolStripMenuItem.Text = "Выход";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(0, 40);
            label1.Name = "label1";
            label1.Size = new Size(677, 288);
            label1.TabIndex = 2;
            label1.Text = "Лабораторная работа №3\r\nВариант 30.1\r\nКузнецов Дмитрий\r\n\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(674, 259);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(700, 330);
            Name = "Form1";
            Text = "Лаюораторная работа 3";
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem заданиеToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem CreateToolStripMenuItem;
        private ToolStripMenuItem ProcessingToolStripMenuItem;
        private ToolStripMenuItem DestroyToolStripMenuItem;
        private Label label1;
    }
}
