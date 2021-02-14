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
using System.Timers;

namespace tp01_SE
{
    public partial class PrincipalForm : Form
    {
        List<Processus> lstProcessus;
        int rowCountMax = 0;
        bool executePCA = false;        

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
            if (lstProcessus.Count >= 1) 
            {
                executePCA = true;
                List<Processus> orderedListProcessus3 = new List<Processus>();
                orderedListProcessus3.AddRange(OrderListProcessusPCA(lstProcessus));
                launchProcessus(orderedListProcessus3);
            }      
            else
            {
                MessageBox.Show("Il n'y a aucun processus dans la ready queue. Veuillez ajouter un processus.");
            }
        }

        private void btnLancerPP_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lancement de la simulation PP");
            dgv_RAM.ClearSelection();            
            if (lstProcessus.Count >= 1)
            {
                List<Processus> orderedListProcessus3 = new List<Processus>();
                orderedListProcessus3.AddRange(OrderListProcessusPP(lstProcessus));
                launchProcessus(orderedListProcessus3);
            }
            else
            {
                MessageBox.Show("Il n'y a aucun processus dans la ready queue. Veuillez ajouter un processus.");
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
                    dgv_RAM.Columns[columnIndex].Name = thread.getInfoThread(process);                                  
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
            List<Processus> newList = new List<Processus>();            
            foreach(Processus processus in newlistProcessus)
            {
                if (Enums.etatProcessus.Pret.Equals(processus.getEtat()))
                {
                    newList.Add(processus);
                }
            }
            int lenght = newList.Count;                    
            while (lenght > 0)
            {
                for (int i = 0; i < lenght - 1; i++)
                {
                    if (newList.Count == 1)
                    {
                        break;
                    }
                    else if (newList[i].getEstimatedExecutionTime() > newList[i + 1].getEstimatedExecutionTime())
                    {
                        Processus processus = newList[i];
                        newList[i] = newList[i + 1];
                        newList[i + 1] = processus;
                    }
                }
                lenght = lenght - 1;
            }            
            return newList;
        }

        private List<Processus> OrderListProcessusPP(List<Processus> newlistProcessus)
        {
            List<Processus> newList = new List<Processus>();
            foreach (Processus processus in newlistProcessus)
            {
                if (Enums.etatProcessus.Pret.Equals(processus.getEtat()))
                {
                    newList.Add(processus);
                }
            }
            int lenght = newList.Count;                 
            while (lenght > 0)
            {
                for (int i = 0; i < lenght - 1; i++)
                {
                    if (newList.Count == 1)
                    {
                        break;
                    }
                    else if (newList[i].getPriorite()< newList[i + 1].getPriorite())
                    {
                        Processus processus = newList[i];
                        newList[i] = newList[i + 1];
                        newList[i + 1] = processus;
                    }
                }
                lenght = lenght - 1;              
            }
            return newList;
        }       

        private void launchProcessus(List<Processus> orderedListPRocessus) 
        {           
            bool flag = false;
            bool termine = false;
            bool pasTermine = false;
            bool justeCalcul = false;
            List<Processus> orderedListProcessus2 = new List<Processus>();          
            while (termine == false)
            {                
                if(flag == true)
                {                   
                    orderedListPRocessus.Clear();
                    orderedListPRocessus.AddRange(orderedListProcessus2);                                   
                }                                
                flag = false;
                if (orderedListPRocessus.Count > 0)
                {
                    foreach (Processus processus in orderedListPRocessus)
                    {
                        if (flag)
                        {
                            break;
                        }
                        int i = 0;
                        if (processus.getEstimatedExecutionTime() == 0)
                        {
                            processus.setEtat(Enums.etatProcessus.Termine);
                        }
                        else
                        {
                            decrementerPriorite(processus);
                        }
                        foreach (Thread thread in processus.getThreads())
                        {
                            if (flag)
                            {
                                break;
                            }                        
                            if (thread.getEstimatedExecutionTime() == 0)
                            {
                                thread.setEtat(Enums.etatThread.Termine);                                                                                                                           
                            }
                            updateInfoThread(processus);
                            foreach (Instruction instruction in thread.getInstructions())
                            {                                
                                if (instruction.Etat != Enums.etatInstruction.Termine)
                                {
                                    pasTermine = true;
                                    if (instruction.Type == Enums.type.EntreeSortie)
                                    {
                                        orderedListProcessus2.Clear();
                                        orderedListProcessus2.AddRange(executerES(instruction, thread, processus));
                                        termine = validerSiTermine();
                                        flag = true;
                                        justeCalcul = false;
                                        break;
                                    }
                                    else
                                    {
                                        executerCalcul(instruction, thread, processus);
                                        justeCalcul = true;
                                    }
                                }
                                i++;
                            }
                            if (thread.getEstimatedExecutionTime() == 0 && justeCalcul == true)
                            {
                                thread.setEtat(Enums.etatThread.Termine);
                                updateInfoThread(processus);
                            }
                        }
                        if (processus.getEstimatedExecutionTime() == 0 && justeCalcul == true)
                        {
                            processus.setEtat(Enums.etatProcessus.Termine);      
                            foreach (Thread thread in processus.getThreads())
                            {
                                thread.setEtat(Enums.etatThread.Termine);
                                updateInfoThread(processus);
                            }
                        }
                        justeCalcul = false;
                        if (pasTermine == false)
                        {
                            decrementerTempsESBloque();
                            orderedListProcessus2.Clear();
                            if (executePCA == true)
                            {
                                orderedListProcessus2.AddRange(OrderListProcessusPCA(orderedListPRocessus));
                            }
                            else
                            {
                                orderedListProcessus2.AddRange(OrderListProcessusPP(orderedListPRocessus));
                            }
                            if (orderedListProcessus2.Count == 0)
                            {
                                flag = true;
                            }
                        }
                        pasTermine = false;
                    }
                    updateCouleur();
                }
                else
                {
                    if (!validerSiTermine())
                    {
                        decrementerTempsESBloque();
                        sleep();
                        orderedListPRocessus.Clear();
                        if (executePCA == true)
                        {
                            orderedListPRocessus.AddRange(OrderListProcessusPCA(lstProcessus));
                        }
                        else
                        {
                            orderedListPRocessus.AddRange(OrderListProcessusPP(lstProcessus));
                        }    
                        termine = validerSiTermine();
                    }
                    else
                    {
                        termine = true;
                    }
                }
                updateCouleur();
            }
        }       

        private void sleep()
        {
            System.Threading.Thread.Sleep(1000);
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
            executePCA = false;
            int indexThread = 0;
            foreach (Processus process in this.lstProcessus)
            {
                process.setEtat(Enums.etatProcessus.Pret);
                process.reinitialiserPriorite();
                foreach (Thread thread in process.getThreads())
                {
                    thread.setEtat(Enums.etatThread.Pret);
                    thread.reinitialiserPriorite();
                    updateInfoThread(process);
                    foreach (Instruction instruction in thread.getInstructions())
                    {
                        instruction.Etat = Enums.etatInstruction.Initialise;
                        if (instruction.Type.Equals(Enums.type.EntreeSortie))
                        {
                            instruction.NbrSecondeBloquee = 3;
                        }
                        else
                        {
                            instruction.NbrSecondeBloquee = 0;
                        }
                    }
                    indexThread++;
                }
            }
            updateCouleur();
        } 
        
        private int getThreadAffiche(Thread thread)
        {
            int positionThreadAffiche = 0;
            int OrdreInfoThreadAffiche = 0;
            foreach (Processus processusAffiche in lstProcessus)
            {
                foreach (Thread threadAffiche in processusAffiche.getThreads())
                {
                    if (threadAffiche.Equals(thread))
                    {
                        positionThreadAffiche = OrdreInfoThreadAffiche;
                    }
                    OrdreInfoThreadAffiche++;
                }
            }
            return positionThreadAffiche;
        }

        private void decrementerTempsESBloque()
        {
            foreach (Processus process in this.lstProcessus)
            {
                if (!process.getEtat().Equals(Enums.etatProcessus.Termine))
                {
                    foreach (Thread thread in process.getThreads())
                    {
                        foreach (Instruction instruction in thread.getInstructions())
                        {
                            if (instruction.NbrSecondeBloquee != 0 && Enums.etatInstruction.EnCours.Equals(instruction.Etat))
                            {
                                instruction.NbrSecondeBloquee--;
                                if (instruction.NbrSecondeBloquee == 0)
                                {
                                    instruction.Etat = Enums.etatInstruction.Termine;
                                    process.setEtat(Enums.etatProcessus.Pret);
                                    thread.setEtat(Enums.etatThread.Pret);
                                    updateInfoThread(process);
                                }                                
                            }                            
                        }
                    }
                }
            }
        }    

        private List<Processus> executerES(Instruction instruction, Thread thread, Processus processus)
        {
            instruction.Etat = Enums.etatInstruction.EnCours;
            processus.setEtat(Enums.etatProcessus.Bloque);                        
            thread.setEtat(Enums.etatThread.Bloque);
            updateInfoThread(processus);
            updateCouleur();
            decrementerTempsESBloque();
            sleep();
            if (executePCA == true)
            {
                return OrderListProcessusPCA(lstProcessus);
            }
            else
            {
                return OrderListProcessusPP(lstProcessus);
            }
        }

        private void executerCalcul(Instruction instruction, Thread thread, Processus processus)
        {
            processus.setEtat(Enums.etatProcessus.Actif);
            thread.setEtat(Enums.etatThread.Actif);
            instruction.Etat = Enums.etatInstruction.EnCours;
            decrementerTempsESBloque();
            updateInfoThread(processus);
            updateCouleur();
            sleep();
            instruction.Etat = Enums.etatInstruction.Termine;
            updateCouleur();            
        }

        private bool validerSiTermine()
        {
            foreach (Processus process in this.lstProcessus)
            {
               if(process.getExecutionTime()> 0 || process.getEtat() != Enums.etatProcessus.Termine)
                {
                    return false;
                }
            }
            return true;
        }

        private void decrementerPriorite(Processus processus)
        {           
            if(executePCA == false)
            {
                processus.setPriorite();
                foreach (Thread thread in processus.getThreads())
                {
                    thread.setPriorite();
                    updateInfoThread(processus);
                }
            }
        }

        private void updateInfoThread(Processus processus)
        {
            int indexThread = 0;
            foreach(Thread thread in processus.getThreads())
            {
                indexThread = getThreadAffiche(thread);
                dgv_RAM.Columns[indexThread].Name = thread.getInfoThread(processus);
            }           
        }
    }
}
