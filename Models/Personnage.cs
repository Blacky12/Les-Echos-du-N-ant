using System;
using System.Collections.Generic;
using System.Linq;

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
        public static int X { get; set; }
        public static int Y { get; set; }
        public List<Competence> Competences { get; set; }

        public Personnages(string nom, int force, int agilite, int intelligence, int pointsDeVie, int x, int y)
        {
            Random Random = new Random();
            Nom = nom;
            Force = force;
            Agilite = agilite;
            Intelligence = intelligence;
            PointsDeVie = pointsDeVie;
            Id = Random.Next(1, 10000);
            X = x;
            Y = y;
            Competences = new List<Competence>();
        }
        
        public void AjouterCompetence(Competence competence)
        {
            Competences.Add(competence);
        }

        public string UtiliserCompetence(string nomCompetence)
        {
            var competence = Competences.FirstOrDefault(c => c.Nom == nomCompetence);
            if (competence != null)
            {
                return competence.Utiliser();
            }

            return "Compétence non trouvée";
        }

        public virtual string AfficherStats()
        {
            return $"Nom: {Nom} \n" +
                   $"Force: {Force} \n" +
                   $"Agilité: {Agilite} \n" +
                   $"Intelligence: {Intelligence} \n" +
                   $"Points de Vie: {PointsDeVie}" +
                   $"Position: {X}, {Y}";
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
            return
                $"{Nom} tente d'esquivé l'attaque"; // A metre en point (pas une comptétence mais une chance d'esqiver l'attaque)
        }

        public void Interagir(Map.Map carte)
        {
            // Vérifie s'il y a un piège à la position actuelle
            var piege = carte.Pieges.FirstOrDefault(p => p.X == X && p.Y == Y);
            if (piege != null)
            {
                // Subit les dégâts du piège
                PointsDeVie -= piege.Degats;
                if (PointsDeVie < 0)
                {
                    PointsDeVie = 0;
                }

                carte.Pieges.Remove(piege);
            }

            // Vérifie s'il y a un coffre à la position actuelle
            var coffre = carte.Coffre.FirstOrDefault(c => c.X == X && c.Y == Y);
            if (coffre != null)
            {
                // Récupère les bonus du coffre
                Force += coffre.BonusForce;
                PointsDeVie += coffre.BonusVie;
                carte.Coffre.Remove(coffre);
            }
        }
    }
}    