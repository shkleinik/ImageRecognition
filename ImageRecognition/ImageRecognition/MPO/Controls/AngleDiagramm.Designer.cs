namespace MPO.Controls
{
    partial class AngleDiagramm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbAngle = new System.Windows.Forms.TrackBar();
            this.lblAngle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAngle
            // 
            this.tbAngle.Location = new System.Drawing.Point(40, 114);
            this.tbAngle.Maximum = 89;
            this.tbAngle.Name = "tbAngle";
            this.tbAngle.Size = new System.Drawing.Size(119, 50);
            this.tbAngle.TabIndex = 0;
            this.tbAngle.Tag = "Angle";
            this.tbAngle.Value = 45;
            this.tbAngle.ValueChanged += new System.EventHandler(this.OnTrackBarValueChanged);
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(5, 127);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(19, 13);
            this.lblAngle.TabIndex = 1;
            this.lblAngle.Text = "α=45";
            // 
            // AngleDiagramm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAngle);
            this.Controls.Add(this.tbAngle);
            this.Name = "AngleDiagramm";
            this.Size = new System.Drawing.Size(175, 181);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TrackBar tbAngle;
        private System.Windows.Forms.Label lblAngle;
    }
}