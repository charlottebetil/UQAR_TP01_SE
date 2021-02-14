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
        private int PID;
        private string nom;
        private int priorite;
        private int prioriteInitiale;
        private decimal nbInstructCalc;
        private decimal nbInstructES;
        private int estimatedExecutionTime;
        public int nbThread;
        private Enums.etatProcessus etat;
        private List<Thread> lstThread = new List<Thread>();
        public Processus(int PID, string nom, int priorite, decimal nbInstructCalc, decimal nbInstructES, int nbThread)
        {
            this.PID = PID;
            this.nom = nom;
            this.priorite = priorite;
            this.nbInstructCalc = nbInstructCalc;
            this.nbInstructES = nbInstructES;
            this.nbThread = nbThread;
            this.initLstThread();
            this.calculateEstimatedExecutionTime();
            this.etat = Enums.etatProcessus.Pret;
            this.prioriteInitiale = priorite;
        }

        public string getName()
        {
            return (this.nom);
        }

        public List<Thread> getThreads()
        {
            return (this.lstThread);
        }

        public Enums.etatProcessus getEtat()
        {
            return (this.etat);
        }

        public void setEtat(Enums.etatProcessus etat)
        {
            this.etat = etat;
        }

        public void initLstThread()
        {
            for (int i = 0; i < this.nbThread; i++)
            {
                List<Instruction> emptyLstInstructions = new List<Instruction>();
                Thread thread = new Thread(this.nom, this.PID, this.priorite, i, emptyLstInstructions);
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

        public int getExecutionTime()
        {
            return (this.estimatedExecutionTime);
        }

        public int getEstimatedExecutionTime()
        {
            this.calculateEstimatedExecutionTime();
            return (this.estimatedExecutionTime);
        }

        public int getPriorite()
        {
            return (this.priorite);
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
            foreach (Thread thread in this.lstThread)
            {
                estimatedExecutionTime += thread.getEstimatedExecutionTime();
            }
        }        
    }

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