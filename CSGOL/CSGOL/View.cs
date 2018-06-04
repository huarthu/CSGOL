using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSGOL
{
    public partial class View : Form
    {
        CellGrid cellGrid;
        System.Timers.Timer timer;
        long iteration = 0;

        public View()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Chargement de la vue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_Load(object sender, EventArgs e)
        {
            cellGrid = new CellGrid(pnlCells.Width);
            cellGrid.InitCells((trBarSize.Value + 1) * 10);

            timer = new System.Timers.Timer(20);
            timer.Elapsed += timerTick;
            DrawCells(cellGrid);
        }

        private void timerTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Step();
        }

        /// <summary>
        /// Dessine dans le panel les éléments boutons d'une grille de cellules
        /// </summary>
        /// <param name="cellGrid"></param>
        private void DrawCells(CellGrid cellGrid)
        {
            //Clear efficace des précédents contrôles
            List<Control> ctrls = new List<Control>(pnlCells.Controls.Count);
            pnlCells.Controls.Clear();
            foreach (Control c in ctrls)
                c.Dispose();

            for (int j = 0; j < cellGrid.cells.Count; j++)
                pnlCells.Controls.Add(cellGrid.cells[j].btnElement);

        }

        /// <summary>
        /// Changement de la taille de la grille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trBarSize_Changed(object sender, EventArgs e)
        {
            int newSize = (trBarSize.Value + 1) * 10;
            cellGrid.InitCells(newSize);
            DrawCells(cellGrid);
        }

        /// <summary>
        /// Prochaine itération
        /// </summary>
        private void Step()
        {
            cellGrid.NextGrid();
            UpdatePanel(cellGrid);
            iteration++;
            lblIteration.Text = "Itération : " + iteration;
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            Step();
        }

        private void btnAutoStep_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
                timer.Stop();
            else
                timer.Start();
        }

        private void UpdatePanel(CellGrid newCellGrid)
        {
            for (int i = 0; i < newCellGrid.cells.Count; i++)
                pnlCells.Controls[i].BackColor = newCellGrid.cells[i].btnElement.BackColor;
        }
    }
}
