namespace lab6
{
    partial class GuessAnswerSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuessAnswerSettings));
            GameStartButton = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            BTextBox = new TextBox();
            label1 = new Label();
            ATextBox = new TextBox();
            ExitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // GameStartButton
            // 
            GameStartButton.Font = new Font("Segoe UI", 12F);
            GameStartButton.Location = new Point(933, 260);
            GameStartButton.Margin = new Padding(4, 2, 4, 2);
            GameStartButton.Name = "GameStartButton";
            GameStartButton.Size = new Size(312, 98);
            GameStartButton.TabIndex = 15;
            GameStartButton.Text = "Начать";
            GameStartButton.UseVisualStyleBackColor = true;
            GameStartButton.Click += GameStartButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(489, 28);
            pictureBox1.Margin = new Padding(4, 2, 4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(756, 201);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F);
            label2.Location = new Point(20, 134);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 86);
            label2.TabIndex = 13;
            label2.Text = "b:";
            // 
            // BTextBox
            // 
            BTextBox.Font = new Font("Segoe UI", 24F);
            BTextBox.Location = new Point(117, 136);
            BTextBox.Margin = new Padding(4, 2, 4, 2);
            BTextBox.Name = "BTextBox";
            BTextBox.Size = new Size(364, 93);
            BTextBox.TabIndex = 12;
            BTextBox.KeyPress += BTextBox_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(26, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 86);
            label1.TabIndex = 11;
            label1.Text = "a:";
            // 
            // ATextBox
            // 
            ATextBox.Font = new Font("Segoe UI", 24F);
            ATextBox.Location = new Point(118, 28);
            ATextBox.Margin = new Padding(4, 2, 4, 2);
            ATextBox.Name = "ATextBox";
            ATextBox.Size = new Size(363, 93);
            ATextBox.TabIndex = 10;
            ATextBox.KeyPress += ATextBox_KeyPress;
            // 
            // ExitButton
            // 
            ExitButton.Font = new Font("Segoe UI", 12F);
            ExitButton.Location = new Point(20, 260);
            ExitButton.Margin = new Padding(4, 2, 4, 2);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(312, 98);
            ExitButton.TabIndex = 16;
            ExitButton.Text = "Назад";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += Exit_Click;
            // 
            // GuessAnswerSettings
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1534, 823);
            Controls.Add(ExitButton);
            Controls.Add(GameStartButton);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(BTextBox);
            Controls.Add(label1);
            Controls.Add(ATextBox);
            Margin = new Padding(4, 2, 4, 2);
            Name = "GuessAnswerSettings";
            Text = "Q";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button GameStartButton;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ATextBox;
        private System.Windows.Forms.Button ExitButton;
    }
}