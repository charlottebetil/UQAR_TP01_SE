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
    public partial class SupBarriereForm : Form
    {
        private List<Barriere> lstBarrieres;
        public SupBarriereForm(ref List<Barriere> lstBarrieres)
        {
            InitializeComponent();
            this.lstBarrieres = lstBarrieres;
            this.displayLstBarrieres();
        }

        // Reconstruire la liste des barrières
        private void displayLstBarrieres()
        {
            this.lstBarrieresAnnulees.BeginUpdate();
            foreach (Barriere barriere in this.lstBarrieres)
            {
                this.lstBarrieresAnnulees.Items.Add(barriere.getID());
            }
            this.lstBarrieresAnnulees.EndUpdate();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.lstBarrieresAnnulees.SelectedItem != null)
            {
                ListBox.SelectedObjectCollection selectedItem = new ListBox.SelectedObjectCollection(lstBarrieresAnnulees);
                lstBarrieresAnnulees.Items.Remove(selectedItem);
                lstBarrieres.Remove(lstBarrieres.Find(barriere => barriere.getID() == Convert.ToInt32(this.lstBarrieresAnnulees.SelectedItem)));
                this.Close();
            }
            else
            {
                MessageBox.Show("Selectionnez une barrière");
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
