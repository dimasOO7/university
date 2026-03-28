namespace LabWork2
{
    partial class Processing
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
            label1 = new Label();
            label2 = new Label();
            BeforeProcessing = new ListBox();
            AfterProcessing = new ListBox();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(BeforeProcessing, 0, 1);
            tableLayoutPanel1.Controls.Add(AfterProcessing, 1, 1);
            tableLayoutPanel1.Controls.Add(button1, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tableLayoutPanel1.Size = new Size(945, 832);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(327, 54);
            label1.TabIndex = 0;
            label1.Text = "F1 до обработки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(475, 0);
            label2.Name = "label2";
            label2.Size = new Size(388, 54);
            label2.TabIndex = 1;
            label2.Text = "F1 после обработки";
            // 
            // BeforeProcessing
            // 
            BeforeProcessing.Dock = DockStyle.Fill;
            BeforeProcessing.Font = new Font("Segoe UI", 15F);
            BeforeProcessing.FormattingEnabled = true;
            BeforeProcessing.Location = new Point(3, 75);
            BeforeProcessing.Name = "BeforeProcessing";
            BeforeProcessing.Size = new Size(466, 682);
            BeforeProcessing.TabIndex = 2;
            // 
            // AfterProcessing
            // 
            AfterProcessing.Dock = DockStyle.Fill;
            AfterProcessing.Font = new Font("Segoe UI", 15F);
            AfterProcessing.FormattingEnabled = true;
            AfterProcessing.Location = new Point(475, 75);
            AfterProcessing.Name = "AfterProcessing";
            AfterProcessing.Size = new Size(467, 682);
            AfterProcessing.TabIndex = 3;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(475, 763);
            button1.Name = "button1";
            button1.Size = new Size(467, 66);
            button1.TabIndex = 4;
            button1.Text = "Закрыть";
            button1.UseVisualStyleBackColor = true;
            // 
            // Processing
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 832);
            Controls.Add(tableLayoutPanel1);
            Name = "Processing";
            Text = "Processing";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private ListBox BeforeProcessing;
        private ListBox AfterProcessing;
        private Button button1;
    }
}