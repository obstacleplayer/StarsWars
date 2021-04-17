using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsRepositories
{
    public class StormtroopersRepositories : SoldiersRepositories
    {
        public void Attack(Rebels Rebel)
        {
            base.Attack(Rebel);
            Console.WriteLine($" Pour la princesses Organa !");

        }
        public override string GetTypeTeam()
        {
            return "Stormtrooper";
        }
    }
}
