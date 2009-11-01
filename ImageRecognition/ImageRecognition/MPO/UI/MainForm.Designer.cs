using MPO.Controls;

namespace MPO.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelImages = new System.Windows.Forms.Panel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monoPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.halfToneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageToHalfToneGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GridtoImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GridToHalfToneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloredToHalfToneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi2009 = new System.Windows.Forms.ToolStripMenuItem();
            this.miZondMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.miCheckZongeSun = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStripToChessRange = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildHistogrammToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privmitivesLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyMedianFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowNeighboursMatrix = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.commonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.angleDiagramm = new MPO.Controls.AngleDiagramm();
            this.histogramm = new MPO.Controls.HistogrammControl();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripToChessRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // panelImages
            // 
            this.panelImages.AutoScroll = true;
            this.panelImages.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelImages.Location = new System.Drawing.Point(0, 24);
            this.panelImages.Name = "panelImages";
            this.panelImages.Size = new System.Drawing.Size(1126, 136);
            this.panelImages.TabIndex = 0;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.gridToolStripMenuItem,
            this.mi2009});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1126, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monoPictureToolStripMenuItem,
            this.halfToneToolStripMenuItem,
            this.coloredToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.loadToolStripMenuItem.Text = "Load Picture";
            // 
            // monoPictureToolStripMenuItem
            // 
            this.monoPictureToolStripMenuItem.Name = "monoPictureToolStripMenuItem";
            this.monoPictureToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.monoPictureToolStripMenuItem.Text = "Mono";
            this.monoPictureToolStripMenuItem.Click += new System.EventHandler(this.monoPictureToolStripMenuItem_Click);
            // 
            // halfToneToolStripMenuItem
            // 
            this.halfToneToolStripMenuItem.Name = "halfToneToolStripMenuItem";
            this.halfToneToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.halfToneToolStripMenuItem.Text = "HalfTone";
            this.halfToneToolStripMenuItem.Click += new System.EventHandler(this.halfToneToolStripMenuItem_Click);
            // 
            // coloredToolStripMenuItem
            // 
            this.coloredToolStripMenuItem.Name = "coloredToolStripMenuItem";
            this.coloredToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.coloredToolStripMenuItem.Text = "Colored";
            this.coloredToolStripMenuItem.Click += new System.EventHandler(this.coloredToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageToHalfToneGridToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // ImageToHalfToneGridToolStripMenuItem
            // 
            this.ImageToHalfToneGridToolStripMenuItem.Name = "ImageToHalfToneGridToolStripMenuItem";
            this.ImageToHalfToneGridToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ImageToHalfToneGridToolStripMenuItem.Text = "To HalfTone";
            this.ImageToHalfToneGridToolStripMenuItem.Click += new System.EventHandler(this.ImageToHalfTone);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GridtoImageToolStripMenuItem,
            this.GridToHalfToneToolStripMenuItem,
            this.coloredToHalfToneToolStripMenuItem});
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.gridToolStripMenuItem.Text = "Grid";
            // 
            // GridtoImageToolStripMenuItem
            // 
            this.GridtoImageToolStripMenuItem.Name = "GridtoImageToolStripMenuItem";
            this.GridtoImageToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.GridtoImageToolStripMenuItem.Text = "To Image";
            this.GridtoImageToolStripMenuItem.Click += new System.EventHandler(this.GridToImageToolStripMenuItem_Click);
            // 
            // GridToHalfToneToolStripMenuItem
            // 
            this.GridToHalfToneToolStripMenuItem.Name = "GridToHalfToneToolStripMenuItem";
            this.GridToHalfToneToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.GridToHalfToneToolStripMenuItem.Text = "To halfTone";
            this.GridToHalfToneToolStripMenuItem.Click += new System.EventHandler(this.GridToHalfToneToolStripMenuItem_Click);
            // 
            // coloredToHalfToneToolStripMenuItem
            // 
            this.coloredToHalfToneToolStripMenuItem.Name = "coloredToHalfToneToolStripMenuItem";
            this.coloredToHalfToneToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.coloredToHalfToneToolStripMenuItem.Text = "ColoredToHalfTone";
            this.coloredToHalfToneToolStripMenuItem.Click += new System.EventHandler(this.GridColoredToHalfToneToolStripMenuItem_Click);
            // 
            // mi2009
            // 
            this.mi2009.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miZondMethod,
            this.miCheckZongeSun});
            this.mi2009.Name = "mi2009";
            this.mi2009.Size = new System.Drawing.Size(43, 20);
            this.mi2009.Text = "2009";
            // 
            // miZondMethod
            // 
            this.miZondMethod.Name = "miZondMethod";
            this.miZondMethod.Size = new System.Drawing.Size(186, 22);
            this.miZondMethod.Text = "Zond Method (laba2)";
            this.miZondMethod.Click += new System.EventHandler(this.On_miZondMethod_Click);
            // 
            // miCheckZongeSun
            // 
            this.miCheckZongeSun.Name = "miCheckZongeSun";
            this.miCheckZongeSun.Size = new System.Drawing.Size(186, 22);
            this.miCheckZongeSun.Text = "CheckZongeSun";
            this.miCheckZongeSun.Click += new System.EventHandler(this.On_miCheckZongeSun_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "bmp, jpeg files|*.bmp;*.jpeg;*.jpg";
            this.openFileDialog1.InitialDirectory = "D:\\Temp\\images";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.Size = new System.Drawing.Size(250, 35);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "bmp files|*.bmp";
            this.saveFileDialog1.InitialDirectory = "D:\\Temp\\images";
            // 
            // contextMenuStripToChessRange
            // 
            this.contextMenuStripToChessRange.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toToolStripMenuItem,
            this.buildHistogrammToolStripMenuItem,
            this.privmitivesLengthToolStripMenuItem,
            this.filtrateToolStripMenuItem,
            this.applyMedianFilterToolStripMenuItem,
            this.miShowNeighboursMatrix});
            this.contextMenuStripToChessRange.Name = "contextMenuStripToChessRange";
            this.contextMenuStripToChessRange.Size = new System.Drawing.Size(217, 136);
            this.contextMenuStripToChessRange.Text = "To Chess Range";
            this.contextMenuStripToChessRange.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripToChessRange_Opening);
            // 
            // toToolStripMenuItem
            // 
            this.toToolStripMenuItem.Name = "toToolStripMenuItem";
            this.toToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.toToolStripMenuItem.Text = "To Chess Range";
            this.toToolStripMenuItem.Click += new System.EventHandler(this.toChessRangeToolStripMenuItem_Click);
            // 
            // buildHistogrammToolStripMenuItem
            // 
            this.buildHistogrammToolStripMenuItem.Name = "buildHistogrammToolStripMenuItem";
            this.buildHistogrammToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.buildHistogrammToolStripMenuItem.Text = "Build Histogramm";
            this.buildHistogrammToolStripMenuItem.Click += new System.EventHandler(this.buildHistogrammToolStripMenuItem_Click);
            // 
            // privmitivesLengthToolStripMenuItem
            // 
            this.privmitivesLengthToolStripMenuItem.Name = "privmitivesLengthToolStripMenuItem";
            this.privmitivesLengthToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.privmitivesLengthToolStripMenuItem.Text = "Длина примитива (лаба3)";
            this.privmitivesLengthToolStripMenuItem.Click += new System.EventHandler(this.primitiveLengthToolStripMenuItem_Click);
            // 
            // filtrateToolStripMenuItem
            // 
            this.filtrateToolStripMenuItem.Name = "filtrateToolStripMenuItem";
            this.filtrateToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.filtrateToolStripMenuItem.Text = "Enter extension filter";
            this.filtrateToolStripMenuItem.Click += new System.EventHandler(this.OnFilterClick);
            // 
            // applyMedianFilterToolStripMenuItem
            // 
            this.applyMedianFilterToolStripMenuItem.Name = "applyMedianFilterToolStripMenuItem";
            this.applyMedianFilterToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.applyMedianFilterToolStripMenuItem.Text = "Apply median filter";
            this.applyMedianFilterToolStripMenuItem.Click += new System.EventHandler(this.OnApplyMedianFilter);
            // 
            // miShowNeighboursMatrix
            // 
            this.miShowNeighboursMatrix.Name = "miShowNeighboursMatrix";
            this.miShowNeighboursMatrix.Size = new System.Drawing.Size(216, 22);
            this.miShowNeighboursMatrix.Text = "Show neighboours matrix";
            this.miShowNeighboursMatrix.Click += new System.EventHandler(this.On_miShowNeighboursMatrix_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.ContextMenuStrip = this.contextMenuStripToChessRange;
            this.pictureBoxPreview.Location = new System.Drawing.Point(12, 207);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPreview.TabIndex = 4;
            this.pictureBoxPreview.TabStop = false;
            // 
            // commonToolTip
            // 
            this.commonToolTip.AutoPopDelay = 5000;
            this.commonToolTip.InitialDelay = 100;
            this.commonToolTip.ReshowDelay = 100;
            this.commonToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // angleDiagramm
            // 
            this.angleDiagramm.Angle = 45;
            this.angleDiagramm.BP = new System.Drawing.Point(20, 100);
            this.angleDiagramm.Location = new System.Drawing.Point(12, 463);
            this.angleDiagramm.Name = "angleDiagramm";
            this.angleDiagramm.Size = new System.Drawing.Size(166, 182);
            this.angleDiagramm.TabIndex = 5;
            this.angleDiagramm.Visible = false;
            // 
            // histogramm
            // 
            this.histogramm.BackColor = System.Drawing.Color.White;
            this.histogramm.Location = new System.Drawing.Point(814, 463);
            this.histogramm.Name = "histogramm";
            this.histogramm.Size = new System.Drawing.Size(300, 150);
            this.histogramm.TabIndex = 6;
            this.histogramm.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 647);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.angleDiagramm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelImages);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.histogramm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripToChessRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelImages;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GridtoImageToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem GridToHalfToneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monoPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem halfToneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageToHalfToneGridToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripToChessRange;
        private System.Windows.Forms.ToolStripMenuItem toToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloredToHalfToneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildHistogrammToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem privmitivesLengthToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private AngleDiagramm angleDiagramm;
        private HistogrammControl histogramm;
        private System.Windows.Forms.ToolStripMenuItem filtrateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyMedianFilterToolStripMenuItem;
        private System.Windows.Forms.ToolTip commonToolTip;
        private System.Windows.Forms.ToolStripMenuItem mi2009;
        private System.Windows.Forms.ToolStripMenuItem miZondMethod;
        private System.Windows.Forms.ToolStripMenuItem miCheckZongeSun;
        private System.Windows.Forms.ToolStripMenuItem miShowNeighboursMatrix;
    }
}