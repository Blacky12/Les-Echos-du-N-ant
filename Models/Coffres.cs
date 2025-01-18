namespace lesEchoDuNeant.Models
{
    public class Coffre
    {
        public string Nom { get; set; }
        public int BonusForce { get; set; }
        public int BonusVie { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Coffre(string nom, int bonusForce, int bonusVie, int x, int y)
        {
            Nom = nom;
            BonusForce = bonusForce;
            BonusVie = bonusVie;
            X = x;
            Y = y;
        }
    }
}