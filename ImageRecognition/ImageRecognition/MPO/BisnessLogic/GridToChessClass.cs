using System;
using System.Drawing;
using System.Windows.Forms;
using MPO.Grids;

namespace MPO.BisnessLogic
{
    internal class GridToChessClass
    {
        private void BitmapToChessBitmap(Bitmap bitmap, DataGridView dataGrid)
        {
            BitmapToGrid(bitmap, dataGrid);
            //DataGridView chessDataGrid= GridToChess(dataGrid);
            //GridToBitmap(chessDataGrid, bitmap);
        }

        private void BitmapToGrid(Bitmap bitmap, DataGridView dataGrid)
        {
            var cellStyle = new DataGridViewCellStyle(dataGrid.DefaultCellStyle);
            cellStyle.Font = new Font("Arial", 6);
            dataGrid.DefaultCellStyle = cellStyle;
            //SetColumnsToGridFromAnotherGrid(bitmap, dataGrid);
            //FillGridFromAnotherGrid(bitmap, dataGrid);
        }

        private DataGridView GridToChess(DataGridView dataGrid)
        {
            DataGridView helpGrid = BaseGrid.CreateDataGrid(0, dataGrid.Rows.Count);

            for (int i = 0; i < dataGrid.Columns.Count; i++)
                for (int j = 0; j < dataGrid.Rows.Count; j++)
                {
                    int range = 0;
                    int currentCellValue = Convert.ToInt32(dataGrid[i, j].Value);

                    if (currentCellValue == 0) //current is black?
                    {
                        range = SearchNearest(dataGrid, i, j, "white");
                    }
                    else
                    {
                        range = 0 - SearchNearest(dataGrid, i, j, "black");
                    }

                    helpGrid[i, j].Value = range;
                }
            var f = new Form();
            f.Controls.Add(helpGrid);
            f.Show();
            return helpGrid;
        }

        private int SearchNearest(DataGridView dataGrid, int column, int row, string aim)
        {
            int answer = -1;
            int maxRange = GetMaxRange(dataGrid);

            for (int range = 1; range < maxRange; range++)
            {
                if (aim == "white")
                {
                    answer = SearchInRange(dataGrid, range, 255, row, column);
                }
                else
                {
                    answer = SearchInRange(dataGrid, range, 0, row, column);
                }

                if (answer != -1)
                {
                    break;
                }
            }

            return answer;
        }

        private int GetMaxRange(DataGridView dataGrid)
        {
            int maxRange;
            if (dataGrid.Columns.Count > dataGrid.Rows.Count)
            {
                maxRange = dataGrid.Columns.Count;
            }
            else
            {
                maxRange = dataGrid.Rows.Count;
            }
            return maxRange;
        }

        private int SearchInRange(DataGridView dataGrid, int range, int aim, int row, int column)
        {
            int answer = -1;
            int maxRow = dataGrid.Rows.Count;
            int maxColumn = dataGrid.Columns.Count;

            for (int col = -range; col <= range; col++)
                for (int r = -range; r <= range; r++)
                {
                    //current row and column
                    int rangeRow = row + r;
                    int rangeColumn = column + col;

                    //check grid constraints
                    if (rangeRow > -1 && rangeRow < maxRow && rangeColumn > -1 && rangeColumn < maxColumn)
                    {
                        int checkingCell = Convert.ToInt32(dataGrid[column + col, row + r].Value);

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

        private void GridToBitmap(DataGridView dataGrid, Bitmap bitmap)
        {
            NormailizeGrid(dataGrid, 255);
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int colorValue = Convert.ToInt32(dataGrid[i, j].Value);
                    Color color = Color.FromArgb(colorValue, colorValue, colorValue);
                    bitmap.SetPixel(i, j, color);
                }
        }

        private void NormailizeGrid(DataGridView dataGrid, int maxNormalizeValue)
        {
            int minValue = Convert.ToInt32(dataGrid[0, 0].Value);
            int maxValue = Convert.ToInt32(dataGrid[0, 0].Value);
            for (int i = 0; i < dataGrid.Columns.Count; i++)
                for (int j = 0; j < dataGrid.Rows.Count; j++)
                {
                    int currentValue = Convert.ToInt32(dataGrid[i, j].Value);
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
            for (int i = 0; i < dataGrid.Columns.Count; i++)
                for (int j = 0; j < dataGrid.Rows.Count; j++)
                {
                    double currentValue = Convert.ToDouble(dataGrid[i, j].Value);
                    currentValue =
                        Math.Abs(maxNormalizeValue -
                                 Convert.ToInt32((maxNormalizeValue/range)*(currentValue - minValue)));
                    dataGrid[i, j].Value = currentValue;
                }
        }
    }
}