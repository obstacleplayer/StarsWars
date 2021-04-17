using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsRepositories
{
    public abstract class SoldiersRepositories
    {
        public abstract string GetTypeTeam();

        public void Attack(Soldiers soldier)
        {
            soldier.Health -= soldier.Damage * soldier.currentPurcent / 100;

        }
    }
}
