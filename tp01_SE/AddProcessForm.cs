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
    public partial class AddProcessForm : Form
    {
        private List<Processus> lstProcessus;
        public static bool annuler = false;
        public AddProcessForm(ref List<Processus> lstProcessus)
        {
            InitializeComponent();
            this.lstProcessus = lstProcessus;
        }

        private int nbThread()
        {
            if (this.rdBtnMono.Checked) {
                return (1);
            } else if (this.rdBtn2Thread.Checked)
            {
                return (2);
            } else if (this.rdBtn3Thread.Checked)
            {
                return (3);
            }
             return (1);
        }

        // Vérifier les infos d'ajout d'un processus
        private bool checkInputFilled()
        {
            if (this.txtNom.Text == "" || this.numNbInstructCalc.Value + this.numNbInstructES.Value < this.nbThread())
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        // Ajouter le processus quand on clique sur ok
        private void btnOk_Click(object sender, EventArgs e)
        {
            int indiceTID = -1;
            foreach(Processus processus in lstProcessus)
            {
                foreach(Thread thread in processus.getThreads())
                {
                    indiceTID++;
                }
            }

            Processus currentProcessus = new Processus(this.lstProcessus.Count() , this.txtNom.Text, Convert.ToInt32(this.numPriorite.Value), this.numNbInstructCalc.Value, this.numNbInstructES.Value, this.nbThread(), indiceTID);
            if (this.checkInputFilled())
            {
                this.lstProcessus.Add(currentProcessus);
                this.Close();
            }
            else
            {
                MessageBox.Show("Saisie incorrecte");
            }
        }

        // Annuler l'ajout d'un processus
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            annuler = true;
            this.Close();
        }

        // Calculer la taille totale de tous les processus créés
        private int calculerTailleTotaleProcessus()
        {
            int tailleTotale = 0;
            foreach (Processus processus in lstProcessus)
            {
                tailleTotale += processus.getTaille();
            }
            return tailleTotale;
        }
    }
}
