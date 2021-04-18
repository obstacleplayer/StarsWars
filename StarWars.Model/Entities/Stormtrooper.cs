namespace StarsWars.Model.Entities
{
    public class Stormtrooper : Soldier
    {
        public Stormtrooper(int matricule, float health, float damage, int currentPurcent, Role role) : base(matricule,
            health, damage, currentPurcent, role)
        {
        }
    }
}