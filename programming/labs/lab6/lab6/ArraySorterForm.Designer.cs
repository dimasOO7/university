namespace lab6
{
    partial class ArraySorterForm
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
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            SortButton = new Button();
            ExitButton = new Button();
            dataGrid = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            numbers = new DataGridViewTextBoxColumn();
            tableLayoutPanel2 = new TableLayoutPanel();
            GenerateButton = new Button();
            label1 = new Label();
            ArraySizeNumeric = new NumericUpDown();
            GnomeSortLabel = new Label();
            SelectionSortLabel = new Label();
            ClearButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArraySizeNumeric).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(SortButton, 1, 1);
            tableLayoutPanel1.Controls.Add(ExitButton, 0, 1);
            tableLayoutPanel1.Controls.Add(dataGrid, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 91.62304F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.376964F));
            tableLayoutPanel1.Size = new Size(1678, 1095);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // SortButton
            // 
            SortButton.Dock = DockStyle.Fill;
            SortButton.Font = new Font("Segoe UI", 24F);
            SortButton.Location = new Point(600, 1003);
            SortButton.Margin = new Padding(2, 0, 2, 0);
            SortButton.Name = "SortButton";
            SortButton.Size = new Size(1076, 92);
            SortButton.TabIndex = 16;
            SortButton.Text = "Сортировка";
            SortButton.UseVisualStyleBackColor = true;
            SortButton.Click += SortButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Dock = DockStyle.Fill;
            ExitButton.Font = new Font("Segoe UI", 24F);
            ExitButton.Location = new Point(2, 1003);
            ExitButton.Margin = new Padding(2, 0, 2, 0);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(594, 92);
            ExitButton.TabIndex = 15;
            ExitButton.Text = "Выйти";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // dataGrid
            // 
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = "0";
            dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { id, numbers });
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = SystemColors.Window;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle15.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.False;
            dataGrid.DefaultCellStyle = dataGridViewCellStyle15;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.Location = new Point(3, 3);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 82;
            dataGrid.Size = new Size(592, 997);
            dataGrid.TabIndex = 1;
            dataGrid.CellValidating += dataGrid_CellValidating;
            dataGrid.RowsAdded += dataGrid_RowsAdded;
            dataGrid.RowsRemoved += dataGrid_RowsRemoved;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = "1";
            id.DefaultCellStyle = dataGridViewCellStyle13;
            id.HeaderText = "id";
            id.MinimumWidth = 10;
            id.Name = "id";
            id.ReadOnly = true;
            id.SortMode = DataGridViewColumnSortMode.NotSortable;
            id.Width = 40;
            // 
            // numbers
            // 
            numbers.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = "0";
            numbers.DefaultCellStyle = dataGridViewCellStyle14;
            numbers.HeaderText = "numbers";
            numbers.MinimumWidth = 10;
            numbers.Name = "numbers";
            numbers.SortMode = DataGridViewColumnSortMode.NotSortable;
            numbers.Width = 114;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1004F));
            tableLayoutPanel2.Controls.Add(GenerateButton, 0, 2);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(ArraySizeNumeric, 0, 1);
            tableLayoutPanel2.Controls.Add(GnomeSortLabel, 0, 4);
            tableLayoutPanel2.Controls.Add(SelectionSortLabel, 0, 5);
            tableLayoutPanel2.Controls.Add(ClearButton, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(601, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(1074, 997);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // GenerateButton
            // 
            GenerateButton.Dock = DockStyle.Fill;
            GenerateButton.Font = new Font("Segoe UI", 24F);
            GenerateButton.Location = new Point(2, 185);
            GenerateButton.Margin = new Padding(2, 0, 2, 0);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new Size(1070, 86);
            GenerateButton.TabIndex = 17;
            GenerateButton.Text = "Сгенерировать массив";
            GenerateButton.UseVisualStyleBackColor = true;
            GenerateButton.Click += GenerateButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(1068, 86);
            label1.TabIndex = 0;
            label1.Text = "размер массива для генерации:";
            // 
            // ArraySizeNumeric
            // 
            ArraySizeNumeric.Dock = DockStyle.Fill;
            ArraySizeNumeric.Font = new Font("Segoe UI", 24F);
            ArraySizeNumeric.Location = new Point(3, 89);
            ArraySizeNumeric.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            ArraySizeNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ArraySizeNumeric.Name = "ArraySizeNumeric";
            ArraySizeNumeric.Size = new Size(1068, 93);
            ArraySizeNumeric.TabIndex = 1;
            ArraySizeNumeric.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // GnomeSortLabel
            // 
            GnomeSortLabel.AutoSize = true;
            GnomeSortLabel.Font = new Font("Segoe UI", 24F);
            GnomeSortLabel.Location = new Point(3, 363);
            GnomeSortLabel.Name = "GnomeSortLabel";
            GnomeSortLabel.Size = new Size(999, 86);
            GnomeSortLabel.TabIndex = 2;
            GnomeSortLabel.Text = "Время гномьей сортировки: 0.0c";
            // 
            // SelectionSortLabel
            // 
            SelectionSortLabel.AutoSize = true;
            SelectionSortLabel.Font = new Font("Segoe UI", 24F);
            SelectionSortLabel.Location = new Point(3, 449);
            SelectionSortLabel.Name = "SelectionSortLabel";
            SelectionSortLabel.Size = new Size(1027, 86);
            SelectionSortLabel.TabIndex = 3;
            SelectionSortLabel.Text = "Время сортировки выбором: 0.0c";
            // 
            // ClearButton
            // 
            ClearButton.Dock = DockStyle.Fill;
            ClearButton.Font = new Font("Segoe UI", 24F);
            ClearButton.Location = new Point(2, 271);
            ClearButton.Margin = new Padding(2, 0, 2, 0);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(1070, 92);
            ClearButton.TabIndex = 18;
            ClearButton.Text = "Очистить массив";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // ArraySorterForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1678, 1095);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1157, 723);
            Name = "ArraySorterForm";
            Text = "ArraySorterForm";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ArraySizeNumeric).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGrid;
        private Button ExitButton;
        private Button SortButton;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private NumericUpDown ArraySizeNumeric;
        private Label GnomeSortLabel;
        private Label SelectionSortLabel;
        private Button GenerateButton;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn numbers;
        private Button ClearButton;
    }
}