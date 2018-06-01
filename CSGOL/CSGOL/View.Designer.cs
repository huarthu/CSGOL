namespace CSGOL
{
    partial class View
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCells = new System.Windows.Forms.Panel();
            this.trBarSize = new System.Windows.Forms.TrackBar();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnStep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trBarSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCells
            // 
            this.pnlCells.Location = new System.Drawing.Point(12, 12);
            this.pnlCells.Name = "pnlCells";
            this.pnlCells.Size = new System.Drawing.Size(550, 550);
            this.pnlCells.TabIndex = 0;
            // 
            // trBarSize
            // 
            this.trBarSize.Location = new System.Drawing.Point(568, 39);
            this.trBarSize.Maximum = 5;
            this.trBarSize.Name = "trBarSize";
            this.trBarSize.Size = new System.Drawing.Size(354, 45);
            this.trBarSize.TabIndex = 1;
            this.trBarSize.Scroll += new System.EventHandler(this.trBarSize_Changed);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(568, 13);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(145, 18);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Taille de la grille : ";
            // 
            // btnStep
            // 
            this.btnStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep.Location = new System.Drawing.Point(571, 478);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(141, 84);
            this.btnStep.TabIndex = 3;
            this.btnStep.Text = "STEP";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 612);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.trBarSize);
            this.Controls.Add(this.pnlCells);
            this.MaximizeBox = false;
            this.Name = "View";
            this.Text = "CSGOL";
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trBarSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCells;
        private System.Windows.Forms.TrackBar trBarSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnStep;
    }
}

