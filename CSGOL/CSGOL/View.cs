using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSGOL
{
    public partial class View : Form
    {
        CellGrid cellGrid;

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
            DrawCells(cellGrid);
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

        private void btnStep_Click(object sender, EventArgs e)
        {
            cellGrid.NextGrid();
            UpdatePanel(cellGrid);
        }

        private void UpdatePanel(CellGrid newCellGrid)
        {
            for (int i = 0; i < newCellGrid.cells.Count; i++)
                pnlCells.Controls[i].BackColor = newCellGrid.cells[i].btnElement.BackColor;
        }
    }

    public static class Zoo
    {
        public const int douze = 12;
        public static void Write(string text)
        {
            Console.Write(text);
            Console.ReadLine();
        }
    }
}
