using System;
using System.Drawing;
using System.Windows.Forms;
using MPO.Grids;
using MPO.UI;

namespace MPO.Grids
{
    internal class ColoredGrid : BaseGrid
    {
        private readonly int[] trackValueBefore = new int[3] {0, 0, 0};
        public DataGridView[] colorGrids;
        public TrackBar[] trackBar1;

        public ColoredGrid(int imageSize, MainForm mainForm)
        {
            var dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point,
                                                   ((204)));
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;


            colorGrids = new DataGridView[3];
            trackBar1 = new TrackBar[3];
            for (int j = 0; j < 3; j++)
            {
                colorGrids[j] = new DataGridView();
                colorGrids[j].AllowUserToAddRows = false;
                colorGrids[j].AllowUserToDeleteRows = false;
                colorGrids[j].AllowUserToResizeColumns = false;
                colorGrids[j].AllowUserToResizeRows = false;
                colorGrids[j].ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                colorGrids[j].ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                colorGrids[j].ColumnHeadersVisible = false;
                colorGrids[j].DefaultCellStyle = dataGridViewCellStyle1;
                colorGrids[j].EditMode = DataGridViewEditMode.EditProgrammatically;
                colorGrids[j].Location = new Point(280 + j*290, 177);
                colorGrids[j].Name = j.ToString();
                colorGrids[j].ReadOnly = true;
                colorGrids[j].RowHeadersVisible = false;
                colorGrids[j].RowHeadersWidth = 20;
                colorGrids[j].RowTemplate.Height = 20;
                colorGrids[j].Size = new Size(200, 460);
                colorGrids[j].TabIndex = 2;
                colorGrids[j].Visible = true;
                //this.DefaultCellStyle.Format = "N2";
                //this.DefaultCellStyle.NullValue = (object)(0);            
                //this.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
                colorGrids[j].SelectionChanged += dataGridView1_SelectionChanged;

                for (int i = 0; i < imageSize; i++)
                {
                    var column = new DataGridViewTextBoxColumn();
                    column.Width = 20;
                    column.Name = i + "name";
                    column.CellTemplate.Style.BackColor = Color.LightBlue;
                    colorGrids[j].Columns.Add(column);
                }
                for (int i = 0; i < imageSize; i++)
                {
                    var row = new DataGridViewRow();
                    row.Height = 20;
                    colorGrids[j].Rows.Add(row);
                }

                for (int i = 0; i < imageSize; i++)
                    for (int k = 0; k < imageSize; k++)
                    {
                        colorGrids[j][i, k].Value = 255; //white
                    }

                trackBar1[j] = new TrackBar();
                trackBar1[j].LargeChange = 1;
                trackBar1[j].Location = new Point(500 + j*290, 180);
                trackBar1[j].Maximum = 510;
                trackBar1[j].Name = j.ToString();
                trackBar1[j].Orientation = Orientation.Vertical;
                trackBar1[j].RightToLeft = RightToLeft.Yes;
                trackBar1[j].Size = new Size(35, 250);
                trackBar1[j].TabIndex = 5;
                trackBar1[j].Value = 255;
                trackBar1[j].Scroll += trackBar1_Scroll;

                mainForm.Controls.Add(trackBar1[j]);
                mainForm.Controls.Add(colorGrids[j]);
            }
        }

        public override Bitmap GridToOriginalBitmap()
        {
            var mainForm = (MainForm) FindForm();
            int size = mainForm.imageSize;
            var originalBitmap = new Bitmap(size, size);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    int colorR = Convert.ToInt32((colorGrids[0][i, j].Value));
                    int colorG = Convert.ToInt32((colorGrids[1][i, j].Value));
                    int colorB = Convert.ToInt32((colorGrids[2][i, j].Value));
                    Color color = Color.FromArgb(colorR, colorG, colorB);
                    originalBitmap.SetPixel(i, j, color);
                }

            return originalBitmap;
        }

        public override void ImageToGrid(Bitmap originalBitmap)
        {
            var mainForm = (MainForm) FindForm();
            int imageSize = mainForm.imageSize;

            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    byte color;
                    color = Convert.ToByte(originalBitmap.GetPixel(i, j).R);
                    colorGrids[0][i, j].Value = color;
                    color = Convert.ToByte(originalBitmap.GetPixel(i, j).G);
                    colorGrids[1][i, j].Value = color;
                    color = Convert.ToByte(originalBitmap.GetPixel(i, j).B);
                    colorGrids[2][i, j].Value = color;
                }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var grid = (DataGridView) sender;
            int index = Convert.ToInt32(grid.Name);

            trackBar1[index].Value = 255;
            trackValueBefore[index] = 255;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var trackbar = (TrackBar) sender;
            int index = Convert.ToInt32(trackbar.Name);

            DataGridViewSelectedCellCollection cellCollection = colorGrids[index].SelectedCells;
            for (int i = 0; i < cellCollection.Count; i++)
            {
                int cellValue = Convert.ToInt32(cellCollection[i].Value);
                cellValue += (trackBar1[index].Value - trackValueBefore[index]);
                if (cellValue > 255)
                {
                    cellValue = 255;
                }
                if (cellValue < 0)
                {
                    cellValue = 0;
                }
                cellCollection[i].Value = cellValue;
            }
            trackValueBefore[index] = trackBar1[index].Value;
        }


        public void SetVisible()
        {
            for (int i = 0; i < 3; i++)
            {
                colorGrids[i].Visible = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            var mainForm = (MainForm) FindForm();
            if (mainForm != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    mainForm.Controls.Remove(colorGrids[i]);
                    mainForm.Controls.Remove(trackBar1[i]);
                }
            }
            base.Dispose(disposing);
        }


        //laba 2
        //3.1.2
        public override BaseGrid ToHalfToneGrid(MainForm mainForm)
        {
            int imageSize = mainForm.imageSize;
            var halfToneGrid = new HalfToneGridView(imageSize, imageSize, mainForm);
            //DataGridView helpGrid = BaseGrid.CreateDataGrid(10, imageSize + 2);

            halfToneGrid.Visible = true;
            Visible = false;

            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    int R = Convert.ToInt32(colorGrids[0][i, j].Value);
                    int G = Convert.ToInt32(colorGrids[1][i, j].Value);
                    int B = Convert.ToInt32(colorGrids[2][i, j].Value);
                    var mas = new int[3];
                    mas[0] = R;
                    mas[1] = G;
                    mas[2] = B;
                    Array.Sort(mas);
                    int max = mas[2];
                    int min = mas[0];
                    int average = (max + min)/2;
                    halfToneGrid[i, j].Value = average;
                }

            //FromHelpToHalfToneGrid(halfToneGrid, helpGrid, imageSize);

            return halfToneGrid;
        }
    }
}