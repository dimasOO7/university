namespace lab6
{
    partial class AboutAuthor
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
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.Font = new Font("Segoe UI", 32F);
            label1.Location = new Point(1, -2);
            label1.Name = "label1";
            label1.Size = new Size(995, 403);
            label1.TabIndex = 0;
            label1.Text = "Приложение созданно: Кузнецов Дмитрий Группа 6101-090301D";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 24F);
            button1.Location = new Point(12, 360);
            button1.Margin = new Padding(3, 3, 3, 10);
            button1.Name = "button1";
            button1.Size = new Size(330, 112);
            button1.TabIndex = 1;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Exit_Click;
            // 
            // AboutAuthor
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1153, 851);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "AboutAuthor";
            Text = "Об Авторе";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
    }
}