using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataFile
{
    internal class Personne
    {
        public string Pseudo;
        public int Victoire;
        public int defaite;
        public int egalite;
        public int nbrjeu;
    }

    internal class Score
    {
        public static void AfficherScores(List<Personne> playersData)
        {
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(" ║                                                                                                      ║");
            Console.WriteLine(" ║                                           TABLEAU DES SCORE                                          ║");
            Console.WriteLine(" ║                                                                                                      ║");
            Console.WriteLine(" ╠════════════════════════════════════╦═════════════════╦═══════════════╦═══════════════╦═══════════════╣");
            Console.WriteLine(" ║              JOUEURS               ║   VICTOIRE(S)   ║   DEFAITE(S)  ║   EGALITE(S)  ║   Nombre jeu  ║");
            Console.WriteLine(" ╠════════════════════════════════════╬═════════════════╬═══════════════╣═══════════════╣═══════════════╣");

            foreach (var player in playersData)
            {
                Console.WriteLine($" ║ {player.Pseudo,-34} ║ {player.Victoire,-15} ║ {player.defaite,-13} ║ {player.egalite,-13} ║ {player.nbrjeu,-13} ║");
                Console.WriteLine(" ╠════════════════════════════════════╬═════════════════╬═══════════════╬═══════════════╬═══════════════╣");
            }
                Console.WriteLine(" ╚════════════════════════════════════╩═════════════════╩═══════════════╩═══════════════╩═══════════════╝");


        }
    }
}










