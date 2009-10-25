using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MPO.Grids
{
    class GridBuilder
    {
        /// <summary>
        /// Init grid with empty rows and columns
        /// </summary>
        /// <param name="grid">grid to init</param>
        /// <param name="colCount">number of columns to add</param>
        /// <param name="rowCount">number of rows to add</param>
        public static void InitGrid(DataGridView grid, int colCount, int rowCount)
        {
            grid.Columns.Clear();            
            for (int i = 0; i < colCount; i++)
            {
                string colName = string.Format("Col{0}", i);
                grid.Columns.Add(colName, colName);
            }
            grid.Rows.Add(rowCount-grid.Rows.Count);
        }

        public static void SetHeadersVisibility(DataGridView grid, bool isColumnHeadersVisible, bool isRowHeadersVisible)
        {
            grid.RowHeadersVisible = isRowHeadersVisible;
            grid.ColumnHeadersVisible = isColumnHeadersVisible;
        }

        /// <summary>
        /// Sets specified height and width for all cells in grid
        /// </summary>
        /// <param name="grid">grid to modify</param>
        /// <param name="height">height for each cell</param>
        /// <param name="width">width for each cell</param>
        public static void SetCellStyle(DataGridView grid, int cellHeight, int cellWidth)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].Width = cellWidth;
            }
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].Height = cellHeight;
            }
        }

        public static void StretchCellsToTableSize(DataGridView grid)
        {
            int cellWidth = (grid.Size.Width) / (grid.Columns.Count == 0 ? 1 : grid.Columns.Count);
            int cellHeight = (grid.Size.Height) / (grid.Rows.Count == 0 ? 1 : grid.Rows.Count);

            SetCellStyle(grid, cellHeight, cellWidth);            
        }

        public static void SetDefaultBackgroundColor(DataGridView grid)
        {
            for (int y = 0; y < grid.Rows.Count; y++)
            {
                for (int x = 0; x < grid.Columns.Count; x++)
                {
                    grid[x,y].Style.BackColor = grid.DefaultCellStyle.BackColor;
                }
            }
        }
    }
}
