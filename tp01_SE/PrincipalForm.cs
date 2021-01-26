using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp01_SE
{
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenue sur l'outil: Ordonnanceur\n" +
                            "Version: Beta\n" +
                            "Author: Bétil Charlotte & Chevallier Pierre\n" +
                            "Organisation: UQAR\n");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnLancer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lancement de la simulation");
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Ajout d'un nouveau processus");
            Form form = new AddProcessForm();
            form.ShowDialog();
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            Form form = new SupProcessForm();
            form.ShowDialog();
        }
    }
}
