using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class MainJoueur : Carte
    {

        public Dictionary<Joueur, List<string[]>> GetMainDujoueurs { get; set; }
        public static Joueur Joueur { get; set; }



        public MainJoueur () 
        {
            
        }


        public List<string[]> getMainJoueur()
        {
            return this.MainDuJoueur();
        }



        public static bool isBlackJack()
        {
            return IsBlackJack;
        }

    }
}
