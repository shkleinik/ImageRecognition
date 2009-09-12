using System.Drawing;
using System.Windows.Forms;
using MPO.UI;

namespace MPO.Grids
{
    public abstract class BaseGrid : DataGridView
    {
        public abstract Bitmap GridToOriginalBitmap();
        public abstract void ImageToGrid(Bitmap originalBitmap);
        //public abstract HalfToneGridView ToHalfToneGrid();
        public abstract BaseGrid ToHalfToneGrid(MainForm mainForm);
        //public abstract BaseGrid ToColoredGrid(MainForm mainForm);

        public static DataGridView CreateDataGrid(int maxCellValue, int imageSize)
        {
            var helpGrid = new DataGridView();
            var dataGridViewCellStyle1 = new DataGridViewCellStyle();
            helpGrid.AllowUserToAddRows = false;
            helpGrid.AllowUserToDeleteRows = false;
            helpGrid.AllowUserToResizeColumns = false;
            helpGrid.AllowUserToResizeRows = false;
            helpGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            helpGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            helpGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point,
                                                   ((204)));
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            helpGrid.DefaultCellStyle = dataGridViewCellStyle1;
            helpGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
            helpGrid.Location = new Point(10, 10);
            //helpGrid.Name = "dataGridView1";
            helpGrid.ReadOnly = true;
            helpGrid.RowHeadersVisible = false;
            helpGrid.RowHeadersWidth = 20;
            helpGrid.RowTemplate.Height = 20;
            helpGrid.Size = new Size(530, 462);
            //helpGrid.TabIndex = 2;
            //helpGrid.Visible = true;
            //helpGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(helpGrid.dataGridView1_CellMouseClick);

            for (int i = 0; i < imageSize; i++)
            {
                var column = new DataGridViewTextBoxColumn();
                column.Width = 15;
                column.Name = i + "name";
                column.CellTemplate.Style.BackColor = Color.LightBlue;
                helpGrid.Columns.Add(column);
            }
            for (int i = 0; i < imageSize; i++)
            {
                var row = new DataGridViewRow();
                row.Height = 15;
                helpGrid.Rows.Add(row);
            }

            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    helpGrid.Rows[j].Cells[i].Value = maxCellValue;
                }

            return helpGrid;
        }

        public static BaseGrid CreateHalfToneGrid(int maxCellValue, int imageSize, MainForm mainForm)
        {
            var helpGrid = new HalfToneGridView(imageSize, imageSize, mainForm);

            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    helpGrid.Rows[j].Cells[i].Value = maxCellValue;
                }

            return helpGrid;
        }
    }
}