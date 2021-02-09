namespace tp01_SE
{
    partial class PrincipalForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSup = new System.Windows.Forms.Button();
            this.btnAjout = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_reinitialiser = new System.Windows.Forms.Button();
            this.btnLancerPP = new System.Windows.Forms.Button();
            this.btnLancerPCA = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_RAM = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RAM)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSup);
            this.groupBox1.Controls.Add(this.btnAjout);
            this.groupBox1.Location = new System.Drawing.Point(16, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(199, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processus";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_reinitialiser);
            this.groupBox2.Controls.Add(this.btnLancerPP);
            this.groupBox2.Controls.Add(this.btnLancerPCA);
            this.groupBox2.Location = new System.Drawing.Point(234, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(400, 116);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulation";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_RAM);
            this.groupBox3.Location = new System.Drawing.Point(16, 132);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1285, 447);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RAM";
            // 
            // dgv_RAM
            // 
            this.dgv_RAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RAM.Location = new System.Drawing.Point(9, 22);
            this.dgv_RAM.Name = "dgv_RAM";
            this.dgv_RAM.RowHeadersWidth = 51;
            this.dgv_RAM.RowTemplate.Height = 24;
            this.dgv_RAM.Size = new System.Drawing.Size(1269, 418);
            this.dgv_RAM.TabIndex = 1;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 602);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PrincipalForm";
            this.Text = "Ordonnanceur";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RAM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnSup;
        private System.Windows.Forms.Button btnLancerPCA;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_RAM;
        private System.Windows.Forms.Button btnLancerPP;
        private System.Windows.Forms.Button btn_reinitialiser;
    }
}

