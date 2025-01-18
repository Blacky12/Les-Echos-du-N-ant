using lesEchoDuNeant.Models;

namespace lesEchoDuNeant.Service
{
    public class ChoixPersoService
    {
        public Personnages PersonnageChoisis { get; private set; } // Stockez le personnage en tant qu'objet
        public (int x, int y) PositionPersonnage { get; private set; }

        public void SaveChoice(Personnages personnage)
        {
            PersonnageChoisis = personnage;
        }

        public bool PersonnageEstChoisis()
        {
            return PersonnageChoisis != null;
        }

        public void SetInitialPosition(int x, int y)
        {
            PositionPersonnage = (x, y);
        }
    }
}
