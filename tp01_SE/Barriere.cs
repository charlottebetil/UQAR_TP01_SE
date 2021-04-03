using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01_SE
{
    public class Barriere
    {
        private int id;      
        private bool barrierePassee;
        private Dictionary<int, int> barriere = new Dictionary<int, int>();
        private List<Processus> lstProcessus;
        private List<Barriere> lstBarrieres;

        public Barriere(System.Windows.Forms.CheckedListBox.CheckedItemCollection selectedItems, ref List<Processus> lstProcessus, int id, ref List<Barriere> lstBarrieres)
        {            
            barrierePassee = false;
            this.lstProcessus = lstProcessus;
            this.lstBarrieres = lstBarrieres;
            construireDictionnaire(selectedItems);
            this.id = id;
        }

        // Construire le dictionnaire
        private void construireDictionnaire(System.Windows.Forms.CheckedListBox.CheckedItemCollection selectedItems)
        {            
            foreach (object selectedItem in selectedItems)
            {
                foreach (Processus processus in lstProcessus)
                {
                    if (processus.getPID() == Convert.ToInt32(selectedItem))
                    {                        
                        barriere.Add(Convert.ToInt32(selectedItem), genererNbAleatoire(processus));
                    }
                }
            }                       
        }
        
        // Générer un nombre aléatoire entre 1 et le nombre d'instructions du processus
        private int genererNbAleatoire(Processus processus)
        {                                  
            int niemeInstruction = 0;
            if(lstBarrieres.Count == 0)
            {             
                niemeInstruction = RandomNumber(1, trouverNbInstructionsProcessus(processus) + 1);
            }
            else
            {               
                niemeInstruction = RandomNumber(trouverInstructionPrecedante(processus), trouverNbInstructionsProcessus(processus) + 1);
            }   
                
            return niemeInstruction;
        }

        //Function to get a random number 
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }


        // Trouver le nombre d'instructions que possède un processus
        private int trouverNbInstructionsProcessus(Processus processus)
        {
            int nbInstructions = 0;
            foreach (Thread thread in processus.getThreads())
            {
                nbInstructions += thread.getInstructions().Count;
            }
            return nbInstructions;
        }

        // Trouver l'instruction du processus de la barrière précédante (pour éviter les interblocages)
        private int trouverInstructionPrecedante(Processus processus)
        {
            int instructionPrec = 1;
            
            foreach (KeyValuePair< int, int> kvp in lstBarrieres[lstBarrieres.Count-1].barriere)
            {
                if(kvp.Key == processus.getPID())
                {
                    instructionPrec = kvp.Value;
                }
            }
            return instructionPrec;
        }


        // Obtenir l'ID d'une barrière
        public int getID()
        {
            return (this.id);
        }

        // Obtenir le nombre d'instructions pour la barriere
        public Dictionary<int, int> getBarriere()
        {
            return (this.barriere);
        }

        // Voir si tous les processus ont atteint la barrière
        public bool getBarrierePassee()
        {
            return (this.barrierePassee);
        }

        // Mettre la variable à true quand tous les processus ont atteint la barrière
        public void setBarrierePassee()
        {
            this.barrierePassee = true;
        }

        // Réinitialiser la valeur à false
        public void reinitialiserBarrierePassee()
        {
            this.barrierePassee = false;
        }        
    }
}
