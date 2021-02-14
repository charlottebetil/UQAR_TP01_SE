using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01_SE
{
    public class Instruction
    {
        private Enums.etatInstruction etat;
        private Enums.type type;
        private int nbrSecondeBloquee;

        public Instruction(Enums.type type)
        {
            this.etat = Enums.etatInstruction.Initialise;
            this.type = type;
            
            if (type.Equals(Enums.type.EntreeSortie))
            {
                this.nbrSecondeBloquee = 3;
            }
            else
            {
                this.nbrSecondeBloquee = 0;
            }                        
        }
        public Enums.etatInstruction Etat
        {
            get { return etat; }
            set { this.etat = value; }
        }
        public Enums.type Type
        {
            get { return type; }
            set { this.type = value; }
        }

        public int NbrSecondeBloquee
        {
            get { return nbrSecondeBloquee; }
            set { this.nbrSecondeBloquee = value; }
        }

    }
}
