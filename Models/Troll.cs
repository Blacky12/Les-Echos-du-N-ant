namespace lesEchoDuNeant.Models
{
    public class Troll : Monstres
    {
        public Troll(): base("Troll", 10, 2, 50,"/images/troll.png")
        {

        }

        public string Ecraser()
        {
            return $"{Nom} écrase tout sur son passage";
        }
    }
}