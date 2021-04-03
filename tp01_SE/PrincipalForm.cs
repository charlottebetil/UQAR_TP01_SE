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
    // Formulaire principal 
    public partial class principalForm : Form
    {
        List<Processus> lstProcessus;
        List<Barriere> lstBarrieres;       
        int rowCountMax = 0;
        bool executePCA = false;       

        public principalForm()
        {
            InitializeComponent();
            this.lstProcessus = new List<Processus>();
            this.lstBarrieres = new List<Barriere>();
        }

        private void principalForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenue sur l'outil: Ordonnanceur\n" +                           
                            "Auteurs: Bétil Charlotte & Chevallier Pierre\n" +
                            "Organisation: UQAR\n");
        }

        //Lancement de PCA
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

        //Lancement de PP
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

        // Ajout de processus
        private void btnAjout_Click(object sender, EventArgs e)
        {
            Form form = new AddProcessForm(ref this.lstProcessus);
            form.ShowDialog();
            if (AddProcessForm.annuler == false)
            {
                this.displayLstThread();
            }
            AddProcessForm.annuler = false;
        }

        // Suppression de processus
        private void btnSup_Click(object sender, EventArgs e)
        {
            Form form = new SupProcessForm(ref this.lstProcessus, ref this.lstBarrieres);
            form.ShowDialog();            
            this.displayLstThread();
            afficherInfosBarrieres();
        }

        // Construction du tableau représentant la RAM
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

        // Gestion des changements de couleur
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

        // Algorithme d'ordonnancement PCA
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

        // Algorithme d'ordonnancement PP
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

        // Lancement d'un processus
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
                        processusTousRenduBarriere();
                        unSeulProcessusBarriere();
                        attenteSiBarriere(processus);
                        if (processus.getAttenteBarriere() == false)
                        {
                            if (flag)
                            {
                                break;
                            }
                            if (processus.getAttenteBarriere() == true)
                            {
                                break;
                            }
                            int i = 0;
                            // Terminer le processus si son temps d'exécution est 0
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
                                if (processus.getAttenteBarriere() == true)
                                {                                    
                                    break;
                                }
                                // Terminer le thread si son temps d'exécution est 0
                                if (thread.getEstimatedExecutionTime() == 0)
                                {
                                    thread.setEtat(Enums.etatThread.Termine);
                                }                                
                                updateInfoThread(processus);
                                foreach (Instruction instruction in thread.getInstructions())
                                {
                                    processusTousRenduBarriere();
                                    if (processus.getAttenteBarriere() == true)
                                    {
                                        thread.setEtat(Enums.etatThread.Pret);
                                        processus.setEtat(Enums.etatProcessus.Pret);
                                        updateInfoThread(processus);
                                        break;
                                    }
                                        if (instruction.Etat != Enums.etatInstruction.Termine)
                                    {
                                        pasTermine = true;                                                                                
                                        // Réordonnancement quand on atteint une E/S
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
                                            // Exécution du calcul                                            
                                            executerCalcul(instruction, thread, processus);
                                            processus.setNbInstructionsExecutees();
                                            attenteSiBarriere(processus);
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
                        else if (processusBarriereOuBloque(orderedListPRocessus) == true)
                        {                                               
                            orderedListProcessus2.Clear();
                            flag = true;
                        }
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

        // Temps d'exécution pour les calculs
        private void sleep()
        {
            System.Threading.Thread.Sleep(1000);
        }
        
        // Update la taille du tableau qui représente la RAM
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

        // Réinitialiser les processus
        private void btn_reinitialiser_Click(object sender, EventArgs e)
        {
            executePCA = false;
            int indexThread = 0;
            foreach (Processus process in this.lstProcessus)
            {
                process.reinitialiserNbInstructionsExecutees();
                process.libererDeBarriere();
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
            foreach(Barriere barriere in lstBarrieres)
            {
                barriere.reinitialiserBarrierePassee();
            }
            updateCouleur();
        } 
        
        // Obtenir la position d'un thread
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

        // Décrémenter le temps d'exécution d'une E/S
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
                                    process.setNbInstructionsExecutees();
                                    attenteSiBarriere(process);
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

        // Exécution d'une E/S
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

        // Exécution d'un calcul
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

        // Valider si tous les processus sont terminés
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

        // Décrémenter la priorité (pour le PP uniquement)
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

        // Update les informations d'un thread
        private void updateInfoThread(Processus processus)
        {
            int indexThread = 0;
            foreach(Thread thread in processus.getThreads())
            {
                indexThread = getThreadAffiche(thread);
                dgv_RAM.Columns[indexThread].Name = thread.getInfoThread(processus);
            }           
        }

        // Ajouter une barrière
        private void btn_ajouterBarriere_Click(object sender, EventArgs e)
        {
            Form form = new AddBarriereForm(ref this.lstBarrieres, ref this.lstProcessus);
            if(AddBarriereForm.deuxProcessusBarriere == true)
            {
                form.ShowDialog();
            }
            afficherInfosBarrieres();
        }

        // Supprimer une barrière
        private void btn_supprimerBarriere_Click(object sender, EventArgs e)
        {
            Form form = new SupBarriereForm(ref this.lstBarrieres);
            form.ShowDialog();
            afficherInfosBarrieres();
        }                

        // Mettre en attente un processus s'il doit attendre à la barrière
        private void attenteSiBarriere(Processus processus)
        {
            foreach (Barriere barriere in lstBarrieres)
            {
                if (barriere.getBarrierePassee() == false)
                {
                    foreach (KeyValuePair<int, int> kvp in barriere.getBarriere())
                    {
                        if(processus.getPID() == kvp.Key)
                        {
                            if (processus.getNbInstructionsExecutees() == kvp.Value)
                            {
                                processus.mettreEnAttenteBarriere();
                                processus.setEtat(Enums.etatProcessus.Pret);
                                foreach (Thread thread in processus.getThreads())
                                {
                                    thread.setEtat(Enums.etatThread.Pret);
                                    updateInfoThread(processus);
                                }
                            }
                        }
                    }                    
                }
            }
        }

        // Si tous les processus sont rendus à la barrière, les débloquer
        private void processusTousRenduBarriere()
        {            
            int nbProcessusEnAttente = 0;         
            foreach (Barriere barriere in lstBarrieres)
            {
                nbProcessusEnAttente = 0;
                if (barriere.getBarrierePassee() == false)
                {                                 
                    foreach (Processus processus in lstProcessus)
                    {
                        foreach (KeyValuePair<int, int> kvp in barriere.getBarriere())
                        {
                            if (processus.getPID() == kvp.Key)
                            {                                
                                if (processus.getAttenteBarriere() == true && processus.getNbInstructionsExecutees() == kvp.Value)
                                {
                                    nbProcessusEnAttente++;
                                }
                            }
                        }                         
                    }                  
                    if (nbProcessusEnAttente == barriere.getBarriere().Count)
                    {
                        foreach (Processus processus in lstProcessus)
                        {
                            processus.libererDeBarriere();
                            barriere.setBarrierePassee();
                        }                        
                    }
                    foreach (Processus processus in lstProcessus)
                    {
                        attenteSiBarriere(processus);
                    }                                                            
                }                   
            }            
        }

        // Gérer les cas quand il reste un seul processus à passer la barrière et que tous les autres sont terminés
        private void unSeulProcessusBarriere()
        {          
            int nbProcessusEnAttente = 0;           
            int nbProcessusTermines = 0;
            foreach (Processus processus in lstProcessus)
            {
                if (processus.getAttenteBarriere() == true || (processus.getEtat() == Enums.etatProcessus.Termine && processus.getAttenteBarriere() == false))
                {
                    nbProcessusEnAttente++;
                }
            }                          
            if (nbProcessusTermines + nbProcessusEnAttente == lstProcessus.Count)
            {
                foreach (Processus processus in lstProcessus)
                {
                    processus.libererDeBarriere();
                    foreach (Barriere barriere in lstBarrieres)
                    {
                        foreach (KeyValuePair<int, int> kvp in barriere.getBarriere())
                        {
                            if (processus.getPID() == kvp.Key)
                            {
                                if (processus.getNbInstructionsExecutees() == kvp.Value)
                                {
                                    barriere.setBarrierePassee();
                                }
                            }
                        }                       
                    }
                }
            }                     
        }

        private bool processusBarriereOuBloque(List<Processus> listeProcessus)
        {
            bool processusBarriereOuBloque = false;
            int nbProcessusBloquee = 0;
            foreach (Processus processus in listeProcessus)
            {
                if (processus.getEtat() == Enums.etatProcessus.Bloque || processus.getAttenteBarriere() == true || processus.getEtat() == Enums.etatProcessus.Termine)                        
                {
                    nbProcessusBloquee++;
                }
            }
            if (nbProcessusBloquee >= listeProcessus.Count)
            {
                processusBarriereOuBloque = true;
            }
            return processusBarriereOuBloque;
        }

        // Afficher les informations des barrières
        private void afficherInfosBarrieres()
        {
            lblInfosBarrieres.Text = "";
            lblInfosBarrieres.Height += 10;
            foreach (Barriere barriere in lstBarrieres)
            {
                lblInfosBarrieres.Text += $"Barriere {barriere.getID()} : \n";
                foreach (KeyValuePair<int, int> kvp in barriere.getBarriere())
                {
                    lblInfosBarrieres.Text += $"PID {kvp.Key} : instruction #{kvp.Value} \n";
                }
            }
        }
    }
}
