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
    public partial class SupProcessForm : Form
    {
        private List<Processus> lstProcessus;
        public SupProcessForm(ref List<Processus> lstProcessus)
        {
            InitializeComponent();
            this.lstProcessus = lstProcessus;
            this.displayLstProcess();
        }

        private void displayLstProcess()
        {
            this.lstProcessusAnnule.BeginUpdate();
            foreach (Processus process in this.lstProcessus)
            {
                this.lstProcessusAnnule.Items.Add(process.getName());
            }
            this.lstProcessusAnnule.EndUpdate();
        }

        /*private void updateLstProcessus(ListBox currentElem) 
        {
            for (int i = currentElem.Items.Count - 1; i >= 0; i--)
            {
                Processus currentProcess = (Processus)currentElem[i];

            }

        }*/


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.lstProcessusAnnule.SelectedItems != null) {

                ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstProcessusAnnule);
                selectedItems = lstProcessusAnnule.SelectedItems;

                if (lstProcessusAnnule.SelectedIndex != -1)
                {
                    this.lstProcessusAnnule.BeginUpdate();
                    for (int i = selectedItems.Count - 1; i >= 0; i--)
                    {
                        lstProcessusAnnule.Items.Remove(selectedItems[i]);
                    }

                    this.lstProcessusAnnule.EndUpdate();
                    this.Close();
                }
            } else
            {
                MessageBox.Show("Selectionnez un processsus");
            }
        }
        /*public static implicit operator int(Duree a)
        {
            return (a.secondes + ((a.minutes + (a.heures * 60)) * 60));
        }*/


        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstProcessusAnnule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
