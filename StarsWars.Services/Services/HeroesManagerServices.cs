using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarsWars.Services.Services
{
    public class HeroesManagerServices
    {
        public static Soldiers GetHero(HashSet<Soldiers> Soldier)
        {

            return Soldier.OrderByDescending(item => (item.Damage + item.Health) * 10).FirstOrDefault();
        }
    }
}
