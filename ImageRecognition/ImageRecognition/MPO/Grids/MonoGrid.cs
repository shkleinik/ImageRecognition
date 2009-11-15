using System;
using System.Drawing;
using System.Windows.Forms;
using MPO.UI;
using MPO.BisnessLogic;

namespace MPO.Grids
{
    internal class MonoGrid : BaseGrid
    {
        public MonoGrid(int width, int height)
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
            Visible = false;
            CellMouseClick += dataGridView1_CellMouseClick;

            for (int i = 0; i < width; i++)
            {
                var column = new DataGridViewTextBoxColumn();
                column.Width = 15;
                column.Name = i + "name";
                column.CellTemplate.Style.BackColor = Color.LightBlue;
                Columns.Add(column);
            }
            for (int i = 0; i < height; i++)
            {
                var row = new DataGridViewRow();
                row.Height = 15;
                Rows.Add(row);
            }

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Rows[j].Cells[i].Value = 0;
                }
        }

        #region GridViewOperations

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ReverseCell();
        }

        private void ReverseCell()
        {
            DataGridViewSelectedCellCollection cellCollection = SelectedCells;
            for (int i = 0; i < cellCollection.Count; i++)
            {
                if ((int) (cellCollection[i].Value) == 1)
                {
                    cellCollection[i].Value = 0;
                    cellCollection[i].Style.ForeColor = Color.White;
                }
                else
                {
                    cellCollection[i].Value = 1;
                    cellCollection[i].Style.ForeColor = Color.Black;
                }
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
                    var colorValue = (int) (Rows[j].Cells[i].Value);
                    originalBitmap.SetPixel(i, j, GetColorFromCell(colorValue));
                }
            return originalBitmap;
        }

        private Color GetColorFromCell(int CellValue)
        {
            var color = new Color();
            if (CellValue == 1)
            {
                color = Color.Black;
            }
            else
            {
                color = Color.White;
            }
            return color;
        }

        public override void ImageToGrid(Bitmap originalBitmap)
        {
            var mainForm = (MainForm) FindForm();
            //this.a
            int imageSize = mainForm.imageSize;

            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    int color;
                    if (originalBitmap.GetPixel(i, j).R == 0) //black
                    {
                        color = 1; //black
                    }
                    else
                    {
                        color = 0;
                    }
                    Rows[j].Cells[i].Value = color;
                    Rows[j].Cells[i].Style.ForeColor = originalBitmap.GetPixel(i, j);
                }
            Visible = true;
        }
        
        public override BaseGrid ToHalfToneGrid(MainForm mainForm)
        {
            int imageSize = mainForm.imageSize;
            var halfToneGrid = new HalfToneGridView(imageSize, imageSize, mainForm);
            DataGridView helpGrid = CreateDataGrid(10, imageSize + 2);

            halfToneGrid.Visible = true;
            Visible = false;

            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    if ((int) (Rows[j].Cells[i].Value) == 1)
                    {
                        DecreaseNeighbourCells(helpGrid, i + 1, j + 1);
                    }
                }

            FromHelpToHalfToneGrid(halfToneGrid, helpGrid, imageSize);

            return halfToneGrid;
        }

        private void DecreaseNeighbourCells(DataGridView baseGrid, int cell, int row)
        {
            for (int ii = -1; ii < 2; ii++)
                for (int jj = -1; jj < 2; jj++)
                {
                    var value = (int) (baseGrid.Rows[row + ii].Cells[cell + jj].Value);

                    value -= 1;
                    baseGrid.Rows[row + ii].Cells[cell + jj].Value = value;
                }
            var centralValue = (int) (baseGrid.Rows[row].Cells[cell].Value);
            centralValue -= 1;
            baseGrid.Rows[row].Cells[cell].Value = centralValue;
        }

        private void FromHelpToHalfToneGrid(HalfToneGridView halfToneGrid, DataGridView helpGrid, int imageSize)
        {
            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    int value = Convert.ToInt32(helpGrid[i + 1, j + 1].Value);
                    halfToneGrid[i, j].Value = Math.Round(value*25.5);
                }
        }

        public BaseGrid ToChessGrid(MainForm mainForm)
        {
            int imageSize = mainForm.imageSize;
            DataGridView helpGrid = CreateDataGrid(0, imageSize);
            helpGrid.Visible = true;

            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    int range = 0;
                    int currentCellValue = Convert.ToInt32(this[i, j].Value);

                    if (currentCellValue == 1) //current is black?
                    {
                        range = SearchNearest(i, j, "white");
                    }
                    else
                    {
                        range = 0 - SearchNearest(i, j, "black");
                    }

                    helpGrid[i, j].Value = range;
                }
            var f = new Form();
            f.Controls.Add(helpGrid);
            f.Show();
            BaseGrid resultGrid = ChessToHalfTone(helpGrid, mainForm);

            return resultGrid;
        }

        private BaseGrid ChessToHalfTone(DataGridView chessGrid, MainForm mainForm)
        {
            BaseGrid resultGrid = new HalfToneGridView(chessGrid.Columns.Count, chessGrid.Rows.Count, mainForm);
            int minValue = Convert.ToInt32(chessGrid[0, 0].Value);
            int maxValue = Convert.ToInt32(chessGrid[0, 0].Value);
            for (int i = 0; i < chessGrid.Columns.Count; i++)
                for (int j = 0; j < chessGrid.Rows.Count; j++)
                {
                    int currentValue = Convert.ToInt32(chessGrid[i, j].Value);
                    if (maxValue < currentValue)
                    {
                        maxValue = currentValue;
                    }
                    if (minValue > currentValue)
                    {
                        minValue = currentValue;
                    }
                }
            double range = maxValue - minValue;
            for (int i = 0; i < chessGrid.Columns.Count; i++)
                for (int j = 0; j < chessGrid.Rows.Count; j++)
                {
                    double currentValue = Convert.ToDouble(chessGrid[i, j].Value);
                    currentValue = Math.Abs(255 - Convert.ToInt32((255.0/range)*(currentValue - minValue)));
                    resultGrid[i, j].Value = currentValue;
                }
            return resultGrid;
        }

        private int SearchNearest(int column, int row, string aim)
        {
            int answer = -1;
            int maxRange = GetMaxRange();

            for (int range = 1; range < maxRange; range++)
            {
                if (aim == "white")
                {
                    answer = SearchInRange(range, 0, row, column);
                }
                else
                {
                    answer = SearchInRange(range, 1, row, column);
                }

                if (answer != -1)
                {
                    break;
                }
            }

            return answer;
        }

        private int GetMaxRange()
        {
            int maxRange;
            if (Columns.Count > Rows.Count)
            {
                maxRange = Columns.Count;
            }
            else
            {
                maxRange = Rows.Count;
            }
            return maxRange;
        }

        private int SearchInRange(int range, int aim, int row, int column)
        {
            int answer = -1;
            int maxRow = Rows.Count;
            int maxColumn = Columns.Count;

            for (int col = -range; col <= range; col++)
                for (int r = -range; r <= range; r++)
                {
                    //current row and column
                    int rangeRow = row + r;
                    int rangeColumn = column + col;

                    //check grid constraints
                    if (rangeRow > -1 && rangeRow < maxRow && rangeColumn > -1 && rangeColumn < maxColumn)
                    {
                        int checkingCell = Convert.ToInt32(this[column + col, row + r].Value);

                        if (checkingCell == aim)
                        {
                            answer = range;
                            break;
                        }
                    }

                    //walk by edge of range rectangle
                    if (col != -range && col != range && r != range)
                    {
                        r = range - 1;
                    }
                }

            return answer;
        }

        public BaseGrid CheckZongeSun(MainForm mainForm)
        {
            int imageSize = mainForm.imageSize;

            ZongeSyn.BlackValue = 1;
            int[,] gridMas = new int[imageSize, imageSize];
            //copy values to mas from grid
            for (int y = 0; y < imageSize; y++)
            {
                for (int x = 0; x < imageSize; x++)
                {
                    gridMas[y, x] = Convert.ToInt32(this[x, y].Value);
                }
            }

            ZongeSyn.Thin(ref gridMas, imageSize, imageSize);

            //copy values to grid from mas
            for (int y = 0; y < imageSize; y++)
            {
                for (int x = 0; x < imageSize; x++)
                {
                    this[x, y].Value = gridMas[y, x];
                }
            }

            return this;
        }

        #endregion
    }
}