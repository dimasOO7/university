namespace LabWork2
{
    partial class DeleteAt
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
            tableLayoutPanel2 = new TableLayoutPanel();
            comboBox1 = new ComboBox();
            listBox1 = new ListBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            NumberNumericUpDown = new NumericUpDown();
            label1 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            Close = new Button();
            okButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumberNumericUpDown).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 506F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.050251F));
            tableLayoutPanel1.Size = new Size(831, 450);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(comboBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(listBox1, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 91.3924F));
            tableLayoutPanel2.Size = new Size(319, 444);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 15F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "F1", "F2", "F3" });
            comboBox1.Location = new Point(3, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 62);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(3, 70);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(313, 371);
            listBox1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 302F));
            tableLayoutPanel3.Controls.Add(NumberNumericUpDown, 0, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(328, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 92.43028F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 81F));
            tableLayoutPanel3.Size = new Size(500, 444);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // NumberNumericUpDown
            // 
            NumberNumericUpDown.Dock = DockStyle.Fill;
            NumberNumericUpDown.Font = new Font("Segoe UI", 15F);
            NumberNumericUpDown.Location = new Point(3, 55);
            NumberNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NumberNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            NumberNumericUpDown.Name = "NumberNumericUpDown";
            NumberNumericUpDown.Size = new Size(494, 61);
            NumberNumericUpDown.TabIndex = 3;
            NumberNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(424, 52);
            label1.TabIndex = 1;
            label1.Text = "Удалить i-ый элемент:";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(Close, 1, 0);
            tableLayoutPanel4.Controls.Add(okButton, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 366);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(494, 75);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // Close
            // 
            Close.AutoSize = true;
            Close.DialogResult = DialogResult.Cancel;
            Close.Dock = DockStyle.Fill;
            Close.Font = new Font("Segoe UI", 15F);
            Close.Location = new Point(250, 3);
            Close.Name = "Close";
            Close.Size = new Size(241, 69);
            Close.TabIndex = 6;
            Close.Text = "Закрыть";
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // okButton
            // 
            okButton.AutoSize = true;
            okButton.DialogResult = DialogResult.OK;
            okButton.Dock = DockStyle.Fill;
            okButton.Font = new Font("Segoe UI", 15F);
            okButton.Location = new Point(3, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(241, 69);
            okButton.TabIndex = 5;
            okButton.Text = "Удалить";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // DeleteAt
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "DeleteAt";
            Text = "Удаление произвольного";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumberNumericUpDown).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox comboBox1;
        private ListBox listBox1;
        private TableLayoutPanel tableLayoutPanel3;
        public NumericUpDown NumberNumericUpDown;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel4;
        private Button Close;
        private Button okButton;
    }
}