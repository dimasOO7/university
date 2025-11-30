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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ALabel
            // 
            ALabel.AutoSize = true;
            ALabel.Font = new Font("Segoe UI", 24F);
            ALabel.Location = new Point(29, 9);
            ALabel.Margin = new Padding(2, 0, 2, 0);
            ALabel.Name = "ALabel";
            ALabel.Size = new Size(137, 86);
            ALabel.TabIndex = 1;
            ALabel.Text = "a: 1";
            // 
            // BLabel
            // 
            BLabel.AutoSize = true;
            BLabel.Font = new Font("Segoe UI", 24F);
            BLabel.Location = new Point(24, 95);
            BLabel.Margin = new Padding(2, 0, 2, 0);
            BLabel.Name = "BLabel";
            BLabel.Size = new Size(142, 86);
            BLabel.TabIndex = 3;
            BLabel.Text = "b: 1";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(639, 9);
            pictureBox1.Margin = new Padding(2, 0, 2, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(840, 236);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // TimeBar
            // 
            TimeBar.Location = new Point(219, 245);
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
            TimeLabel.Font = new Font("Segoe UI", 24F);
            TimeLabel.Location = new Point(11, 245);
            TimeLabel.Margin = new Padding(2, 0, 2, 0);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(204, 86);
            TimeLabel.TabIndex = 7;
            TimeLabel.Text = "30,0 с";
            // 
            // TryesLabel
            // 
            TryesLabel.AutoSize = true;
            TryesLabel.BackColor = Color.Transparent;
            TryesLabel.Font = new Font("Segoe UI", 24F);
            TryesLabel.Location = new Point(307, 457);
            TryesLabel.Margin = new Padding(2, 0, 2, 0);
            TryesLabel.Name = "TryesLabel";
            TryesLabel.Size = new Size(646, 86);
            TryesLabel.TabIndex = 10;
            TryesLabel.Text = "Осталось попыток: 3";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 24F);
            label5.Location = new Point(11, 356);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(236, 86);
            label5.TabIndex = 11;
            label5.Text = "Ответ: ";
            // 
            // AnswerBox
            // 
            AnswerBox.Font = new Font("Segoe UI", 24F);
            AnswerBox.Location = new Point(272, 356);
            AnswerBox.Margin = new Padding(2, 0, 2, 0);
            AnswerBox.Name = "AnswerBox";
            AnswerBox.Size = new Size(787, 93);
            AnswerBox.TabIndex = 12;
            AnswerBox.KeyDown += AnswerBox_KeyDown;
            AnswerBox.KeyPress += AnswerBox_KeyPress;
            // 
            // AnswerButton
            // 
            AnswerButton.Font = new Font("Segoe UI", 24F);
            AnswerButton.Location = new Point(1077, 356);
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
            ExitButton.Font = new Font("Segoe UI", 24F);
            ExitButton.Location = new Point(11, 457);
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
            // GuesAnswerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1634, 1031);
            Controls.Add(ExitButton);
            Controls.Add(AnswerButton);
            Controls.Add(AnswerBox);
            Controls.Add(label5);
            Controls.Add(TryesLabel);
            Controls.Add(TimeLabel);
            Controls.Add(TimeBar);
            Controls.Add(pictureBox1);
            Controls.Add(BLabel);
            Controls.Add(ALabel);
            Margin = new Padding(2, 0, 2, 0);
            Name = "GuesAnswerForm";
            Text = "GuesAnswer";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}