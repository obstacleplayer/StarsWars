using StarsWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarsWars.Service
{
    public class WarServices
    {
        private List<Soldier> _rebels = new List<Soldier>();
        private List<Soldier> _stormtroopers = new List<Soldier>();
        private readonly Random _random = new Random();
        public bool Init(int nbSoldiers)
        {
            if (nbSoldiers < 0 || nbSoldiers > 10000)
            {
                Console.WriteLine("Merci de choisir un nombre de soldats compris entre 0 et 10 000");
                return false;
            }

            for (var i = 1; i <= nbSoldiers; i++)
            {
                var Rebel = new Rebel(i,
                    _random.Next(1000, 2000),
                    _random.Next(100, 500),
                    _random.Next(1, 100),
                    Role.Rebel);

                var Stormtrooper = new Stormtrooper(i,
                    _random.Next(1000, 2000),
                    _random.Next(100, 500),
                    _random.Next(1, 100),
                    Role.Stormtrooper);

                _rebels.Add(Rebel);
                _stormtroopers.Add(Stormtrooper);
            }

            DetermineHero(_rebels);
            DetermineHero(_stormtroopers);

            return true;
        }

        public void DetermineHero(List<Soldier> soldiers) => HeroesManagerServices.GetHero(soldiers).IsHero = true;

        public void SeparateLineConsole() => Console.WriteLine("".PadRight(100, '-'));

        public Soldier PickAnAliveSoldier(List<Soldier> soldiers) => soldiers.FirstOrDefault(item => item.IsAlive);
        
        public void Fight(Soldier rebel, Soldier stormtrooper)
        {
            Soldier attacker;
            Soldier victim;

            var chooseWhoAttack = _random.Next(1, 10);

            if (chooseWhoAttack % 2 == 0)
            {
                attacker = rebel;
                victim = stormtrooper;
            }
            else
            {
                attacker = stormtrooper;
                victim = rebel;
            }

            attacker.Attack(victim);
            Console.WriteLine(
                $"\nLe : {attacker.Role} au matricule : {attacker.Matricule} attaque le : {victim.Role}, au matricule {victim.Matricule}, et lui inflige: {attacker.Damage} dégâts,  vie restante : {victim.Health} ");

            if (victim.Health <= 0)
            {
                if (victim.IsHero)
                    Console.WriteLine(
                        $"\nLe héro des Stormtroopers au matricule {victim.Matricule} est mort ");
                else
                    Console.WriteLine($"\nLe {victim.Role} au matricule {victim.Matricule} est mort ");

                victim.IsAlive = false;
            }
        }

        public void WhoHasWon()
        {
            var winner = _rebels.Count(item => item.IsAlive == true) == 0 ? "Stormtrooper" : "Rebel";

            Console.WriteLine($"L'équipe des {winner} a gagné");

            if (FavsManagersServices.GetFavs(_rebels, _stormtroopers).Equals(winner))
                Console.WriteLine("\nElle était désignée comme favorie");
            else
                Console.WriteLine("\nElle n'était pas désignée comme favorie");
        }

        public void StartWar()
        {
            int nbSoldiers;

            do
            {
                Console.WriteLine("Combien Voulez vous de soldat :");
                nbSoldiers = int.Parse(Console.ReadLine());
            } while (!Init(nbSoldiers));

            var TeamFav = FavsManagersServices.GetFavs(_rebels, _stormtroopers);

            Console.WriteLine($"Voici l'équipe favorite de la bataille : {TeamFav}");
            Console.ReadLine();

            var WarOver = false;
            
            while (!WarOver)
            {
                var CurrentRebel = PickAnAliveSoldier(_rebels);
                var CurrentStormtrooper = PickAnAliveSoldier(_stormtroopers);

                SeparateLineConsole();

                if (CurrentRebel != null && CurrentStormtrooper != null)
                {
                    Fight(CurrentRebel, CurrentStormtrooper);

                    SeparateLineConsole();
                }
                else
                {
                    WhoHasWon();
                    WarOver = true;
                    Console.WriteLine("\nGuerre terminée ");
                }
            }
        }
    }
}