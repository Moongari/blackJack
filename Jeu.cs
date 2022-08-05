using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Jeu : Joueur
    {




        public Jeu() { }



        public void ShowNbreOfPlayers()
        {
            Console.WriteLine("--------------------------------- GAME -----------------------------------------------");
            var NbreOfPLayers = Joueur.Joueurs.Count();
            Console.WriteLine($"\t\t  il y a {NbreOfPLayers -1} participants au jeu du Black Jack"           );

            Console.WriteLine("--------------------------------------------------------------------------------------");
            
        }



    }
}
