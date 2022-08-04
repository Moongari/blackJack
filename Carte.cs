using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public enum ColorCarte
    {
        Rouge,
        Noir
    }

    public enum FormeCarte
    {
        Pique,
        Carreaux,
        Trefle,
        Coeur
    }

    public class Carte
    {
        private Dictionary<string, int> carteMap  = new Dictionary<string, int>();
        private readonly int _NbrDeCarte = 52;
        private bool _isVisible = false;
        private List<string[]> mainDuJoueur = new List<string[]>();
        private const int nbrOfCardByPlayer = 2;
        private int _valeurPoint = 0;
        private string valeurCard = string.Empty;
        private int pointCard = 0;
        private string[] mainArray = new string[4];
        public  List<string> whatIsCardInList = new List<string>();
        private static bool _isBlackJack = false;



        public int GetNbreOfCard { get { return _NbrDeCarte; } }

        public string? GetColorCarte { get; set; } = string.Empty;
        public string? GetFormCarte { get; set; } = string.Empty;
        public string? GetCarteCache { get; set; } = string.Empty;
        public static bool IsBlackJack { get { return _isBlackJack; } }    

        


        public int GetPointCarteMainJoueur { get { return _valeurPoint; } set { } }

        public bool CacheCarte { get { return _isVisible; } set => _isVisible = value; }
        
        public Carte() => initialCartePointDic();

        private void initialCartePointDic()
        {
            carteMap.Add("As", 1);
            carteMap.Add("2", 2);
            carteMap.Add("3", 3);
            carteMap.Add("4", 4);
            carteMap.Add("5", 5);
            carteMap.Add("6", 6);
            carteMap.Add("7", 7);
            carteMap.Add("8", 8);
            carteMap.Add("9", 9);
            carteMap.Add("X", 10);
            carteMap.Add("Valet", 10);
            carteMap.Add("Dame", 10);
            carteMap.Add("Roi", 10);
        }


        //Melange les cartes afin de pouvoir les distribuer aux joueurs.
        public List<string[]> MainDuJoueur()
        {

            Random rnd = new Random();
          


            for (int i = 0; i < nbrOfCardByPlayer; i++)
            {
                ChoiceColorCarte();
                ChoiceTypeCarte();
                var choixCarte = rnd.Next(0, 13);
                

                for (int j = 0; j < carteMap.Count; j++)
                {
                    if (choixCarte == j)
                    {
                        valeurCard = carteMap.ElementAt(j).Key;
                        pointCard = carteMap.ElementAt(j).Value;

                        whatIsCardInList.Add(valeurCard);

                        if( i < 1)
                        {
                            mainArray[0] = valeurCard;
                            mainArray[1] = pointCard.ToString();
                        }
                        else
                        {
                            mainArray[2] = valeurCard;
                            mainArray[3] = pointCard.ToString();
                        }
                        

                        

                        _valeurPoint += pointCard;
                        mainDuJoueur.Add(mainArray);
                        break;
                    }




                }

              
            }

            //verifie si la list contient un As et une autre carte de valeur 10
            cardAsWithCard_10("As");

            return mainDuJoueur;

        }


        //definit une couleur aleatoire de carte
        private void ChoiceColorCarte()
        {
            Random rndColor = new Random();
            var typeColor = rndColor.Next(0, 2);
            string? resultColor = String.Empty;
      
            foreach (int i in Enum.GetValues(typeof(ColorCarte)))
            {
                if (i == typeColor)
                {
                    GetColorCarte = Enum.GetName(typeof(ColorCarte), i);
                    break;
                }
                    
               

                }
          
        }

        // definit une forme aleatoire de la forme de la carte
        private void ChoiceTypeCarte()
        {
            Random rndType = new Random();
            var typeFormCarte = rndType.Next(0, 3);
            string? resultFormCarte= String.Empty;

            foreach (int i in Enum.GetValues(typeof(FormeCarte)))
            {
                if (i == typeFormCarte)
                {
                    GetFormCarte = Enum.GetName(typeof(FormeCarte), i);
                    break;
                }

            }
          
        }



        public  void cardAsWithCard_10(string CardAs)
        {
               string As_Value = "11";
          
            if (whatIsCardInList.Contains(CardAs))
            {
                if( whatIsCardInList.Contains("X") || 
                    whatIsCardInList.Contains("Valet") ||
                    whatIsCardInList.Contains("Dame") ||
                    whatIsCardInList.Contains("Roi"))
                {
                    _valeurPoint = 0;
                    for (int i = 0; i < mainArray.Length; i++)
                    {
                        if (mainArray[i] == CardAs)
                        {
                            mainArray[i + 1] = As_Value;

                        }

                    }
                    _valeurPoint = Convert.ToInt32(mainArray[1]) + Convert.ToInt32(mainArray[3]);
                    _isBlackJack = true;
                }

              
                
            }

         

        }
        
    }
}
