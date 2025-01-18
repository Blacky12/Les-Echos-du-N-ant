using System;
using lesEchoDuNeant.Models;

namespace lesEchoDuNeant.Combat
{
    public class CombatManager
    {
        public Personnages Joueur { get; private set; }
        public Monstres Monstre { get; private set; }
        public bool CombatTerminer { get; private set; }
        public string Resultat { get; private set; }

        // Constructeur
        public CombatManager(Personnages joueur, Monstres monstre)
        {
            Joueur = joueur;
            Monstre = monstre;
            CombatTerminer = false;
            Resultat = string.Empty;
        }

        public string AttaqueJoueur()
        {
            if (CombatTerminer) return "Le combat est terminé";

            int degats = Joueur.Attaque();
            Monstre.PointsDeVie -= degats;

            if (Monstre.PointsDeVie <= 0)
            {
                Monstre.PointsDeVie = 0;
                CombatTerminer = true;
                Resultat = $"Victoire du {Joueur.Nom}";
            }

            return $"{Joueur.Nom} attaque {Monstre.Nom} et inflige {degats} dégâts.";
        }

        public string AttaqueMonstre()
        {
            if (CombatTerminer) return "Le Combat est terminé";

            int degats = Monstre.Attaque();
            Joueur.PointsDeVie -= degats;

            if (Joueur.PointsDeVie <= 0)
            {
                Joueur.PointsDeVie = 0;
                CombatTerminer = true;
                Resultat = $"Game Over";
            }

            return $"{Monstre.Nom} attaque votre {Joueur.Nom} et inflige {degats} dégâts.";
        }

        public string ExecuterTour(bool joueurAttaqueEnPremier)
        {
            if (CombatTerminer) return "Le combat est terminé";

            string message = "";

            if (joueurAttaqueEnPremier)
            {
                message += AttaqueJoueur();
                if (!CombatTerminer) message += "\n" + AttaqueMonstre();
            }
            else
            {
                message += AttaqueMonstre();
                if (!CombatTerminer) message += "\n" + AttaqueJoueur();
            }

            return message;
        }

        public string EtatCombat()
        {
            return $"{Joueur.Nom} - PV: {Joueur.PointsDeVie}\nMonstre: {Monstre.Nom} - PV : {Monstre.PointsDeVie}";
        }
    }
}
