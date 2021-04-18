namespace StarsWars.Model.Entities
{
    public abstract class Soldier
    {
        public int Matricule { get; set; }
        public float Health { get; set; }
        public float Damage { get; set; }
        public bool IsAlive { get; set; }
        public int CurrentPurcent { get; set; }
        public Role Role { get; set; }
        public bool IsHero { get; set; }
        public Soldier(int matricule, float health, float damage, int currentPurcent, Role role)
        {
            Matricule = matricule;
            Health = health;
            Damage = damage;
            CurrentPurcent = currentPurcent;
            IsAlive = true;
            Role = role;
        }

        public void Attack(Soldier soldier) => soldier.Health -= Damage * CurrentPurcent / 100;
    }
}