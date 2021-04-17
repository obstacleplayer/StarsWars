using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Model.Entities
{
    public class Rebels : Soldiers
    {
        public Rebels() : base()
        {

        }

        public override string GetTypeTeam()
        {
            return "Rebels";
        }
    }
}
