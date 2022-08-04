# blackJack

But du jeu :
Le Blackjack est un jeu de cartes dans lequel le joueur tente de battre le casino(represente par le croupier).

il faut pour cela :
en obtenant une main d’une valeur egale ou inferieure a 21 et superieure a la main du croupier.
donc  obtenir une main <= a 21 et > a celle du croupier.

on joue contre le casino.

il y a le Donneur le croupier et de 1 a 7 joueurs soit 8 personnes au totale.

52 cartes 
Valeur cartes : 
As : 11 ou 1
DAME = 10
ROI = 10
Valet = 10
X = 10
les autres cartes ont la valeur de leur poids.
si le joueur possede 1 AS et une carte de 10 => blackJack il recupere 3/2 de sa mise 

si le joueur et le croupier font egalité = 21 alors le joueur recupere sa mise mais pas de gain.

chaque joueur fait sa mise et recoit 2 cartes : une visible et une caché.
le joueur peut doubler sa mise apres avoir recu ces 2 cartes mais ne peut recevoir qu'une seule carte supplémentaire (doubler)
le joueur peut demande une ou plusieurs cartes jusqu'a ce qu'il souhaite arreter ou bien qu'il 'saute' cad qu'il depasse 21.
si la main du joueur depasse 21 on dit qu'il a sauté et perd sa mise , ces cartes et sa mise sont collectés par le croupier.
le blackJack sera toujours vainqueur face a une main de 21. (ex : 10 pique + 4 coeur + 7 pique)

Action Donneur :
quand tous les joueurs ont joué, et si il reste des joueurs qui n'ont pas sauté .
le donneur decouvre sa carte caché et se ditribue des cartes si besoin.et ce jusqu'a ce que sa main ai atteint 17 ou plus.
Si le donneur 'saute'  il paie les joueurs restant , sinon il paie le joueurs qui a une main plus forte que lui.

1) Definition 
nom : le types de noms des joueurs
cartes : paire d'un nombre (1 ...10) ou figure (V,R,D) et couleur
main : liste de cartes qui decrive la main d'un joueur ou du croupier ou le jeu
argent : representation de l'argent ex (20 euros)
croupier : description de sa main
joueur : nom, sa main,l'argent dans sa poche et sa mise sur la table
Table : croupier et la liste des joueurs.
