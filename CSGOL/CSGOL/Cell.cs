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
        private bool alive = false;
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


        /// <summary>
        /// Constructeur d'une cellule, la taille definit la fraction par rapport au tableau
        /// </summary>
        /// <param name="size"></param>
        public Cell(Size size, Point location)
        {
            //Création du bouton
            btn = new Button();
            btn.FlatStyle = FlatStyle.Flat;
            this.location = location;
            btn.Location = location;
            btn.Size = size;
            btn.BackColor = Color.White;
            //
            btn.Click += btnElementClick;
        }

        private void btnElementClick(object sender, EventArgs e)
        {
            switch (alive)
            {
                case true:
                    {
                        alive = false;
                        btn.BackColor = Color.White;
                        break;
                    }
                case false:
                    {                      
                        alive = true;
                        btn.BackColor = Color.Black;
                        break;
                    }
            }

        }
    }
}
