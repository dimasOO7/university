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
                isSorterActual = false;
                if (!int.TryParse(e.FormattedValue.ToString(), out value))
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

            isSorterActual = true;
        }

        private void DisplayArr(int[] arr)
        {
            dataGrid.Rows.Clear();
            foreach (int i in arr)
            {
                int rowIndex = dataGrid.Rows.Add();
                dataGrid.Rows[rowIndex].Cells[1].Value = i;
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (!isSorterActual)
            {
                int[] arr = dataGrid.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => Convert.ToInt32(r.Cells[1].Value))
                    .ToArray();

                sorter = new ArraySorter(arr);
            }

            (int[] sortedArr, double selectionSortTime, double gnomeSortTime) sortResult = sorter.GetSortedArr();

            DisplayArr(sortResult.sortedArr);

            GnomeSortLabel.Text = $"Время гномьей сортировки: {sortResult.gnomeSortTime:F2}c";

            SelectionSortLabel.Text = $"Время сортировки выбором: {sortResult.selectionSortTime:F2}c";

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            isSorterActual = false;

            DisplayArr([]);
        }
    }
}
