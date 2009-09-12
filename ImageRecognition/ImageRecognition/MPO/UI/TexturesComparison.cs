using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MPO.BisnessLogic;

namespace MPO.UI
{
    public partial class TexturesComparison : Form
    {
        public MainForm owner;

        public TexturesComparison(Image image, DataGridView dataGrid)
        {
            InitializeComponent();
            LoadNewImage(image, dataGrid);
        }

        public void LoadNewImage(Image image, DataGridView dataGrid)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            CopyDataGrid(dataGridView1, dataGrid);
            DrawBackColorForAllCells(dataGridView1);
            FillPictureBoxes(image);
        }

        private void FillPictureBoxes(Image image)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = image;
                ScanGrid(false);
                return;
            }
            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = image;
                ScanGrid(false);
                return;
            }
            if (pictureBox3.Image == null)
            {
                pictureBox3.Image = image;
                ScanGrid(false);
                return;
            }
            pictureBox4.Image = image;
            ScanGrid(true);
        }

        private void CopyDataGrid(DataGridView dataGridTarget, DataGridView dataGridFrom)
        {
            var cellStyle = new DataGridViewCellStyle(dataGridTarget.DefaultCellStyle);
            cellStyle.Font = new Font("Arial", 7, FontStyle.Bold);
            cellStyle.ForeColor = Color.Blue;
            dataGridTarget.DefaultCellStyle = cellStyle;
            SetColumnsToGridFromAnotherGrid(dataGridTarget, dataGridFrom);
            FillGridFromAnotherGrid(dataGridTarget, dataGridFrom);
        }

        private void SetColumnsToGridFromAnotherGrid(DataGridView dataGridTarget, DataGridView dataGridFrom)
        {
            for (int i = 0; i < dataGridFrom.Columns.Count; i++)
            {
                dataGridTarget.Columns.Add(i.ToString(), i.ToString());
                dataGridTarget.Columns[i].Width = 30;
            }
        }

        private void FillGridFromAnotherGrid(DataGridView dataGridTarget, DataGridView dataGridFrom)
        {
            for (int i = 0; i < dataGridFrom.Rows.Count; i++)
            {
                var values = new object[dataGridFrom.Columns.Count];
                for (int j = 0; j < dataGridFrom.Columns.Count; j++)
                {
                    string value = dataGridFrom[j, i].Value.ToString();
                    values[j] = value;
                }
                int rowIndex = dataGridTarget.Rows.Add(values);
                dataGridTarget.Rows[rowIndex].Height = dataGridTarget.Columns[0].Width;
            }
        }

        private void DrawBackColorForAllCells(DataGridView dataGrid)
        {
            for (int i = 0; i < dataGrid.Columns.Count; i++)
                for (int j = 0; j < dataGrid.Rows.Count; j++)
                {
                    int value = Convert.ToInt32(dataGrid[i, j].Value);
                    Color color = Color.FromArgb(value, value, value);
                    var cellStyle = new DataGridViewCellStyle(dataGrid.DefaultCellStyle);
                    cellStyle.BackColor = color;
                    dataGrid.Rows[j].Cells[i].Style = cellStyle;
                }
        }

        private void ScanGrid(bool makeComparison)
        {
            double[] koefs = PrimitiveLength.ExecuteAlgorithm(dataGridView1);
            Console.WriteLine("result koefs");
            for (int i = 0; i < koefs.Length; i++)
            {
                Console.WriteLine(koefs[i].ToString());
            }
            var row = new object[compareGrid.Columns.Count];
            row[0] = 0;
            row[1] = koefs[0];
            row[2] = koefs[1];
            row[3] = koefs[2];
            if (compareGrid.Rows.Count == 4)
            {
                compareGrid.Rows.RemoveAt(3);
            }
            compareGrid.Rows.Add(row);
            if (makeComparison)
            {
                var templateKoefs = new double[3];
                templateKoefs[0] = Convert.ToDouble(compareGrid[1, 3].Value);
                templateKoefs[1] = Convert.ToDouble(compareGrid[2, 3].Value);
                templateKoefs[2] = Convert.ToDouble(compareGrid[3, 3].Value);
                for (int i = 0; i < 3; i++)
                {
                    var withWhatkoefs = new double[3];
                    withWhatkoefs[0] = Convert.ToDouble(compareGrid[1, i].Value);
                    withWhatkoefs[1] = Convert.ToDouble(compareGrid[2, i].Value);
                    withWhatkoefs[2] = Convert.ToDouble(compareGrid[3, i].Value);
                    double result = PrimitiveLength.GetCompareKoef(templateKoefs, withWhatkoefs);
                    compareGrid[0, i].Value = result;
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            owner.CompareTexturesForm = null;
            base.OnClosing(e);
        }
    }
}