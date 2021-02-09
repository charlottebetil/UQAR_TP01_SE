using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01_SE
{
    public class Enums
    {
        public enum type
        {
            EntreeSortie,
            Calcul
        }
        public enum etatInstruction
        {
            Initialise,
            EnCours,
            Termine
        }

        public enum etatThread
        {
            Initialise,
            Actif,
            Bloque,
            Termine
        }
    }
}
