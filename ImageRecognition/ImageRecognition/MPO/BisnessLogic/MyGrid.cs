using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MPO.BisnessLogic
{
    public class MyGrid
    {
        public int bottomTextMargin = 10;
        public int cellSize = 100; //px
        public bool drawValues = true;
        public int gridEndX;
        public int gridEndY;
        public Color gridLineColor = Color.Gray;
        public DashStyle gridLineStyle = DashStyle.Dash;
        public int gridLineWidth = 1;
        public int gridStartX = 50;
        public int gridStartY = 50;
        public float interval = 0.5f;
        public int leftTextMargin = 25;
        public float maxX = 2;
        public float maxY = 1;
        public float minX = -2;
        public float minY = -1;
        public Panel owner;

        public int GridHeigthPix
        {
            get { return (gridEndY - gridStartY); }
        }

        public int GridWidthPix
        {
            get { return (gridEndX - gridStartX); }
        }

        public void RecountGridEndX()
        {
            int xNumberIntervals = GetXNumberIntervals();
            gridEndX = GetGridEndX(xNumberIntervals);
        }

        public void RecountGridEndY()
        {
            int yNumberIntervals = GetYNumberIntervals();
            gridEndY = GetGridEndY(yNumberIntervals);
        }

        public void DrawGrid(Graphics g)
        {
            var pen = new Pen(gridLineColor, gridLineWidth);
            pen.DashStyle = gridLineStyle;
            int xNumberIntervals = GetXNumberIntervals();
            int yNumberIntervals = GetYNumberIntervals();
            gridEndX = GetGridEndX(xNumberIntervals);
            gridEndY = GetGridEndY(yNumberIntervals);
            //g.DrawRectangle(pen, gridStartX, gridStartY, gridEndX - gridStartX, gridEndY - gridStartY);
            for (int i = 0; i <= xNumberIntervals; i++)
            {
                if (drawValues)
                {
                    var stringFormat = new StringFormat(StringFormatFlags.DirectionVertical);
                    g.DrawString((minX + i*interval).ToString(), new Font("Arial", 8f), new SolidBrush(Color.White),
                                 gridStartX + i*cellSize - 5, gridEndY + bottomTextMargin, stringFormat);
                }
                g.DrawLine(pen, gridStartX + i*cellSize, gridStartY, gridStartX + i*cellSize, gridEndY);
            }
            for (int j = 0; j <= yNumberIntervals; j++)
            {
                if (drawValues)
                    g.DrawString((maxY - j*interval).ToString(), new Font("Arial", 8f), new SolidBrush(Color.White),
                                 gridStartX - leftTextMargin, gridStartY + j*cellSize - 5);
                g.DrawLine(pen, gridStartX, gridStartY + j*cellSize, gridEndX, gridStartY + j*cellSize);
            }
        }

        private int GetYNumberIntervals()
        {
            return Convert.ToInt32(((maxY - minY)/interval));
        }

        private int GetXNumberIntervals()
        {
            return Convert.ToInt32(((maxX - minX)/interval));
        }

        private int GetGridEndX(int xNumberIntervals)
        {
            return (xNumberIntervals*cellSize) + gridStartX;
        }

        private int GetGridEndY(int yNumberIntervals)
        {
            return (yNumberIntervals*cellSize) + gridStartY;
        }

        public void DrawLimits(double accuracy, Graphics g)
        {
            //Pen pen=new Pen(Color.LightGreen);
            //double gridWidth = gridEndX - gridStartX;
            //double gridHeight = gridEndY - gridStartY;
            //int xNumberAccuracy = GetXNumberAccuracy(accuracy);
            //int yNumberAccuracy=GetYNumberAccuracy(accuracy);
            //for (int i = 0; i <= xNumberAccuracy; i++)
            //{
            //    double pointX = i * accuracy;
            //    for (int j = 0; j <= yNumberAccuracy; j++)
            //    {
            //        double pointY = j * accuracy;
            //        int xCoord = gridStartX + Convert.ToInt32(gridWidth * (pointX / (maxX - minX)));
            //        int yCoord = gridStartY + Convert.ToInt32(gridHeight * (pointY / (maxY - minY)));
            //        //call check limits function there
            //        if (Form1.CheckLimits(minX + pointX, maxY - pointY))
            //        {
            //            pen.Color = Color.LightGreen;
            //            g.DrawEllipse(pen, xCoord, yCoord, 1, 1);
            //        }
            //        else
            //        {
            //            pen.Color = Color.Pink;
            //            g.DrawEllipse(pen, xCoord, yCoord, 1, 1);
            //        }
            //    }
            //}
        }

        private int GetXNumberAccuracy(double accuracy)
        {
            return Convert.ToInt32(((maxX - minX)/accuracy));
        }

        private int GetYNumberAccuracy(double accuracy)
        {
            return Convert.ToInt32(((maxY - minY)/accuracy));
        }

        public Point CoordToFormCoord(double pointX, double pointY)
        {
            int xCoord = gridStartX + Convert.ToInt32(GridWidthPix*((pointX - minX)/(maxX - minX)));
            int yCoord = gridEndY - Convert.ToInt32(GridHeigthPix*((pointY - minY)/(maxY - minY)));
            return (new Point(xCoord, yCoord));
        }
    }
}