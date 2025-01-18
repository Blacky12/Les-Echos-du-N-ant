namespace lesEchoDuNeant.Models
{
    public class Piege
    {
        public string Nom { get; set; }
        public int Degats { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Piege(string nom, int degats, int x, int y)
        {
            Nom = nom;
            Degats = degats;
            X = x;
            Y = y;
        }
    }
}