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
        private decimal priorite;
        private int TID;
        private Enums.etatThread etat;        
        private List<Instruction> lstInstructions = new List<Instruction>();
        public Thread(string processNom, int PID, decimal priorite, int TID, List<Instruction>  lstInstructions)
        {
            this.processNom = processNom;
            this.PID = PID;
            this.priorite = priorite;
            this.TID = TID;
            this.lstInstructions = lstInstructions;
            this.etat = Enums.etatThread.Initialise;
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
    }
}
