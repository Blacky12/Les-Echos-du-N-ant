using lesEchoDuNeant.Models;

namespace lesEchoDuNeant.Map
{
    // Brique de base de la carte. Chaque case est représenté par l'objet cellule
    public class Cellule
    {
        public int X{ get; set; }
        public int Y{ get; set; }
        public string TypeTerrain{ get; set; }
        public string Image{get; set; }
        public bool HasPlayer{ get; set; }
        public Personnages Personnage { get; set; }
        public string PersonnageImage{get; set; }

        // monstre
        public bool HasMonstre{ get; set; }
        public string MonstreImage{get; set; }
        public Monstres Monstres{get; set; }
        

        public Cellule(int x, int y, string typeTerrain,string image)
        {
            X = x;
            Y = y;
            TypeTerrain = typeTerrain;
            Image = image;
            HasPlayer = false;
            HasMonstre = false;
        }   
    }
}