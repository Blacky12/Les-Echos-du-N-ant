namespace lesEchoDuNeant.Service
{
    using lesEchoDuNeant.Models;
    public class CombatService
    {
        public Personnages Joueur { get; private set; }
        public Monstres Monstre { get; private set; }

        public void InitierCombat(Personnages joueur, Monstres monstre)
        {
            Joueur = joueur;
            Monstre = monstre;
        }

        public void ReinitialiserCombat()
        {
            Joueur = null;
            Monstre = null;
        }
    }
}
