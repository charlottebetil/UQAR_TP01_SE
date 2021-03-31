using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01_SE
{
    public class Processus
    {
        private int indiceTID;
        private int PID;
        private string nom;
        private int priorite;
        private int prioriteInitiale;
        private decimal nbInstructCalc;
        private decimal nbInstructES;
        private int estimatedExecutionTime;
        public int nbThread;
        private int nbInstructionsExecutees;
        private int taille;
        private bool attenteBarriere;
        private Enums.etatProcessus etat;
        private List<Thread> lstThread = new List<Thread>();

        public Processus(int PID, string nom, int priorite, decimal nbInstructCalc, decimal nbInstructES, int nbThread, int indiceTID)
        {
            this.PID = PID;
            this.nom = nom;
            this.priorite = priorite;
            this.nbInstructCalc = nbInstructCalc;
            this.nbInstructES = nbInstructES;
            this.nbThread = nbThread;
            this.indiceTID = indiceTID;
            this.initLstThread();
            this.calculateEstimatedExecutionTime();
            this.calculerTaille();
            this.etat = Enums.etatProcessus.Pret;
            this.prioriteInitiale = priorite;
            this.nbInstructionsExecutees = 0;
            this.attenteBarriere = false;
        }

        // Obtenir le nom d'un processus
        public string getName()
        {
            return (this.nom);
        }

        // Obtenir le PID d'un processus
        public int getPID()
        {
            return (this.PID);
        }

        // Obtenir tous les threads d'un processus
        public List<Thread> getThreads()
        {
            return (this.lstThread);
        }

        // Obtenir l'état d'un processus
        public Enums.etatProcessus getEtat()
        {
            return (this.etat);
        }

        // Changer l'état d'un processus
        public void setEtat(Enums.etatProcessus etat)
        {
            this.etat = etat;
        }

        // Ajouter les threads d'un processus et y ajouter les instructions
        public void initLstThread()
        {            
            for (int i = 0; i < this.nbThread; i++)
            {
                this.indiceTID++;
                List<Instruction> emptyLstInstructions = new List<Instruction>();
                Thread thread = new Thread(this.nom, this.PID, this.priorite, this.indiceTID, emptyLstInstructions);
                lstThread.Add(thread);
            }
            List<Instruction> lstInstructions = new List<Instruction>();
            lstInstructions = createLstInstructions();
            int y = 0;
            foreach (Instruction instruction in lstInstructions)
            {
                this.lstThread[y].setInstructions(instruction);
                y++;
                if (y >= this.nbThread)
                {
                    y = 0;
                }
            }
        }

        // Créer la liste d'instructions
        public List<Instruction> createLstInstructions()
        {
            List<Instruction> lstInstructions = new List<Instruction>();
            int nbrInstruction = Convert.ToInt32(this.nbInstructCalc + this.nbInstructES);
            for (int i = 0; i < this.nbInstructCalc; i++)
            {
                Instruction instruction = new Instruction(Enums.type.Calcul);
                lstInstructions.Add(instruction);
            }
            for (int i = 0; i < this.nbInstructES; i++)
            {
                Instruction instruction = new Instruction(Enums.type.EntreeSortie);
                lstInstructions.Add(instruction);
            }
            lstInstructions.Shuffle();
            return lstInstructions;
        }

        // Obtenir le temps d'exécution d'un processus sans recalcul
        public int getExecutionTime()
        {
            return (this.estimatedExecutionTime);
        }

        // Obtenir le temps d'exécution d'un processus en le recalculant
        public int getEstimatedExecutionTime()
        {
            this.calculateEstimatedExecutionTime();
            return (this.estimatedExecutionTime);
        }

        // Obtenir la priorité d'un processus
        public int getPriorite()
        {
            return (this.priorite);
        }

        // Définir la priorité d'un processus
        public void setPriorite()
        {
            this.priorite--;
        }

        // Réinitialiser la priorité d'un processus
        public void reinitialiserPriorite()
        {
            this.priorite = this.prioriteInitiale;
        }

        // Calculer le temps d'exécution d'un processus
        private void calculateEstimatedExecutionTime()
        {
            this.estimatedExecutionTime = 0;
            foreach (Thread thread in this.lstThread)
            {
                estimatedExecutionTime += thread.getEstimatedExecutionTime();
            }
        }

        // Obtenir la taille qu'occupe le processus dans la RAM
        public int getTaille()
        {
            this.calculerTaille();
            return (this.taille);
        }

        // Calculer la taille qu'occupe le processus dans la RAM
        private void calculerTaille()
        {
            this.taille = 0;
            foreach (Thread thread in this.lstThread)
            {
                foreach (Instruction instruction in thread.getInstructions())
                {
                    taille += 1;
                }
            }
        }

        // Obtenir le nombre d'instructions exécutées du processus
        public int getNbInstructionsExecutees()
        {
            return (this.nbInstructionsExecutees);
        }

        // Définir le nombre d'instructions exécutées du processus
        public void setNbInstructionsExecutees()
        {
            this.nbInstructionsExecutees++;
        }

        // Réinitialiser le nombre d'instructions exécutées du processus
        public void reinitialiserNbInstructionsExecutees()
        {
            this.nbInstructionsExecutees = 0;
        }

        // Mettre un processus en attente de la barrière
        public void mettreEnAttenteBarriere()
        {
            this.attenteBarriere = true;
        }

        // Arrêter d'attendre à la barrière
        public void libererDeBarriere()
        {
            this.attenteBarriere = false;
        }

        // Savoir si un processus attend après une barrière
        public bool getAttenteBarriere()
        {
            return (this.attenteBarriere);
        }
    }

    // Mélanger les instructions
    public static class ShuffleInstructions        
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}