using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_Mots_Glisses
{
    internal class Program
    {
        /// <summary>
        /// Jeux Mots Glisser
        /// </summary>
        public static void Jeux_Mots_Glisses()
        {
            //Création du dictionnaire trié
            Dictionnaire dico = new Dictionnaire();
            dico.Motsfrancais = Dictionnaire.Tri_Rapide(dico.Motsfrancais);


            //Création et initialisation du joueur 1
            Console.WriteLine("Nom du joueur 1: ");
            string nom1 = Console.ReadLine();
            Joueur joueur1 = new Joueur(nom1);




            //Création et initialisation du joueur 2
            Console.WriteLine("Nom du joueur 2: ");
            string nom2 = Console.ReadLine();
            Joueur joueur2 = new Joueur(nom2);
            Console.Clear();



            //Iniatialisation de la durée de la partie et du tour
            Console.Write("Durée de la partie en minutes (défaut 5 minutes): ");
            string dp = Console.ReadLine();
            TimeSpan dureepartie;
            if (dp != "")
            {
                dureepartie = TimeSpan.FromMinutes(int.Parse(dp));
            }
            else
            {
                dureepartie = TimeSpan.FromMinutes(5);
            }
            Console.WriteLine();
            Console.Write("Durée d'un tour en secondes (défaut 30 secondes): ");
            string dt = Console.ReadLine();
            TimeSpan dureetour;
            if (dt != "")
            {
                dureetour = TimeSpan.FromSeconds(int.Parse(dt));
            }
            else
            {
                dureetour = TimeSpan.FromSeconds(30);
            }
            Console.Clear();


            //Initialisation du plateau
            int choix = 0;
            do
            {
                Console.WriteLine("Veuillez entrer un des 3 chiffre proposé si vous voulez jouer : \n- A partir d'un fichier : 1\n- Avec un plateau généré aléatoirement : 2 \n- Arreter le jeu : 3");
                choix = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (choix != 1 && choix != 2 && choix != 3);


            //Permet d'appeller la méthode jeu qui permet donc de finalement jouer
            bool fin = false;
            while (fin != true)
            {
                switch (choix)
                {
                    case 1:
                        Console.Write("Nom du fichier: ");
                        string fichier = Console.ReadLine();
                        Plateau plat1 = new Plateau(fichier);
                        Jeu jeu1 = new Jeu(dico, plat1, joueur1, joueur2, dureepartie, dureetour);
                        jeu1.Jouer();
                        fin = true;
                        break;

                    case 2:
                        Plateau plat2 = new Plateau();
                        Jeu jeu2 = new Jeu(dico, plat2, joueur1, joueur2, dureepartie, dureetour);
                        jeu2.Jouer();
                        fin = true;
                        break;

                    case 3:
                        fin = true;
                        break;
                }
            }
            Console.WriteLine("Fin de Partie");
            Console.WriteLine("Les scores sont : " + joueur1.Nom + " : " + joueur1.Score + " et " + joueur2.Nom + " : " + joueur2.Score);
        }


        /// <summary>
        /// Test Recherche dichotomique : qui cherche le mot "amour" et un string null
        /// </summary>
        public static void Test1()
        {
            Dictionnaire dico = new Dictionnaire();


            //Le ditcionnaire n'est pas trier donc devrait ecrire :"Le dictionnaire n'est pas trier !!!"
            Dictionnaire.RechDichoRecursif(dico.Motsfrancais, "amour");


            //Trie du dictionnaire pour permettre la recherche dichotomique
            dico.Motsfrancais = Dictionnaire.Tri_Rapide(dico.Motsfrancais);


            //Test pour le mot "amour" et un string null
            Console.WriteLine("Le mot amour appartient au dictionnaire : " + Dictionnaire.RechDichoRecursif(dico.Motsfrancais, "amour"));
            Console.WriteLine("Le string null appartient au dictionnaire : " + Dictionnaire.RechDichoRecursif(dico.Motsfrancais, null));
        }


        /// <summary>
        /// Test sur Tri_Rapide
        /// </summary>
        public static void Test2()
        {
            string[] tab = new string[] { "Zebre", "Taureau", "Tigre", "Lion", "Poule", "Mouton", "Vache", "Chat", "Cheval", "Dragon" };
            string[] tab2 = null;
            string[] tab3 = new string[] { };

            //Tableau non trier
            Console.WriteLine("Avant tri : ");
            AfficherTab(tab);
            AfficherTab(tab2);
            AfficherTab(tab3);
            Console.WriteLine();

            //Après tri
            Console.WriteLine("Après tri : ");
            tab = Dictionnaire.Tri_Rapide(tab);
            tab2 = Dictionnaire.Tri_Rapide(tab2);
            tab3 = Dictionnaire.Tri_Rapide(tab3);
            AfficherTab(tab);
            AfficherTab(tab2);
            AfficherTab(tab3);

        }


        /// <summary>
        /// Test pour Contient
        /// </summary>
        public static void Test3()
        {
            List<string> mottrouvé = new List<string>();
            mottrouvé.Add("amour");
            mottrouvé.Add("Houssam");
            Joueur joueur1 = new Joueur("Test", mottrouvé, 100);

            Console.WriteLine("Est ce que amour ce trouve dans la liste : " + joueur1.Contient("amour"));
            Console.WriteLine("Est ce que le string null ce trouve dans la liste : " + joueur1.Contient(null));
            Console.WriteLine("Est ce que Rafiou ce trouve dans la liste : " + joueur1.Contient("Rafiou"));


        }


        /// <summary>
        /// Test pour calculer le score d'un mot
        /// </summary>
        public static void Test4()
        {
            Console.WriteLine("Le score du mot amour est : " + Jeu.Scoremot("amour"));
            Console.WriteLine("Le score du mot Rafiou est : " + Jeu.Scoremot("Rafiou"));
            Console.WriteLine("Le string null a pour score : " + Jeu.Scoremot(null));
        }


        /// <summary>
        /// Test addscore et addmot
        /// </summary>
        public static void Test5()
        {
            List<string> mottrouvé = new List<string>();
            Joueur joueur1 = new Joueur("Houssam", mottrouvé, 0);
            //Avant l'ajout de points
            Console.WriteLine(joueur1.toString());
            Console.WriteLine();

            //Après l'ajout de 100 points et des mots "amour" et "Bonjour"
            joueur1.Add_Score(100);
            joueur1.Add_Mot("Bonjour");
            joueur1.Add_Mot("Amour");
            Console.WriteLine(joueur1.toString());
            Console.WriteLine();

            //Après l'ajout de 0 points et d'un string null
            joueur1.Add_Score(0);
            joueur1.Add_Mot(null);
            Console.WriteLine(joueur1.toString());
        }

        public static void AfficherTab(string[] tab)
        {
            if (tab == null)
            {
                Console.WriteLine("Tableau null");
            }
            else if (tab.Length == 0)
            {
                Console.WriteLine("Tableau vide");
            }
            else
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    if (i == tab.Length - 1)
                    {
                        Console.Write(tab[i]);
                    }
                    else
                    {
                        Console.Write(tab[i] + " ; ");
                    }

                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Jeux_Mots_Glisses();
            /*Test1();
            Test2();
            Test3();
            Test4();
            Test5();*/
        }
        
    }
}
