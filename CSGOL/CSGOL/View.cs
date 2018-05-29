using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void View_Load(object sender, EventArgs e)
        {

            cellGrid = new CellGrid(pnlCells);
            cellGrid.InitCells(10);
            DrawCells(cellGrid);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DrawCells(CellGrid cellGrid)
        {
            pnlCells.Controls.Clear();
            foreach (Cell c in cellGrid.cells)
            {
                pnlCells.Controls.Add(c.btnElement);
            }

        }

        private void trBarSize_Changed(object sender, EventArgs e)
        {
            int newSize = (trBarSize.Value + 1) * 10;
            cellGrid.InitCells(newSize);
            DrawCells(cellGrid);
        }
    }
}
