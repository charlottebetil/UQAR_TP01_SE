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
        private decimal nbInstructCalc;
        private decimal nbInstructES;
        private decimal nbCycle;
        private int estimatedExecutionTime;
        public int nbThread;
        private List<Thread> lstThread = new List<Thread>();
        public Processus(int PID, string nom, int priorite, decimal nbInstructCalc, decimal nbInstructES, decimal nbCycle, int nbThread)
        {
            this.PID = PID;
            this.nom = nom;
            this.priorite = priorite;
            this.nbInstructCalc = nbInstructCalc;
            this.nbInstructES = nbInstructES;
            this.nbCycle = nbCycle;
            this.nbThread = nbThread;
            this.initLstThread();
            this.calculateEstimatedExecutionTime();
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
            return lstInstructions;
        }

        public int getEstimatedExecutionTime()
        {
            return (this.estimatedExecutionTime);
        }

        public int getPriorite()
        {
            return (this.priorite);
        }

        private void calculateEstimatedExecutionTime()
        {            
            foreach(Thread thread in this.lstThread)
            {
                foreach(Instruction instruction in thread.getInstructions())
                {
                    if(instruction.Type == Enums.type.Calcul)
                    {
                        this.estimatedExecutionTime +=1;
                    }
                    else
                    {
                        this.estimatedExecutionTime +=3;
                    }
                }
            }            
        }
    }
}