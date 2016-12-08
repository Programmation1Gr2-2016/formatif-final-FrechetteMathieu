using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Mathieu Fréchette
 * 2016-11-29
 * Examen formatif 3 - Question 5
 * 14/15 
 */

namespace Question5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Déclaration des variables
            bool[] tabValeur = new bool[100];
            bool deplacement = false;
            bool encorePossibleAvancer = true;
            bool finTableauAtteint = false;
            int positionTableau = 0;
            int valeurDeplacement = 0;
            int nbEssaie = 0;
            Random rnd = new Random();
            ConsoleKeyInfo touche = new ConsoleKeyInfo();

            // Remplissage du tableau de bool
            tabValeur[0] = true;
            tabValeur[99] = true;
            for (int i = 1; i < 99; i++)
            {
                if (rnd.Next(0, 2) == 0)
                {
                    tabValeur[i] = false;
                }
                else
                {
                    tabValeur[i] = true;
                }
            }

            Console.WriteLine("Déplacement : ASDGH  AffichageEntier(): Y  Affichage10(): P  Quitter: Q");

            do
            {
                deplacement = false;
                if (Console.KeyAvailable)
                {
                    touche = Console.ReadKey(true);

                    switch (touche.Key)
                    {
                        case ConsoleKey.A:
                            valeurDeplacement = -3;
                            deplacement = true;
                            break;
                        case ConsoleKey.S:
                            valeurDeplacement = -2;
                            deplacement = true;
                            break;
                        case ConsoleKey.D:
                            valeurDeplacement = -1;
                            deplacement = true;
                            break;
                        case ConsoleKey.G:
                            valeurDeplacement = 2;
                            deplacement = true;
                            break;
                        case ConsoleKey.H:
                            valeurDeplacement = 4;
                            deplacement = true;
                            break;
                        case ConsoleKey.P:
                            Affichage10(tabValeur, positionTableau);
                            break;
                        case ConsoleKey.Y:
                            AffichageEntier(tabValeur, positionTableau);
                            break;
                        default:
                            break;
                    }

                    // Logique quand un touche de déplacement est détecté
                    if (deplacement)
                    {
                        // Augmente le nombre d'essaie
                        nbEssaie++;
                        // Teste si la fin du tableau à été atteint
                        if ((positionTableau + valeurDeplacement) >= tabValeur.GetLength(0) - 1)
                        {
                            finTableauAtteint = true;
                        }
                        else if ((positionTableau + valeurDeplacement) < 0)
                        {
                            positionTableau = 0;
                            valeurDeplacement = 0;
                        }
                        else if (tabValeur[positionTableau + valeurDeplacement] == false)
                        {
                            Console.WriteLine("Impossible d'avancer sur cette case");
                            valeurDeplacement = 0;
                        }
                        
                        // Déplace le joueur
                        positionTableau += valeurDeplacement;
                        
                        // Affiche la position
                        Console.WriteLine("Position du personnage : {0} nombre d'essais : {1}", positionTableau, nbEssaie);
                        //AffichageEntier(tabValeur, positionTableau);

                        // Test si c'est encore possible d'avancer
// CC : PositionTableau n'est pas toujours >= 0 ??
                        if (positionTableau >= 0)
                        {
// CC OK : Tu aurais pu faire une boucle, ou mettre sur plusieurs lignes pour faciliter la lecture
// Tu aurais aussi pu mettre un commentaire qui explique ce que tu fais ici
                            if (tabValeur[positionTableau + 1] == false && tabValeur[positionTableau + 2] == false 
                                && tabValeur[positionTableau + 3] == false && tabValeur[positionTableau + 4] == false)
                            {
                                encorePossibleAvancer = false;
                            }
                        }
                    }

                }
            } while (touche.Key != ConsoleKey.Q && finTableauAtteint != true && encorePossibleAvancer == true);

            // Message de fin
            Console.WriteLine("Le jeu est terminé");
            if (encorePossibleAvancer != true)
            {
                Console.WriteLine("Ce n'est plus possible d'avancer car il y a 4 case faux consécutives");
            }
            if (finTableauAtteint)
            {
                Console.WriteLine("Bravo vous êtes arrivé à la fin du tableau");
            }
            Console.WriteLine("Vous avez fait {0} essais!", nbEssaie);
            
            Console.Write("\nAppuyer sur Entrée pour quitter");
            Console.ReadLine();
        }

        // fonction qui affiche le tableau en entier
        private static void AffichageEntier(bool[] tabValeur, int position)
        {
            Console.Write("[");
            for (int i = 0; i < tabValeur.GetLength(0); i++)
            {
                if (i == position)
                {
                    Console.Write("*");
                }
                else if (tabValeur[i] == true)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write("|");
                }
            }
            Console.Write("]\n");
        }

        // fonction qui affiche les 10 cellules à la suite du personnage
        private static void Affichage10(bool[] tabValeur, int position)
        {
            Console.Write("[*");
            for (int i = position + 1; i <= position+10; i++)   
            {
                if (i < tabValeur.GetLength(0))
                {
                    if(tabValeur[i] == true)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write("|");
                    }
                    
                }
            }
            Console.Write("]\n");
        }
    }
}
