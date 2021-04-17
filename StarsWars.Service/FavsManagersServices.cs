using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarsWars.Service
{
    public class FavsManagersServices
    {
        public static string GetFavs(HashSet<Soldiers> Rebels, HashSet<Soldiers> Stormtroopers)
        {
            return GetTotalDammage(Rebels) <= GetTotalDammage(Stormtroopers) ? Stormtroopers.FirstOrDefault().GetTypeTeam() : Rebels.FirstOrDefault().GetTypeTeam();
        }

        public static float GetTotalDammage(HashSet<Soldiers> Persons)
        {

            return Persons.Sum(item => item.Damage);
        }
    }
}
