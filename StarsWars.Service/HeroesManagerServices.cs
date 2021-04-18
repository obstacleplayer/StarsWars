using StarsWars.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StarsWars.Service
{
    public class HeroesManagerServices
    {
        public static Soldier GetHero(List<Soldier> soldiers) => soldiers.OrderByDescending(item => (item.Damage + item.Health) * 10).First();
        
    }
}
