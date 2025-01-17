namespace lesEchoDuNeant.Models
{
    public class Gobelin : Monstres
    {
        public Gobelin(): base("Gobelin", 5, 3, 30,"/images/gobelin.png")
        {

        }

        public string CriDeGuerre()
        {
            return $"{Nom} : Cri effrayant Oo";
        }
    }
}