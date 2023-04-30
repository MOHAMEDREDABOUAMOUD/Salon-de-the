# Salon-de-thé
## Réaliser une application de Gestion d’un Salon de Thé. On suppose que le salon sert uniquement des boissons.
## La base de données contiendra les tables suivantes, les clés primaires sont soulignées et les clé étrangères sont préfixées par # :
* Table Serveurs : Id Serveur, nom et prénom
* Table Boissons : Id Boisson, désignation, prix, qtéStock
* Table Commandes : Id Commande, dateCom, heureCom, #IdServeur
* Table BoissonsCommandées : #Id Boisson, #Id Commande, quantité commandée
## On veut offrir les fonctionnalités suivantes :
* Gestion des serveurs,
* Gestion des boissons,
* Gestion des commandes,
* Lister pour chaque serveur le bilan des commandes de la journée
