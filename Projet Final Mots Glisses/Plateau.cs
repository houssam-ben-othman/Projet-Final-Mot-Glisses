using System;
using System.Collections.Generic;
using System.IO;

namespace Projet_Final_Mots_Glisses
{

    internal class Plateau
    {
        private char[,] plateau;

        public char[,] Plateaux
        {
            get { return plateau; }
            set { plateau = value; }
        }

        /// <summary>
        /// Constructeur aléatoire
        /// </summary>
        public Plateau() //Constructeur Aléatoire
        {
            //bloc pour gérer les contraintes en nombre de lettres par plateau
            string[] lignes = File.ReadAllLines("Lettres.txt");
            string[] parties;
            int[] maxLettre = new int[lignes.Length];
            for (int i = 0; i < lignes.Length; i++)
            {
                parties = lignes[i].Split(',');
                maxLettre[i] = int.Parse(parties[1]);
            }
            int[] freq = new int[lignes.Length];
            int index;
            //bloc pour création du plateau
            Random random = new Random();
            int n;
            char lettre;
            this.plateau = new char[8, 8];
            for (int i = 0; i < this.plateau.GetLength(0); i++)
            {
                for (int j = 0; j < this.plateau.GetLength(1); j++)
                {
                    while (true)
                    {
                        n = random.Next(1, lignes.Length + 1);
                        lettre = (char)('A' + n - 1);// en gros les char sont en réalité des nombres en ASCII et se suivent par exemple 'A' = 65, 'B' = 66 ... 'Z' = 90 le fait de mettre (char) devant permet de transformer le nombre obtenu en char
                        index = lettre - 'A';
                        if (freq[index] < maxLettre[index])
                        {
                            freq[index]++;
                            break;
                        }
                    }
                    plateau[i, j] = lettre;
                }
            }
        }



        /// <summary>
        /// Constructeur à partir d'un fichier
        /// </summary>
        /// <param name="nomFichier">Nom du fichier ou se trouve le plateau</param>
        public Plateau(string nomFichier) //Constructeur a partir d'un fichier
        {
            string[] a = File.ReadAllLines(nomFichier);
            this.plateau = new char[8, 8];
            for (int i = 0; i < this.plateau.GetLength(0); i++)
            {
                string[] valeurs = a[i].Split(';');
                for (int j = 0; j < this.plateau.GetLength(1); j++)
                {
                    this.plateau[i, j] = char.Parse(valeurs[j]);
                }
            }
        }




        /// <summary>
        /// Méthode ToString avec un override pour pouvoir directement écrire Console.WriteLine(plateau)
        /// </summary>
        /// <returns> Sors un string à afficher </returns>
        public override string ToString()
        {
            string r = "";
            for (int i = 0; i < this.plateau.GetLength(0); i++)
            {
                for (int j = 0; j < this.plateau.GetLength(1); j++)
                {
                    r += " " + this.plateau[i, j] + " ";
                }
                r += "\n";
            }
            return r;
        }




        /// <summary>
        /// Permet d'enregistrer le plateau dans un fichier
        /// </summary>
        /// <param name="nomFile">Nom du fichier qui sera crée</param>
        public void ToFile(string nomFile)
        {
            int k = 0;
            string[] a = new string[8];
            for (int i = 0; i < this.plateau.GetLength(0); i++)
            {
                for (int j = 0; j < this.plateau.GetLength(1); j++)
                {
                    if (j != this.plateau.GetLength(1) - 1)
                    {
                        a[k] += this.plateau[i, j] + ";";
                    }
                    else
                    {
                        a[k] += this.plateau[i, j];
                    }
                }
                k++;
            }
            File.WriteAllLines(nomFile, a);
        }




        /// <summary>
        /// Programme permettant la recherche d'un mot entré par l'utilisateur
        /// </summary>
        /// <param name="Mot">mot entré par l'utilisateur</param>
        /// <returns>Return une liste contenant les coordonées de chaque caractère du mot si il est trouvés </returns>
        public List<int> Recherche_Mot(string Mot)
        {
            if (Mot == null)
            {
                return null;
            }
            string mot = Mot.ToUpper();
            int c = 0;
            List<int> a = new List<int>(mot.Length * 2);
            for (int i = 0; i < this.plateau.GetLength(0); i++)
            {
                if (mot[0] == this.plateau[7, i])
                {
                    c++;
                }
            }
            if (c == 0)
            {
                Console.WriteLine("Le mot ne commence pas en bas du tableau");
                return null;
            }
            for (int j = 0; j < this.plateau.GetLength(1); j++)
            {
                if (this.plateau[7, j] == mot[0])
                {
                    List<int> CoordMot = ChercheAutour(7, j, mot, 0, a);
                    if (CoordMot != null)
                    {
                        return CoordMot;
                    }
                }
            }
            Console.WriteLine("Le mot n'est pas dans le plateau");
            return null;
        }





        /// <summary>
        /// Sous programme récursif de Recherche_Mot permettant de regarder si au moins un caractère adjacent au mot correspond a la suite du mot
        /// </summary>
        /// <param name="i">indice permettant de regarder la ligne au dessus ou en dessous du caractère du plateau</param>
        /// <param name="j">indice permettant de regarder la colonne à gauche ou à droite du caractère du plateau</param>
        /// <param name="mot">le mot entré par le joueur</param>
        /// <param name="k">Compteur permettant de mettre fin a la récursivité une fois que tous les caractères ont été parcourut</param>
        /// <param name="a">Liste contenant les coordonées du mot</param>
        /// <returns>
        /// return <param name = "a"> permet d'obtenir la liste de coordonées
        /// return res permet d'obtenir le bon chemin
        /// </returns>
        public List<int> ChercheAutour(int i, int j, string mot, int k, List<int> a)
        {
            if (k == mot.Length)
            {
                return a;
            }
            if (i < 0 || j < 0 || i >= plateau.GetLength(0) || j >= plateau.GetLength(1))
            {
                return null;
            }
            if (plateau[i, j] != mot[k])
            {
                return null;
            }
            for (int x = 0; x < a.Count; x += 2)
            {
                if (a[x] == i && a[x + 1] == j)
                {
                    Console.WriteLine("Passage par plusieurs fois le même caractère interdit !!");
                    return null;
                }
            }
            List<int> C = new List<int>(a);
            C.Add(i);
            C.Add(j);
            List<int> res;
            res = ChercheAutour(i - 1, j, mot, k + 1, C);
            if (res != null)
            {
                return res;
            }
            res = ChercheAutour(i + 1, j, mot, k + 1, C);
            if (res != null)
            {
                return res;
            }
            res = ChercheAutour(i, j - 1, mot, k + 1, C);
            if (res != null)
            {
                return res;
            }
            res = ChercheAutour(i, j + 1, mot, k + 1, C);
            if (res != null)
            {
                return res;
            }
            res = ChercheAutour(i - 1, j - 1, mot, k + 1, C);
            if (res != null)
            {
                return res;
            }
            res = ChercheAutour(i + 1, j + 1, mot, k + 1, C);
            if (res != null)
            {
                return res;
            }
            res = ChercheAutour(i - 1, j + 1, mot, k + 1, C);
            if (res != null)
            {
                return res;
            }
            res = ChercheAutour(i + 1, j - 1, mot, k + 1, C);
            if (res != null)
            {
                return res;
            }
            return null;
        }




        /// <summary>
        /// Permet de mettre à jour le plateau une fois qu'un mot à été trouvé
        /// </summary>
        /// <param name="Coord">Liste contenant les coordonées du mot trouvé</param>
        public void Maj_Plateau(List<int> Coord)
        {
            if (Coord == null || Coord.Count == 0)
            {
                return;
            }
            int x = 0;
            while (x < Coord.Count - 1)
            {
                this.plateau[Coord[x], Coord[x + 1]] = ' ';
                x += 2;
            }
            DescentePlateau();
        }




        /// <summary>
        /// Sous programme récursif gérant la descente des cases
        /// </summary>
        /// <param name="i">indice pour parcourir le plateau</param>
        /// <param name="j">indice pour parcourir le plateau</param>
        public void DescentePlateau(int i = 7, int j = 7)
        {
            if (i < 0)
            {
                return;
            }
            if (this.plateau[i, j] == ' ' && i - 1 >= 0)
            {
                if (this.plateau[i - 1, j] != ' ')
                {
                    this.plateau[i, j] = this.plateau[i - 1, j];
                    this.plateau[i - 1, j] = ' ';
                    if (i < plateau.GetLength(0) - 1)
                    {
                        DescentePlateau(i + 1, j);
                    }
                    else
                    {
                        DescentePlateau(i, j);
                    }
                    return;
                }
            }
            if (j > 0)
            {
                DescentePlateau(i, j - 1);
            }
            else
            {
                DescentePlateau(i - 1, this.plateau.GetLength(1) - 1);
            }
        }

        public bool Plateauvide()
        {
            bool vide = true;
            for (int i = 0; i < plateau.GetLength(0); i++)
            {
                for (int j = 0; j < plateau.GetLength(1); j++)
                {
                    if (plateau[i, j] != ' ')
                    {
                        vide = false;
                    }
                }
            }
            return vide;
        }
    }

}