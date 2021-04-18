using StarsWars.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StarsWars.Service
{
    public class HeroesManagerServices
    {
        public static Soldiers GetHero(HashSet<Soldiers> soldiers)
        {

            return soldiers.OrderByDescending(item => (item.Damage + item.Health) * 10).First();
        }
    }
}
