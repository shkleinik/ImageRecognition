using System;
using System.Drawing;
using System.Windows.Forms;

namespace MPO.Controls
{
    public partial class AngleDiagramm : UserControl
    {
        private const int height = 100;
        private const int width = 100;

        public AngleDiagramm()
        {
            BP = new Point(20, height);
            InitializeComponent();
            Angle = 45;
        }

        public int Angle { get; set; }

        public double AngleRad
        {
            get { return Angle*Math.PI/180; }
        }

        //base point
        public Point BP { get; set; }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawAxises();
            DrawObliqueLine(Angle);
        }

        private void DrawObliqueLine(int angle)
        {
            Graphics g = CreateGraphics();
            double pi = Math.PI;
            double newX = BP.X + width*Math.Cos(angle*pi/180);
            double newY = BP.Y - width*Math.Sin(angle*pi/180);

            g.DrawLine(Pens.Black, BP, new Point((int) newX, (int) newY));
        }

        public void EraseObliqueLine(int angle)
        {
            Graphics g = CreateGraphics();
            double pi = Math.PI;
            double newX = BP.X + width*Math.Cos(angle*pi/180);
            double newY = BP.Y - width*Math.Sin(angle*pi/180);

            g.DrawLine(new Pen(BackColor), BP, new Point((int) newX, (int) newY));
        }

        private void DrawAxises()
        {
            Graphics g = CreateGraphics();
            g.DrawLine(new Pen(Color.Black, 2.0F), BP, new Point(BP.X, BP.Y - height));
            g.DrawLine(new Pen(Color.Black, 2.0F), BP, new Point(BP.X + width, BP.Y));
            g.DrawString("255",
                         new Font(FontFamily.GenericSerif, 10.0F),
                         Brushes.Black,
                         new PointF(BP.X - 20, BP.Y - height)
                );
            g.DrawString("255",
                         new Font(FontFamily.GenericSerif, 10.0F),
                         Brushes.Black,
                         new PointF(BP.X + width, BP.Y)
                );
            g.DrawString("0",
                         new Font(FontFamily.GenericSerif, 10.0F),
                         Brushes.Black,
                         new PointF(BP.X - 15, BP.Y)
                );
        }

        private void OnTrackBarValueChanged(object sender, EventArgs e)
        {
            EraseObliqueLine(Angle);
            EraseObliqueLine(Angle);
            Angle = tbAngle.Value;
            DrawObliqueLine(Angle);
            DrawAxises();
            lblAngle.Text = "α=" + Angle.ToString();
        }
    }
}