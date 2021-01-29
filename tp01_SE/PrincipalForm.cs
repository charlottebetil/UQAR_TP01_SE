using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp01_SE
{
    public partial class PrincipalForm : Form
    {
        public List<Processus> lstProcessus;
        public PrincipalForm()
        {
            InitializeComponent();
            this.lstProcessus = new List<Processus>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenue sur l'outil: Ordonnanceur\n" +
                            "Version: Beta\n" +
                            "Author: Bétil Charlotte & Chevallier Pierre\n" +
                            "Organisation: UQAR\n");

        }

        private void btnLancer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lancement de la simulation");
            //Algo principale
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Ajout");
            Form form = new AddProcessForm(ref this.lstProcessus);
            form.ShowDialog();
            this.displayLstThread();
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            Form form = new SupProcessForm(ref this.lstProcessus);
            form.ShowDialog();
        }

        private void displayLstThread()
        {
            this.lstRAM.BeginUpdate();
            //Je clear les items de la listBox, pour pas que ça reécrive le process précedant
            this.lstRAM.Items.Clear();
            Debug.WriteLine("Affichage des threads: nbProcess:" + this.lstProcessus.Count());
            foreach (Processus process in this.lstProcessus)
            {
                Debug.WriteLine("nbThread: " + process.getThreads().Count());
                foreach(Thread thread in process.getThreads())
                {
                    this.lstRAM.Items.Add(thread.getInfoThread());
                    foreach (string instruct in thread.getInstructions())
                    {
                        this.lstRAM.Items.Add(instruct);
                    }
                }
                
            }
            this.lstRAM.EndUpdate();
        }

        private void lstRAM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
