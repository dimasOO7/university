namespace LabWork2
{
    partial class InsertAt
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
            tableLayoutPanel1 = new TableLayoutPanel();
            button2 = new Button();
            TargetNumericUpDown = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            NumberNumericUpDown = new NumericUpDown();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TargetNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumberNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 416F));
            tableLayoutPanel1.Controls.Add(button2, 1, 2);
            tableLayoutPanel1.Controls.Add(TargetNumericUpDown, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(NumberNumericUpDown, 1, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.DialogResult = DialogResult.Cancel;
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(233, 381);
            button2.Name = "button2";
            button2.Size = new Size(564, 66);
            button2.TabIndex = 5;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            // 
            // TargetNumericUpDown
            // 
            TargetNumericUpDown.Dock = DockStyle.Fill;
            TargetNumericUpDown.Font = new Font("Segoe UI", 15F);
            TargetNumericUpDown.Location = new Point(233, 192);
            TargetNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            TargetNumericUpDown.Name = "TargetNumericUpDown";
            TargetNumericUpDown.Size = new Size(564, 61);
            TargetNumericUpDown.TabIndex = 3;
            TargetNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(189, 54);
            label1.TabIndex = 0;
            label1.Text = "Вставить:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(3, 189);
            label2.Name = "label2";
            label2.Size = new Size(224, 54);
            label2.TabIndex = 1;
            label2.Text = "В позицию";
            // 
            // NumberNumericUpDown
            // 
            NumberNumericUpDown.Dock = DockStyle.Fill;
            NumberNumericUpDown.Font = new Font("Segoe UI", 15F);
            NumberNumericUpDown.Location = new Point(233, 3);
            NumberNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NumberNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            NumberNumericUpDown.Name = "NumberNumericUpDown";
            NumberNumericUpDown.Size = new Size(564, 61);
            NumberNumericUpDown.TabIndex = 2;
            NumberNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.DialogResult = DialogResult.OK;
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(3, 381);
            button1.Name = "button1";
            button1.Size = new Size(224, 66);
            button1.TabIndex = 4;
            button1.Text = "Ок";
            button1.UseVisualStyleBackColor = true;
            // 
            // InsertAt
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "InsertAt";
            Text = "InsertAt";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TargetNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumberNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        public NumericUpDown NumberNumericUpDown;
        public NumericUpDown TargetNumericUpDown;
    }
}