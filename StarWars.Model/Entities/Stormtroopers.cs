using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Model.Entities
{
    public class Stormtroopers : Soldiers
    {
        public Stormtroopers() : base()
        {

        }

        public override string GetTypeTeam()
        {
            return "Stormtroopers";

        }
    }
}
