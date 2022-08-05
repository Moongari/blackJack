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
        private double _argent = 0;
        private double _mise = 0;
        private bool _isCroupier = false;
        private string _erreurMise = "la mise ne peut etre superieur au montant que possede le joueur";
        private string _isMiseNull = "la mise doit etre superieur a 0";
        private string _blackJackMessage = "Vous etes le vainqueur ! Congratulations ";
        private double _gain = 0;
        private int Max = 0;
        private static int _cptWinner = 0;

        private static Dictionary<Joueur, List<string[]>> dicJoueur = new Dictionary<Joueur, List<string[]>>();

        private static List<Joueur> lstJoueurs = new List<Joueur>();
        public string Nom { get { return _nom; } set { this._nom = value; } }
        public double Argent { get { return _argent; } set { this._argent = value; } }
        public double Mise { get { return _mise; } set { this._mise = value; } }
        public bool Croupier { get { return _isCroupier; } set { this._isCroupier = value;} }

        public double Gain { get { return _gain; } set { this._gain = value; } }
        public static int CompteurWinner { get { return _cptWinner; } set { _cptWinner = value; } }

        public static List<Joueur> Joueurs { get { return lstJoueurs;} }


        public string ErreurMise { get { return _erreurMise; } }
        public string ErreurMiseNull { get { return _isMiseNull; } }

        public Joueur() { }

        public Joueur(string nom, int argent, int mise)
        {
            this._nom = nom; this._argent = argent; this._mise = mise; 
        }

        public void Play([Optional] bool croupier)
        {

            if(dicJoueur.Count > 0)
            {
                if (croupier) { Nom = Nom + " Croupier"; }
                foreach (KeyValuePair<Joueur, List<string[]>> item in dicJoueur)
                {
                    Console.WriteLine($" " +
                        $"  Nom :{item.Key.Nom}  " +
                        $"  Mise :{item.Key.Mise} " +
                        $"  Argent :{item.Key.Argent} € " +
                        $"  Carte 1: {item.Value[0][0].ToString()} " +
                        $"  Valeur => {item.Value[0][1].ToString()} " +
                        $"  Carte 2: {item.Value[0][2].ToString()} " +
                        $"  Valeur =>{item.Value[1][3].ToString()} " +
                        $"  Total : {item.Key.GetPointCarteMainJoueur} points ");
                   
                }

                Console.WriteLine("");
                var joueurParticipant = dicJoueur.OrderByDescending(x => x.Key.GetPointCarteMainJoueur).ToList();


                Console.WriteLine("----------------------MEILLEUR JOUEUR DANS L'ordre des Points -------------------------");
                Console.WriteLine();
                Console.WriteLine();

                foreach (var j in joueurParticipant)
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
                            _cptWinner++;
                        }

                      
                    }

                    RealizeGain(j.Key);

                    Console.WriteLine($"{j.Key.Nom} => GAIN : {j.Key.Gain.ToString("0.##")} € Argent: {j.Key.Argent.ToString("0.##")} €  Points :{j.Key.GetPointCarteMainJoueur} points");

                    //WinnerPlayer(j.Key, j.Key.GetPointCarteMainJoueur);

                    lstJoueurs.Add(j.Key);
                }


               playerPointMoreThanDonneur();

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


        /// <summary>
        /// Definit qui est le meilleur joueur
        /// </summary>
        /// <param name="j"></param>
        /// <param name="points"></param>
        public void WinnerPlayer(Joueur j, int points,[Optional] bool isCroupier,[Optional] Joueur j2)
        {
            

           if( Max < points) { Max = points; }

           
           if(isCroupier != true)
            {
                if (Max >= points && j.GetPointCarteMainJoueur >= Max)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------    WINNER IS    -------------------------------------------------------");
                    Console.WriteLine($" Nom : {j.Nom}  Gain : {j.Gain.ToString("0.##")} €  Points : {Max} Argent : {j.Argent.ToString("0.##")}€");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine();
                    _cptWinner++;
                }
            }

           

            if (isCroupier)
            {
                try
                {
                    if (j.GetPointCarteMainJoueur == j2.GetPointCarteMainJoueur 
                        && j.GetPointCarteMainJoueur==Max
                        && j.GetPointCarteMainJoueur == Max)
                    {

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"------------------ {j.Nom} ----------------------------");
                        Console.WriteLine($" Gain : {j.Gain.ToString("0.##")} €  Points : {j.GetPointCarteMainJoueur} Argent : {j.Argent.ToString("0.##")}€");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"----------------- {j2.Nom} --------------------------");
                        Console.WriteLine($" Gain : {j2.Gain.ToString("0.##")} €  Points : {j2.GetPointCarteMainJoueur} Argent : {j2.Argent.ToString("0.##")}€");
                        Console.WriteLine("------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine();
                        _cptWinner++;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"{ex.Message}");
                }
              
            }

            if (j._isCroupier)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------    CROUPIER   -------------------------------------------------------");
                    Console.WriteLine($" Nom : {j.Nom}  Gain : {j.Gain.ToString("0.##")} €  Points : {Max} Argent : {j.Argent.ToString("0.##")}€");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine();
                    _cptWinner++;
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"{ex.Message}");
                }
               
            }

           
        }


       
        //Verifie si le joueur qui a le plus de points n'est pas le Donneur
        public void playerPointMoreThanDonneur()
        {
            var isNotCroupier = lstJoueurs.Where(j => j._isCroupier != true).ToList();
            var isCroupier = lstJoueurs.Where(j => j._isCroupier == true).FirstOrDefault();

            foreach (var j in isNotCroupier)
            {
                if(isCroupier != null)
                {
                    if (j.GetPointCarteMainJoueur > isCroupier.GetPointCarteMainJoueur)
                    {

                        //RealizeGain(j);
                        WinnerPlayer(j, j.GetPointCarteMainJoueur);
                    }
                 
                }

                if (isCroupier != null)
                {
                    if (j.GetPointCarteMainJoueur == isCroupier.GetPointCarteMainJoueur)
                    {

                        //RealizeGain(j);
                        WinnerPlayer(j, j.GetPointCarteMainJoueur,isCroupier._isCroupier,isCroupier);
                    }

                }
            }

           
            if(isCroupier != null)
            {

                int JoueurMaxPoints = (from j in isNotCroupier select j.GetPointCarteMainJoueur).Max();
              
                    if (isCroupier.GetPointCarteMainJoueur > JoueurMaxPoints)
                    {

                        //RealizeGain(j);
                        WinnerPlayer(isCroupier, isCroupier.GetPointCarteMainJoueur, isCroupier._isCroupier, isCroupier);
                    }
               
               

            }
        }


        //Mise a jour des mises des joueurs
        public void UpdateOfPlayerMise()
        {

        }


        //Calcul du gain
        public void RealizeGain(Joueur j)
        {
            if(j != null)
            {
                switch (j.GetPointCarteMainJoueur)
                {

                    case 21:
                        j.Gain = (1.5 * j.Mise);
                        j.Argent = j.Argent + j.Gain;
                        break;

                    case 20:
                        j.Gain = (0.8 * j.Mise);
                        j.Argent = j.Argent + j.Gain;
                        break;

                    case 15: 
                    case 16: 
                    case 17:
                    case 18:
                    case 19:
                        j.Gain = (0.5 * j.Mise);
                        j.Argent = j.Argent + j.Gain;
                        break;

                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        j.Gain = (0.2 * j.Mise);
                        j.Argent = j.Argent + j.Gain;
                        break;

                    default:
                        j.Gain = (0 * j.Mise);
                        j.Argent = j.Argent + j.Gain;
                        break;
                }
            }
        }

      
    }
}
