using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace CSGOL
{
    public partial class View : Form
    {
        private Controller controller;
        private System.Windows.Forms.Timer t;
        private int iterations;

        public View(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            controller.View = this;
        }

        /// <summary>
        /// Chargement de la vue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_Load(object sender, EventArgs e)
        {
            DrawCells((short)((trBarSize.Value + 1) * 10));
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000 / (trBarSpeed.Value + 1);
            t.Tick += timerTick;
            iterations = 0;
        }

        private void timerTick(object sender, EventArgs e)
        {
            iterations++;
            lblIteration.Text = "Itération : " + iterations;
            UpdateToNextGrid();
        }

        /// <summary>
        /// Dessine dans le panel les éléments boutons d'une grille de cellules
        /// </summary>
        /// <param name="cellGrid"></param>
        private void DrawCells(short size)
        {
            controller.Start();
            dtGrid.SuspendLayout();
            for (short i = 0; i < size; i++)
            {
                dtGrid.Columns.Add("", "");
                dtGrid.Columns[i].Width = (dtGrid.Width / size);
            }
            dtGrid.Rows.Add(size - 1);
            for (short j = 0; j < dtGrid.Rows.Count; j++)
            {
                dtGrid.Rows[j].Height = (dtGrid.Width / size);
            }
            dtGrid.ResumeLayout();
        }



        /// <summary>
        /// Prochaine itération
        /// </summary>
        private void UpdateToNextGrid()
        {
            var toChange = controller.GetCellsToChange();
            for (short i = 0; i < toChange.Count; i++)
            {
                if (toChange[i][2] == 1)
                    dtGrid.Rows[toChange[i][1]].Cells[toChange[i][0]].Style.BackColor = Color.Black;
                else
                    dtGrid.Rows[toChange[i][1]].Cells[toChange[i][0]].Style.BackColor = Color.White;
            }
        }

        /// <summary>
        ///
        /// </summary>
        private void ChangeGridSize(short newSize)
        {
            short toAdd = (short)(newSize - dtGrid.Columns.Count);
            if (toAdd > 0)
            {
                dtGrid.SuspendLayout();
                for (short i = 0; i < toAdd; i++)
                    dtGrid.Columns.Add("", "");
                for (short j = 0; j < dtGrid.Columns.Count; j++)
                    dtGrid.Columns[j].Width = (dtGrid.Width / newSize);
                dtGrid.Rows.Add(toAdd);
                for (short k = 0; k < dtGrid.Rows.Count; k++)
                    dtGrid.Rows[k].Height = (dtGrid.Height / newSize);
                dtGrid.ResumeLayout();
            }
            else
            {
                dtGrid.SuspendLayout();
                short debutRange = (short)(dtGrid.Columns.Count + toAdd);
                short columnCount = (short)dtGrid.Columns.Count;
                short rowCount = (short)dtGrid.Rows.Count;
                for (short i = (short)(columnCount - 1); i >= debutRange; i--)
                    dtGrid.Columns.RemoveAt(i);
                for (short j = (short)(rowCount - 2); j >= debutRange; j--)
                    dtGrid.Rows.RemoveAt(j);

                for (short k = 0; k < dtGrid.Columns.Count; k++)
                    dtGrid.Columns[k].Width = (dtGrid.Width / newSize);
                for (short l = 0; l < dtGrid.Rows.Count; l++)
                    dtGrid.Rows[l].Height = (dtGrid.Height / newSize);
                dtGrid.ResumeLayout();
            }


        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearGrid()
        {
            controller.ClearGrid();
            var size = (short)dtGrid.Columns.Count;
            dtGrid.Columns.Clear();
            DrawCells(size);
            iterations = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStep_Click(object sender, EventArgs e)
        {
            iterations++;
            lblIteration.Text = "Itération : " + iterations;
            UpdateToNextGrid();
        }

        /// <summary>
        /// Click du Bouton autoStep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoStep_Click(object sender, EventArgs e)
        {
            this.btnAutoStep.ForeColor = Color.Green;
            this.t.Start();
        }

        private void cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            dtGrid.ClearSelection();
            controller.SwitchCellValue((short)e.ColumnIndex, (short)e.RowIndex);
            if (dtGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Black)
                this.dtGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            else
                this.dtGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Black;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnAutoStep.ForeColor = Color.Red;
            t.Stop();
        }

        /// <summary>
        /// Changement de la taille de la grille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trBarSize_Changed(object sender, EventArgs e)
        {
            ChangeGridSize((short)((trBarSize.Value + 1) * 10));
        }

        private void trBarSpeed_Scroll(object sender, EventArgs e)
        {
            t.Interval = 1000 / (trBarSpeed.Value + 1);
        }

        /// <summary>
        /// Réinitialise l'affichage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearGrid();
            trBarSize.Value = 0;
            lblIteration.Text = "Itération : " + iterations;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = txtFilePath.Text;
            if (!controller.Export(path))
                MessageBox.Show("caca");
        }
    }
}
