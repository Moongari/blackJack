using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Joueur :MainJoueur , IMain
    {
        private string _nom = string.Empty;
        private int _argent = 0;
        private int _mise = 0;
        private bool _isCroupier = false;
        private string _erreurMise = "la mise ne peut etre superieur au montant que possede le joueur";
        private string _isMiseNull = "la mise doit etre superieur a 0";
        private string _blackJackMessage = "Vous etes le vainqueur ! Congratulations ";
        private int _gain = 0;
        private int Max = 0;

        private static Dictionary<Joueur, List<string[]>> dicJoueur = new Dictionary<Joueur, List<string[]>>();
        private static List<Joueur> lstJoueurs = new List<Joueur>();
        public string Nom { get { return _nom; } set { this._nom = value; } }
        public int Argent { get { return _argent; } set { this._argent = value; } }
        public int Mise { get { return _mise; } set { this._mise = value; } }
        public bool Croupier { get { return _isCroupier; } set { this._isCroupier = value;} }

        public int Gain { get { return _gain; } set { this._gain = value; } }


        public string ErreurMise { get { return _erreurMise; } }
        public string ErreurMiseNull { get { return _isMiseNull; } }

        public Joueur() { }

        public Joueur(string nom, int argent, int mise)
        {
            this._nom = nom; this._argent = argent; this._mise = mise; 
        }

        public void GiveJoueursMain([Optional] bool croupier)
        {

            if(dicJoueur.Count > 0)
            {
                if (croupier) { Nom = Nom + " Croupier"; }
                foreach (KeyValuePair<Joueur, List<string[]>> item in dicJoueur)
                {
                    Console.WriteLine($" " +
                        $"  Nom :{item.Key.Nom}  " +
                        $"  Mise :{item.Key.Mise} " +
                        $"  Argent :{item.Key.Argent} " +
                        $"  Carte 1: {item.Value[0][0].ToString()} " +
                        $"  Valeur => {item.Value[0][1].ToString()} " +
                        //$"  Carte 2: {item.Value[0][2].ToString()} " +
                        //$"  Valeur =>{item.Value[1][3].ToString()} " +
                        $"  Total : {item.Key.GetPointCarteMainJoueur} ");
                   
                }

                Console.WriteLine("");
                var jouerGagnant = dicJoueur.OrderByDescending(x => x.Key.GetPointCarteMainJoueur).ToList();


                Console.WriteLine("----------------------MEILLEUR JOUEUR DANS L'ordre des Points -------------------------");
                Console.WriteLine();
                Console.WriteLine();

                foreach (var j in jouerGagnant)
                {
                    if (MainJoueur.IsBlackJack)
                    {
                       if(j.Key.GetPointCarteMainJoueur == 21)
                        {
                            MainJoueur.Joueur = j.Key;
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------BLACK JACK-------------------------");
                            Console.WriteLine($"{ _blackJackMessage}  =>  {MainJoueur.Joueur.Nom} ");
                            Console.WriteLine("---------------------------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                      
                    }
                    Console.WriteLine($"{j.Key.Nom} => {j.Key.GetPointCarteMainJoueur}");
                    WinnerPlayer(j.Key, j.Key.GetPointCarteMainJoueur);

                }




            }
            else
            {
                Console.WriteLine("la liste ne contient aucun joueur impossible de lancer la partie");
            }


        }


        public static void AjoutJoueur(Joueur j, List<string[]> main)
        {
            dicJoueur.Add(j, main);
        }

        public static void SupprimerToutLesJoueurs()
        {
            dicJoueur.Clear();
        }

        public bool isMiseSuperieurArgent()
        {
            if (Mise > Argent)
            {
                return true;
            }
            return false;
        }


        public bool isMiseIsNotNull()
        {
            if(Mise < 0)
            {
                return true;
            }
            return false;
        }



        public void WinnerPlayer(Joueur j, int points)
        {
         

           if( Max < points) { Max = points; }

            if (Max >= points && j.GetPointCarteMainJoueur >= Max) 
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("----------- WINNER IS ------------------------");
                Console.WriteLine($" Nom : {j.Nom}  Gain : {j.Gain}  Points : {Max}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
            }

           
        }
       
    }
}
