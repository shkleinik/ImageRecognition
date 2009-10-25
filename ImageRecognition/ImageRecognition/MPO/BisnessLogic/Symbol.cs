using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MPO.BisnessLogic
{
    public class Symbol
    {
        public int[,] SymbolPoints;
        private DataGridView grid;
        private Color foreColor;

        private string name = string.Empty;
        public string Name
        {
            get
            {               
                return name;
            }
        }

        public int Width
        {
            get { return grid.Columns.Count; }
        }

        public int Height
        {
            get { return grid.Rows.Count; }
        }

        public int[] Intersections;

        public Symbol(DataGridView grid,Color foreColor)
        {
            this.grid = grid;
            this.SymbolPoints = new int[grid.Rows.Count, grid.Columns.Count];
            this.foreColor = foreColor;
        }

        public void AddPoint(int x, int y)
        {
            this.SymbolPoints[x, y] = 1;
            grid[x, y].Style.BackColor = foreColor;
        }

        public void InitName(string name)
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            sb.AppendFormat("Symbol #{0}",name);
            this.name = sb.ToString();
        }

        public void Remove()
        {
            for (int y = 0; y < grid.Rows.Count; y++)
            {
                for (int x = 0; x < grid.Columns.Count; x++)
                {
                    if (SymbolPoints[x, y] == 1)
                    {
                        grid[x,y].Style.BackColor = grid.DefaultCellStyle.BackColor;
                    }
                }
            }
        }

        public void Redraw()
        {
            for (int y = 0; y < grid.Rows.Count; y++)
            {
                for (int x = 0; x < grid.Columns.Count; x++)
                {
                    if (SymbolPoints[x, y] == 1 )
                        //&& grid[x, y].Style.BackColor == grid.DefaultCellStyle.BackColor)
                    {
                        grid[x, y].Style.BackColor = this.foreColor;
                    }
                }
            }
        }
    }
}
