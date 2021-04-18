using System.Collections.Generic;
using System.Linq;
using StarsWars.Model.Entities;

namespace StarsWars.Service
{
    public class FavsManagersServices
    {
        public static string GetFavs(HashSet<Soldiers> rebels, HashSet<Soldiers> stormtroopers) => GetTotalDamage(rebels) <= GetTotalDamage(stormtroopers) ? stormtroopers.First().GetTypeTeam() : rebels.First().GetTypeTeam();
        


        public static float GetTotalDamage(HashSet<Soldiers> persons) => persons.Sum(item => item.Damage);
        
    }
}