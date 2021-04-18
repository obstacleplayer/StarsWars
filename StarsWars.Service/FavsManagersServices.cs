using System.Collections.Generic;
using System.Linq;
using StarWars.Model.Entities;

namespace StarsWars.Service
{
    public class FavsManagersServices
    {
        public static string GetFavs(HashSet<Soldiers> rebels, HashSet<Soldiers> stormtroopers)
        {
            return GetTotalDamage(rebels) <= GetTotalDamage(stormtroopers)
                ? stormtroopers.First().GetTypeTeam()
                : rebels.First().GetTypeTeam();
        }

        public static float GetTotalDamage(HashSet<Soldiers> Persons)
        {
            return Persons.Sum(item => item.Damage);
        }
    }
}