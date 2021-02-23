namespace tp01_SE
{
    partial class SupProcessForm
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
            this.lstProcessusAnnule = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstProcessusAnnule
            // 
            this.lstProcessusAnnule.FormattingEnabled = true;
            this.lstProcessusAnnule.ItemHeight = 20;
            this.lstProcessusAnnule.Location = new System.Drawing.Point(18, 18);
            this.lstProcessusAnnule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstProcessusAnnule.Name = "lstProcessusAnnule";
            this.lstProcessusAnnule.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstProcessusAnnule.Size = new System.Drawing.Size(319, 224);
            this.lstProcessusAnnule.TabIndex = 0;        
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(105, 271);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 35);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(226, 271);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(112, 35);
            this.btnAnnuler.TabIndex = 2;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // SupProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 325);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lstProcessusAnnule);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SupProcessForm";
            this.Text = "Suppression de Processus";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstProcessusAnnule;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnuler;
    }
}