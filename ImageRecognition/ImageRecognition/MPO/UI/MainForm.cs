//-----------------------------------------------------------------------
// <copyright file="KvaziTopologicMethod.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Zui Maxim,Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace MPO.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Text;
    using System.Windows.Forms;
    using BisnessLogic;
    using Grids;

    /// <summary>
    /// Main GUI entry of application. Unfortunately contains some elements of business logic.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constants
        private const string BRAND_MESSAGE = "Pasha & Max informs you that . . .";
        private const string IMAGE_ALREADE_LOADED_MESSAGE = "The image you are trying to load had been already laoded";
        private const string IMAGE_PANELS_TOOL_TIP = "You can press the left mouse button to view pictures GridView or Middle to remove picture from panel";
        #endregion

        #region Fields
        private static int[,] AuxiliaryArray;
        private BaseGrid currentGrid;
        public int imageSize = 50;

        public TexturesComparison CompareTexturesForm;
        public int multy = 5;
        private Bitmap originalBitmap;
        private string selectedImageFile;
        private Symbol symbolRecognizedByKvazar;
        #endregion

        #region Constructors
        public MainForm()
        {
            InitializeComponent();
            angleDiagramm.tbAngle.ValueChanged += OnLiniarScaling;
            commonToolTip.ToolTipTitle = BRAND_MESSAGE;
        }
        #endregion

        #region Main form events
        private void MainForm_Load(object sender, EventArgs e)
        {
            ActivateMenu(state.start, false);
#if DEBUG
            LoadPicture(@"TestImages\a_Mono.bmp", imageType.mono);
            LoadPicture(@"TestImages\h.bmp", imageType.mono);
            LoadPicture(@"TestImages\h_Mono.bmp", imageType.mono);
            LoadPicture(@"TestImages\Test.bmp", imageType.mono);
            LoadPicture(@"TestImages\Ц.bmp", imageType.mono);
            LoadPicture(@"TestImages\K.bmp", imageType.mono);
            LoadPicture(@"TestImages\7_0.bmp", imageType.mono);
            LoadPicture(@"TestImages\7_2.bmp", imageType.mono);
            LoadPicture(@"TestImages\П.bmp", imageType.mono);
#endif
        }
        #endregion

        #region Menus events
        private void On_miToChessRange_Click(object sender, EventArgs e)
        {
            currentGrid.ImageToGrid(originalBitmap);
            Controls.Remove(currentGrid);
            currentGrid = ((MonoGrid)currentGrid).ToChessGrid(this);
            Controls.Add(currentGrid);
            pictureBoxPreview.Tag = imageType.tone;
            GridToImageToolStripMenuItem_Click(this, null);
        }

        private void On_miBuildHistogramm_Click(object sender, EventArgs e)
        {
            var imageT = (imageType)pictureBoxPreview.Tag;
            if (imageT == imageType.tone)
            {
                var histogForm = new Histogramm(currentGrid);
                histogForm.Show();
            }
            if (imageT == imageType.mono)
            {
                var histogForm = new Histogramm(currentGrid);
                histogForm.Show();
            }
        }

        private void On_miToChessRange_Opening(object sender, CancelEventArgs e)
        {
            if (pictureBoxPreview.Tag == null)
            {
                contextMenuStripToChessRange.Enabled = false;
            }
            else
            {
                var imageT = (imageType)pictureBoxPreview.Tag;
                switch (imageT)
                {
                    case imageType.colored:
                        toToolStripMenuItem.Enabled = false;
                        buildHistogrammToolStripMenuItem.Enabled = false;
                        privmitivesLengthToolStripMenuItem.Enabled = false;
                        filtrateToolStripMenuItem.Enabled = false;
                        applyMedianFilterToolStripMenuItem.Enabled = false;
                        break;
                    case imageType.mono:
                        toToolStripMenuItem.Enabled = true;
                        buildHistogrammToolStripMenuItem.Enabled = true;
                        privmitivesLengthToolStripMenuItem.Enabled = true;
                        filtrateToolStripMenuItem.Enabled = true;
                        applyMedianFilterToolStripMenuItem.Enabled = true;
                        break;
                    case imageType.tone:
                        toToolStripMenuItem.Enabled = false;
                        buildHistogrammToolStripMenuItem.Enabled = true;
                        privmitivesLengthToolStripMenuItem.Enabled = false;
                        filtrateToolStripMenuItem.Enabled = false;
                        applyMedianFilterToolStripMenuItem.Enabled = true;
                        break;
                }
            }
        }

        private void On_miPrimitiveLength_Click(object sender, EventArgs e)
        {
            imageSize = 20;
            On_miToChessRange_Click(sender, e);
            if (CompareTexturesForm == null)
            {
                CompareTexturesForm = new TexturesComparison(pictureBoxPreview.Image, currentGrid);
                CompareTexturesForm.Show();
                CompareTexturesForm.owner = this;
            }
            else
            {
                CompareTexturesForm.LoadNewImage(pictureBoxPreview.Image, currentGrid);
            }
            imageSize = 50;
        }

        private void On_miZondMethod_Click(object sender, EventArgs e)
        {
            var zondForm = new ZondForm();
            zondForm.ShowDialog();
        }

        private void On_miCheckZongeSun_Click(object sender, EventArgs e)
        {
            currentGrid.ImageToGrid(originalBitmap);
            Controls.Remove(currentGrid);
            currentGrid = ((MonoGrid)currentGrid).CheckZongeSun(this);
            Controls.Add(currentGrid);
            pictureBoxPreview.Tag = imageType.mono;
            GridToImageToolStripMenuItem_Click(this, null);
        }

        private void On_miShowNeighboursMatrix_Click(object sender, EventArgs e)
        {
            var kvazar = new KvaziTopologicMethod(GetAuxiliaryArray(currentGrid));
            //ApplyMatrixToGrid(kvazar.NeighboursMatrix));
            //ApplyMatrixToGrid(kvazar.MultipliesMatrix);
            ApplyMatrixToGrid(kvazar.SwitchesMatrix);

            symbolRecognizedByKvazar = kvazar.RecognizedSymbol;

            var keys = new StringBuilder();

            foreach (var key in kvazar.RecognizedSymbol.Keys)
            {
                keys.Append(String.Format("{0}, ", key));
            }

            // keys.Replace(", ", "", keys.Length - 4, 3);

            MessageBox.Show(String.Format("Keys of the current symbol or pattern are: \n {0}", keys),
                "Keys of the current symbol or pattern.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            miRecognizeLetter.Enabled = true;
        }

        private void On_miRecognizeLetter_Click(object sender, EventArgs e)
        {
            if (symbolRecognizedByKvazar == null)
                throw new ArgumentException("Symbol was not recognized by Kvazar");

            var Ц = new Symbol { Keys = new List<int> { 1, 1, 3, 1 }, Name = "Ц" };
            var K = new Symbol { Keys = new List<int> { 1, 1, 3, 3, 1, 1 }, Name = "К" };
            var Семь = new Symbol { Keys = new List<int> { 1, 1, 1, 3, 3, 1 }, Name = "7" };
            var Семь_1 = new Symbol { Keys = new List<int> { 1, 1, 3, 1, 1 }, Name = "7" };

            var supportedSymbols = new List<Symbol> { Ц, K, Семь, Семь_1 };

            foreach (var symbol in supportedSymbols)
            {
                if (0 != symbolRecognizedByKvazar.CompareTo(symbol))
                    continue;
                MessageBox.Show(String.Format("Recognized symbol is \"{0}\"", symbol.Name), "Recognition result");
                return;
            }
            MessageBox.Show("Symbol is not recognized.", "Recognition result");
        }

        private void On_miEnterFilter_Click(object sender, EventArgs e)
        {
            var filterDialog = new FilterForm();
            var dlgResult = filterDialog.ShowDialog();
            var filter = filterDialog.Filter;

            if (dlgResult == DialogResult.Yes)
            {
                //AuxiliaryArray = GetAuxiliaryArray(currentGrid);
                ApplyFilterToCurrentGrid(filter);
                AuxiliaryArray = GetAuxiliaryArray(currentGrid);
                histogramm.grid = currentGrid;
                histogramm.DrawHistogramm();
                GridToImageToolStripMenuItem_Click(this, null);
            }
            if (dlgResult == DialogResult.No)
            {
                MessageBox.Show("You've DISAGREED!");
            }
        }

        private void On_miApplyMedianFilter_Click(object sender, EventArgs e)
        {
            ApplyMedianFilteringToCurrentGrid();
            histogramm.grid = currentGrid;
            histogramm.DrawHistogramm();
            AuxiliaryArray = GetAuxiliaryArray(currentGrid);
            GridToImageToolStripMenuItem_Click(this, null);
        }
        #endregion

        #region Angle diagram events
        private void OnLiniarScaling(object sender, EventArgs e)
        {
            ApplyScaleToGrid();
            GridToImageToolStripMenuItem_Click(this, null);
            histogramm.grid = currentGrid;
            histogramm.DrawHistogramm();
        }
        #endregion

        #region ActivateMainMenu

        private void ActivateMenu(state status, bool activate)
        {
            switch (status)
            {
                case state.start:
                    saveAsToolStripMenuItem.Enabled = activate;
                    saveToolStripMenuItem.Enabled = activate;
                    imageToolStripMenuItem.Enabled = activate;
                    gridToolStripMenuItem.Enabled = activate;
                    break;
                case state.image:
                    saveAsToolStripMenuItem.Enabled = activate;
                    saveToolStripMenuItem.Enabled = activate;
                    imageToolStripMenuItem.Enabled = activate;
                    miRecognizeLetter.Enabled = false;
                    break;
                case state.grid:
                    gridToolStripMenuItem.Enabled = activate;
                    break;
            }
        }

        #endregion

        #region Main menu

        private void LoadFileDialog(imageType imageT)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != null)
                {
                    try
                    {
                        LoadPicture(openFileDialog1.FileName, imageT);
                        selectedImageFile = openFileDialog1.FileName;
                        Text = openFileDialog1.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void LoadPicture(string filename, imageType imageT)
        {
            foreach (Control control in panelImages.Controls)
            {
                if (control.GetType() == typeof(PictureBox))
                {
                    if (((PictureBox)control).ImageLocation == filename)
                    {
                        MessageBox.Show(IMAGE_ALREADE_LOADED_MESSAGE, BRAND_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
            }


            var pictureBox = new PictureBox();
            int num = GetNumberOfPictures();
            pictureBox.SetBounds(15 + num * 115, 15, 100, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.MouseClick += OnClickPicture;
            pictureBox.Load(filename);
            pictureBox.Tag = imageT;
            commonToolTip.SetToolTip(pictureBox, IMAGE_PANELS_TOOL_TIP);
            panelImages.Controls.Add(pictureBox);
            pictureBox.Show();
            var label = new Label();
            label.SetBounds(15 + num * 115, 120, 100, 15);
            label.Text = GetShortFileName(filename);
            panelImages.Controls.Add(label);
        }

        private void monoPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFileDialog(imageType.mono);
        }

        private void halfToneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFileDialog(imageType.tone);
        }

        private void coloredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFileDialog(imageType.colored);
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GridToImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            originalBitmap = currentGrid.GridToOriginalBitmap();
            ZoomOriginalBitmap((imageType)pictureBoxPreview.Tag);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            originalBitmap.Save(selectedImageFile, ImageFormat.Bmp);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != null)
                {
                    try
                    {
                        originalBitmap.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                        LoadPicture(saveFileDialog1.FileName, (imageType)pictureBoxPreview.Tag);
                        selectedImageFile = saveFileDialog1.FileName;
                        Text = saveFileDialog1.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        private void GridToHalfToneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imageT = (imageType)pictureBoxPreview.Tag;

            if (imageT == imageType.mono)
            {
                Controls.Remove(currentGrid);
                currentGrid = currentGrid.ToHalfToneGrid(this);
                Controls.Add(currentGrid);
                pictureBoxPreview.Tag = imageType.tone;
                GridToImageToolStripMenuItem_Click(this, null);
            }
            else
            {
                MessageBox.Show("Current image is not MONO");
            }
        }

        private void GridColoredToHalfToneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imageT = (imageType)pictureBoxPreview.Tag;
            if (imageT == imageType.colored)
            {
                RemoveCurrentGrid();
                Controls.Remove(currentGrid);
                currentGrid = currentGrid.ToHalfToneGrid(this);
                Controls.Add(currentGrid);
                pictureBoxPreview.Tag = imageType.tone;
                GridToImageToolStripMenuItem_Click(this, null);
            }
            else
            {
                MessageBox.Show("Current image is not Colored");
            }
        }

        #endregion

        #region Image ToGrid-BackToImage
        private void ImageToMono()
        {
            currentGrid = new MonoGrid(imageSize, imageSize);
            Controls.Add(currentGrid);
            currentGrid.ImageToGrid(originalBitmap);
        }

        private void ImageToHalfTone(object sender, EventArgs e)
        {
            var imageT = (imageType)pictureBoxPreview.Tag;

            if (imageT == imageType.tone)
            {
                currentGrid = new HalfToneGridView(imageSize, imageSize, this);
                Controls.Add(currentGrid);
                currentGrid.ImageToGrid(originalBitmap);
                AuxiliaryArray = GetAuxiliaryArray(currentGrid);
                angleDiagramm.Visible = true;
                angleDiagramm.tbAngle.Value = 45;
                histogramm.Visible = true;
                histogramm.grid = currentGrid;
                histogramm.DrawHistogramm();
            }

            if (imageT == imageType.mono)
            {
                //make half tone from mono
                currentGrid.ImageToGrid(originalBitmap);
                Controls.Remove(currentGrid);
                currentGrid = currentGrid.ToHalfToneGrid(this);
                Controls.Add(currentGrid);
                pictureBoxPreview.Tag = imageType.tone;
                GridToImageToolStripMenuItem_Click(this, null);
                angleDiagramm.Visible = true;
                angleDiagramm.tbAngle.Value = 45;
                histogramm.Visible = true;
                histogramm.grid = currentGrid;
                histogramm.DrawHistogramm();
            }
            if (imageT == imageType.colored)
            {
                MessageBox.Show("Current image is not MONO");
            }
        }

        private static int[,] GetAuxiliaryArray(DataGridView currentGrid)
        {
            int width = currentGrid.Columns.Count;
            int height = currentGrid.Rows.Count;
            var auxiliaruArray = new int[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    auxiliaruArray[i, j] = int.Parse(currentGrid[i, j].Value.ToString());
                }
            }
            return auxiliaruArray;
        }

        private void ImageToColoredGrid()
        {
            currentGrid = new ColoredGrid(imageSize, this);
            Controls.Add(currentGrid);
            currentGrid.ImageToGrid(originalBitmap);
        }
        #endregion

        #region ImagePanel

        private void OnClickPicture(object sender, MouseEventArgs e)
        {

            switch (e.Button)
            {
                case MouseButtons.Left:
                    var clickedPictureBox = (PictureBox)sender;
                    originalBitmap = new Bitmap(clickedPictureBox.Image);
                    imageSize = clickedPictureBox.Image.Width;
                    ZoomOriginalBitmap((imageType)clickedPictureBox.Tag);

                    RemoveCurrentGrid();
                    ImageToGrid(clickedPictureBox);

                    ActivateMenu(state.image, true);
                    ActivateMenu(state.grid, true);
                    break;
                case MouseButtons.Middle:


                    if (!panelImages.Controls.Contains((PictureBox)sender))
                        return;

                    var indexOfLabel = panelImages.Controls.IndexOf((PictureBox)sender) + 1;
                    panelImages.Controls.RemoveAt(indexOfLabel);
                    panelImages.Controls.Remove((PictureBox)sender);

                    var controlsCounter = 0;
                    foreach (Control control in panelImages.Controls)
                    {
                        if (control.GetType() == typeof(PictureBox))
                            control.SetBounds(15 + controlsCounter * 115, 15, 100, 100);
                        if (control.GetType() == typeof(Label))
                        {
                            control.SetBounds(15 + controlsCounter * 115, 120, 100, 15);
                            controlsCounter++;
                        }
                    }

                    if (GetNumberOfPictures() == 0)
                    {
                        RemoveCurrentGrid();
                        pictureBoxPreview.Image = null;
                    }

                    break;

            }
        }

        private void RemoveCurrentGrid()
        {
            if (currentGrid != null)
            {
                currentGrid.Dispose();
                Controls.Remove(currentGrid);
                GC.Collect();
            }
        }

        private void ImageToGrid(PictureBox pictureBox)
        {
            var imageT = (imageType)pictureBox.Tag;
            switch (imageT)
            {
                case imageType.mono:
                    angleDiagramm.Visible = false;
                    histogramm.Visible = false;
                    ImageToMono();
                    break;
                case imageType.tone:
                    ImageToHalfTone(this, null);
                    break;
                case imageType.colored:
                    angleDiagramm.Visible = false;
                    histogramm.Visible = false;
                    ImageToColoredGrid();
                    break;
            }
        }

        #endregion

        #region Nested types

        private enum imageType
        {
            none,
            mono,
            tone,
            colored
        } ;

        private enum state
        {
            start,
            image,
            grid
        } ;

        #endregion

        #region Actions with grid
        private void ApplyMatrixToGrid(int[,] newState)
        {
            for (var i = 0; i < newState.GetLength(0); i++)
            {
                for (var j = 0; j < newState.GetLength(1); j++)
                {
                    currentGrid[i, j].Value = newState[i, j];
                }
            }
        }

        public void ApplyScaleToGrid()
        {
            var height = currentGrid.Rows.Count;
            var width = currentGrid.Columns.Count;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var k = Math.Tan(angleDiagramm.Angle * Math.PI / 180);
                    var oldValue = (double)AuxiliaryArray[i, j];
                    var newValue = (int)(oldValue * k);

                    if (newValue > 255)
                        newValue = 255;
                    currentGrid[i, j].Value = newValue;
                }
            }
        }

        private void ApplyMedianFilteringToCurrentGrid()
        {
            var height = currentGrid.Rows.Count;
            var width = currentGrid.Columns.Count;
            var extendedMatrix = GetExtendedMatrixFromCurrentGrid();

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var newValue = GetMedianValue(extendedMatrix, i, j);

                    if (newValue > 255)
                        newValue = 255;
                    currentGrid[i, j].Value = newValue;
                }
            }
        }

        private void ApplyFilterToCurrentGrid(int[,] filter)
        {
            var height = currentGrid.Rows.Count;
            var width = currentGrid.Columns.Count;
            var extendedMatrix = GetExtendedMatrixFromCurrentGrid();

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (extendedMatrix[i + 1, j + 1] == 1)
                        continue;
                    var newValue = GetCellValueAccordingFilter(filter, extendedMatrix, i, j);

                    currentGrid[i, j].Value = newValue;
                }
            }
        }

        private int[,] GetExtendedMatrixFromCurrentGrid()
        {
            var width = currentGrid.Columns.Count;
            var height = currentGrid.Rows.Count;

            var extendedMatrix = new int[height + 2, width + 2];

            for (var i = 1; i < height + 1; i++)
            {
                for (var j = 1; j < width + 1; j++)
                {
                    extendedMatrix[i, j] = int.Parse(currentGrid[i - 1, j - 1].Value.ToString());
                }
            }
            for (var i = 1; i < width + 1; i++)
            {
                extendedMatrix[0, i] = int.Parse(currentGrid[0, i - 1].Value.ToString());
                extendedMatrix[height + 1, i] = int.Parse(currentGrid[height - 1, i - 1].Value.ToString());
            }

            for (var i = 1; i < height + 1; i++)
            {
                extendedMatrix[i, 0] = int.Parse(currentGrid[i - 1, 0].Value.ToString());
                extendedMatrix[i, width + 1] = int.Parse(currentGrid[i - 1, width - 1].Value.ToString());
            }

            extendedMatrix[0, 0] = int.Parse(currentGrid[0, 0].Value.ToString());
            extendedMatrix[height + 1, width + 1] = int.Parse(currentGrid[height - 1, width - 1].Value.ToString());
            extendedMatrix[0, width + 1] = int.Parse(currentGrid[0, width - 1].Value.ToString());
            extendedMatrix[height + 1, 0] = int.Parse(currentGrid[height - 1, 0].Value.ToString());

            return extendedMatrix;
        }
        #endregion

        #region Auxiliary methods

        private static int GetMedianValue(int[,] extendedMatrix, int currI, int currJ)
        {
            var ii = 0;
            var jj = 0;
            var neighbours = new List<int>();

            for (var i = currI - 1; i <= currI + 1; i++)
            {
                for (var j = currJ - 1; j <= currJ + 1; j++)
                {
                    neighbours.Add(extendedMatrix[i + 1, j + 1]);
                    jj++;
                }
                ii++;
                jj = 0;
            }

            neighbours.Sort();
            return neighbours[4];
        }

        /// <summary>
        /// Returns number of neighbours of current pixel.
        /// </summary>
        /// <param name="auxiliaryMatrix">Matrix of pixels. Matrix should be binarized (contain only "0" or "1").</param>
        /// <param name="currI">X-coordinate of pixel number of neighbours would be returned.</param>
        /// <param name="currJ">Y-coordinate of pixel number of neighbours would be returned.</param>
        /// <returns>Returns number of neighbours of current pixel.</returns>
        private static int GetNeighboursNumber(int[,] auxiliaryMatrix, int currI, int currJ)
        {
            var neighboursNumber = 0;
            for (var i = currI - 1; i <= currI + 1; i++)
            {
                for (var j = currJ - 1; j <= currJ + 1; j++)
                {
                    if (i < 0 || j < 0 || i > (auxiliaryMatrix.GetLength(0) - 2) || j > (auxiliaryMatrix.GetLength(1) - 2))
                        continue;
                    if (i == currI && j == currJ)
                        continue;

                    neighboursNumber += auxiliaryMatrix[i, j];
                }
            }

            return neighboursNumber;
        }

        private static int GetCellValueAccordingFilter(int[,] filter, int[,] extendedMatrix, int currI, int currJ)
        {
            var ii = 0;
            var jj = 0;

            for (var i = currI - 1; i <= currI + 1; i++)
            {
                for (var j = currJ - 1; j <= currJ + 1; j++)
                {
                    if (filter[jj, ii] == 1 && extendedMatrix[i + 1, j + 1] == 1)
                    {
                        return 1;
                    }
                    jj++;
                }
                ii++;
                jj = 0;
            }

            return extendedMatrix[currI + 1, currJ + 1];
        }

        private void ZoomOriginalBitmap(imageType imageT)
        {
            var color = new Color();
            var brush = new SolidBrush(color);
            int multy = 5;
            // todo suspend memory leak here
            var zoomBitmap = new Bitmap(imageSize * multy, imageSize * multy);
            IntPtr ptr = zoomBitmap.GetHbitmap();
            Image im = Image.FromHbitmap(ptr);
            Graphics g = Graphics.FromImage(im);


            for (int i = 0; i < imageSize; i++)
                for (int j = 0; j < imageSize; j++)
                {
                    brush.Color = originalBitmap.GetPixel(i, j);
                    var rect = new Rectangle(0 + i * multy, 0 + j * multy, multy, multy);
                    g.FillRectangle(brush, rect);
                }

            pictureBoxPreview.Tag = imageT;
            pictureBoxPreview.Image = im;
            g.Dispose();
            GC.Collect();
        }

        private string GetShortFileName(string path)
        {
            char[] slash = { '\\' };
            string[] directories = path.Split(slash);
            string filename = directories[directories.Length - 1];
            filename = filename.Remove(filename.IndexOf("."));
            return filename;
        }

        private int GetNumberOfPictures()
        {
            return panelImages.Controls.Count / 2;
        }
        #endregion
    }
}