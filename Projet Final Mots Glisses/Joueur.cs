using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_Mots_Glisses
{
    internal class Joueur
    {
        private string nom;
        private List<string> mottrouve;
        private int score;




        /// <summary>
        /// Initialiation en début de partie
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        public Joueur(string nom)
        {
            while (nom == null)
            {
                Console.WriteLine("Saisissez un nom de joueur : ");
                nom = Console.ReadLine();
            }
            this.nom = nom;
            this.mottrouve = new List<string>();
            this.score = 0;
        }



        /// <summary>
        /// Permet de garder les scores et la liste de mot trouvé au cour de la partie
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="mottrouve">Liste de mot trouvé</param>
        /// <param name="score">Score du joueur</param>
        public Joueur(string nom, List<string> mottrouve, int score)
        {
            while (nom == null)
            {
                Console.WriteLine("Saisissez un nom de joueur : ");
                nom = Console.ReadLine();
            }
            this.nom = nom;
            this.mottrouve = mottrouve;
            this.score = score;
        }



        /// <summary>
        /// Propriété de lecture et écriture : ce qui va permettre de savoir les mots déja entrer par le joueur et d'en ajouter au fur et à mesure de la partie
        /// </summary>
        public List<string> Mottrouve
        {
            get { return mottrouve; }
            set { mottrouve = value; }
        }



        /// <summary>
        /// Propriété de lecture et écriture : ce qui va permettre de savoir le score du joueur et lui ajouter des points
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }



        /// <summary>
        /// Propriété de lecture et écriture
        /// </summary>
        public string Nom
        {
            get { return nom; }
        }


        /// <summary>
        /// Permet d'ajouter un mot dans la liste de mots
        /// </summary>
        /// <param name="mot">Liste de mots entrée du joueur</param>
        public void Add_Mot(string mot)
        {
            if (mot != null)
            {
                Mottrouve.Add(mot);
            }
        }


        /// <summary>
        /// Permet d'écrire une phrase nous expliquant l'avancer du joueur, de son score et liste de mots trouvés
        /// </summary>
        /// <returns>Retourne la chaine de caractère expliquant l'avancer du joueur, de son score et liste de mots trouvés</returns>
        public string toString()
        {
            string a = "Le joueur : " + Nom + "\nAyant un score de : " + Score + "\nAyant trouvé comme mot : ";
            for (int i = 0; i < Mottrouve.Count; i++)
            {
                if (i != Mottrouve.Count - 1)
                {
                    a = a + Mottrouve[i] + " ; ";
                }
                else
                {
                    a = a + Mottrouve[i];
                }
            }
            return a;
        }



        /// <summary>
        /// Permet de changer les scores au cour de la partie
        /// </summary>
        /// <param name="val">Nombre de point à ajouter</param>
        public void Add_Score(int val)
        {
            Score = Score + val;
        }



        /// <summary>
        /// Permet de trouver si le mot a déja était trouvé auparavant par le joueur
        /// </summary>
        /// <param name="mot">mot à chercher dans la liste de mot déja entrée</param>
        /// <returns></returns>
        public bool Contient(string mot)
        {
            bool b = false;
            if (mot == null)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Mottrouve.Count; i++)
                {
                    if (mot == Mottrouve[i])
                    {
                        b = true;
                    }
                }
                return b;
            }

        }
    }
}
