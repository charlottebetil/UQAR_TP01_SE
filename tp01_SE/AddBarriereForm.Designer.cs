namespace tp01_SE
{
    partial class AddBarriereForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.cLstBoxProcessus = new System.Windows.Forms.CheckedListBox();
            this.lblDescription1 = new System.Windows.Forms.Label();
            this.lblDescription2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(226, 253);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(343, 253);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(100, 28);
            this.btnAnnuler.TabIndex = 17;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // cLstBoxProcessus
            // 
            this.cLstBoxProcessus.FormattingEnabled = true;
            this.cLstBoxProcessus.Location = new System.Drawing.Point(30, 12);
            this.cLstBoxProcessus.Name = "cLstBoxProcessus";
            this.cLstBoxProcessus.Size = new System.Drawing.Size(413, 191);
            this.cLstBoxProcessus.TabIndex = 19;
            // 
            // lblDescription1
            // 
            this.lblDescription1.AutoSize = true;
            this.lblDescription1.Location = new System.Drawing.Point(30, 206);
            this.lblDescription1.Name = "lblDescription1";
            this.lblDescription1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDescription1.Size = new System.Drawing.Size(485, 17);
            this.lblDescription1.TabIndex = 20;
            this.lblDescription1.Text = "Cochez les PID des processus pour lesquels vous désirez mettre la barrière";
            // 
            // lblDescription2
            // 
            this.lblDescription2.AutoSize = true;
            this.lblDescription2.Location = new System.Drawing.Point(27, 223);
            this.lblDescription2.Name = "lblDescription2";
            this.lblDescription2.Size = new System.Drawing.Size(487, 17);
            this.lblDescription2.TabIndex = 21;
            this.lblDescription2.Text = "Les instructions où la barrière sera effective seront générées aléatoirement.";
            // 
            // AddBarriereForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 294);
            this.Controls.Add(this.lblDescription2);
            this.Controls.Add(this.lblDescription1);
            this.Controls.Add(this.cLstBoxProcessus);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnOk);
            this.Name = "AddBarriereForm";
            this.Text = "AjouterBarriere";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.CheckedListBox cLstBoxProcessus;
        private System.Windows.Forms.Label lblDescription1;
        private System.Windows.Forms.Label lblDescription2;
    }
}