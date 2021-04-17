using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsRepositories
{
    public class RebelsRepositories : SoldiersRepositories
    {

        public void Attack(Stormtroopers stormtroopers)
        {
            base.Attack(stormtroopers);
            Console.WriteLine($"Traitor");

        }

        public override string GetTypeTeam()
        {
            return "Rebel";
        }
    }
}
