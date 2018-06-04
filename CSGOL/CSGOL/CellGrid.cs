using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace CSGOL
{
    public class CellGrid
    {
        public List<Cell> cells;

        private int panelSize;
        public int PanelSize
        {
            get { return this.panelSize; }
        }

        private int width;
        public int Width
        {
            get { return this.width; }
        }

        public CellGrid(int panelSize)
        {
            this.panelSize = panelSize;
        }

        public void InitCells(int num)
        {
            width = num;
            cells = new List<Cell>();
            Point p = new Point();
            var size = new Size(panelSize / width, panelSize / width);
            for (int y = 0; y < width; y++)
                for (int x = 0; x < width; x++)
                {
                    p.X = x * (panelSize / width);
                    p.Y = y * (panelSize / width);
                    Cell cell = new Cell(this, size, p);
                    cell.SetLogicalPosition(x, y);
                    cell.SwitchCell(false);
                    cells.Add(cell);
                }
            SetAllNeighbors(cells, width);
        }

        /// <summary>
        /// Trouve les positions logiques des voisines du tableau selon les limites
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private List<int[]> GetNeighbors(int x, int y, int lastIndex)
        {
            List<int[]> neighbors = new List<int[]>();
            neighbors.Add(new int[] { x, y - 1 });
            neighbors.Add(new int[] { x + 1, y - 1 });
            neighbors.Add(new int[] { x + 1, y });
            neighbors.Add(new int[] { x + 1, y + 1 });
            neighbors.Add(new int[] { x, y + 1 });
            neighbors.Add(new int[] { x - 1, y + 1 });
            neighbors.Add(new int[] { x - 1, y });
            neighbors.Add(new int[] { x - 1, y - 1 });
            return neighbors;
        }

        /// <summary>
        /// Assigne toutes les voisines des cellules
        /// </summary>
        /// <param name="cells"></param>
        public void SetAllNeighbors(List<Cell> cells, int lastIndex)
        {
            foreach (Cell c in cells)
            {
                int x = c.XPosition;
                int y = c.YPosition;

                var validNeighbors = GetNeighbors(x, y, lastIndex);
                foreach (int[] i in validNeighbors)
                {
                    foreach (Cell d in cells)
                    {
                        if (d.XPosition == i[0] && d.YPosition == i[1])
                        {
                            c.neighbors.Add(d);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void NextGrid()
        {
            var temp = new CellGrid(this.panelSize);
            temp.InitCells(this.width);
            var next = temp.cells;
            byte cellsAlive = 0;
            for (int i = 0; i < this.cells.Count; i++)
            {
                cellsAlive = 0;
                foreach (Cell c in cells[i].neighbors)
                    if (c.isAlive)
                        cellsAlive++;
                if (cellsAlive == 3 || (cellsAlive == 2 && cells[i].isAlive == true))
                    next[i].SwitchCell(true);
                else
                    next[i].SwitchCell(false);
            }
            this.cells = next;
        }
    }
}
