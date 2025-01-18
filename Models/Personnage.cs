using System;

namespace lesEchoDuNeant.Models
{
    public abstract class Personnages
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Force { get; set; }
        public int Agilite { get; set; }
        public int Intelligence { get; set; }
        public int PointsDeVie { get; set; }

        public Personnages(string nom, int force, int agilite, int intelligence, int pointsDeVie)
        {
            Random Random = new Random();
            Nom = nom;
            Force = force;
            Agilite = agilite;
            Intelligence = intelligence;
            PointsDeVie = pointsDeVie;
            Id = Random.Next(1, 10000);
        }

        public virtual string AfficherStats()
        {
            return $"Nom: {Nom} \n" +
                   $"Force: {Force} \n" +
                   $"Agilité: {Agilite} \n" +
                   $"Intelligence: {Intelligence} \n" +
                   $"Points de Vie: {PointsDeVie}";
        }

       public int Attaque()
       {
            return Force;
       }

        public virtual string Defendre()
        {
            return $"{Nom} se met en position défensive";
        }

        public virtual string Esquiver()
        {
            return $"{Nom} tente d'esquivé l'attaque"; // A metre en point (pas une comptétence mais une chance d'esqiver l'attaque)
        }
    }
}