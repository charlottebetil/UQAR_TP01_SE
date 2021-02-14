using System;
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

        public string getInfoThread()
        {
            string infos = "Processus: " + this.processNom + "\n\t";
            infos += "PID: " + this.PID + "\n\t";
            infos += "TID: " + this.TID + "\n\t";
            infos += "Priorité: " + this.priorite + "\n\t";
            infos += "Etat: "+ this.etat;
            return (infos);
        }
        public List<Instruction> getInstructions()
        {
            return (this.lstInstructions);
        }
        public void setInstructions(Instruction instruction)
        {
            this.lstInstructions.Add(instruction);
        }
        public void setEtat(Enums.etatThread etat)
        {
            this.etat = etat;
        }
        public Enums.etatThread getEtat()
        {
            return (this.etat);
        }

        public int getEstimatedExecutionTime()
        {
            this.calculateEstimatedExecutionTime();
            return (this.estimatedExecutionTime);
        }
        public void setPriorite()
        {
            this.priorite--;
        }
        public void reinitialiserPriorite()
        {
            this.priorite = this.prioriteInitiale;
        }
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
