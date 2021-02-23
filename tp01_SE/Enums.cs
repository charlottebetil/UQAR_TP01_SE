﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01_SE
{
    // Classe d'énumération des états
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
            Pret,
            Actif,
            Bloque,
            Termine
        }

        public enum etatProcessus
        {
            Pret,
            Actif,
            Bloque,
            Termine
        }
    }
}
