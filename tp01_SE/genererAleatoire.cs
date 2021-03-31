using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01_SE
{
    class GenererAleatoire
    {
        private Random aleatoire { get; set; }
        private int debut;
        private int fin;
        public GenererAleatoire(int debut, int fin)
        {
            this.debut = debut;
            this.fin = fin;
            this.aleatoire = new Random();
        }
        public int randomNumber()
        {
            return this.aleatoire.Next(debut, fin);
        }
    }
}
