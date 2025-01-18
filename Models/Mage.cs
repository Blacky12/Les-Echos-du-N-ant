namespace lesEchoDuNeant.Models
{
    public class Mage : Personnages
    {
        public Mage() : base("Mage", 3, 4, 10, 100, 0, 0)
        {

        }

        public string LancerSort()
        {
            return $"{Nom}: Lance une Boule de Feu ! Intelligence X2";
        }
    }
}