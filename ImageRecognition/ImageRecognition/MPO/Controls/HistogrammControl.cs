using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MPO.Controls
{
    public partial class HistogrammControl : UserControl
    {

        public DataGridView grid;
        private const int maxHeight = 120;

        private Point BP = new Point(20, 130);

        public HistogrammControl()
        {
            InitializeComponent();
        }


        public HistogrammControl(DataGridView dataGrid)
        {
            InitializeComponent();
            grid = dataGrid;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawHistogramm();
        }

        public void DrawHistogramm()
        {
            var g = CreateGraphics();
            g.Clear(BackColor);
            var columnsHeights = GetColumnsHeights();
            if (columnsHeights == null) return;
            var maxColumnHeight = GetColumnsMaxHeight(columnsHeights);
            DrawDesignElements(maxColumnHeight);
            for (var i = 0; i < columnsHeights.Length; i++)
            {
                DrawColumn(i, columnsHeights[i], maxColumnHeight);
            }
        }

        private void DrawDesignElements(int maxColumnHeight)
        {
            var g = CreateGraphics();
            g.DrawString(maxColumnHeight.ToString(),
                new Font(FontFamily.GenericSerif,8.0F),
                Brushes.Black,
                BP.X + 3,
                BP.Y-maxHeight);

            g.DrawString("0",
                new Font(FontFamily.GenericSerif, 8.0F),
                Brushes.Black,
                BP.X,
                BP.Y
                );

            g.DrawString("255",
                new Font(FontFamily.GenericSerif,8.0F),
                Brushes.Black,
                BP.X+255,
                BP.Y
                );

            g.DrawLine(new Pen(Brushes.Black,2.0F),
                new Point(BP.X - 3,BP.Y),
                new Point( BP.X-3,BP.Y - maxHeight));
        }

        private void DrawColumn(int columnNumber, int columnHeight, int maxColumnHeight)
        {
            var g = CreateGraphics();

            if (grid == null) return;
            var k = (double)maxHeight / maxColumnHeight;

            var bottom = new Point(BP.X + columnNumber, BP.Y);
            var top = new Point(BP.X + columnNumber, (int)(BP.Y - columnHeight * k));
            g.DrawLine(Pens.DarkGray, bottom, top);
        }

        private int[] GetColumnsHeights()
        {
            if (grid == null) return null;
            var width = grid.Columns.Count;
            var height = grid.Rows.Count;
            var columnsHeights = new int[256];

            //for (var c = 0; c < columnsHeights.Length; c++)
            //{
                for (var i = 0; i < height; i++)
                {
                    for (var j = 0; j < width; j++)
                    {
                        var curValue = int.Parse(grid[i, j].Value.ToString());
                        //if (curValue == c)
                        columnsHeights[curValue]++;
                    }
                }
            //}

            return columnsHeights;
        }

        private static int GetColumnsMaxHeight(int[] columnsHeights)
        {
            var maxColumnHeight = int.MinValue;

            for (var i = 0; i < columnsHeights.Length; i++)
            {
                if (columnsHeights[i] > maxColumnHeight)
                    maxColumnHeight = columnsHeights[i];
            }
            if (maxColumnHeight == 0)
                return maxHeight * maxHeight;
            return maxColumnHeight;
        }
    }
}