using System;
using System.Collections.Generic;
using lesEchoDuNeant.Models;

namespace lesEchoDuNeant.Map
{
    // Structure globale de la carte qui contient toutes les cellules dans une liste
    public class Map
    {
        public int Hauteur { get; private set; }
        public int Largeur { get; private set; }
        public Cellule[,] Cellules { get; private set; }
        public List<Piege> Pieges { get; private set; }
        public List<Coffre> Coffre { get; private set; }

        public Map(int hauteur, int largeur)
        {
            Hauteur = hauteur;
            Largeur = largeur;
            Cellules = new Cellule[Largeur, Hauteur];
            Pieges = new List<Piege>();
            Coffre = new List<Coffre>();

            // Types de terrain
            var typesTerrain = new[]
            {
                new { Type = "Herbe", Image = "/images/herbe.webp" },
                new { Type = "Eau", Image = "/images/eau.webp" },
                new { Type = "Montagne", Image = "/images/montagne.webp" }
            };

            var random = new Random();

            // Génération de la carte
            for (int y = 0; y < Hauteur; y++)
            {
                for (int x = 0; x < Largeur; x++)
                {
                    var terrain = typesTerrain[random.Next(typesTerrain.Length)];
                    Cellules[x, y] = new Cellule(x, y, terrain.Type, terrain.Image);
                }
            }
            
            // Génération aléatoire des pièges et coffres
            GenererPieges(random);
            GenererCoffres(random);
        }
        
        private void GenererPieges(Random random)
        {
            for (int i = 0; i < 5; i++) // Ajoute 5 pièges aléatoires
            {
                int x = random.Next(Largeur);
                int y = random.Next(Hauteur);
                Pieges.Add(new Piege("Piège à loups", 20, x, y));
            }
        }

        private void GenererCoffres(Random random)
        {
            for (int i = 0; i < 5; i++) // Ajoute 5 coffres aléatoires
            {
                int x = random.Next(Largeur);
                int y = random.Next(Hauteur);
                Coffre.Add(new Coffre("Coffre en bois", 5, 20, x, y));
            }
        }

        public void InitialiserCarte(string personnage, int nombreMonstres)
        {
            // Placer le personnage
            var (posX, posY) = PlacerPersonnage(personnage);

            // Placer les monstres après avoir placé le personnage
            PlacerMonstresAleatoires(nombreMonstres);

            Console.WriteLine($"Personnage placé en ({posX}, {posY}).");
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Largeur && y >= 0 && y < Hauteur;
        }

        public Cellule GetCellule(int x, int y)
        {
            if (x >= 0 && x < Largeur && y >= 0 && y < Hauteur)
            {
                return Cellules[x, y];
            }
            return null;
        }

        public Personnages GetPersonnage()
        {
            // Parcourir les cellules pour trouver celle contenant un joueur
            foreach (var cellule in Cellules)
            {
                if (cellule.HasPlayer)
                {
                    return cellule.Personnage; // Retourne le personnage de la cellule
                }
            }

            // Retourne null si aucun joueur n'est trouvé
            return null;
        }


        public (int posX, int posY) PlacerPersonnage(string personnage)
        {
            var random = new Random();
            Cellule cellule = null;
            int posX = 0, posY = 0;

            do
            {
                // Génération de coordonnées aléatoires
                posX = random.Next(0, Largeur);
                posY = random.Next(0, Hauteur);

                cellule = GetCellule(posX, posY);

                // Recherche d'une cellule correspondante
            } while (cellule == null || cellule.TypeTerrain != "Herbe" || cellule.HasPlayer);

            // Mise à jour de la cellule pour indiquer la présence du joueur
            cellule.HasPlayer = true;
            cellule.PersonnageImage = $"/images/{personnage.ToLower()}.png";
            Console.WriteLine($"Position initiale du personnage : ({posX}, {posY})");

            // Retourner les coordonnées
            return (posX, posY);
        }

        public void PlacerMonstresAleatoires(int nombreMonstres)
        {
            int monstresPlaces = 0;
            var random = new Random();
            int essais = 0;

            while (monstresPlaces < nombreMonstres && essais < 100)
            {
                int x = random.Next(0, Largeur);
                int y = random.Next(0, Hauteur);

                var cellule = GetCellule(x, y);

                if (cellule != null && cellule.TypeTerrain == "Herbe" && !cellule.HasMonstre && !cellule.HasPlayer)
                {
                    var monstre = MonstreFactory.CreerMonstreAleatoire();
                    cellule.Monstres = monstre;
                    cellule.HasMonstre = true;
                    monstresPlaces++;
                }

                essais++;

                if (essais >= 100)
                {
                    Console.WriteLine($"Nombre maximal d'essais atteint. Seulement {monstresPlaces} monstres placés sur {nombreMonstres}.");
                }
            }
        }
    }
}
