using System;

namespace Lab_3
{
    class Program
    {
        static Random generateur = new Random();
        //Exercise 1
        static void Main(string[] args)
        {
            int Choix = 0;
            Console.WriteLine(" Choix 1-Jeux de mot \n Choix 2 - Pendu \n Choix 3- Tic Tac Toe");
            Choix = Convert.ToInt32(Console.ReadLine());
            {
                if (Choix == 1)
                {
                    Console.WriteLine("Veuillez entrez votre phrase! :)");
                    string phrase = Console.ReadLine();
                    bool finProgramme = false;
                    while (finProgramme == false)
                    {
                        AfficherMenu();
                        int choixMenu = Convert.ToInt32(Console.ReadLine());
                        switch (choixMenu)
                        {
                            case 1: nombreDeMot(phrase); break;
                            case 2: nombreFoisLettreApparait(phrase); break;
                            case 3: lettreApparaitSouvent(phrase); break;
                            case 4: encoder(phrase); break;
                            case 5: finProgramme = true; break;
                            default: Console.WriteLine("Entrer un choix valide"); break;
                        }
                    }
                }
                else if (Choix == 2)
                {//Pendu

                    bool finProgramme = false;
                    Console.Clear();
                    int nbErreur = 0;
                    Console.Write("Bienvenue dans le jeu du pendu. Vous avez le droit à seulement 5 lettre d'essaie! Appuyer sur enter pour commencer! \n");
                    string[] tabPendu = { "prog", "corde", "crack", "snitch", "lol", "rasoir", "pont", "gorille", "autruche", "tabarnake" };
                    bool sauveVie = false;
                    bool fini = false;
                    string choixLettre = "";
                    String motTrouver = tabPendu[generateur.Next(1, 11)];
                    char[] tabLettre = new char[motTrouver.Length];
                    for (int i = 0; i < tabLettre.Length; i++)
                    {
                        tabLettre[i] = '_';
                    }
                    while (finProgramme == false && nbErreur < 6 && fini==false)
                    {
                        AfficherPendu(nbErreur);
                        Console.WriteLine("Veuillez saisir une lettre!");
                        for (int i = 0; i < tabLettre.Length; i++)
                        {
                            Console.Write(tabLettre[i] + " ");
                        }
                        choixLettre = Console.ReadLine();

                        for (int i = 0; i < motTrouver.Length; i++)
                        {
                            if (choixLettre[0] == motTrouver[i])
                            {
                                tabLettre[i] = choixLettre[0];
                                sauveVie = true;
                            }
                        }
                        if (sauveVie == false)
                        {
                            nbErreur += 1;
                        }
                        else
                        {
                            bool resteTiret = false;
                            for (int i = 0; i < tabLettre.Length; i++)
                            {
                                if (tabLettre[i] == '_')
                                {
                                    resteTiret = true;
                                }
                            }

                            if (!resteTiret)
                                finProgramme = true;
                        }
                        sauveVie = false;
                        Console.Clear();
                    }
                  
                    if (fini==true)
                    {
                        Console.WriteLine("\n Bravo! Vous avez gagné! Le mot était " + motTrouver);
                    }
                    else
                    {
                        Console.WriteLine("Vous avez perdu! X_X !");
                    }
                    Console.ReadKey();

                }
                else if (Choix == 3)
                {
                    //Tic tac toe
                    Console.Write("Combien de match voulez-vous jouez?: ");
                    nbMatch = int.Parse(Console.ReadLine());

                    Console.Write("Nom joueur 1: ");
                    player1 = Console.ReadLine();

                    Console.Write("Nom joueur 2: ");
                    player2 = Console.ReadLine();

                    while (conteurDeMatch < nbMatch)
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Score: ");
                            Console.WriteLine("{0}: {1}", player1, gagnant_p1);
                            Console.WriteLine("{0}: {1}", player2, gagnant_p2);
                            Console.WriteLine("{0} est X et {1} est O!", player1, player2);
                            Console.WriteLine("");
                            if (player % 2 == 0)
                            {

                                Console.WriteLine("{0} tour", player2);

                            }

                            else
                            {

                                Console.WriteLine("{0} tour", player1);

                            }

                            Console.WriteLine("");
                            Tableau();
                            tour = int.Parse(Console.ReadLine());
                            if (casse[tour] != 'X' && casse[tour] != '0')
                            {
                                if (player % 2 == 0)
                                {
                                    casse[tour] = 'O';
                                    player++;
                                }
                                else
                                {
                                    casse[tour] = 'X';
                                    player++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cette place {0} est marqué par {1}", tour, casse[tour]);
                                Console.WriteLine("");
                            }

                            point = VerifierGagnant();

                        } while (point != 1 && point != -1);

                        Console.Clear();
                        Tableau();

                        if (point == 1 && ((player % 2) + 1 == 1))
                        {
                            gagnant_p1++;
                            Console.WriteLine("Score: ");
                            Console.WriteLine("{0}: {1}", player1, gagnant_p1);
                            Console.WriteLine("{0}: {1}", player2, gagnant_p2);

                            Console.WriteLine("{0} Gagnant!", player1);
                        }

                        else if (point == 1 && ((player % 2) + 1 != 1))
                        {
                            gagnant_p2++;
                            Console.WriteLine("Score: ");
                            Console.WriteLine("{0}: {1}", player1, gagnant_p1);
                            Console.WriteLine("{0}: {1}", player2, gagnant_p2);

                            Console.WriteLine("{0} Gagnant!", player2);
                        }
                        else

                        {
                            Console.WriteLine("Score: ");
                            Console.WriteLine("{0}: {1}", player1, gagnant_p1);
                            Console.WriteLine("{0}: {1}", player2, gagnant_p2);

                            Console.WriteLine("Perdant!");
                        }

                        Console.ReadLine();

                        conteurDeMatch++;

                    }

                    if (gagnant_p1 <= gagnant_p2)
                    {
                        Console.WriteLine("{0} Gagnant!", player2);
                        Console.WriteLine("Score: ");
                        Console.WriteLine("{0}: {1}", player1, gagnant_p1);
                        Console.WriteLine("{0}: {1}", player2, gagnant_p2);
                    }
                    else
                    {
                        Console.WriteLine("{0} Gagnant!", player1);
                        Console.WriteLine("Score: ");
                        Console.WriteLine("{0}: {1}", player1, gagnant_p1);
                        Console.WriteLine("{0}: {1}", player2, gagnant_p2);
                    }


                }
            
            }
        }
        static void Tableau()
        {
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", casse[1], casse[2], casse[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", casse[4], casse[5], casse[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", casse[7], casse[8], casse[9]);

            Console.WriteLine("     |     |      ");
        }
        static int VerifierGagnant()

        {
            //Horizontale

            if (casse[1] == casse[2] && casse[2] == casse[3])
            { return 1; }

            else if (casse[4] == casse[5] && casse[5] == casse[6])
            { return 1; }

            else if (casse[7] == casse[8] && casse[8] == casse[9])
            { return 1; }

            //Fin

            //Vertical

            else if (casse[1] == casse[4] && casse[4] == casse[7])
            { return 1; }

            else if (casse[2] == casse[5] && casse[5] == casse[8])
            { return 1; }

            else if (casse[3] == casse[6] && casse[6] == casse[9])
            { return 1; }

            //Fin

            //Diagonale

            else if (casse[1] == casse[5] && casse[5] == casse[9])
            { return 1; }

            else if (casse[3] == casse[5] && casse[5] == casse[7])
            { return 1; }

            //Fin

            //Pige

            else if (casse[1] != '1' && casse[2] != '2' && casse[3] != '3' && casse[4] != '4' && casse[5] != '5' && casse[6] != '6' && casse[7] != '7' && casse[8] != '8' && casse[9] != '9')

            { return -1; }

            //Fin

            else { return 0; }

        }
        static char[] casse = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static string player1, player2;
        static int player = 1;
        static int tour;
        static int point = 0;
        static int gagnant_p1, gagnant_p2, nbMatch;
        static int conteurDeMatch = 0;
        static void AfficherPendu(int nbErreur)
        {
            switch (nbErreur)
            {
                case 0:

                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 1:
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 2:
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("    /|  |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 3:
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("    /|7 |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 4:
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("    /|7 |     ");
                    Console.WriteLine("     -  |     ");
                    Console.WriteLine("    /   |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 5:
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("    /|7 |    ");
                    Console.WriteLine("     -  |     ");
                    Console.WriteLine("    / 7 |    ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;
            }
        }
            static void AfficherMenu()
            {
                Console.WriteLine("Veuillez choisir l'une des options suivantes : ");
                Console.WriteLine("1- Afficher le nombre de mots contenu dans la phrase ");
                Console.WriteLine("2- Afficher combien de fois chaque lettre apparaît ");
                Console.WriteLine("3- Afficher la lettre qui apparait le plus souvent");
                Console.WriteLine("4- Encoder la phrase en utilisant une clé de +2 et afficher le résultat");
                Console.WriteLine("7- Termine le programme");
            }
            static void nombreDeMot(string phrase)
            {
                string[] tabMot = phrase.Split(' ');
                int cpt = 0;
                for (var i = 0; i < tabMot.Length; i++)
                {
                    cpt += 1;
                }
                Console.WriteLine("Il y a " + cpt + "mots");

            }
            static void nombreFoisLettreApparait(string phrase)
            {
                int[] tabLettre = new int[26];

                for (int i = 0; i < phrase.Length; i++)
                {
                    int indice = (int)phrase[i] - 97;
                    if (indice >= 0 && indice < 26)
                        tabLettre[indice]++;
                }
                for (int i = 0; i < tabLettre.Length; i++)
                {
                    Console.WriteLine((char)(i + 97) + "-" + tabLettre[i]);
                }
            }
            static void lettreApparaitSouvent(string phrase)
            {
                int[] tabLettre = new int[26];
                int plusLettre = 0;
                int pos = 0;
                for (int i = 0; i < phrase.Length; i++)
                {
                    int indice = (int)phrase[i] - 97;
                    if (indice >= 0 && indice < 26)
                        tabLettre[indice]++;
                }
                for (int i = 0; i < phrase.Length; i++)
                {
                    if (tabLettre[i] > plusLettre)
                    {
                        plusLettre = tabLettre[i];
                        pos = i;
                    }
                }
                Console.WriteLine("La lettre qui apparait le plus souvent est le " + (char)(pos + 97) + "- " + tabLettre[pos]);
            }
            static void encoder(string phrase)
            {
                string nouveauPhrase = "";
                for (int i = 0; i < phrase.Length; i++)
                {
                    int valeurAscii = (int)phrase[i];
                    nouveauPhrase += Char.ConvertFromUtf32(valeurAscii + 2);
                }
                Console.WriteLine("Voici la phrase \n - " + nouveauPhrase);
            }      
    }
}
