using lab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class ArraySorterForm : Form
    {
        Form mainMenu;

        ArraySorter sorter;

        bool isSorterActual = false;

        private bool IsSorterActual
        {
            get
            {
                return isSorterActual;
            }

            set
            {
                isSorterActual = value;
                MinLabel.Text = "";
                MaxLabel.Text = "";
                AvgLabel.Text = "";
                GnomeSortLabel.Text = "";
                SelectionSortLabel.Text = "";
            }
        }
        public ArraySorterForm(Form mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            this.FormClosing += OnClosing;
        }



        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            mainMenu.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateRowIds();
        }

        private void dataGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateRowIds();
        }
        private void UpdateRowIds()
        {
            IsSorterActual = false;
            for (int i = 1; i < dataGrid.Rows.Count + 1; i++)
            {
                dataGrid.Rows[i - 1].Cells["id"].Value = i;
            }
        }

        private void dataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int value;
                IsSorterActual = false;
                if (!int.TryParse(e.FormattedValue.ToString().Replace(" ", ""), out value))
                {
                    MessageBox.Show("Введите целое число!");
                    e.Cancel = true;
                }
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {

            sorter = new ArraySorter((int)ArraySizeNumeric.Value);

            DisplayArr(sorter.Array);

            IsSorterActual = true;
        }

        private void DisplayArr(int[] arr)
        {
            dataGrid.Rows.Clear();

            var rows = new DataGridViewRow[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGrid);
                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = arr[i];
                rows[i] = row;
            }

            dataGrid.Rows.AddRange(rows);
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            UpdateSorter();
            (int[] sortedArr, double selectionSortTime, double gnomeSortTime) sortResult = sorter.GetSortedArr();

            DisplayArr(sortResult.sortedArr);

            GnomeSortLabel.Text = $"Время гномьей сортировки: {sortResult.gnomeSortTime:F2}c";

            SelectionSortLabel.Text = $"Время сортировки выбором: {sortResult.selectionSortTime:F2}c";

        }

        private int[] GetArr()
        {
            int[] arr = dataGrid.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => Convert.ToInt32(r.Cells[1].Value))
                    .ToArray();
            return arr;
        }

        private void UpdateSorter()
        {
            if (!isSorterActual)
            {
                int[] arr = GetArr();

                sorter = new ArraySorter(arr);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            isSorterActual = false;

            DisplayArr([]);
        }

        private void MaxButton_Click(object sender, EventArgs e)
        {
            UpdateSorter();
            int index = sorter.GetMaxIndex();
            dataGrid.Rows[index].DefaultCellStyle.BackColor = Color.Green;
            MaxLabel.Text = $"Максимум = {sorter.Array[index]}";
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            UpdateSorter();
            int index = sorter.GetMinIndex();
            dataGrid.Rows[index].DefaultCellStyle.BackColor = Color.Red;
            MinLabel.Text = $"Минимум = {sorter.Array[index]}";
        }

        private void AvgButton_Click(object sender, EventArgs e)
        {
            UpdateSorter();
            AvgLabel.Text = $"Среднее = {sorter.FindAverage():F2}";
        }

        private void GenerateDefault_Click(object sender, EventArgs e)
        {
            sorter = new ArraySorter();

            DisplayArr(sorter.Array);

            IsSorterActual = true;
        }
    }
}
