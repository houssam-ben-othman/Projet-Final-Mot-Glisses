using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Projet_Final_Mots_Glisses;

namespace Projet_Final_Mots_Glisses
{
    internal class Jeu
    {
        private Dictionnaire dico;
        private Plateau plateau;
        private Joueur joueur1;
        private Joueur joueur2;
        private TimeSpan dureepartie;
        private DateTime tempspartie;//Permettre de comparer le temps de la partie avec sa duree
        private TimeSpan dureetour;
        private DateTime tempstourjoueur;// compter le temps du tour qui va permettre de le comparer avc duree tour

        /// <summary>
        /// Constructeur qui va permettre de jouer suivant une durée de partie et de tour personnalisé
        /// </summary>
        /// <param name="dico">Dictionnaire</param>
        /// <param name="plato">Plateau de jeu</param>
        /// <param name="joueur1">Joueur 1</param>
        /// <param name="joueur2">Joueur 2</param>
        /// <param name="dureepartie">Durée d'une partie</param>
        /// <param name="tempspartie">Temps du tour</param>
        /// <param name="dureetour">Duree d'un tour</param>
        /// <param name="tempstourjoueur">Temps du tour du joueur</param>
        public Jeu(Dictionnaire dico, Plateau plato, Joueur joueur1, Joueur joueur2, TimeSpan dureepartie, TimeSpan dureetour)
        {
            this.dico = dico;
            this.plateau = plato;
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
            this.dureepartie = dureepartie;
            this.dureetour = dureetour;
            this.tempstourjoueur = DateTime.Now;
            this.tempspartie = DateTime.Now;
        }


        /// <summary>
        ///  Constructeur qui va permettre de jouer suivant une durée de partie et de tour par défaut (5 min la partie et 30 sec le tour)
        /// </summary>
        /// <param name="dico">Dictionnaire</param>
        /// <param name="plato">Plateau de jeu</param>
        /// <param name="joueur1">Joueur 1</param>
        /// <param name="joueur2">Joueur 2</param>
        public Jeu(Dictionnaire dico, Plateau plato, Joueur joueur1, Joueur joueur2)
        {
            this.dico = dico;
            this.plateau = plato;
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
            this.dureepartie = TimeSpan.FromMinutes(5);
            this.dureetour = TimeSpan.FromSeconds(30);
            this.tempstourjoueur = DateTime.Now;
            this.tempspartie = DateTime.Now;
        }



        /// <summary>
        /// Dictionnaire de mots français
        /// </summary>
        public Dictionnaire Dico
        {
            get { return dico; }
        }



        /// <summary>
        /// Plateau de jeu
        /// </summary>
        public Plateau Plateau
        {
            get { return plateau; }
            set { plateau = value; }
        }



        /// <summary>
        /// 1 er joueur
        /// </summary>
        public Joueur Joueur1
        {
            get { return joueur1; }
        }



        /// <summary>
        /// 2 ème joueur
        /// </summary>
        public Joueur Joueur2
        {
            get { return joueur2; }
        }



        /// <summary>
        /// Durée d'un tour (30 sec)
        /// </summary>
        public TimeSpan Dureetour
        {
            get { return dureetour; }
        }



        /// <summary>
        /// Durée d'une partie (5 min)
        /// </summary>
        public TimeSpan Dureepartie
        {
            get { return dureepartie; }
        }



        /// <summary>
        /// Combien de temps il restera au joueur
        /// </summary>
        public DateTime Tempstourjoueur
        {
            get { return tempstourjoueur; }
            set { tempstourjoueur = value; }
        }



        /// <summary>
        /// Combien de temps il restera à la partie
        /// </summary>
        public DateTime Tempspartie
        {
            get { return tempspartie; }
            set { tempspartie = value; }
        }



        /// <summary>
        /// Permet de nous indiquer si cela est la fin de la partie ou non
        /// </summary>
        /// <returns>Retourne un booléen qui nous indique si c'est la fin de partie ou non</returns>
        public bool Findepartie()
        {
            TimeSpan tempsecoule = DateTime.Now - tempspartie;
            if (Plateau.Plateauvide() == true || dureepartie <= tempsecoule)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Permet de renvoyer si on doit changer de tour ou non
        /// </summary>
        /// <returns>Retourne un booléen en fonction si on doit changer de joueur ou pas</returns>
        public bool Changementdetour()
        {
            TimeSpan tempsecoule = DateTime.Now - tempstourjoueur;
            if (dureetour <= tempsecoule)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Permet de compter le score du mot rentrer en paramètre
        /// </summary>
        /// <param name="mot">Mot a calculer le score</param>
        /// <returns>Score du mot</returns>
        public static int Scoremot(string mot)
        {
            int compt = 0;
            mot = mot.ToUpper();
            for (int i = 0; i < mot.Length; i++)
            {
                switch (mot[i])
                {
                    case 'A':
                        compt = compt + 1;
                        break;
                    case 'B':
                        compt = compt + 2;
                        break;
                    case 'C':
                        compt = compt + 2;
                        break;
                    case 'D':
                        compt = compt + 2;
                        break;
                    case 'E':
                        compt = compt + 1;
                        break;
                    case 'F':
                        compt = compt + 3;
                        break;
                    case 'G':
                        compt = compt + 3;
                        break;
                    case 'H':
                        compt = compt + 4;
                        break;
                    case 'I':
                        compt = compt + 1;
                        break;
                    case 'J':
                        compt = compt + 3;
                        break;
                    case 'K':
                        compt = compt + 5;
                        break;
                    case 'L':
                        compt = compt + 2;
                        break;
                    case 'M':
                        compt = compt + 2;
                        break;
                    case 'N':
                        compt = compt + 2;
                        break;
                    case 'O':
                        compt = compt + 1;
                        break;
                    case 'P':
                        compt = compt + 2;
                        break;
                    case 'Q':
                        compt = compt + 5;
                        break;
                    case 'R':
                        compt = compt + 3;
                        break;
                    case 'S':
                        compt = compt + 3;
                        break;
                    case 'T':
                        compt = compt + 3;
                        break;
                    case 'U':
                        compt = compt + 1;
                        break;
                    case 'V':
                        compt = compt + 5;
                        break;
                    case 'W':
                        compt = compt + 7;
                        break;
                    case 'X':
                        compt = compt + 7;
                        break;
                    case 'Y':
                        compt = compt + 7;
                        break;
                    case 'Z':
                        compt = compt + 7;
                        break;
                    default:
                        break;

                }
            }
            return compt;
        }


        /// <summary>
        /// Permet de lancer une partie
        /// </summary>
        public void Jouer()
        {
            int numerojoueur = 1;
            bool fin = false;
            bool tour;
            tempspartie = DateTime.Now;
            while (fin != true)
            {
                tour = false;
                tempstourjoueur = DateTime.Now;
                Console.WriteLine(plateau);
                string mot = "";
                switch (numerojoueur)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("0 : Arret du jeu");
                        Console.WriteLine();
                        while (tour != true && fin != true)//permet de verifier si on doit changer de joueur ou pas et si c'est la fin de partie ou non
                        {
                            fin = Findepartie();
                            tour = Changementdetour();
                            if (fin == true || tour == true)
                            {
                                break;
                            }
                            TimeSpan tempsecouletour = DateTime.Now - tempstourjoueur;
                            TimeSpan tempsrestanttour = dureetour - tempsecouletour;
                            TimeSpan tempsecoulepartie = DateTime.Now - tempspartie;
                            TimeSpan tempsrestantpartie = dureepartie - tempsecoulepartie;
                            Console.WriteLine(plateau);
                            Console.WriteLine();
                            Console.WriteLine("Veuillez entrer un mot que vous reperé : ");
                            Console.WriteLine();
                            Console.WriteLine("Score de " + joueur1.Nom + " : " + joueur1.Score + "                                           " + "Score de " + joueur2.Nom + " : " + joueur2.Score);
                            Console.WriteLine();
                            Console.WriteLine("Il reste " + tempsrestanttour.Seconds + " secondes pour ce tour");
                            Console.WriteLine();
                            Console.WriteLine("Il reste " + tempsrestantpartie.Minutes + " minutes et " + tempsrestantpartie.Seconds + " secondes pour cette partie");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Joueur " + joueur1.Nom + " :");
                            Console.WriteLine();
                            while (Changementdetour() == false && mot == "" && fin == false)
                            {
                                mot = Console.ReadLine();
                                if (mot == "0")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Arret du jeu voulez vou sauvegarder le plateau ? (O/N)");
                                    string Save = Console.ReadLine();
                                    Save = Save.ToUpper();
                                    if (Save == "O")
                                    {
                                        plateau.ToFile("PlateauMotsGlisses.csv");
                                        Console.WriteLine("Plateau sauvegardé");
                                        Thread.Sleep(1000);
                                    }
                                    fin = true;
                                    Console.Clear();
                                    return;
                                }
                                Console.Clear();
                                fin = Findepartie();
                                tour = Changementdetour();
                                if (fin == true || tour == true)// permet de vérifier si le temps est écouler pour si oui ne pas prendre en compte l'entrée précédente
                                {
                                    break;
                                }

                            }
                            if (Dictionnaire.RechDichoRecursif(Dico.Motsfrancais, mot) == true && joueur1.Contient(mot) == false && plateau.Recherche_Mot(mot) != null)//ajoute le score du mot si toute les conditions sont remplies
                            {
                                joueur1.Add_Score(Scoremot(mot));
                                joueur1.Mottrouve.Add(mot);
                                List<int> coords = plateau.Recherche_Mot(mot);
                                if (coords != null)
                                {
                                    // Affichage temporaire avec '*'
                                    for (int x = 0; x < coords.Count; x += 2)
                                    {
                                        plateau.Plateaux[coords[x], coords[x + 1]] = '*';
                                    }
                                    Console.Clear();
                                    Console.WriteLine(plateau);
                                    Thread.Sleep(1000); // pause de 1 seconde pour montrer les '*'

                                    // Mise à jour du plateau
                                    plateau.Maj_Plateau(coords);
                                }
                                tour = true;
                                break;
                            }
                            else if (Dictionnaire.RechDichoRecursif(Dico.Motsfrancais, mot) == false)// renvoie un message d'erreur si le mot n'appartient pas au dictionnaire
                            {
                                mot = "";
                                Console.WriteLine("Mot ne se trouvant pas dans le dictionnaire français !!! ");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            else if (joueur1.Contient(mot) == true)// renvoie un message d'erreur si le mot appartient deja a la liste de mot trouver par le joueur
                            {
                                mot = "";
                                Console.WriteLine("Le mot est deja dans la liste de mot trouvés par " + joueur1.Nom);
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            else if (plateau.Recherche_Mot(mot) == null)// renvoie un message d'erreur si le mot n'est pas dans le plateau
                            {
                                mot = "";
                                Console.WriteLine("Le mot entré n'appartient pas au plateau");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            tour = Changementdetour();
                        }
                        numerojoueur = 2;
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("0 : Arret du jeu");
                        Console.WriteLine();
                        while (tour != true && fin != true)//permet de verifier si on doit changer de joueur ou pas et si c'est la fin de partie ou non
                        {
                            fin = Findepartie();
                            tour = Changementdetour();
                            if (fin == true || tour == true)
                            {
                                break;
                            }
                            TimeSpan tempsecouletour = DateTime.Now - tempstourjoueur;
                            TimeSpan tempsrestanttour = dureetour - tempsecouletour;
                            TimeSpan tempsecoulepartie = DateTime.Now - tempspartie;
                            TimeSpan tempsrestantpartie = dureepartie - tempsecoulepartie;
                            Console.WriteLine(plateau);
                            Console.WriteLine();
                            Console.WriteLine("Veuillez entrée un mot que vous reperé : ");
                            Console.WriteLine();
                            Console.WriteLine("Score de " + joueur1.Nom + " : " + joueur1.Score + "                                           " + "Score de " + joueur2.Nom + " : " + joueur2.Score);
                            Console.WriteLine();
                            Console.WriteLine("Il reste " + tempsrestanttour.Seconds + " secondes pour ce tour");
                            Console.WriteLine();
                            Console.WriteLine("Il reste " + tempsrestantpartie.Minutes + " minutes et " + tempsrestantpartie.Seconds + " secondes pour cette partie");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Joueur " + joueur2.Nom + " :");
                            Console.WriteLine();

                            while (Changementdetour() == false && mot == "" && fin == false)
                            {
                                mot = Console.ReadLine();
                                if (mot == "0")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Arret du jeu voulez vou sauvegarder le plateau ? (O/N)");
                                    string Save = Console.ReadLine();
                                    Save = Save.ToUpper();
                                    if (Save == "O")
                                    {
                                        plateau.ToFile("PlateauMotsGlisses.csv");
                                        Console.WriteLine("Plateau sauvegardé");
                                        Thread.Sleep(1000);
                                    }
                                    fin = true;
                                    Console.Clear();
                                    return;
                                }
                                Console.Clear();
                                fin = Findepartie();
                                tour = Changementdetour();
                                if (fin == true || tour == true)// permet de vérifier si le temps est écouler pour si oui ne pas prendre en compte l'entrée précédente
                                {
                                    break;
                                }

                            }
                            if (Dictionnaire.RechDichoRecursif(Dico.Motsfrancais, mot) == true && joueur2.Contient(mot) == false && plateau.Recherche_Mot(mot) != null)//ajoute le score du mot si toute les conditions sont remplies
                            {
                                joueur2.Add_Score(Scoremot(mot));
                                joueur2.Mottrouve.Add(mot);
                                List<int> coords = plateau.Recherche_Mot(mot);
                                if (coords != null)
                                {
                                    // Affichage temporaire avec '*'
                                    for (int x = 0; x < coords.Count; x += 2)
                                    {
                                        plateau.Plateaux[coords[x], coords[x + 1]] = '*';
                                    }
                                    Console.Clear();
                                    Console.WriteLine(plateau);
                                    Thread.Sleep(1000); // pause de 1 seconde pour montrer les '*'

                                    // Maintenant on met à jour le plateau normalement
                                    plateau.Maj_Plateau(coords);
                                }
                                tour = true;
                                break;
                            }
                            else if (Dictionnaire.RechDichoRecursif(Dico.Motsfrancais, mot) == false)// renvoie un message d'erreur si le mot n'appartient pas au dictionnaire
                            {
                                mot = "";
                                Console.WriteLine("Mot ne se trouvant pas dans le dictionnaire français !!! ");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            else if (joueur2.Contient(mot) == true)// renvoie un message d'erreur si le mot appartient deja a la liste de mot trouver par le joueur
                            {
                                mot = "";
                                Console.WriteLine("Le mot est deja dans la liste de mot trouvés par " + joueur2.Nom);
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            else if (plateau.Recherche_Mot(mot) == null)// renvoie un message d'erreur si le mot n'est pas dans le plateau
                            {
                                mot = "";
                                Console.WriteLine("Le mot entré n'appartient pas au plateau");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            tour = Changementdetour();
                        }
                        numerojoueur = 1;
                        break;
                }
            }



        }

    }
}