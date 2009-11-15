namespace MPO.BisnessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Symbol class.
    /// </summary>
    public class Symbol : IComparable
    {
        #region Fields
        public int[,] SymbolPoints;
        public int[] Intersections;

        private readonly DataGridView grid;
        private readonly Color foreColor;
        private string name = string.Empty;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
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

        public List<int> Keys { get; set; }
        #endregion

        public Symbol()
        {
        }

        public Symbol(DataGridView grid, Color foreColor)
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
            sb.AppendFormat("Symbol #{0}", name);
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
                        grid[x, y].Style.BackColor = grid.DefaultCellStyle.BackColor;
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
                    if (SymbolPoints[x, y] == 1)
                    //&& grid[x, y].Style.BackColor == grid.DefaultCellStyle.BackColor)
                    {
                        grid[x, y].Style.BackColor = this.foreColor;
                    }
                }
            }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is Symbol)
            {
                var otherSymbol = (Symbol)obj;

                if (otherSymbol.Keys.Count != Keys.Count)
                    return otherSymbol.Keys.Count - Keys.Count;

                for (var i = 0; i < Keys.Count; i++)
                {
                    if(otherSymbol.Keys[i]==Keys[i])
                        continue;
                    return otherSymbol.Keys[i] - Keys[i];
                }
                
                return 0;
            }

            throw new ArgumentException("object is not a Symbol");
        }

        #endregion
    }
}

// Note : Move drawing logic to some outer class like SymbolManager.