using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01_SE
{
    public enum Thread: ushort
    { 
        mono = 1,
        couple = 2,
        triple = 3,
        random = 1|2|3
    }
    public class Processus
    {
        private int id;
        private string nom;
        private decimal priorite;
        private decimal nbInstructCalc;
        private decimal nbInstructES;
        private decimal nbCycle;
        private Thread nbThread;
        public Processus(int id, string nom, decimal priorite, decimal nbInstructCalc, decimal nbInstructES, decimal nbCycle, Thread nbThread)
        {
            this.id = id;
            this.nom = nom;
            this.priorite = priorite;
            this.nbInstructCalc = nbInstructCalc;
            this.nbInstructES = nbInstructES;
            this.nbCycle = nbCycle;
            this.nbThread = nbThread;
        }

        public string getName() 
        {
            return (this.nom);
        }
    }
}
