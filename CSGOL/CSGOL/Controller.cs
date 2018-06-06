using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSGOL
{
    public class Controller
    {
        private View view;
        public View View
        {
            get { return this.view; }
            set { this.view = value; }
        }

        private Model model;
        public Model Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        private Random rndName;

        public void Start()
        {
            rndName = new Random();
            this.model.StartGrid(20);
            model.NextGrid();
        }


        /// <summary>
        /// Switch la valeur d'une cellule
        /// </summary>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        public void SwitchCellValue(short xPosition, short yPosition)
        {
            if (this.model.cellGrid[xPosition, yPosition])
                this.model.cellGrid[xPosition, yPosition] = false;
            else
                this.model.cellGrid[xPosition, yPosition] = true;

        }

        /// <summary>
        /// Retourne les positions des cellules qui ont changées
        /// </summary>
        /// <returns></returns>
        public List<short[]> GetCellsToChange()
        {
            List<short[]> pertinentGrid = new List<short[]>();
            bool[,] next = this.model.NextGrid();
            short size = (short)next.GetLength(0);
            for (short y = 0; y < size; y++)
                for (short x = 0; x < size; x++)
                    if (next[x, y] != this.model.cellGrid[x, y])
                        pertinentGrid.Add(new short[] { x, y, Convert.ToByte(next[x, y]) });
            this.model.cellGrid = next;
            return pertinentGrid;
        }

        /// <summary>
        /// Aggrandi la taille de la grille de cellules et conserve les valeurs
        /// </summary>
        public bool[,] ChangeSizeAndKeep(short newSize)
        {
            bool[,] newGrid = new bool[newSize, newSize];
            short actualSize = (short)this.model.cellGrid.GetLength(0);
            for (short y = 0; y < actualSize; y++)
                for (short x = 0; x < actualSize; x++)
                    if (x < newSize && y < newSize)
                        newGrid[x, y] = this.model.cellGrid[x, y];

            model.cellGrid = newGrid;
            return newGrid;
        }

        /// <summary>
        /// Réinitialise la grille à zéro
        /// </summary>
        public void ClearGrid()
        {
            short size = (short)this.model.cellGrid.GetLength(0);
            for (short y = 0; y < size; y++)
                for (short x = 0; x < size; x++)
                    this.model.cellGrid[x, y] = false;
        }

        /// <summary>
        /// Importer la grille
        /// </summary>
        public void Import(string path)
        {


        }
        
        /// <summary>
        /// Exportation de la grille
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Export(string path)
        {
            string toExport = "";
            short size = (short)this.model.cellGrid.GetLength(0);
            for (short y = 0; y < size; y++)
            {
                for (short x = 0; x < size; x++)
                    toExport += this.model.cellGrid[x, y].ToString() + " ";
                toExport += "|";
            }
            try
            {
                File.WriteAllText(path + rndName.Next(0, Int32.MaxValue) + ".txt", toExport);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
