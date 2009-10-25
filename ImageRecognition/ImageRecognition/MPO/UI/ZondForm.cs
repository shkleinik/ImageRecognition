using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPO.Grids;
using MPO.BisnessLogic;

namespace MPO.UI
{
    public partial class ZondForm : Form
    {
        //constants
        private Color symbolColor = Color.Black;
        private Color zondColor = Color.Gray;

        List<Control> step1Controls = new List<Control>();
        List<Control> step2Controls = new List<Control>();
        List<Control> step3Controls = new List<Control>();
        int currentStep = 1;
        ZondDraw zond;
        Symbol sym;
        bool isStartDrawZond = false;
        bool isStartDrawSymbol= false;        

        List<ZondDraw> zonds = new List<ZondDraw>();

        #region init form
        public ZondForm()
        {
            InitializeComponent();
            GridBuilder.InitGrid(this.dataGridViewMain, 20, 20);
            GridBuilder.SetHeadersVisibility(this.dataGridViewMain, false, false);            
            GridBuilder.StretchCellsToTableSize(dataGridViewMain);
            dataGridViewMain.DefaultCellStyle.BackColor = Color.White;
            InitControlPackages();
            radioButtonStep1_CheckedChanged(null, null);
            listBoxZonds.DisplayMember = "Name";
            listBoxClasses.DisplayMember = "Name";
        }

        private void InitControlPackages()
        {            
            step1Controls.Add(buttonRemZond);
            step1Controls.Add(listBoxZonds);

            step2Controls.Add(buttonRemoveClass);
            step2Controls.Add(buttonAddClass);
            step2Controls.Add(listBoxClasses);

            step3Controls.Add(buttonCheckClass);
            step3Controls.Add(labelResult);
        }
        #endregion init form

        #region steps logic
        private void SetControlsEnability(List<Control> stepControls,bool isEnabled)
        {
            for (int i = 0; i < stepControls.Count; i++)
            {
                stepControls[i].Enabled = isEnabled;
            }
        }

        private void StepSelectionChanged(int step)
        {
            switch (step)
            { 
                case 1:
                    SetControlsEnability(step1Controls, true);
                    SetControlsEnability(step2Controls, false);
                    SetControlsEnability(step3Controls, false);
                    break;
                case 2:
                    SetControlsEnability(step1Controls, false);
                    SetControlsEnability(step2Controls, true);
                    SetControlsEnability(step3Controls, false);
                    break;
                case 3:
                    SetControlsEnability(step1Controls, false);
                    SetControlsEnability(step2Controls, false);
                    SetControlsEnability(step3Controls, true);
                    break;
            }
        }

        private void radioButtonStep1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStep1.Checked)
            {
                currentStep = 1;
                StepSelectionChanged(currentStep);          
            }
        }

        private void radioButtonStep2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStep2.Checked)
            {
                sym = new Symbol(dataGridViewMain,symbolColor);
                currentStep = 2;
                StepSelectionChanged(currentStep);                
            }
        }

        private void radioButtonStep3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStep3.Checked)
            {
                currentStep = 3;
                StepSelectionChanged(currentStep);
            }
        }        

        #endregion steps logic


        #region step methods

        private void dataGridViewMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButtonStep1.Checked)
            {
                StartStopDrawZond(sender, e);
            }           
        }

        private void dataGridViewMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {            
            if (radioButtonStep2.Checked)
            {
                isStartDrawSymbol = true;
                DrawSymbol(sender,e.RowIndex,e.ColumnIndex );
            }          
        }

        private void dataGridViewMain_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButtonStep2.Checked)
            {
                DrawSymbol(sender, e.RowIndex,e.ColumnIndex);
            }
        }

        private void dataGridViewMain_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            isStartDrawSymbol = false;
        }

        private void dataGridViewMain_MouseLeave(object sender, EventArgs e)
        {
            isStartDrawSymbol = false;
        }

        //zond methods       
        private void StartStopDrawZond(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = zondColor;
            isStartDrawZond = !isStartDrawZond;
            if (isStartDrawZond)
            {
                zond = new ZondDraw(dataGridViewMain);
                zond.ColIndexStart = e.ColumnIndex;
                zond.RowIndexStart = e.RowIndex;
            }
            else
            {
                zond.ColIndexEnd = e.ColumnIndex;
                zond.RowIndexEnd = e.RowIndex;
                zond.DrawZond(Color.Gray);
                listBoxZonds.Items.Add(zond);          
            }            
        }

        private void buttonRemZond_Click(object sender, EventArgs e)
        {
            if (listBoxZonds.SelectedIndex > -1)
            {
                zond = (ZondDraw)listBoxZonds.Items[listBoxZonds.SelectedIndex];
                zond.Remove();
                listBoxZonds.Items.RemoveAt(listBoxZonds.SelectedIndex);
                RedrawZonds();
            }
        }

        private void RedrawZonds()
        {
            for (int i = 0; i < listBoxZonds.Items.Count; i++)
            {
                zond = (ZondDraw)listBoxZonds.Items[i];
                zond.Redraw();
            }
        }

        //classes methods
        private void DrawSymbol(object sender, int rowIndex,int colIndex)
        {                        
            if (isStartDrawSymbol)
            {
                sym.AddPoint(colIndex, rowIndex);
            }
        }

        private void buttonAddClass_Click(object sender, EventArgs e)
        {
            string className = GetClassName();
            if (!string.IsNullOrEmpty(className))
            {
                sym.InitName(className);
                listBoxClasses.Items.Add(sym);
                sym = new Symbol(dataGridViewMain, symbolColor);
                GridBuilder.SetDefaultBackgroundColor(dataGridViewMain);
                RedrawZonds();
            }
        }

        private string GetClassName()
        {
            ClassNameForm classNameForm = new ClassNameForm();
            if (classNameForm.ShowDialog() == DialogResult.OK)
            {
                if(!string.IsNullOrEmpty(classNameForm.textBoxClassName.Text))
                return classNameForm.textBoxClassName.Text;
            }
            return null;
        }

        private void buttonRemoveClass_Click(object sender, EventArgs e)
        {
            if (listBoxClasses.SelectedIndex > -1)
            {
                int selectedIndex = listBoxClasses.SelectedIndex;
                sym = (Symbol)listBoxClasses.Items[selectedIndex];
                sym.Remove();
                listBoxClasses.Items.RemoveAt(selectedIndex);
                RedrawZonds();
            }
        }

        private void RedrawSymbols()
        {
            for (int i = 0; i < listBoxClasses.Items.Count; i++)
            {
                sym = (Symbol)listBoxClasses.Items[i];
                sym.Redraw();
            }
        }
        //result methods
        private void AnalyzeIntersections()
        {
            textBoxResult.Text = "";

            List<ZondDraw> zondes=new List<ZondDraw>();
            for (int i = 0; i < listBoxZonds.Items.Count; i++)
            {
                zondes.Add((ZondDraw)listBoxZonds.Items[i]);
            }

            //init intersections in all symbols
            List<Symbol> symbols = new List<Symbol>();
            for (int i = 0; i < listBoxClasses.Items.Count; i++)
            {
                symbols.Add((Symbol)listBoxClasses.Items[i]);
                IntersectionsAnalyzer.InitIntersections(symbols[i], zondes);
            }

            int index= IntersectionsAnalyzer.Analyze(symbols);
            listBoxClasses.ClearSelected();
            listBoxClasses.SelectedIndex = index;

            textBoxResult.Text = "Выделенный символ наиболее похож на последний символ в списке";
        }

        #endregion step methods

        private void buttonCheckClass_Click(object sender, EventArgs e)
        {
            AnalyzeIntersections();
        }

        private void buttonClearGrid_Click(object sender, EventArgs e)
        {
            GridBuilder.SetDefaultBackgroundColor(dataGridViewMain);
            sym = new Symbol(dataGridViewMain, symbolColor);
            RedrawZonds();
        }

        private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClasses.SelectedIndex > -1)
            {
                buttonClearGrid_Click(null, null);
                ((Symbol)listBoxClasses.Items[listBoxClasses.SelectedIndex]).Redraw();
            }
        }
    }
}
