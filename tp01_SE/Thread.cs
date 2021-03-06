﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tp01_SE
{
    public class Thread
    {
        private string processNom;
        private int PID;
        private int priorite;
        private int TID;
        private Enums.etatThread etat; 
        private int estimatedExecutionTime;
        private List<Instruction> lstInstructions = new List<Instruction>();
        private int prioriteInitiale;
        public Thread(string processNom, int PID, int priorite, int TID, List<Instruction>  lstInstructions)
        {
            this.processNom = processNom;
            this.PID = PID;
            this.priorite = priorite;
            this.TID = TID;
            this.lstInstructions = lstInstructions;
            this.etat = Enums.etatThread.Pret;
            this.prioriteInitiale = priorite;
        }

        // Obtenir les infos d'un thread
        public string getInfoThread(Processus processus)
        {
            string infos = "NomProcessus: " + this.processNom + "\n\t";
            infos += "PID: " + this.PID + "\n\t";
            infos += "TID: " + this.TID + "\n\t";
            infos += "PrioriteProcessus: " + this.priorite + "\n\t";
            infos += "EtatProcessus: " + processus.getEtat() + "\n\t";
            infos += "EtatThread: "+ this.etat;
            return (infos);
        }

        // Obtenir les instructions d'un thread
        public List<Instruction> getInstructions()
        {
            return (this.lstInstructions);
        }

        // Ajouter une instruction au thread
        public void setInstructions(Instruction instruction)
        {
            this.lstInstructions.Add(instruction);
        }

        // Changer l'état d'un thread
        public void setEtat(Enums.etatThread etat)
        {
            this.etat = etat;
        }

        // Obtenir l'état d'un thread
        public Enums.etatThread getEtat()
        {
            return (this.etat);
        }

        // Obtenir le temps d'exécution d'un thread
        public int getEstimatedExecutionTime()
        {
            this.calculateEstimatedExecutionTime();
            return (this.estimatedExecutionTime);
        }

        // Décrémenter la priorité d'un thread
        public void setPriorite()
        {
            this.priorite--;
        }

        // Réinitialiser la priorité d'un thread
        public void reinitialiserPriorite()
        {
            this.priorite = this.prioriteInitiale;
        }

        // Calculer le temps d'exécution d'un thread
        private void calculateEstimatedExecutionTime()
        {
            this.estimatedExecutionTime = 0;            
            foreach (Instruction instruction in this.getInstructions())
            {
                if (Enums.etatInstruction.Initialise.Equals(instruction.Etat))
                {
                    if (instruction.Type == Enums.type.Calcul)
                    {
                        this.estimatedExecutionTime += 1;
                    }
                    else
                    {
                        this.estimatedExecutionTime += 3;
                    }
                }
            }
        }
    }
}
