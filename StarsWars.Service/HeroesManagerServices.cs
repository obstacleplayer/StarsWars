using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarsWars.Service
{
    public class HeroesManagerServices
    {
        public static Soldiers GetHero(HashSet<Soldiers> Soldiers)
        {

            return Soldiers.OrderByDescending(item => (item.Damage + item.Health) * 10).FirstOrDefault();
        }
    }
}
