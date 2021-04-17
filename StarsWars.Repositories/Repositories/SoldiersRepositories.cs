using StarsWars.Repositories.InterfaceRepositories;
using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarsWars.Repositories.Repositories
{
    public abstract class  SoldiersRepositories : ISoldiersRepositories
    {
        
        public void Attack(Soldiers soldiers)
        {
            soldiers.Health -= soldiers.Damage * soldiers.currentPurcent / 100;
        }

        public abstract string GetTypeTeam();
        
            
        
    }
}
