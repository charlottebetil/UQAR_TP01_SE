namespace tp01_SE
{
    partial class principalForm
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
            this.gBoxProcessus = new System.Windows.Forms.GroupBox();
            this.btnSup = new System.Windows.Forms.Button();
            this.btnAjout = new System.Windows.Forms.Button();
            this.gBoxSimulation = new System.Windows.Forms.GroupBox();
            this.btn_reinitialiser = new System.Windows.Forms.Button();
            this.btnLancerPP = new System.Windows.Forms.Button();
            this.btnLancerPCA = new System.Windows.Forms.Button();
            this.gBoxRAM = new System.Windows.Forms.GroupBox();
            this.dgv_RAM = new System.Windows.Forms.DataGridView();
            this.btn_ajouterBarriere = new System.Windows.Forms.Button();
            this.gBox_Barriere = new System.Windows.Forms.GroupBox();
            this.btn_supprimerBarriere = new System.Windows.Forms.Button();
            this.lblInfosBarrieres = new System.Windows.Forms.Label();
            this.pnlInfosBarrieres = new System.Windows.Forms.Panel();
            this.gBoxMemVi = new System.Windows.Forms.GroupBox();
            this.dgv_MemVi = new System.Windows.Forms.DataGridView();
            this.gBoxProcessus.SuspendLayout();
            this.gBoxSimulation.SuspendLayout();
            this.gBoxRAM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RAM)).BeginInit();
            this.gBox_Barriere.SuspendLayout();
            this.pnlInfosBarrieres.SuspendLayout();
            this.gBoxMemVi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MemVi)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxProcessus
            // 
            this.gBoxProcessus.Controls.Add(this.btnSup);
            this.gBoxProcessus.Controls.Add(this.btnAjout);
            this.gBoxProcessus.Location = new System.Drawing.Point(16, 14);
            this.gBoxProcessus.Margin = new System.Windows.Forms.Padding(4);
            this.gBoxProcessus.Name = "gBoxProcessus";
            this.gBoxProcessus.Padding = new System.Windows.Forms.Padding(4);
            this.gBoxProcessus.Size = new System.Drawing.Size(199, 110);
            this.gBoxProcessus.TabIndex = 2;
            this.gBoxProcessus.TabStop = false;
            this.gBoxProcessus.Text = "Processus";
            // 
            // btnSup
            // 
            this.btnSup.Location = new System.Drawing.Point(9, 67);
            this.btnSup.Margin = new System.Windows.Forms.Padding(4);
            this.btnSup.Name = "btnSup";
            this.btnSup.Size = new System.Drawing.Size(183, 35);
            this.btnSup.TabIndex = 1;
            this.btnSup.Text = "Supprimer un processus";
            this.btnSup.UseVisualStyleBackColor = true;
            this.btnSup.Click += new System.EventHandler(this.btnSup_Click);
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(9, 25);
            this.btnAjout.Margin = new System.Windows.Forms.Padding(4);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(183, 34);
            this.btnAjout.TabIndex = 0;
            this.btnAjout.Text = "Ajouter un processus";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // gBoxSimulation
            // 
            this.gBoxSimulation.Controls.Add(this.btn_reinitialiser);
            this.gBoxSimulation.Controls.Add(this.btnLancerPP);
            this.gBoxSimulation.Controls.Add(this.btnLancerPCA);
            this.gBoxSimulation.Location = new System.Drawing.Point(234, 14);
            this.gBoxSimulation.Margin = new System.Windows.Forms.Padding(4);
            this.gBoxSimulation.Name = "gBoxSimulation";
            this.gBoxSimulation.Padding = new System.Windows.Forms.Padding(4);
            this.gBoxSimulation.Size = new System.Drawing.Size(400, 116);
            this.gBoxSimulation.TabIndex = 3;
            this.gBoxSimulation.TabStop = false;
            this.gBoxSimulation.Text = "Simulation";
            // 
            // btn_reinitialiser
            // 
            this.btn_reinitialiser.Location = new System.Drawing.Point(248, 23);
            this.btn_reinitialiser.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reinitialiser.Name = "btn_reinitialiser";
            this.btn_reinitialiser.Size = new System.Drawing.Size(144, 34);
            this.btn_reinitialiser.TabIndex = 4;
            this.btn_reinitialiser.Text = "Réinitialiser";
            this.btn_reinitialiser.UseVisualStyleBackColor = true;
            this.btn_reinitialiser.Click += new System.EventHandler(this.btn_reinitialiser_Click);
            // 
            // btnLancerPP
            // 
            this.btnLancerPP.Location = new System.Drawing.Point(8, 65);
            this.btnLancerPP.Margin = new System.Windows.Forms.Padding(4);
            this.btnLancerPP.Name = "btnLancerPP";
            this.btnLancerPP.Size = new System.Drawing.Size(232, 34);
            this.btnLancerPP.TabIndex = 3;
            this.btnLancerPP.Text = "Par priorité (PP)";
            this.btnLancerPP.UseVisualStyleBackColor = true;
            this.btnLancerPP.Click += new System.EventHandler(this.btnLancerPP_Click);
            // 
            // btnLancerPCA
            // 
            this.btnLancerPCA.Location = new System.Drawing.Point(8, 23);
            this.btnLancerPCA.Margin = new System.Windows.Forms.Padding(4);
            this.btnLancerPCA.Name = "btnLancerPCA";
            this.btnLancerPCA.Size = new System.Drawing.Size(232, 34);
            this.btnLancerPCA.TabIndex = 2;
            this.btnLancerPCA.Text = "Le plus court d\'abord (PCA)";
            this.btnLancerPCA.UseVisualStyleBackColor = true;
            this.btnLancerPCA.Click += new System.EventHandler(this.btnLancerPCA_Click);
            // 
            // gBoxRAM
            // 
            this.gBoxRAM.Controls.Add(this.dgv_RAM);
            this.gBoxRAM.Location = new System.Drawing.Point(25, 186);
            this.gBoxRAM.Margin = new System.Windows.Forms.Padding(4);
            this.gBoxRAM.Name = "gBoxRAM";
            this.gBoxRAM.Padding = new System.Windows.Forms.Padding(4);
            this.gBoxRAM.Size = new System.Drawing.Size(998, 479);
            this.gBoxRAM.TabIndex = 3;
            this.gBoxRAM.TabStop = false;
            this.gBoxRAM.Text = "RAM - 15ko";
            // 
            // dgv_RAM
            // 
            this.dgv_RAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RAM.Location = new System.Drawing.Point(7, 22);
            this.dgv_RAM.Name = "dgv_RAM";
            this.dgv_RAM.RowHeadersWidth = 51;
            this.dgv_RAM.RowTemplate.Height = 24;
            this.dgv_RAM.Size = new System.Drawing.Size(980, 478);
            this.dgv_RAM.TabIndex = 1;
            // 
            // btn_ajouterBarriere
            // 
            this.btn_ajouterBarriere.Location = new System.Drawing.Point(8, 23);
            this.btn_ajouterBarriere.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ajouterBarriere.Name = "btn_ajouterBarriere";
            this.btn_ajouterBarriere.Size = new System.Drawing.Size(182, 34);
            this.btn_ajouterBarriere.TabIndex = 5;
            this.btn_ajouterBarriere.Text = "Ajouter une barrière";
            this.btn_ajouterBarriere.UseVisualStyleBackColor = true;
            this.btn_ajouterBarriere.Click += new System.EventHandler(this.btn_ajouterBarriere_Click);
            // 
            // gBox_Barriere
            // 
            this.gBox_Barriere.Controls.Add(this.pnlInfosBarrieres);
            this.gBox_Barriere.Controls.Add(this.btn_supprimerBarriere);
            this.gBox_Barriere.Controls.Add(this.btn_ajouterBarriere);
            this.gBox_Barriere.Location = new System.Drawing.Point(651, 14);
            this.gBox_Barriere.Margin = new System.Windows.Forms.Padding(4);
            this.gBox_Barriere.Name = "gBox_Barriere";
            this.gBox_Barriere.Padding = new System.Windows.Forms.Padding(4);
            this.gBox_Barriere.Size = new System.Drawing.Size(582, 164);
            this.gBox_Barriere.TabIndex = 3;
            this.gBox_Barriere.TabStop = false;
            this.gBox_Barriere.Text = "Barrière";
            // 
            // btn_supprimerBarriere
            // 
            this.btn_supprimerBarriere.Location = new System.Drawing.Point(8, 67);
            this.btn_supprimerBarriere.Margin = new System.Windows.Forms.Padding(4);
            this.btn_supprimerBarriere.Name = "btn_supprimerBarriere";
            this.btn_supprimerBarriere.Size = new System.Drawing.Size(182, 38);
            this.btn_supprimerBarriere.TabIndex = 6;
            this.btn_supprimerBarriere.Text = "Supprimer une barrière";
            this.btn_supprimerBarriere.UseVisualStyleBackColor = true;
            this.btn_supprimerBarriere.Click += new System.EventHandler(this.btn_supprimerBarriere_Click);
            // 
            // lblInfosBarrieres
            // 
            this.lblInfosBarrieres.AutoSize = true;
            this.lblInfosBarrieres.Location = new System.Drawing.Point(19, 7);
            this.lblInfosBarrieres.Name = "lblInfosBarrieres";
            this.lblInfosBarrieres.Size = new System.Drawing.Size(0, 17);
            this.lblInfosBarrieres.TabIndex = 9;
            // 
            // pnlInfosBarrieres
            // 
            this.pnlInfosBarrieres.AutoScroll = true;
            this.pnlInfosBarrieres.Controls.Add(this.lblInfosBarrieres);
            this.pnlInfosBarrieres.Location = new System.Drawing.Point(210, 13);
            this.pnlInfosBarrieres.Name = "pnlInfosBarrieres";
            this.pnlInfosBarrieres.Size = new System.Drawing.Size(346, 132);
            this.pnlInfosBarrieres.TabIndex = 10;
            // 
            // gBoxMemVi
            // 
            this.gBoxMemVi.Controls.Add(this.dgv_MemVi);
            this.gBoxMemVi.Location = new System.Drawing.Point(1033, 186);
            this.gBoxMemVi.Name = "gBoxMemVi";
            this.gBoxMemVi.Size = new System.Drawing.Size(641, 479);
            this.gBoxMemVi.TabIndex = 4;
            this.gBoxMemVi.TabStop = false;
            this.gBoxMemVi.Text = "Mémoire virtuelle";
            // 
            // dgv_MemVi
            // 
            this.dgv_MemVi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MemVi.Location = new System.Drawing.Point(15, 22);
            this.dgv_MemVi.Name = "dgv_MemVi";
            this.dgv_MemVi.RowHeadersWidth = 51;
            this.dgv_MemVi.RowTemplate.Height = 24;
            this.dgv_MemVi.Size = new System.Drawing.Size(620, 451);
            this.dgv_MemVi.TabIndex = 0;
            // 
            // principalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 748);
            this.Controls.Add(this.gBoxMemVi);
            this.Controls.Add(this.gBox_Barriere);
            this.Controls.Add(this.gBoxRAM);
            this.Controls.Add(this.gBoxSimulation);
            this.Controls.Add(this.gBoxProcessus);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "principalForm";
            this.Text = "Ordonnanceur";
            this.Load += new System.EventHandler(this.principalForm_Load);
            this.gBoxProcessus.ResumeLayout(false);
            this.gBoxSimulation.ResumeLayout(false);
            this.gBoxRAM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RAM)).EndInit();
            this.gBox_Barriere.ResumeLayout(false);
            this.pnlInfosBarrieres.ResumeLayout(false);
            this.pnlInfosBarrieres.PerformLayout();
            this.gBoxMemVi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MemVi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxProcessus;
        private System.Windows.Forms.GroupBox gBoxSimulation;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnSup;
        private System.Windows.Forms.Button btnLancerPCA;
        private System.Windows.Forms.GroupBox gBoxRAM;
        private System.Windows.Forms.DataGridView dgv_RAM;
        private System.Windows.Forms.Button btnLancerPP;
        private System.Windows.Forms.Button btn_reinitialiser;
        private System.Windows.Forms.Button btn_ajouterBarriere;
        private System.Windows.Forms.GroupBox gBox_Barriere;
        private System.Windows.Forms.Button btn_supprimerBarriere;        
        private System.Windows.Forms.Panel pnlInfosBarrieres;
        private System.Windows.Forms.Label lblInfosBarrieres;
        private System.Windows.Forms.GroupBox gBoxMemVi;
        private System.Windows.Forms.DataGridView dgv_MemVi;
    }
}

