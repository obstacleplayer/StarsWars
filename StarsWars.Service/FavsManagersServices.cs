using System.Collections.Generic;
using System.Linq;
using StarsWars.Model.Entities;

namespace StarsWars.Service
{
    public class FavsManagersServices
    {
        public static string GetFavs(List<Soldier> rebels, List<Soldier> stormtroopers) =>
            GetTotalDamage(rebels) <= GetTotalDamage(stormtroopers)
                ? stormtroopers.First().Role.ToString()
                : rebels.First().Role.ToString();
       
        public static float GetTotalDamage(List<Soldier> persons) => persons.Sum(item => (item.Damage + item.Health));
        
    }
}