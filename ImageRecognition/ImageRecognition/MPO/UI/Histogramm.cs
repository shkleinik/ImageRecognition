using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using MPO.BisnessLogic;

namespace MPO.UI
{
    public partial class Histogramm : Form
    {
        private readonly DataGridView dataGrid;
        private readonly List<int> histValues = new List<int>(256);
        private readonly MyGrid myGrid;
        private int maxNumber;

        public Histogramm(DataGridView dataGrid)
        {
            InitializeComponent();
            InitHistValuesList();
            this.dataGrid = dataGrid;
            AnalyzeGrid(this.dataGrid);
            var grid = new MyGrid();
            grid.minX = 0;
            grid.maxX = 255;
            grid.minY = 0;
            grid.maxY = maxNumber;
            grid.interval = 1f;
            grid.cellSize = 2;
            grid.drawValues = false;
            myGrid = grid;
        }

        private void Histogramm_Load(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            CreateImage(g);
            g.Dispose();
        }

        private void CreateImage(Graphics g)
        {
            myGrid.RecountGridEndX();
            myGrid.RecountGridEndY();
            pictureBox1.Width = myGrid.GridWidthPix + 10 + myGrid.gridStartX;
            pictureBox1.Height = myGrid.GridHeigthPix + 40 + myGrid.gridStartY;

            var bit = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format16bppRgb555);
            Image im = Image.FromHbitmap(bit.GetHbitmap());
            Graphics newG = Graphics.FromImage(im);
            myGrid.DrawGrid(newG);
            DrawHistogramm(newG);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Width *= 2;
            pictureBox1.Height = Convert.ToInt32(Convert.ToDouble(pictureBox1.Height)/1.5);
            pictureBox1.Image = im;
        }

        private void AnalyzeGrid(DataGridView grid)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                for (int j = 0; j < grid.Rows.Count; j++)
                {
                    int index = Convert.ToInt32(grid[i, j].Value);
                    histValues[index]++;
                    if (histValues[index] > maxNumber)
                        maxNumber = histValues[index];
                }
        }

        private void InitHistValuesList()
        {
            for (int i = 0; i < histValues.Capacity; i++)
            {
                histValues.Add(0);
            }
        }

        private void DrawHistogramm(Graphics g)
        {
            for (int i = 0; i < histValues.Count; i++)
            {
                g.FillRectangle(new SolidBrush(Color.Red), myGrid.gridStartX + i*myGrid.cellSize,
                                myGrid.gridEndY - myGrid.cellSize*histValues[i], myGrid.cellSize,
                                myGrid.cellSize*histValues[i]);
            }
        }
    }
}