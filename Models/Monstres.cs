using Microsoft.Identity.Client;

namespace lesEchoDuNeant.Models
{
    public abstract class Monstres
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Force { get; set; }
        public int Agilite { get; set; }
        public int PointsDeVie { get; set; }
        public string ImagePath { get; set; }

        private static int _currentId = 1; // Gestion des IDs uniques

        public Monstres(string nom, int force,int agilite,int pointsDeVie,string imagePath)
        {
            Id = _currentId++;
            Nom = nom;
            Force = force;
            Agilite = agilite;
            PointsDeVie = pointsDeVie;
            ImagePath = imagePath;
        }

        public string AfficherStats()
        {
            return $"{Nom} : Force = {Force} : Agilité = {Agilite} : Point de Vie = {PointsDeVie}";
        }

        public int Attaque()
        {
            return Force;
        }
    }
}