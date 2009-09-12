using System;
using System.Windows.Forms;

namespace MPO.UI
{
    public partial class FilterForm : Form
    {
        public int[,] Filter { get; set; }

        public FilterForm()
        {
            InitializeComponent();
            InitMaskGrid();
        }

        private void InitMaskGrid()
        {
            for (var i = 0; i < 3; i++)
            {
                var column = new DataGridViewTextBoxColumn
                                 {
                                     Width = 20,
                                     Name = (i + "name"),
                                     ValueType = typeof(int)
                                 };
                gridMask.Columns.Add(column);
            }

            for (var i = 0; i < 3; i++)
            {
                gridMask.Rows.Add();
            }

            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                {
                    gridMask[i, j].Value = 0;
                }


            gridMask.DataError += OnInputErrorOccured;
        }

        private static void OnInputErrorOccured(object sender, DataGridViewDataErrorEventArgs e)
        {
            ShowErrorMessage();
        }

        private static void ShowErrorMessage()
        {
            MessageBox.Show("Correct you input! Only digits '1' and '0' allowed!",
                            "Input error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private bool ValidateInput()
        {
            foreach (DataGridViewRow row in gridMask.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    var value = int.Parse(cell.Value.ToString());

                    if (value == 0 || value == 1) continue;
                    ShowErrorMessage();
                    return false;
                }
            }
            return true;
        }

        private void OnApply(object sender, EventArgs e)
        {


            if (!ValidateInput()) return;
            Filter = GetFilter();
            DialogResult = DialogResult.Yes;
            Close();

        }

        private int[,] GetFilter()
        {
            var filter = new int[3, 3];
            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                {
                    var value = int.Parse(gridMask[j, i].Value.ToString());
                    filter[i, j] = value;
                }
            return filter;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            var i = e.ColumnIndex;
            var j = e.RowIndex;
            
            var curValue = int.Parse(gridMask[i, j].Value.ToString());
            switch (curValue)
            {
                case 0:
                    gridMask[i, j].Value = 1;
                    break;
                case 1:
                    gridMask[i, j].Value = 0;
                    break;
            }
        }
    }
}