using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Model.Entities
{
    public abstract class Soldiers
    {
        public int Matricule { get; set; }
        public float Health { get; set; }
        public float Damage { get; set; }
        public bool IsAlive { get; set; }

        public Random random = new Random();
        public int currentPurcent { get; set; }

        public Soldiers()
        {
            Matricule = random.Next(1, 10000);
            Health = random.Next(100, 200);
            Damage = random.Next(1000, 5000);
            currentPurcent = random.Next(1, 100);
            IsAlive = true;
        }

        public void Attack(Soldiers soldier)
        {
            soldier.Health -= Damage * currentPurcent / 100;

        }

        public abstract string GetTypeTeam();


    }
}
