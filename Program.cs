// See https://aka.ms/new-console-template for more information

using BlackJack;
using System.Text;


Console.OutputEncoding = Encoding.UTF8;
Carte carte = new Carte();
Jeu jeu = new Jeu();
Dictionary<Joueur, List<string[]>> dicJoueurs = new Dictionary<Joueur, List<string[]>>();

Joueur joueur1 = new Joueur() { Nom = "Albert", Mise = 30, Argent = 50 };
Joueur joueur2 = new Joueur() { Nom = "Robert", Mise = 20, Argent = 50 };
Joueur joueur3 = new Joueur() { Nom = "Momo", Mise =12, Argent = 20 };
Joueur croupier = new Joueur() { Nom = "Bill", Mise = 35, Argent = 50 };



Console.WriteLine("Nombre de carte dans le jeu : " + carte.GetNbreOfCard);

Console.WriteLine("-----------------------------------------------------------------------------------------");


var player1 = joueur1.getMainJoueur();
var player2 = joueur2.getMainJoueur();
var player3 = joueur3.getMainJoueur();
var donneur = croupier.getMainJoueur();


Joueur.AjoutJoueur(joueur1, player1);
Joueur.AjoutJoueur(joueur2, player2);
Joueur.AjoutJoueur(joueur3, player3);
Joueur.AjoutJoueur(croupier, donneur);


//dicJoueurs.Add(joueur1, player1);
//dicJoueurs.Add(joueur2, player2);
//dicJoueurs.Add(joueur3, player3);
//dicJoueurs.Add(croupier, donneur);


var isCroupier = croupier.Croupier = true;
croupier.Play(isCroupier);



Console.WriteLine("-----------------------------------------------------------");

Console.WriteLine("Nombre de Gagnant sur cette partie : " + Joueur.CompteurWinner);

Console.WriteLine("------------------------------------------------------------");

jeu.ShowNbreOfPlayers();



