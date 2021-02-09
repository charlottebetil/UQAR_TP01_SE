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
        List<Processus> lstProcessus;
        int rowCountMax = 0;

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

        private void btnLancerPCA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lancement de la simulation PCA");
            dgv_RAM.ClearSelection();
            //Algo principale

            if (lstProcessus.Count > 1) 
            {               
                List<Processus> orderedListProcessus3 = new List<Processus>();
                orderedListProcessus3.AddRange(OrderListProcessusPCA(lstProcessus));                
                
                launchProcessus(orderedListProcessus3);
            }
            else
            {
                launchProcessus(this.lstProcessus);
            } 
        }

        private void btnLancerPP_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lancement de la simulation PP");
            dgv_RAM.ClearSelection();
            
            if (lstProcessus.Count > 1)
            {
                List<Processus> orderedListProcessus = new List<Processus>();
                orderedListProcessus.AddRange(OrderListProcessusPP(lstProcessus));

                launchProcessusPP(orderedListProcessus);
            }
            else
            {
                launchProcessusPP(this.lstProcessus);
            }
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            Form form = new AddProcessForm(ref this.lstProcessus);
            form.ShowDialog();
            this.displayLstThread();
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            Form form = new SupProcessForm(ref this.lstProcessus);
            form.ShowDialog();            
            this.displayLstThread();
            
        }

        private void displayLstThread()
        {         
            int rowIndex = 1;
            int columnIndex = 0;

            updateSizeDgv_RAM();

            foreach (Processus process in this.lstProcessus)
            {   
                foreach(Thread thread in process.getThreads())
                {
                    
                    rowIndex = 0;
                   
                    dgv_RAM.Columns[columnIndex].Name = thread.getInfoThread();
                                  
                    foreach (Instruction instruct in thread.getInstructions())
                    {
                        if(rowIndex < thread.getInstructions().Count)
                        {
                            dgv_RAM.Rows[rowIndex].Cells[columnIndex].Value = instruct.Type.ToString();
                        } 
                        else
                        {
                            dgv_RAM.Rows[rowIndex].Cells[columnIndex].Value = "";
                        }
                        rowIndex++;
                    }
                    columnIndex++;
                }
            }
        }         

        private void updateCouleur()
        {
            int column = 0;
            foreach (Processus process in lstProcessus)
            {                
                foreach (Thread thread in process.getThreads())
                {
                    int row = 0;
                    foreach (Instruction instruction in thread.getInstructions())
                    {                        
                        if (instruction.Etat.Equals(Enums.etatInstruction.EnCours))
                        {
                            dgv_RAM.Rows[row].Cells[column].Style.BackColor = Color.Red;
                        }
                        if (instruction.Etat.Equals(Enums.etatInstruction.Termine))
                        {
                            dgv_RAM.Rows[row].Cells[column].Style.BackColor = Color.LightGray;
                        }
                        if (instruction.Etat.Equals(Enums.etatInstruction.Initialise))
                        {
                            dgv_RAM.Rows[row].Cells[column].Style.BackColor = Color.White;
                        }
                        
                        row++;
                    }
                    column++;
                }
            }           
            dgv_RAM.Refresh();
        }
        private List<Processus> OrderListProcessusPCA(List<Processus> newlistProcessus)
        {
            List<Processus> newlist = new List<Processus>();
            newlist.AddRange(newlistProcessus);

            int lenght = newlistProcessus.Count;
            int i = 0;            
            while (lenght>0)
            {
                for (i = 0; i < lenght - 1; i++)
                {
                    if (newlist[i].getEstimatedExecutionTime() > newlist[i+1].getEstimatedExecutionTime())
                    {
                        Processus processus = newlist[i];
                        newlist[i] = newlist[i+1];
                        newlist[i + 1] = processus;
                    }
                }
                lenght = lenght - 1;                
            }
            return newlist;
        }

        private List<Processus> OrderListProcessusPP(List<Processus> newlistProcessus)
        {
            List<Processus> newlist = new List<Processus>();
            newlist.AddRange(newlistProcessus);

            int lenght = newlistProcessus.Count;
            int i = 0;           
            while (lenght > 0)
            {
                for (i = 0; i < lenght - 1; i++)
                {
                    if (newlist[i].getPriorite()< newlist[i + 1].getPriorite())
                    {
                        Processus processus = newlist[i];
                        newlist[i] = newlist[i + 1];
                        newlist[i + 1] = processus;
                    }
                }
                lenght = lenght - 1;              
            }
            return newlist;
        }

        private void launchProcessus(List<Processus> orderedListPRocessus) 
        {
            foreach(Processus processus in orderedListPRocessus)
            {
                foreach(Thread thread in processus.getThreads())
                {
                    foreach(Instruction instruction in thread.getInstructions())
                    {
                        instruction.Etat = Enums.etatInstruction.EnCours;
                        updateCouleur();
                        sleep(instruction);
                        instruction.Etat = Enums.etatInstruction.Termine;
                        updateCouleur();
                    }
                }
            }
        }
        private void launchProcessusPP(List<Processus> orderedListPRocessus)
        {
            int i = 0;
            int index = 0;
            while (i < rowCountMax)
            {
                int indexThread = 0;
                foreach (Processus processus in orderedListPRocessus)
                { 
                    foreach (Thread thread in processus.getThreads())
                    {
                        int OrdreInfoThreadAffiche = 0;
                        foreach (Processus processusAffiche in lstProcessus)
                        {                            
                            foreach (Thread threadAffiche in processusAffiche.getThreads())
                            {
                                if(threadAffiche.Equals(thread))
                                {
                                    indexThread = OrdreInfoThreadAffiche;
                                }
                                OrdreInfoThreadAffiche++;
                            }
                        }                           
                        if (thread.getInstructions().Count > i)
                        {
                            thread.setEtat(Enums.etatThread.Actif);
                            dgv_RAM.Columns[indexThread].Name = thread.getInfoThread();

                            Instruction instruction = thread.getInstructions()[index];
                            instruction.Etat = Enums.etatInstruction.EnCours;
                            updateCouleur();
                            sleep(instruction);
                            instruction.Etat = Enums.etatInstruction.Termine;
                            updateCouleur();
                            
                            if(thread.getInstructions().Count-1 == i)
                            {
                                thread.setEtat(Enums.etatThread.Termine);
                            }
                            else
                            {
                                thread.setEtat(Enums.etatThread.Bloque);
                            }
                            dgv_RAM.Columns[indexThread].Name = thread.getInfoThread();                            
                        }                        
                    }                    
                }
                index++;
                i++;
            }
        }

        private void sleep(Instruction instruction)
        {
            if (instruction.Type == Enums.type.Calcul)
            {
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                System.Threading.Thread.Sleep(3000);
            }
        }
        
        private void updateSizeDgv_RAM()
        {
            dgv_RAM.Rows.Clear();
            int columnCount = 0;            
            
            foreach (Processus process in this.lstProcessus)
            {
                foreach (Thread thread in process.getThreads())
                {
                    columnCount++;
                    int rowCount = 0;
                    foreach(Instruction instruction in thread.getInstructions())
                    {
                        rowCount++;
                        if (rowCountMax < rowCount)
                        {
                            rowCountMax = rowCount;
                        }
                    }
                }
            }
            dgv_RAM.RowCount = rowCountMax;
            dgv_RAM.ColumnCount = columnCount;
        }

        private void btn_reinitialiser_Click(object sender, EventArgs e)
        {
            foreach (Processus process in this.lstProcessus)
            {
                foreach (Thread thread in process.getThreads())
                {                   
                    foreach (Instruction instruction in thread.getInstructions())
                    {
                        instruction.Etat = Enums.etatInstruction.Initialise;                       
                    }
                }
            }
            updateCouleur();
        }
    }
}
