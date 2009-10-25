using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MPO.BisnessLogic
{
    public class ZondDraw
    {
        public int ColIndexStart=0;
        public int RowIndexStart = 0;
        public int ColIndexEnd = 0;
        public int RowIndexEnd = 0;
        Color foreColor;

        private DataGridView grid;
        public int[,] ZondLine;

        private string name;
        public string Name
        {
            get { return InitName() ; }
        }

        public ZondDraw(DataGridView grid)
        {
            this.grid = grid;
        }

        private string InitName()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0},{1}-{2},{3}", ColIndexStart,RowIndexStart,ColIndexEnd,RowIndexEnd);
            this.name=string.Format("Zond {0}",sb.ToString());
            return name;
        }

        public void DrawZond(Color foreColor)
        {
            this.foreColor = foreColor;
            Bitmap b = new Bitmap(grid.Columns.Count, grid.Rows.Count);
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, b.Width, b.Height);
            g.DrawLine(new Pen(Color.Black), ColIndexStart, RowIndexStart, ColIndexEnd, RowIndexEnd);

            int[,] resultLine = new int[b.Height, b.Width];
            ZondLine = new int[b.Height, b.Width];

            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    if (b.GetPixel(x, y).R != 255)
                    {
                        grid[x, y].Style.BackColor = foreColor;
                        ZondLine[x, y] = 1;
                    }
                    else
                    {
                        ZondLine[x, y] = 0;
                    }
                }
            }
            g.Dispose();
        }

        public void Remove()
        {
            for (int y = 0; y < grid.Rows.Count; y++)
            {
                for (int x = 0; x < grid.Columns.Count; x++)
                {
                    if (ZondLine[x,y]==1)
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
                    if (ZondLine[x, y] == 1 && grid[x, y].Style.BackColor == grid.DefaultCellStyle.BackColor)
                    {
                        grid[x, y].Style.BackColor = this.foreColor;
                    }
                }
            }
        }

        //this method is unneccessary here
        //but it is usefull if you want to get line (massive of line points)
        public static int[,] GetLineFromTwoPoints(int startX,int startY,int endX,int endY,int bitWidth,int bitHeight)
        {
            Bitmap b = new Bitmap(bitWidth, bitHeight);
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, b.Width, b.Height);
            g.DrawLine(new Pen(Color.Black), startX, startY, endX, endY);

            int[,] resultLine = new int[b.Height, b.Width];
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    if (b.GetPixel(i, j) == Color.White)
                    {
                        resultLine[i, j] = 0;
                    }
                    else
                    {
                        resultLine[i, j] = 1;
                    }
                }
            }
            g.Dispose();

            return resultLine;
        }
    }
}
