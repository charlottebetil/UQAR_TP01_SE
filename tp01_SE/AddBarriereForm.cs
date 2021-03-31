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
    public partial class AddBarriereForm : Form
    {
        private List<Barriere> lstBarrieres;
        private List<Processus> lstProcessus;
        public static bool deuxProcessusBarriere = true;
        public AddBarriereForm(ref List<Barriere> lstBarrieres, ref List<Processus> lstProcessus)
        {
            InitializeComponent();
            this.lstBarrieres = lstBarrieres;
            this.lstProcessus = lstProcessus;
            plusDunOuZeroProcessus();
            displayLstProcess();
        }

        // Vérifier qu'il y a plus d'un ou zéro processus

        private void plusDunOuZeroProcessus()
        {
            if (lstProcessus.Count == 1)
            {
                MessageBox.Show("Il doit y avoir plus d'un processus dans la job queue pour faire une barrière.");
                deuxProcessusBarriere = false;
                this.Close();
            }
            else if(lstProcessus.Count == 0)
            {
                MessageBox.Show("Il doit y avoir au moins 2 dans la job queue pour faire une barrière.");
                deuxProcessusBarriere = false;
                this.Close();
            }
            else
            {
                deuxProcessusBarriere = true;
            }
        }

        // Reconstruire la liste des processus
        private void displayLstProcess()
        {
            this.cLstBoxProcessus.BeginUpdate();
            foreach (Processus process in this.lstProcessus)
            {
                this.cLstBoxProcessus.Items.Add(process.getPID());
            }
            this.cLstBoxProcessus.EndUpdate();
        }

        // Annuler l'ajout d'une barrière
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Ajouter la barrière quand on clique sur ok
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.cLstBoxProcessus.SelectedItem == null)
            {
                MessageBox.Show("Selectionnez un processus.");
            }
            else if (cLstBoxProcessus.CheckedItems.Count == 1)                
            {
                MessageBox.Show("Selectionnez plus d'un processus");
            }
            else
            {
                Barriere barriere = new Barriere(cLstBoxProcessus.CheckedItems, ref lstProcessus, this.lstBarrieres.Count(), ref lstBarrieres);
                lstBarrieres.Add(barriere);
                this.Close();
            }
        }        
    }
}
