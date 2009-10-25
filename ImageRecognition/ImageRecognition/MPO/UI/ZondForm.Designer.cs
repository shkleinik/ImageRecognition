using System.Windows.Forms;
namespace MPO.UI
{
    partial class ZondForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.listBoxZonds = new System.Windows.Forms.ListBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonCheckClass = new System.Windows.Forms.Button();
            this.listBoxClasses = new System.Windows.Forms.ListBox();
            this.buttonRemoveClass = new System.Windows.Forms.Button();
            this.buttonAddClass = new System.Windows.Forms.Button();
            this.buttonRemZond = new System.Windows.Forms.Button();
            this.radioButtonStep3 = new System.Windows.Forms.RadioButton();
            this.radioButtonStep2 = new System.Windows.Forms.RadioButton();
            this.radioButtonStep1 = new System.Windows.Forms.RadioButton();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.buttonClearGrid = new System.Windows.Forms.Button();
            this.groupBoxParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.textBoxResult);
            this.groupBoxParameters.Controls.Add(this.listBoxZonds);
            this.groupBoxParameters.Controls.Add(this.labelResult);
            this.groupBoxParameters.Controls.Add(this.buttonCheckClass);
            this.groupBoxParameters.Controls.Add(this.listBoxClasses);
            this.groupBoxParameters.Controls.Add(this.buttonRemoveClass);
            this.groupBoxParameters.Controls.Add(this.buttonAddClass);
            this.groupBoxParameters.Controls.Add(this.buttonRemZond);
            this.groupBoxParameters.Controls.Add(this.radioButtonStep3);
            this.groupBoxParameters.Controls.Add(this.radioButtonStep2);
            this.groupBoxParameters.Controls.Add(this.radioButtonStep1);
            this.groupBoxParameters.Location = new System.Drawing.Point(518, 23);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(340, 444);
            this.groupBoxParameters.TabIndex = 0;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Parameters";
            // 
            // textBoxResult
            // 
            this.textBoxResult.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxResult.Location = new System.Drawing.Point(166, 346);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(157, 92);
            this.textBoxResult.TabIndex = 12;
            // 
            // listBoxZonds
            // 
            this.listBoxZonds.FormattingEnabled = true;
            this.listBoxZonds.Location = new System.Drawing.Point(123, 55);
            this.listBoxZonds.Name = "listBoxZonds";
            this.listBoxZonds.Size = new System.Drawing.Size(200, 95);
            this.listBoxZonds.TabIndex = 11;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(101, 346);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(59, 13);
            this.labelResult.TabIndex = 10;
            this.labelResult.Text = "Результат";
            // 
            // buttonCheckClass
            // 
            this.buttonCheckClass.Location = new System.Drawing.Point(17, 383);
            this.buttonCheckClass.Name = "buttonCheckClass";
            this.buttonCheckClass.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckClass.TabIndex = 9;
            this.buttonCheckClass.Text = "Check class";
            this.buttonCheckClass.UseVisualStyleBackColor = true;
            this.buttonCheckClass.Click += new System.EventHandler(this.buttonCheckClass_Click);
            // 
            // listBoxClasses
            // 
            this.listBoxClasses.FormattingEnabled = true;
            this.listBoxClasses.Location = new System.Drawing.Point(123, 203);
            this.listBoxClasses.Name = "listBoxClasses";
            this.listBoxClasses.Size = new System.Drawing.Size(200, 95);
            this.listBoxClasses.TabIndex = 8;
            this.listBoxClasses.SelectedIndexChanged += new System.EventHandler(this.listBoxClasses_SelectedIndexChanged);
            // 
            // buttonRemoveClass
            // 
            this.buttonRemoveClass.Location = new System.Drawing.Point(17, 246);
            this.buttonRemoveClass.Name = "buttonRemoveClass";
            this.buttonRemoveClass.Size = new System.Drawing.Size(100, 23);
            this.buttonRemoveClass.TabIndex = 7;
            this.buttonRemoveClass.Text = "Remove class <";
            this.buttonRemoveClass.UseVisualStyleBackColor = true;
            this.buttonRemoveClass.Click += new System.EventHandler(this.buttonRemoveClass_Click);
            // 
            // buttonAddClass
            // 
            this.buttonAddClass.Location = new System.Drawing.Point(17, 217);
            this.buttonAddClass.Name = "buttonAddClass";
            this.buttonAddClass.Size = new System.Drawing.Size(100, 23);
            this.buttonAddClass.TabIndex = 6;
            this.buttonAddClass.Text = "Add class >";
            this.buttonAddClass.UseVisualStyleBackColor = true;
            this.buttonAddClass.Click += new System.EventHandler(this.buttonAddClass_Click);
            // 
            // buttonRemZond
            // 
            this.buttonRemZond.Location = new System.Drawing.Point(17, 91);
            this.buttonRemZond.Name = "buttonRemZond";
            this.buttonRemZond.Size = new System.Drawing.Size(100, 23);
            this.buttonRemZond.TabIndex = 4;
            this.buttonRemZond.Text = "Remove zond <";
            this.buttonRemZond.UseVisualStyleBackColor = true;
            this.buttonRemZond.Click += new System.EventHandler(this.buttonRemZond_Click);
            // 
            // radioButtonStep3
            // 
            this.radioButtonStep3.AutoSize = true;
            this.radioButtonStep3.Location = new System.Drawing.Point(23, 349);
            this.radioButtonStep3.Name = "radioButtonStep3";
            this.radioButtonStep3.Size = new System.Drawing.Size(56, 17);
            this.radioButtonStep3.TabIndex = 2;
            this.radioButtonStep3.Text = "Step 3";
            this.radioButtonStep3.UseVisualStyleBackColor = true;
            this.radioButtonStep3.CheckedChanged += new System.EventHandler(this.radioButtonStep3_CheckedChanged);
            // 
            // radioButtonStep2
            // 
            this.radioButtonStep2.AutoSize = true;
            this.radioButtonStep2.Location = new System.Drawing.Point(23, 180);
            this.radioButtonStep2.Name = "radioButtonStep2";
            this.radioButtonStep2.Size = new System.Drawing.Size(56, 17);
            this.radioButtonStep2.TabIndex = 1;
            this.radioButtonStep2.Text = "Step 2";
            this.radioButtonStep2.UseVisualStyleBackColor = true;
            this.radioButtonStep2.CheckedChanged += new System.EventHandler(this.radioButtonStep2_CheckedChanged);
            // 
            // radioButtonStep1
            // 
            this.radioButtonStep1.AutoSize = true;
            this.radioButtonStep1.Checked = true;
            this.radioButtonStep1.Location = new System.Drawing.Point(23, 30);
            this.radioButtonStep1.Name = "radioButtonStep1";
            this.radioButtonStep1.Size = new System.Drawing.Size(56, 17);
            this.radioButtonStep1.TabIndex = 0;
            this.radioButtonStep1.TabStop = true;
            this.radioButtonStep1.Text = "Step 1";
            this.radioButtonStep1.UseVisualStyleBackColor = true;
            this.radioButtonStep1.CheckedChanged += new System.EventHandler(this.radioButtonStep1_CheckedChanged);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.AllowUserToResizeColumns = false;
            this.dataGridViewMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewMain.Location = new System.Drawing.Point(12, 23);
            this.dataGridViewMain.MultiSelect = false;
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewMain.Size = new System.Drawing.Size(500, 500);
            this.dataGridViewMain.TabIndex = 1;
            this.dataGridViewMain.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMain_CellMouseUp);
            this.dataGridViewMain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMain_CellMouseDown);
            this.dataGridViewMain.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellMouseEnter);
            this.dataGridViewMain.MouseLeave += new System.EventHandler(this.dataGridViewMain_MouseLeave);
            this.dataGridViewMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellClick);
            // 
            // buttonClearGrid
            // 
            this.buttonClearGrid.Location = new System.Drawing.Point(535, 483);
            this.buttonClearGrid.Name = "buttonClearGrid";
            this.buttonClearGrid.Size = new System.Drawing.Size(75, 23);
            this.buttonClearGrid.TabIndex = 2;
            this.buttonClearGrid.Text = "Clear Grid";
            this.buttonClearGrid.UseVisualStyleBackColor = true;
            this.buttonClearGrid.Click += new System.EventHandler(this.buttonClearGrid_Click);
            // 
            // ZondForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 529);
            this.Controls.Add(this.buttonClearGrid);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.groupBoxParameters);
            this.Name = "ZondForm";
            this.Text = "ZondForm";
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);

        }       

        #endregion

        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private RadioButton radioButtonStep3;
        private RadioButton radioButtonStep1;
        private Button buttonRemZond;
        private Label labelResult;
        private Button buttonCheckClass;
        private ListBox listBoxClasses;
        private Button buttonRemoveClass;
        private Button buttonAddClass;
        private RadioButton radioButtonStep2;
        private ListBox listBoxZonds;
        private TextBox textBoxResult;
        private Button buttonClearGrid;
    }
}