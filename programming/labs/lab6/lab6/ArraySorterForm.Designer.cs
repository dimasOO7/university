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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            SortButton = new Button();
            ExitButton = new Button();
            dataGrid = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            numbers = new DataGridViewTextBoxColumn();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            ArraySizeNumeric = new NumericUpDown();
            AvgLabel = new Label();
            AvgButton = new Button();
            MinLabel = new Label();
            MinButton = new Button();
            MaxLabel = new Label();
            MaxButton = new Button();
            GenerateDefault = new Button();
            GenerateButton = new Button();
            ClearButton = new Button();
            SelectionSortLabel = new Label();
            GnomeSortLabel = new Label();
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
            tableLayoutPanel1.Size = new Size(1842, 1439);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // SortButton
            // 
            SortButton.Dock = DockStyle.Fill;
            SortButton.Font = new Font("Segoe UI", 24F);
            SortButton.Location = new Point(600, 1318);
            SortButton.Margin = new Padding(2, 0, 2, 0);
            SortButton.Name = "SortButton";
            SortButton.Size = new Size(1240, 121);
            SortButton.TabIndex = 16;
            SortButton.Text = "Сортировка";
            SortButton.UseVisualStyleBackColor = true;
            SortButton.Click += SortButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Dock = DockStyle.Fill;
            ExitButton.Font = new Font("Segoe UI", 24F);
            ExitButton.Location = new Point(2, 1318);
            ExitButton.Margin = new Padding(2, 0, 2, 0);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(594, 121);
            ExitButton.TabIndex = 15;
            ExitButton.Text = "Выйти";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // dataGrid
            // 
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { id, numbers });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGrid.DefaultCellStyle = dataGridViewCellStyle5;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.Location = new Point(3, 3);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 82;
            dataGrid.Size = new Size(592, 1312);
            dataGrid.TabIndex = 1;
            dataGrid.CellValidating += dataGrid_CellValidating;
            dataGrid.RowsAdded += dataGrid_RowsAdded;
            dataGrid.RowsRemoved += dataGrid_RowsRemoved;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "1";
            id.DefaultCellStyle = dataGridViewCellStyle3;
            id.Frozen = true;
            id.HeaderText = "id";
            id.MinimumWidth = 10;
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 92;
            // 
            // numbers
            // 
            numbers.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            numbers.DefaultCellStyle = dataGridViewCellStyle4;
            numbers.HeaderText = "numbers";
            numbers.MinimumWidth = 10;
            numbers.Name = "numbers";
            numbers.Width = 190;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 657F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 367F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(ArraySizeNumeric, 0, 1);
            tableLayoutPanel2.Controls.Add(AvgLabel, 1, 6);
            tableLayoutPanel2.Controls.Add(AvgButton, 1, 5);
            tableLayoutPanel2.Controls.Add(MinLabel, 1, 4);
            tableLayoutPanel2.Controls.Add(MinButton, 1, 3);
            tableLayoutPanel2.Controls.Add(MaxLabel, 1, 2);
            tableLayoutPanel2.Controls.Add(MaxButton, 1, 1);
            tableLayoutPanel2.Controls.Add(GenerateDefault, 1, 0);
            tableLayoutPanel2.Controls.Add(GenerateButton, 0, 2);
            tableLayoutPanel2.Controls.Add(ClearButton, 0, 3);
            tableLayoutPanel2.Controls.Add(SelectionSortLabel, 0, 6);
            tableLayoutPanel2.Controls.Add(GnomeSortLabel, 0, 4);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(601, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 266F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 155F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 181F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 204F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 139F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel2.Size = new Size(1238, 1312);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(651, 266);
            label1.TabIndex = 0;
            label1.Text = "размер массива для генерации:";
            // 
            // ArraySizeNumeric
            // 
            ArraySizeNumeric.Dock = DockStyle.Fill;
            ArraySizeNumeric.Font = new Font("Segoe UI", 24F);
            ArraySizeNumeric.Location = new Point(3, 269);
            ArraySizeNumeric.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            ArraySizeNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ArraySizeNumeric.Name = "ArraySizeNumeric";
            ArraySizeNumeric.Size = new Size(651, 93);
            ArraySizeNumeric.TabIndex = 1;
            ArraySizeNumeric.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // AvgLabel
            // 
            AvgLabel.AutoSize = true;
            AvgLabel.Dock = DockStyle.Fill;
            AvgLabel.Font = new Font("Segoe UI", 24F);
            AvgLabel.Location = new Point(660, 1125);
            AvgLabel.Name = "AvgLabel";
            AvgLabel.Size = new Size(575, 187);
            AvgLabel.TabIndex = 23;
            // 
            // AvgButton
            // 
            AvgButton.Dock = DockStyle.Fill;
            AvgButton.Font = new Font("Segoe UI", 24F);
            AvgButton.Location = new Point(659, 986);
            AvgButton.Margin = new Padding(2, 0, 2, 0);
            AvgButton.Name = "AvgButton";
            AvgButton.Size = new Size(577, 139);
            AvgButton.TabIndex = 24;
            AvgButton.Text = "Найти среднее";
            AvgButton.UseVisualStyleBackColor = true;
            AvgButton.Click += AvgButton_Click;
            // 
            // MinLabel
            // 
            MinLabel.AutoSize = true;
            MinLabel.Dock = DockStyle.Fill;
            MinLabel.Font = new Font("Segoe UI", 24F);
            MinLabel.Location = new Point(660, 782);
            MinLabel.Name = "MinLabel";
            MinLabel.Size = new Size(575, 204);
            MinLabel.TabIndex = 21;
            // 
            // MinButton
            // 
            MinButton.Dock = DockStyle.Fill;
            MinButton.Font = new Font("Segoe UI", 24F);
            MinButton.Location = new Point(659, 602);
            MinButton.Margin = new Padding(2, 0, 2, 0);
            MinButton.Name = "MinButton";
            MinButton.Size = new Size(577, 180);
            MinButton.TabIndex = 22;
            MinButton.Text = "Найти Минимум";
            MinButton.UseVisualStyleBackColor = true;
            MinButton.Click += MinButton_Click;
            // 
            // MaxLabel
            // 
            MaxLabel.AutoSize = true;
            MaxLabel.Dock = DockStyle.Fill;
            MaxLabel.Font = new Font("Segoe UI", 24F);
            MaxLabel.Location = new Point(660, 421);
            MaxLabel.Name = "MaxLabel";
            MaxLabel.Size = new Size(575, 181);
            MaxLabel.TabIndex = 19;
            // 
            // MaxButton
            // 
            MaxButton.Dock = DockStyle.Fill;
            MaxButton.Font = new Font("Segoe UI", 24F);
            MaxButton.Location = new Point(659, 266);
            MaxButton.Margin = new Padding(2, 0, 2, 0);
            MaxButton.Name = "MaxButton";
            MaxButton.Size = new Size(577, 155);
            MaxButton.TabIndex = 20;
            MaxButton.Text = "Найти максимум";
            MaxButton.UseVisualStyleBackColor = true;
            MaxButton.Click += MaxButton_Click;
            // 
            // GenerateDefault
            // 
            GenerateDefault.Dock = DockStyle.Fill;
            GenerateDefault.Font = new Font("Segoe UI", 24F);
            GenerateDefault.Location = new Point(659, 0);
            GenerateDefault.Margin = new Padding(2, 0, 2, 0);
            GenerateDefault.Name = "GenerateDefault";
            GenerateDefault.Size = new Size(577, 266);
            GenerateDefault.TabIndex = 25;
            GenerateDefault.Text = "Сгенерировать стандартный массив";
            GenerateDefault.UseVisualStyleBackColor = true;
            GenerateDefault.Click += GenerateDefault_Click;
            // 
            // GenerateButton
            // 
            GenerateButton.Dock = DockStyle.Fill;
            GenerateButton.Font = new Font("Segoe UI", 24F);
            GenerateButton.Location = new Point(2, 421);
            GenerateButton.Margin = new Padding(2, 0, 2, 0);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new Size(653, 181);
            GenerateButton.TabIndex = 17;
            GenerateButton.Text = "Сгенерировать массив";
            GenerateButton.UseVisualStyleBackColor = true;
            GenerateButton.Click += GenerateButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Dock = DockStyle.Fill;
            ClearButton.Font = new Font("Segoe UI", 24F);
            ClearButton.Location = new Point(2, 602);
            ClearButton.Margin = new Padding(2, 0, 2, 0);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(653, 180);
            ClearButton.TabIndex = 18;
            ClearButton.Text = "Очистить массив";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // SelectionSortLabel
            // 
            SelectionSortLabel.AutoSize = true;
            SelectionSortLabel.Font = new Font("Segoe UI", 24F);
            SelectionSortLabel.Location = new Point(3, 1125);
            SelectionSortLabel.Name = "SelectionSortLabel";
            SelectionSortLabel.Size = new Size(606, 172);
            SelectionSortLabel.TabIndex = 3;
            SelectionSortLabel.Text = "Время сортировки выбором: 0.0c";
            // 
            // GnomeSortLabel
            // 
            GnomeSortLabel.AutoSize = true;
            GnomeSortLabel.Font = new Font("Segoe UI", 24F);
            GnomeSortLabel.Location = new Point(3, 782);
            GnomeSortLabel.Name = "GnomeSortLabel";
            GnomeSortLabel.Size = new Size(531, 172);
            GnomeSortLabel.TabIndex = 2;
            GnomeSortLabel.Text = "Время гномьей сортировки: 0.0c";
            // 
            // ArraySorterForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1842, 1439);
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
        private Button ClearButton;
        private Label MaxLabel;
        private Button AvgButton;
        private Label AvgLabel;
        private Button MinButton;
        private Label MinLabel;
        private Button MaxButton;
        private Button GenerateDefault;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn numbers;
    }
}