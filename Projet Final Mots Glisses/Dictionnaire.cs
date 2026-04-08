using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_Mots_Glisses
{
    internal class Dictionnaire
    {
        private string[] motsfrancais;

        /// <summary>
        /// //Propriété de lecture et d'écriture
        /// </summary>
        public string[] Motsfrancais
        {
            get { return motsfrancais; }
            set { motsfrancais = value; }
        }



        /// <summary>
        /// Transforme le fichier MotFrancais en tableau de chaine de caractère ayant tout les mots de ce fichier
        /// </summary>
        public Dictionnaire()
        {
            string s = "";
            using (StreamReader sr = new StreamReader("MotsFrancais.txt"))
            {
                string ligne = "";
                while ((ligne = sr.ReadLine()) != null)
                {
                    s = s + " " + ligne;
                }
            }
            string[] mots = s.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);//enleve tout séparateur par défaut: espace(sous chaine vide)  et supprime ensuite les sous chaines vides
            this.motsfrancais = mots;
        }



        /// <summary>
        /// Retourne une chaîne de caractères qui décrit le dictionnaire à savoir le nombre de mots par lettre et la langue
        /// </summary>
        /// <returns>Retourne une chaîne de caractères qui décrit le dictionnaire à savoir le nombre de mots par lettre et la langue</returns>
        public override string ToString()
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int e = 0;
            int f = 0;
            int g = 0;
            int h = 0;
            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;
            int m = 0;
            int n = 0;
            int o = 0;
            int p = 0;
            int q = 0;
            int r = 0;
            int s = 0;
            int t = 0;
            int u = 0;
            int v = 0;
            int w = 0;
            int x = 0;
            int y = 0;
            int z = 0;
            for (int az = 0; az < motsfrancais.Length; az++)
            {
                switch (motsfrancais[az][0])
                {
                    case 'A':
                        a++;
                        break;
                    case 'B':
                        b++;
                        break;
                    case 'C':
                        c++;
                        break;
                    case 'D':
                        d++;
                        break;
                    case 'E':
                        e++;
                        break;
                    case 'F':
                        f++;
                        break;
                    case 'G':
                        g++;
                        break;
                    case 'H':
                        h++;
                        break;
                    case 'I':
                        i++;
                        break;
                    case 'J':
                        j++;
                        break;
                    case 'K':
                        k++;
                        break;
                    case 'L':
                        l++;
                        break;
                    case 'M':
                        m++;
                        break;
                    case 'N':
                        n++;
                        break;
                    case 'O':
                        o++;
                        break;
                    case 'P':
                        p++;
                        break;
                    case 'Q':
                        q++;
                        break;
                    case 'R':
                        r++;
                        break;
                    case 'S':
                        s++;
                        break;
                    case 'T':
                        t++;
                        break;
                    case 'U':
                        u++;
                        break;
                    case 'V':
                        v++;
                        break;
                    case 'W':
                        w++;
                        break;
                    case 'X':
                        x++;
                        break;
                    case 'Y':
                        y++;
                        break;
                    case 'Z':
                        z++;
                        break;
                    default:
                        break;
                }

            }
            string save = "La langue est le français et il y a :\n" + "A = " + a + " mots\n" + "B = " + b + " mots\n" + "C = " + c + " mots\n" + "D = " + d + " mots\n" + "E = " + e + " mots\n" + "F = " + f + " mots\n" + "G = " + g + " mots\n" + "H = " + h + " mots\n" + "I = " + i + " mots\n" + "J = " + j + " mots\n" + "K = " + k + " mots\n" + "L = " + l + " mots\n" + "M = " + m + " mots\n" + "N = " + n + " mots\n" + "O = " + o + " mots\n" + "P = " + p + " mots\n" + "Q = " + q + " mots\n" + "R = " + r + " mots\n" + "S = " + s + " mots\n" + "T = " + t + " mots\n" + "U = " + u + " mots\n" + "V = " + v + " mots\n" + "W = " + w + " mot\n" + "X = " + x + " mots\n" + "Y = " + y + " mots\n" + "Z = " + z + " mots";
            return save;
        }




        /// <summary>
        /// Méthode static qui permet de trier le Dictionnaire par la logique du tri rapide
        /// </summary>
        /// <param name="tab">Le tab est un string[] où chaque string est égal à un mot du dictionnaire</param>
        /// <returns>Cela retourne donc le tableau trier par ordre alphabétique</returns>
        public static string[] Tri_Rapide(string[] tab)
        {
            if (tab == null || tab.Length <= 1)
            {
                return tab;
            }
            else
            {
                string pivot;
                int comptpetit = 0;
                int comptgrand = 0;
                pivot = tab[tab.Length / 2];
                for (int i = 0; i < tab.Length; i++)
                {
                    int compare = tab[i].CompareTo(pivot);
                    if (compare < 0)
                    {
                        comptpetit++;
                    }
                    else if (compare > 0)
                    {
                        comptgrand++;
                    }
                }
                string[] petit = new string[comptpetit];
                string[] grand = new string[comptgrand + 1];
                comptpetit = 0;
                comptgrand = 1;
                grand[0] = pivot;
                for (int i = 0; i < tab.Length; i++)
                {
                    int compare = tab[i].CompareTo(pivot);
                    if (compare == 0)
                    {

                    }
                    if (compare < 0)
                    {
                        petit[comptpetit] = tab[i];
                        comptpetit++;
                    }
                    else if (compare > 0)
                    {
                        grand[comptgrand] = tab[i];
                        comptgrand++;
                    }
                }
                petit = Tri_Rapide(petit);
                grand = Tri_Rapide(grand);
                for (int i = 0; i < petit.Length; i++)
                {
                    tab[i] = petit[i];
                }
                for (int i = 0; i < grand.Length; i++)
                {
                    tab[petit.Length + i] = grand[i];
                }
                return tab;
            }
        }





        /// <summary>
        /// Méthode static qui permet de faire une recherche dichotomique en récursif
        /// </summary>
        /// <param name="t">Le tableau (Dictionnaire) où l'on cherche le mot</param>
        /// <param name="rech">Le string a rechercher dans le dictionnaire</param>
        /// <param name="debut">Permet de découper le tableau initial en une partie de tableau où le début correspond au début du nouveau sous-tableau</param>
        /// <param name="fin">Permet de découper le tableau initial en une partie de tableau où le fin correspond à la fin du nouveau sous-tableau</param>
        /// <returns></returns>
        public static bool RechDichoRecursif(string[] t, string rech, int debut = 0, int fin = -1)//
        {

            if (t == null || t.Length == 0 || rech == null)
            {
                return false;
            }
            rech = rech.ToUpper();
            if (fin == -1)
            {
                fin = t.Length - 1;
            }
            for (int i = 1; i < t.Length; i++)
            {
                if (t[i].CompareTo(t[i - 1]) < 0)
                {
                    Console.WriteLine("Le Dictionnaire n'est pas trier !!! ");
                    return false;
                }
            }
            if (debut > fin)
            {
                return false;
            }
            int milieu = (debut + fin) / 2;

            if (rech == t[milieu])
            {
                return true;
            }
            else if (rech.CompareTo(t[milieu]) < 0)
            {
                return RechDichoRecursif(t, rech, debut, milieu - 1);
            }
            else if (rech.CompareTo(t[milieu]) > 0)
            {
                return RechDichoRecursif(t, rech, milieu + 1, fin);
            }
            else
            {
                return false;
            }


        }
    }
}
