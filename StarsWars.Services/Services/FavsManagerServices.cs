using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarsWars.Services.Services
{
    public class FavsManagerServices
    {
        public static string GetFav(HashSet<Soldiers> Rebels, HashSet<Soldiers> Stormtroopers)
        {
            return GetTotalDammage(Rebels) <= GetTotalDammage(Stormtroopers) ? Stormtroopers.FirstOrDefault().GetTypeTeam() : Rebels.FirstOrDefault().GetTypeTeam();

        }

        public static float GetTotalDammage(HashSet<Soldiers> Soldiers)
        {

            return Soldiers.Sum(item => item.Damage);
        }
    }
}
