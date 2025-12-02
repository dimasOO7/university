namespace lab6
{
    partial class SnakeSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SeedButton = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            EasyButton = new Button();
            MediumButton = new Button();
            HardButton = new Button();
            SeedNumeric = new NumericUpDown();
            SizeNumeric = new NumericUpDown();
            WallsNumeric = new NumericUpDown();
            GameSpeedNumeric = new NumericUpDown();
            StartButton = new Button();
            button2 = new Button();
            ExitButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SeedNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SizeNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WallsNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GameSpeedNumeric).BeginInit();
            SuspendLayout();
            // 
            // SeedButton
            // 
            SeedButton.Dock = DockStyle.Fill;
            SeedButton.Font = new Font("Segoe UI", 24F);
            SeedButton.Location = new Point(984, 3);
            SeedButton.Name = "SeedButton";
            SeedButton.Size = new Size(391, 101);
            SeedButton.TabIndex = 4;
            SeedButton.Text = "Случайный";
            SeedButton.UseVisualStyleBackColor = true;
            SeedButton.Click += SeedButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 24F);
            label4.Location = new Point(3, 393);
            label4.Name = "label4";
            label4.Size = new Size(383, 172);
            label4.TabIndex = 3;
            label4.Text = "Скорость игры (1-20):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F);
            label3.Location = new Point(3, 214);
            label3.Name = "label3";
            label3.Size = new Size(418, 172);
            label3.TabIndex = 2;
            label3.Text = "Кол-во препятствий:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F);
            label2.Location = new Point(3, 107);
            label2.Name = "label2";
            label2.Size = new Size(265, 86);
            label2.TabIndex = 1;
            label2.Text = "Размер:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(163, 86);
            label1.TabIndex = 0;
            label1.Text = "Сид:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.8677254F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.1322746F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 396F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(SeedButton, 2, 0);
            tableLayoutPanel1.Controls.Add(EasyButton, 2, 1);
            tableLayoutPanel1.Controls.Add(MediumButton, 2, 2);
            tableLayoutPanel1.Controls.Add(HardButton, 2, 3);
            tableLayoutPanel1.Controls.Add(SeedNumeric, 1, 0);
            tableLayoutPanel1.Controls.Add(SizeNumeric, 1, 1);
            tableLayoutPanel1.Controls.Add(WallsNumeric, 1, 2);
            tableLayoutPanel1.Controls.Add(GameSpeedNumeric, 1, 3);
            tableLayoutPanel1.Controls.Add(StartButton, 2, 4);
            tableLayoutPanel1.Controls.Add(button2, 1, 4);
            tableLayoutPanel1.Controls.Add(ExitButton, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 179F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 193F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 119F));
            tableLayoutPanel1.Size = new Size(1378, 705);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // EasyButton
            // 
            EasyButton.Dock = DockStyle.Fill;
            EasyButton.Font = new Font("Segoe UI", 24F);
            EasyButton.Location = new Point(984, 110);
            EasyButton.Name = "EasyButton";
            EasyButton.Size = new Size(391, 101);
            EasyButton.TabIndex = 6;
            EasyButton.Text = "Лёгкая";
            EasyButton.UseVisualStyleBackColor = true;
            EasyButton.Click += EasyButton_Click;
            // 
            // MediumButton
            // 
            MediumButton.Dock = DockStyle.Fill;
            MediumButton.Font = new Font("Segoe UI", 24F);
            MediumButton.Location = new Point(984, 217);
            MediumButton.Name = "MediumButton";
            MediumButton.Size = new Size(391, 173);
            MediumButton.TabIndex = 7;
            MediumButton.Text = "средняя";
            MediumButton.UseVisualStyleBackColor = true;
            MediumButton.Click += MediumButton_Click;
            // 
            // HardButton
            // 
            HardButton.Dock = DockStyle.Fill;
            HardButton.Font = new Font("Segoe UI", 24F);
            HardButton.Location = new Point(984, 396);
            HardButton.Name = "HardButton";
            HardButton.Size = new Size(391, 187);
            HardButton.TabIndex = 8;
            HardButton.Text = "Сложная";
            HardButton.UseVisualStyleBackColor = true;
            HardButton.Click += HardButton_Click;
            // 
            // SeedNumeric
            // 
            SeedNumeric.Dock = DockStyle.Fill;
            SeedNumeric.Font = new Font("Segoe UI", 24F);
            SeedNumeric.Location = new Point(443, 3);
            SeedNumeric.Maximum = new decimal(new int[] { int.MinValue, 0, 0, 0 });
            SeedNumeric.Name = "SeedNumeric";
            SeedNumeric.Size = new Size(535, 93);
            SeedNumeric.TabIndex = 9;
            // 
            // SizeNumeric
            // 
            SizeNumeric.Dock = DockStyle.Fill;
            SizeNumeric.Font = new Font("Segoe UI", 24F);
            SizeNumeric.Location = new Point(443, 110);
            SizeNumeric.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            SizeNumeric.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            SizeNumeric.Name = "SizeNumeric";
            SizeNumeric.Size = new Size(535, 93);
            SizeNumeric.TabIndex = 10;
            SizeNumeric.Value = new decimal(new int[] { 20, 0, 0, 0 });
            SizeNumeric.ValueChanged += SizeNumeric_ValueChanged;
            // 
            // WallsNumeric
            // 
            WallsNumeric.Dock = DockStyle.Fill;
            WallsNumeric.Font = new Font("Segoe UI", 24F);
            WallsNumeric.Location = new Point(443, 217);
            WallsNumeric.Maximum = new decimal(new int[] { 66, 0, 0, 0 });
            WallsNumeric.Name = "WallsNumeric";
            WallsNumeric.Size = new Size(535, 93);
            WallsNumeric.TabIndex = 11;
            // 
            // GameSpeedNumeric
            // 
            GameSpeedNumeric.Dock = DockStyle.Fill;
            GameSpeedNumeric.Font = new Font("Segoe UI", 24F);
            GameSpeedNumeric.Location = new Point(443, 396);
            GameSpeedNumeric.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            GameSpeedNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            GameSpeedNumeric.Name = "GameSpeedNumeric";
            GameSpeedNumeric.Size = new Size(535, 93);
            GameSpeedNumeric.TabIndex = 12;
            GameSpeedNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // StartButton
            // 
            StartButton.Dock = DockStyle.Fill;
            StartButton.Font = new Font("Segoe UI", 24F);
            StartButton.Location = new Point(984, 589);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(391, 113);
            StartButton.TabIndex = 13;
            StartButton.Text = "начать";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(443, 589);
            button2.Name = "button2";
            button2.Size = new Size(8, 8);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            ExitButton.Dock = DockStyle.Fill;
            ExitButton.Font = new Font("Segoe UI", 24F);
            ExitButton.Location = new Point(3, 589);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(434, 113);
            ExitButton.TabIndex = 14;
            ExitButton.Text = "Назад";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // SnakeSettings
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1378, 705);
            Controls.Add(tableLayoutPanel1);
            Name = "SnakeSettings";
            Text = "SnakeSettings";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SeedNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)SizeNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)WallsNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)GameSpeedNumeric).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button SeedButton;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button2;
        private Button EasyButton;
        private Button MediumButton;
        private Button HardButton;
        private NumericUpDown SeedNumeric;
        private NumericUpDown SizeNumeric;
        private NumericUpDown WallsNumeric;
        private NumericUpDown GameSpeedNumeric;
        private Button StartButton;
        private Button ExitButton;
    }
}