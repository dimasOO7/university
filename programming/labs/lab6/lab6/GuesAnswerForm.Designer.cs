namespace lab6
{
    partial class GuesAnswerForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuesAnswerForm));
            ALabel = new Label();
            BLabel = new Label();
            pictureBox1 = new PictureBox();
            TimeBar = new ProgressBar();
            TimeLabel = new Label();
            TryesLabel = new Label();
            label5 = new Label();
            AnswerBox = new TextBox();
            AnswerButton = new Button();
            ExitButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ALabel
            // 
            ALabel.AutoSize = true;
            ALabel.Dock = DockStyle.Fill;
            ALabel.Font = new Font("Segoe UI", 24F);
            ALabel.Location = new Point(2, 0);
            ALabel.Margin = new Padding(2, 0, 2, 0);
            ALabel.Name = "ALabel";
            ALabel.Size = new Size(272, 236);
            ALabel.TabIndex = 1;
            ALabel.Text = "a: 1";
            // 
            // BLabel
            // 
            BLabel.AutoSize = true;
            BLabel.Dock = DockStyle.Fill;
            BLabel.Font = new Font("Segoe UI", 24F);
            BLabel.Location = new Point(2, 236);
            BLabel.Margin = new Padding(2, 0, 2, 0);
            BLabel.Name = "BLabel";
            BLabel.Size = new Size(272, 86);
            BLabel.TabIndex = 3;
            BLabel.Text = "b: 1";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(278, 0);
            pictureBox1.Margin = new Padding(2, 0, 2, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1260, 236);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // TimeBar
            // 
            TimeBar.Dock = DockStyle.Fill;
            TimeBar.Location = new Point(278, 236);
            TimeBar.Margin = new Padding(2, 0, 2, 0);
            TimeBar.Name = "TimeBar";
            TimeBar.Size = new Size(1260, 86);
            TimeBar.Step = 1;
            TimeBar.TabIndex = 6;
            TimeBar.Value = 100;
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.BackColor = Color.Transparent;
            TimeLabel.Dock = DockStyle.Fill;
            TimeLabel.Font = new Font("Segoe UI", 24F);
            TimeLabel.Location = new Point(1542, 236);
            TimeLabel.Margin = new Padding(2, 0, 2, 0);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(371, 86);
            TimeLabel.TabIndex = 7;
            TimeLabel.Text = "30,0 с";
            TimeLabel.Click += TimeLabel_Click;
            // 
            // TryesLabel
            // 
            TryesLabel.AutoSize = true;
            TryesLabel.BackColor = Color.Transparent;
            TryesLabel.Dock = DockStyle.Fill;
            TryesLabel.Font = new Font("Segoe UI", 24F);
            TryesLabel.Location = new Point(278, 417);
            TryesLabel.Margin = new Padding(2, 0, 2, 0);
            TryesLabel.Name = "TryesLabel";
            TryesLabel.Size = new Size(1260, 94);
            TryesLabel.TabIndex = 10;
            TryesLabel.Text = "Осталось попыток: 3";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 24F);
            label5.Location = new Point(2, 322);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(272, 95);
            label5.TabIndex = 11;
            label5.Text = "Ответ: ";
            // 
            // AnswerBox
            // 
            AnswerBox.Dock = DockStyle.Fill;
            AnswerBox.Font = new Font("Segoe UI", 24F);
            AnswerBox.Location = new Point(278, 322);
            AnswerBox.Margin = new Padding(2, 0, 2, 0);
            AnswerBox.Name = "AnswerBox";
            AnswerBox.Size = new Size(1260, 93);
            AnswerBox.TabIndex = 12;
            AnswerBox.KeyDown += AnswerBox_KeyDown;
            AnswerBox.KeyPress += AnswerBox_KeyPress;
            // 
            // AnswerButton
            // 
            AnswerButton.Dock = DockStyle.Fill;
            AnswerButton.Font = new Font("Segoe UI", 24F);
            AnswerButton.Location = new Point(1542, 322);
            AnswerButton.Margin = new Padding(2, 0, 2, 0);
            AnswerButton.Name = "AnswerButton";
            AnswerButton.Size = new Size(371, 95);
            AnswerButton.TabIndex = 13;
            AnswerButton.Text = "Ответить";
            AnswerButton.UseVisualStyleBackColor = true;
            AnswerButton.Click += AnswerButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Dock = DockStyle.Fill;
            ExitButton.Font = new Font("Segoe UI", 24F);
            ExitButton.Location = new Point(2, 417);
            ExitButton.Margin = new Padding(2, 0, 2, 0);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(272, 94);
            ExitButton.TabIndex = 14;
            ExitButton.Text = "Выйти";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(ALabel, 0, 0);
            tableLayoutPanel1.Controls.Add(AnswerButton, 2, 4);
            tableLayoutPanel1.Controls.Add(ExitButton, 0, 5);
            tableLayoutPanel1.Controls.Add(TryesLabel, 1, 5);
            tableLayoutPanel1.Controls.Add(AnswerBox, 1, 4);
            tableLayoutPanel1.Controls.Add(BLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(pictureBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(TimeBar, 1, 1);
            tableLayoutPanel1.Controls.Add(TimeLabel, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(1859, 507);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // GuesAnswerForm
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1859, 507);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2, 0, 2, 0);
            MinimumSize = new Size(1885, 578);
            Name = "GuesAnswerForm";
            Text = "GuesAnswer";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label ALabel;
        private Label BLabel;
        private PictureBox pictureBox1;
        private ProgressBar TimeBar;
        private Label TimeLabel;
        private System.Windows.Forms.Label TryesLabel;
        private Label label5;
        private TextBox AnswerBox;
        private System.Windows.Forms.Button AnswerButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Timer timer1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}