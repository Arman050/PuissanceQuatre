using Newtonsoft.Json;
using puissance;
using DataFile;


bool endgame = false;
bool end = false;

List<Personne> DataPlayers = new List<Personne>();

plateau plateau = new();
plateau.affichermenu();
Console.ReadKey(intercept: true);

while (!endgame)
{
    bool quitterMenu = false;
    bool pseudoUnique = false;
    bool win1 = false;
    bool win2 = false;
    bool NotWin = false;
    string joueurwin = "";
    
    
    Console.Clear();


    while (!quitterMenu)
    {
        Console.Clear();

        Console.WriteLine(" ╔════════════════════════════════════════════╗");
        Console.WriteLine(" ║                                            ║");
        Console.WriteLine(" ║               MENU PRINCIPAL               ║");
        Console.WriteLine(" ║                                            ║");
        Console.WriteLine(" ╠════════════════════════════════════════════╣");
        Console.WriteLine(" ║                                            ║");
        Console.WriteLine(" ║ 1. Afficher les règles                     ║");
        Console.WriteLine(" ║ 2. Jouer une nouvelle partie               ║");
        Console.WriteLine(" ║ 3. Afficher le tableau des score           ║");
        Console.WriteLine(" ║ 4. Quitter le jeu                          ║");
        Console.WriteLine(" ║                                            ║");
        Console.WriteLine(" ╚════════════════════════════════════════════╝");


        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                Console.Clear();
                plateau.Regle();
                Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu principal...");
                Console.ReadKey(true);
                break;
            case ConsoleKey.D2:
                quitterMenu = true;
                break;
            case ConsoleKey.D3:
                Console.Clear();
                Score.AfficherScores(DataPlayers);
                Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu principal...");
                Console.ReadKey(true);
                break;
            case ConsoleKey.D4:
                end = true;
                quitterMenu = true;
                break;
            default:
                Console.WriteLine("Touche non valide. Veuillez appuyer sur une touche numérique de 1 à 4.");
                break;
        }
    }

    if (end == true)
    {
        endgame = true;
    }
    else
    {
        Console.Clear();

        Console.WriteLine(" Quel est le pseudo du premier joueur ?");
        string joueur1 = "";

        while (!pseudoUnique)
        {
            joueur1 = Console.ReadLine();
            if (DataPlayers.Any(p => p.Pseudo == joueur1))
            {
                break;
            }
            else
            {
                pseudoUnique = true;
                DataPlayers.Add(
                    new Personne
                    {
                        Pseudo = joueur1,
                        Victoire = 0,
                        defaite = 0,
                        egalite = 0,
                    }

                );
            }
        }

        Console.WriteLine(" Quel est le pseudo du deuxième joueur ?");
        string joueur2 = "";

        pseudoUnique = false;

        while (!pseudoUnique)
        {
            joueur2 = Console.ReadLine();
            if (DataPlayers.Any(p => p.Pseudo == joueur2))
            {
                break;
            }
            else
            {
                pseudoUnique = true;
                DataPlayers.Add(
                    new Personne
                    {
                        Pseudo = joueur2,
                        Victoire = 0,
                        defaite = 0,
                    }

                );
            }
        }


        plateau.Initialiser();
        
        // Convertir l'objet DataPlayers en une chaîne JSON
        string data = JsonConvert.SerializeObject(DataPlayers);

        // Stockage des données dans "data.txt" si inexistant => création sinon remplacement des données
        File.WriteAllText("data.txt", data);

        plateau.Afficher();


        while (!win1 && !win2 && !NotWin)
        {
            Console.WriteLine($" {joueur1}, quelle colonne ?");
            int col = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine(" Entrée un entier : ");
                ConsoleKeyInfo keyCol = Console.ReadKey(true);
                if (char.IsDigit(keyCol.KeyChar))
                {
                    col = int.Parse(keyCol.KeyChar.ToString());
                    isValidInput = col >= 1 && col <= 7;
                }

                if (!isValidInput)
                {
                    Console.WriteLine("Entrée invalide. Veuillez entrer un entier (1-7).");
                }
            }
            plateau.Jouer(col, "O");
            plateau.Afficher();
            win1 = plateau.verificationwin("O");



            if (win1 == true)
            {
                joueurwin = joueur1;

                DataPlayers.Find(j => j.Pseudo == joueur1).Victoire += 1;
                DataPlayers.Find(j => j.Pseudo == joueur2).defaite += 1;

                break;
            }


            Console.WriteLine($" {joueur2}, quelle colonne ?");

            int col2 = 0;
            bool isValidInput2 = false;

            while (!isValidInput2)
            {
                Console.WriteLine(" Entrée un entier : ");
                ConsoleKeyInfo keyCol2 = Console.ReadKey(true);
                if (char.IsDigit(keyCol2.KeyChar))
                {
                    col2 = int.Parse(keyCol2.KeyChar.ToString());
                    isValidInput2 = col2 >= 1 && col2 <= 7;
                }

                if (!isValidInput2)
                {
                    Console.WriteLine("Entrée invalide. Veuillez entrer un entier (1-7).");
                }
            }

            plateau.Jouer(col2, "X");
            plateau.Afficher();
            win2 = plateau.verificationwin("X");

            if (win2 == true)
            {
                joueurwin = joueur2;
                DataPlayers.Find(j => j.Pseudo == joueur2).Victoire += 1;
                DataPlayers.Find(j => j.Pseudo == joueur1).defaite += 1;
                win2 = true;
            }

            if (!win1 && !win2)
            {
                NotWin = plateau.VerifEgalite(); 
            }
        }

        DataPlayers.Find(j => j.Pseudo == joueur2).nbrjeu += 1;
        DataPlayers.Find(j => j.Pseudo == joueur1).nbrjeu += 1;

        if (win2 || win1)
        {
            plateau.affichagewin(joueurwin);
        }
        else
        {
            DataPlayers.Find(j => j.Pseudo == joueur2).egalite += 1;
            DataPlayers.Find(j => j.Pseudo == joueur1).egalite += 1;
        }

        Console.WriteLine("");
        Console.WriteLine(" Voulez-vous rejouer ? y / n  :");


        bool correct = false;

        while (correct == false)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.N:
                    endgame = true;
                    correct = true;
                    break;
                case ConsoleKey.Y:
                    endgame = false;
                    correct = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Touche non valide. Veuillez appuyer sur 'y' ou 'n'");
                    break;
            }
        }
    }
}

plateau.afficherOut();

