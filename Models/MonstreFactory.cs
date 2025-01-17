using System;
using lesEchoDuNeant.Models;

namespace lesEchoDuNeant.Models
{
    public static class MonstreFactory
    {
        public static Monstres CreerMonstreAleatoire()
        {
            var random = new Random();
            int typeMonstre = random.Next(0, 2); // 0 pour Gobelin, 1 pour Troll

            if (typeMonstre == 0)
                return new Gobelin();
            else
                return new Troll();
        }
    }
}
