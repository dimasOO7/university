namespace LabWork2
{
    partial class CreateList
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
            Cancel = new Button();
            Ok = new Button();
            Создать = new TableLayoutPanel();
            InputBox = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            Создать.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(Cancel, 1, 0);
            tableLayoutPanel1.Controls.Add(Ok, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 145);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1081, 66);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Cancel
            // 
            Cancel.DialogResult = DialogResult.Cancel;
            Cancel.Dock = DockStyle.Fill;
            Cancel.Font = new Font("Segoe UI", 15F);
            Cancel.Location = new Point(543, 3);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(535, 60);
            Cancel.TabIndex = 2;
            Cancel.Text = "Отмена";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // Ok
            // 
            Ok.DialogResult = DialogResult.OK;
            Ok.Dock = DockStyle.Fill;
            Ok.Font = new Font("Segoe UI", 15F);
            Ok.Location = new Point(3, 3);
            Ok.Name = "Ok";
            Ok.Size = new Size(534, 60);
            Ok.TabIndex = 1;
            Ok.Text = "Ок";
            Ok.UseVisualStyleBackColor = true;
            Ok.Click += Ok_Click;
            // 
            // Создать
            // 
            Создать.ColumnCount = 1;
            Создать.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            Создать.Controls.Add(tableLayoutPanel1, 0, 1);
            Создать.Controls.Add(InputBox, 0, 0);
            Создать.Dock = DockStyle.Fill;
            Создать.Location = new Point(0, 0);
            Создать.Name = "Создать";
            Создать.RowCount = 2;
            Создать.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Создать.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            Создать.Size = new Size(1087, 214);
            Создать.TabIndex = 0;
            // 
            // InputBox
            // 
            InputBox.Dock = DockStyle.Fill;
            InputBox.Font = new Font("Segoe UI", 15F);
            InputBox.Location = new Point(3, 3);
            InputBox.Name = "InputBox";
            InputBox.Size = new Size(1081, 61);
            InputBox.TabIndex = 1;
            InputBox.KeyPress += InputBox_KeyPress;
            // 
            // CreateList
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 214);
            Controls.Add(Создать);
            Name = "CreateList";
            Text = "Создание списка";
            tableLayoutPanel1.ResumeLayout(false);
            Создать.ResumeLayout(false);
            Создать.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button Cancel;
        private Button Ok;
        private TableLayoutPanel Создать;
        private Button button1;
        public TextBox InputBox;
    }
}