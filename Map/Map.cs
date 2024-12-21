using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic;

namespace lesEchoDuNeant.Map
{
    //Structure globale de la carte qui contient toute les cellules dans une liste
    public class Map
    {
        public int Hauteur { get; }
        public int Largeur { get; }
        public List<Cellule> Cellules { get; }
        public Map(int hauteur, int largeur)
        {
            Hauteur = hauteur;
            Largeur = largeur;
            Cellules = new List<Cellule>();

            // Génération aléatoire
            var typesTerrain = new[]
            {
                new {Type = "Herbe", Image = "/images/herbe.webp"},
                new {Type = "Eau", Image = "/images/eau.webp"},
                new {Type = "Montagne", Image = "/images/montagne.webp"}
            };

            var random = new Random();
            for (int y = 0; y < Hauteur; y++)
            {
                for (int x = 0; x < Largeur; x++)
                {
                    var terrain = typesTerrain[random.Next(typesTerrain.Length)];
                    Cellules.Add(new Cellule(x, y, terrain.Type, terrain.Image));
                }
            }
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Largeur && y >= 0 && y < Hauteur;
        }

        public Cellule GetCellule(int x, int y)
        {
            return Cellules.FirstOrDefault(c=> c.X == x && c.Y == y);
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

                // Recherche d'une cellule correspondante
                cellule = Cellules.FirstOrDefault(c => c.X == posX && c.Y == posY && c.TypeTerrain == "Herbe");
            } while (cellule == null);

            // Mise à jour de la cellule pour indiquer la présence du joueur
            cellule.HasPlayer = true;
            cellule.PersonnageImage = $"/images/{personnage.ToLower()}.png";

            // Retourner les coordonnées
            return (posX, posY);
        }

    }
}