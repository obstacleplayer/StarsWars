using System;

namespace StarsWars.Model.Entities
{
    public abstract class Soldiers
    {
        public int Matricule { get; set; }
        public float Health { get; set; }
        public float Damage { get; set; }
        public bool IsAlive { get; set; }

        public Random Random = new Random();
        public int CurrentPurcent { get; set; }

        public Soldiers()
        {
            Matricule = Random.Next(1, 10000);
            Health = Random.Next(100, 200);
            Damage = Random.Next(1000, 5000);
            CurrentPurcent = Random.Next(1, 100);
            IsAlive = true;
        }

        public void Attack(Soldiers soldier)
        {
            soldier.Health -= Damage * CurrentPurcent / 100;

        }

        public abstract string GetTypeTeam();

    }
}