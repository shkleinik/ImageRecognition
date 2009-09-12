using System;
using System.Drawing;
using System.Windows.Forms;
using MPO.Grids;
using MPO.UI;

namespace MPO.Grids
{
    internal class HalfToneGridView : BaseGrid
    {
        private readonly TrackBar trackBar1;
        private int maxCellValue = 255;
        private int trackValueBefore;

        public HalfToneGridView(int width, int height, MainForm main)
        {
            var dataGridViewCellStyle1 = new DataGridViewCellStyle();
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point,
                                                   ((204)));
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            DefaultCellStyle = dataGridViewCellStyle1;
            EditMode = DataGridViewEditMode.EditProgrammatically;
            Location = new Point(281, 177);
            Name = "dataGridView1";
            ReadOnly = true;
            RowHeadersVisible = false;
            RowHeadersWidth = 20;
            RowTemplate.Height = 20;
            Size = new Size(530, 462);
            TabIndex = 2;
            Visible = true;
            //this.DefaultCellStyle.Format = "N2";
            //this.DefaultCellStyle.NullValue = (object)(0);            
            //this.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            SelectionChanged += dataGridView1_SelectionChanged;

            for (int i = 0; i < width; i++)
            {
                var column = new DataGridViewTextBoxColumn();
                column.Width = 20;
                column.Name = i + "name";
                column.CellTemplate.Style.BackColor = Color.LightBlue;
                Columns.Add(column);
            }
            for (int i = 0; i < height; i++)
            {
                var row = new DataGridViewRow();
                row.Height = 20;
                Rows.Add(row);
            }

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Rows[j].Cells[i].Value = maxCellValue;
                }

            trackBar1 = new TrackBar();
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(850, 179);
            trackBar1.Maximum = 2*maxCellValue;
            trackBar1.Name = "trackBar1";
            trackBar1.Orientation = Orientation.Vertical;
            trackBar1.RightToLeft = RightToLeft.Yes;
            trackBar1.Size = new Size(45, 248);
            trackBar1.TabIndex = 5;
            trackBar1.Value = maxCellValue;
            trackBar1.Scroll += trackBar1_Scroll;

            main.Controls.Add(trackBar1);
        }

        public override Bitmap GridToOriginalBitmap()
        {
            var mainForm = (MainForm) FindForm();
            int size = mainForm.imageSize;
            var originalBitmap = new Bitmap(size, size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    byte colorValue = Convert.ToByte((Rows[j].Cells[i].Value));
                    originalBitmap.SetPixel(i, j, GetColorFromCell(colorValue));
                }
            return originalBitmap;
        }

        private Color GetColorFromCell(byte CellValue)
        {
            //CellValue = (byte)(CellValue);//25.5=255/10  10 is maximum in cell
            Color color = Color.FromArgb(CellValue, CellValue, CellValue);
            return color;
        }

        public override void ImageToGrid(Bitmap originalBitmap)
        {
            var mainForm = (MainForm) FindForm();
            int imageSize = mainForm.imageSize;

            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    byte color = Convert.ToByte((originalBitmap.GetPixel(i, j).R));
                    Rows[j].Cells[i].Value = color;
                }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            trackBar1.Value = maxCellValue;
            trackValueBefore = maxCellValue;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cellCollection = SelectedCells;
            for (int i = 0; i < cellCollection.Count; i++)
            {
                int cellValue = Convert.ToInt32(cellCollection[i].Value);
                cellValue += (trackBar1.Value - trackValueBefore);
                if (cellValue > maxCellValue)
                {
                    cellValue = maxCellValue;
                }
                if (cellValue < 0)
                {
                    cellValue = 0;
                }
                cellCollection[i].Value = cellValue;
            }
            trackValueBefore = trackBar1.Value;
        }

        protected override void Dispose(bool disposing)
        {
            var mainForm = (MainForm) FindForm();
            if (mainForm != null)
                mainForm.Controls.Remove(trackBar1);
            base.Dispose(disposing);
        }

        public override BaseGrid ToHalfToneGrid(MainForm mainForm)
        {
            MessageBox.Show("What are you doing??? It's already shown...");
            return this;
        }
    }
}