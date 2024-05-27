using DataFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puissance
{
    public class plateau
    {

        private string[,] Tableau = new string[6, 7];
        public void Initialiser()
        {

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Tableau[i, j] = " ";
                }
            }
        }

        public void Afficher()
        { 
            Console.Clear();
            Console.WriteLine("");
            for (int i = 0; i < 6; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" ║");
                Console.ResetColor();
                for (int j = 0; j < 7; j++)
                {
                    Console.ForegroundColor = Tableau[i, j] == "O" ? ConsoleColor.Red : Tableau[i, j] == "X" ? ConsoleColor.Yellow : ConsoleColor.Gray;
                    Console.Write($" {Tableau[i, j]}");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" ║");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($" ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
            Console.ResetColor();

            Console.WriteLine($" ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            Console.WriteLine($" ║ 1 ║ 2 ║ 3 ║ 4 ║ 5 ║ 6 ║ 7 ║");
            Console.WriteLine($" ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
        }

        public void Jouer(int col, string color)
        {

            bool colonneRemplie = false;
            while (!colonneRemplie)
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (Tableau[i, col - 1] == " ")
                    {
                        Tableau[i, col - 1] = color;
                        colonneRemplie = true;
                        break;
                    }
                    if (i == 0)
                    {
                        Console.WriteLine("Plus de place disponible dans cette colonne !");
                        bool isValidInputt = false;

                        while (!isValidInputt)
                        {
                            Console.WriteLine(" Entrée un entier : ");
                            ConsoleKeyInfo keyCol = Console.ReadKey(true);
                            if (char.IsDigit(keyCol.KeyChar))
                            {
                                col = int.Parse(keyCol.KeyChar.ToString());
                                isValidInputt = col >= 1 && col <= 7;
                            }

                            if (!isValidInputt)
                            {
                                Console.WriteLine("Entrée invalide. Veuillez entrer un entier (1-7).");
                            }
                        }
                    }
                }
            }
        }

        public bool verificationwin(string joueur)
        { 

            // verif horizontale

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Tableau[i, j] == joueur &&
                    Tableau[i, j + 1] == joueur &&
                    Tableau[i, j + 2] == joueur &&
                    Tableau[i, j + 3] == joueur)
                    {
                        return true;
                    }
                }
            }

            // verif verticale

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (Tableau[i, j] == joueur &&
                    Tableau[i + 1, j] == joueur &&
                    Tableau[i + 2, j] == joueur &&
                    Tableau[i + 3, j] == joueur)
                    {
                        return true;
                    }
                }
            }

            // verif diago

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Tableau[i, j] == joueur &&
                    Tableau[i + 1, j + 1] == joueur &&
                    Tableau[i + 2, j + 2] == joueur &&
                    Tableau[i + 3, j + 3] == joueur)
                    {
                        return true;
                    }
                }
            }

            // verif diago inverse

            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Tableau[i, j] == joueur && 
                    Tableau[i - 1, j + 1] == joueur &&
                    Tableau[i - 2, j + 2] == joueur &&
                    Tableau[i - 3, j + 3] == joueur)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void affichagewin(string joueurwin)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine(" ╔═══════════════════════════════════╗");
            Console.WriteLine(" ║");
            Console.WriteLine($" ║ Le joueur '{joueurwin}' a gagné(e) !!! ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╚═══════════════════════════════════╝");
            Console.ResetColor();

        }

        public void affichermenu()
        {
            Console.Clear();

            Console.WriteLine(@"

    ██████╗ ██╗   ██╗██╗███████╗███████╗ █████╗ ███╗   ██╗ ██████╗███████╗    ██╗  ██╗
    ██╔══██╗██║   ██║██║██╔════╝██╔════╝██╔══██╗████╗  ██║██╔════╝██╔════╝    ██║  ██║
    ██████╔╝██║   ██║██║███████╗███████╗███████║██╔██╗ ██║██║     █████╗      ███████║
    ██╔═══╝ ██║   ██║██║╚════██║╚════██║██╔══██║██║╚██╗██║██║     ██╔══╝      ╚════██║
    ██║     ╚██████╔╝██║███████║███████║██║  ██║██║ ╚████║╚██████╗███████╗         ██║
    ╚═╝      ╚═════╝ ╚═╝╚══════╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝╚══════╝         ╚═╝
 ");

        }

        public void afficherOut()
        {
            Console.Clear();

            Console.WriteLine(@"

    ███╗   ███╗███████╗██████╗  ██████╗██╗    ██╗
    ████╗ ████║██╔════╝██╔══██╗██╔════╝██║    ██║
    ██╔████╔██║█████╗  ██████╔╝██║     ██║    ██║
    ██║╚██╔╝██║██╔══╝  ██╔══██╗██║     ██║    ╚═╝
    ██║ ╚═╝ ██║███████╗██║  ██║╚██████╗██║    ██╗
    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝    ╚═╝
                                          ");
        }


        public void Regle()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(" ║");
            Console.WriteLine(" ║ Règles du jeu :               ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine(" ║");
            Console.WriteLine(" ║ 1. Le jeu se joue sur une grille verticale de 7 colonnes et 6 rangées, soit 42 emplacements au total.                ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine(" ║");
            Console.WriteLine(" ║ 2. Deux joueurs s'affrontent, l'un utilisant les pions jaunes et l'autre les rouges.                                 ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine(" ║");
            Console.WriteLine(" ║ 3. Les joueurs prennent tour à tour à placer un pion dans l'une des colonnes de la grille.                       ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine(" ║");
            Console.WriteLine(" ║ 4. Le pion tombe au bas de la colonne, occupant la position la plus basse possible dans cette colonne.                       ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine(" ║");
            Console.WriteLine(" ║ 5.Le but est d'aligner quatre pions de sa couleur, soit horizontalement, verticalement ou en diagonale.                       ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine(" ║");
            Console.WriteLine(" ║ 6. Le jeu se termine dès qu'un joueur réussit à aligner quatre de ses pions ou lorsque la grille est entièrement remplie sans qu'aucun joueur n'ait réussi à aligner quatre pions.  ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine(" ║");
            Console.WriteLine(" ║ 7. Si la grille est remplie sans qu'aucun joueur n'ait aligné quatre pions, la partie est déclarée nulle.                       ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine(" ║");
            Console.WriteLine(" ║ 8.Le joueur qui réussit à aligner quatre de ses pions en premier est déclaré vainqueur.                    ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

        }



        public bool VerifEgalite()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (Tableau[i, j] == " ") // Si une case est vide, il n'y a pas d'égalité
                    {
                        return false;
                    }
                }
            }

            // Si aucune case n'est vide, il y a égalité
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine(" ╔═══════════════════════════════════╗");
            Console.WriteLine(" ║");
            Console.WriteLine($" ║ Egalité, Aucun gagnant !!! ");
            Console.WriteLine(" ║");
            Console.WriteLine(" ╚═══════════════════════════════════╝");
            Console.ResetColor();
            return true;
        }
    }
}
