using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01_SE
{
    public class Processus
    {
        private int PID;
        private string nom;
        private decimal priorite;
        private decimal nbInstructCalc;
        private decimal nbInstructES;
        private decimal nbCycle;
        private int nbThread;
        private List<Thread> lstThread = new List<Thread>();
        public Processus(int PID, string nom, decimal priorite, decimal nbInstructCalc, decimal nbInstructES, decimal nbCycle, int nbThread)
        {
            this.PID = PID;
            this.nom = nom;
            this.priorite = priorite;
            this.nbInstructCalc = nbInstructCalc;
            this.nbInstructES = nbInstructES;
            this.nbCycle = nbCycle;
            this.nbThread = nbThread;
            this.initLstThread();
        }

        public string getName() 
        {
            return (this.nom);
        }

        public List<Thread> getThreads()
        {
            return (this.lstThread);
        }


        public void initLstThread()
        {
            if (this.nbThread == 1)
            {
                Thread newThread = new Thread(this.nom, this.PID, this.priorite, this.PID * 10, this.initInstruction());
                this.lstThread.Add(newThread);
            }

        }

        public List<string> initInstruction() {
            List<string> instruct = new List<string>();
            for (int i = 0; i < nbInstructCalc; i++)
            {
                instruct.Add("Calcul");
            }
            for (int i = 0; i < nbInstructES; i++)
            {
                instruct.Add("Entree Sortie");
            }
            return (instruct);
        }


    }
}
