using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOL
{
    public class Model
    {
        private Controller controller;

        //Variables model
        public bool[,] cellGrid;



        public Model(Controller controller)
        {
            this.controller = controller;
            controller.Model = this;
        }

        /// <summary>
        /// Initialise le tableau logique de cellules
        /// </summary>
        /// <param name="size"></param>
        public void StartGrid(short size)
        {
            cellGrid = null;
            cellGrid = new bool[size, size];
        }

        public bool[,] NextGrid()
        {
            short size = (short)cellGrid.GetLength(0);
            bool[,] nextGrid = new bool[size, size];
            byte cellsAlive;
            for (short y = 0; y < size; y++)
                for (short x = 0; x < size; x++)
                {
                    cellsAlive = 0;
                    if (x + 1 < size)
                    {
                        if (y + 1 < size)
                        {
                            if (cellGrid[x + 1, y + 1])
                                cellsAlive++;
                            if (cellGrid[x, y + 1])
                                cellsAlive++;
                        }
                        if (y - 1 > 0)
                        {
                            if (cellGrid[x, y - 1])
                                cellsAlive++;
                            if (cellGrid[x + 1, y - 1])
                                cellsAlive++;
                        }
                        if (cellGrid[x + 1, y])
                            cellsAlive++;
                    }
                    if (x - 1 > 0)
                    {
                        if (y + 1 < size)
                        {
                            if (cellGrid[x - 1, y + 1])
                                cellsAlive++;
                        }
                        if (y - 1 > 0)
                        {
                            if (cellGrid[x - 1, y - 1])
                                cellsAlive++;
                        }
                        if (cellGrid[x - 1, y])
                            cellsAlive++;
                    }
                    if (cellsAlive == 3 || (cellGrid[x, y] && cellsAlive == 2))
                        nextGrid[x, y] = true;
                }
            
            return nextGrid;
        }
    }
}
