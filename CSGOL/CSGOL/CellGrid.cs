using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace CSGOL
{
    class CellGrid
    {
        public List<Cell> cells;
        private Panel cellPanel;

        public CellGrid(Panel panel)
        {
            this.cellPanel = panel;
        }

        public void InitCells(int num)
        {
            cells = new List<Cell>();
            var size = new Size(cellPanel.Width / num, cellPanel.Width / num);
            for (int y = 0; y < cellPanel.Height; y += cellPanel.Height / num)
                for (int x = 0; x < cellPanel.Width; x += cellPanel.Width / num)
                {
                    Cell cell = new Cell(size, new Point(x, y));
                    cells.Add(cell);
                }
        }

    }
}
