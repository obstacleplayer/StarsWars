using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
