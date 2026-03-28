namespace LabWork1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip = new MenuStrip();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            TaskToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            pictureBox2 = new PictureBox();
            MainPanel = new TableLayoutPanel();
            Execute = new Button();
            OutLabel = new Label();
            InputTextBox = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            AboutPanel = new TableLayoutPanel();
            label1 = new Label();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            AboutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(32, 32);
            menuStrip.Items.AddRange(new ToolStripItem[] { AboutToolStripMenuItem, TaskToolStripMenuItem, ExitToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1558, 40);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(183, 36);
            AboutToolStripMenuItem.Text = "О программе";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // TaskToolStripMenuItem
            // 
            TaskToolStripMenuItem.Name = "TaskToolStripMenuItem";
            TaskToolStripMenuItem.Size = new Size(125, 36);
            TaskToolStripMenuItem.Text = "Задание";
            TaskToolStripMenuItem.Click += TaskToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(103, 36);
            ExitToolStripMenuItem.Text = "Выход";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 219);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1552, 675);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // MainPanel
            // 
            MainPanel.ColumnCount = 1;
            MainPanel.ColumnStyles.Add(new ColumnStyle());
            MainPanel.Controls.Add(Execute, 0, 2);
            MainPanel.Controls.Add(OutLabel, 0, 1);
            MainPanel.Controls.Add(InputTextBox, 0, 0);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 40);
            MainPanel.Name = "MainPanel";
            MainPanel.RowCount = 4;
            MainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 37.5F));
            MainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 37.5F));
            MainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 24.9999962F));
            MainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            MainPanel.Size = new Size(1558, 897);
            MainPanel.TabIndex = 2;
            // 
            // Execute
            // 
            Execute.Dock = DockStyle.Fill;
            Execute.Font = new Font("Segoe UI", 30F);
            Execute.Location = new Point(3, 659);
            Execute.Name = "Execute";
            Execute.Size = new Size(1552, 213);
            Execute.TabIndex = 3;
            Execute.Text = "Выполнить";
            Execute.UseVisualStyleBackColor = true;
            Execute.Click += Execute_Click;
            // 
            // OutLabel
            // 
            OutLabel.AutoEllipsis = true;
            OutLabel.Dock = DockStyle.Fill;
            OutLabel.Font = new Font("Segoe UI", 20F);
            OutLabel.Location = new Point(3, 328);
            OutLabel.Name = "OutLabel";
            OutLabel.Size = new Size(1552, 328);
            OutLabel.TabIndex = 4;
            OutLabel.Text = "Выход:";
            // 
            // InputTextBox
            // 
            InputTextBox.Dock = DockStyle.Fill;
            InputTextBox.Font = new Font("Segoe UI", 20F);
            InputTextBox.Location = new Point(3, 3);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(1552, 78);
            InputTextBox.TabIndex = 5;
            InputTextBox.KeyPress += InputTextBox_KeyPress;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // AboutPanel
            // 
            AboutPanel.ColumnCount = 1;
            AboutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            AboutPanel.Controls.Add(pictureBox2, 0, 1);
            AboutPanel.Controls.Add(label1, 0, 0);
            AboutPanel.Dock = DockStyle.Fill;
            AboutPanel.Font = new Font("Segoe UI", 20F);
            AboutPanel.Location = new Point(0, 40);
            AboutPanel.Name = "AboutPanel";
            AboutPanel.RowCount = 2;
            AboutPanel.RowStyles.Add(new RowStyle());
            AboutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            AboutPanel.Size = new Size(1558, 897);
            AboutPanel.TabIndex = 2;
            AboutPanel.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(1552, 216);
            label1.TabIndex = 2;
            label1.Text = "Выполнил: Кузнецов Дмитрий Анатольевич\r\nГруппа: 6101-090301D\r\nВариант:\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1558, 937);
            Controls.Add(AboutPanel);
            Controls.Add(MainPanel);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "Form1";
            Text = "Лабораторная работа №1";
            FormClosing += Form1_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            AboutPanel.ResumeLayout(false);
            AboutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private ToolStripMenuItem TaskToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private PictureBox pictureBox2;
        private TableLayoutPanel MainPanel;
        private TextBox InputTextBox;
        private Label label2;
        private Button Execute;
        private Label OutLabel;
        private ErrorProvider errorProvider1;
        private TableLayoutPanel AboutPanel;
        private Label label1;
    }
}
