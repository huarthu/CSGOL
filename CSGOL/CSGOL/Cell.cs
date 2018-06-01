using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CSGOL
{
    public class Cell
    {
        private CellGrid cellGrid;
        public List<Cell> neighbors;

        private bool alive = false;
        public bool isAlive
        {
            get { return this.alive; }
        }

        private Button btn;
        public Button btnElement
        {
            get { return this.btn; }
        }
        public Point location;
        Point Location
        {
            get { return this.location; }
            set { btn.Location = value; this.location = value; }
        }

        private int xPosition;
        public int XPosition
        {
            get { return this.xPosition; }
        }

        private int yPosition;
        public int YPosition
        {
            get { return this.yPosition; }
        }

        /// <summary>
        /// Constructeur d'une cellule, la taille definit la fraction par rapport au tableau
        /// </summary>
        /// <param name="size"></param>
        public Cell(CellGrid grid, Size size, Point location)
        {
            this.cellGrid = grid;

            //Création du bouton
            btn = new Button();
            btn.FlatStyle = FlatStyle.Flat;
            this.location = location;
            btn.Location = location;
            btn.Size = size;
            btn.BackColor = Color.White;
            btn.Click += btnSwitched;
            neighbors = new List<Cell>();
        }

        private void btnSwitched(object sender, EventArgs e)
        {
            if (alive == false)
                SwitchCell(true);
            else
                SwitchCell(false);
        }
        
        /// <summary>
        /// Définit la position logique de la cellule dans la grille
        /// </summary>
        public void SetLogicalPosition(int x, int y)
        {
            this.xPosition = x;
            this.yPosition = y;          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SwitchCell(bool value)
        {
            if (value)
            {
                this.alive = true;
                btn.BackColor = Color.Black;
            }
            else
            {
                this.alive = false;
                btn.BackColor = Color.White;
            }
        } 
    }
}

