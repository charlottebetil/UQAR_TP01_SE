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

        private void btnOk_Click(object sender, EventArgs e)
        {
            Processus currentProcessus = new Processus(this.lstProcessus.Count() + 1 , this.txtNom.Text, Convert.ToInt32(this.numPriorite.Value), this.numNbInstructCalc.Value, this.numNbInstructES.Value, this.nbThread());
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

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
