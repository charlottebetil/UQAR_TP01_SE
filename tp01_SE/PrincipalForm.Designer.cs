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
            this.btnLancer = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstRAM = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSup);
            this.groupBox1.Controls.Add(this.btnAjout);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(216, 138);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processus";
            // 
            // btnSup
            // 
            this.btnSup.Location = new System.Drawing.Point(10, 89);
            this.btnSup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSup.Name = "btnSup";
            this.btnSup.Size = new System.Drawing.Size(192, 35);
            this.btnSup.TabIndex = 1;
            this.btnSup.Text = "Supprimer un processus";
            this.btnSup.UseVisualStyleBackColor = true;
            this.btnSup.Click += new System.EventHandler(this.btnSup_Click);
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(10, 31);
            this.btnAjout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(192, 35);
            this.btnAjout.TabIndex = 0;
            this.btnAjout.Text = "Ajouter un processus";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLancer);
            this.groupBox2.Location = new System.Drawing.Point(480, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(266, 138);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulation";
            // 
            // btnLancer
            // 
            this.btnLancer.Location = new System.Drawing.Point(9, 31);
            this.btnLancer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLancer.Name = "btnLancer";
            this.btnLancer.Size = new System.Drawing.Size(248, 35);
            this.btnLancer.TabIndex = 2;
            this.btnLancer.Text = "Lancer";
            this.btnLancer.UseVisualStyleBackColor = true;
            this.btnLancer.Click += new System.EventHandler(this.btnLancer_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstRAM);
            this.groupBox3.Location = new System.Drawing.Point(18, 180);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(728, 452);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RAM";
            // 
            // lstRAM
            // 
            this.lstRAM.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lstRAM.FormattingEnabled = true;
            this.lstRAM.ItemHeight = 20;
            this.lstRAM.Location = new System.Drawing.Point(10, 29);
            this.lstRAM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstRAM.Name = "lstRAM";
            this.lstRAM.Size = new System.Drawing.Size(706, 404);
            this.lstRAM.TabIndex = 1;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 665);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PrincipalForm";
            this.Text = "Ordonnanceur";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnSup;
        private System.Windows.Forms.Button btnLancer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstRAM;
    }
}

