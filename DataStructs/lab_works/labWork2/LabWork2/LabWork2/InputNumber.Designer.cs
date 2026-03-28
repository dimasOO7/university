namespace LabWork2
{
    partial class InputNumber
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
            numericUpDown = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // numericUpDown
            // 
            numericUpDown.Dock = DockStyle.Top;
            numericUpDown.Font = new Font("Segoe UI", 15F);
            numericUpDown.Location = new Point(0, 0);
            numericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(439, 61);
            numericUpDown.TabIndex = 0;
            numericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(184, 3);
            button1.Name = "button1";
            button1.Size = new Size(175, 75);
            button1.TabIndex = 1;
            button1.Text = "Выход";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.OK;
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(175, 75);
            button2.TabIndex = 2;
            button2.Text = "Ок";
            button2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 127);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(439, 75);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // InputNumber
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 202);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(numericUpDown);
            MinimumSize = new Size(400, 200);
            Name = "InputNumber";
            Text = "InputNumber";
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
        public NumericUpDown numericUpDown;
    }
}