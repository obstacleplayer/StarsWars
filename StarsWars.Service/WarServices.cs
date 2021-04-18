using StarsWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarsWars.Service
{
    public class WarServices
    {
        private readonly HashSet<Soldiers> _rebels = new HashSet<Soldiers>();
        private readonly HashSet<Soldiers> _stormtroopers = new HashSet<Soldiers>();
        private readonly Random _random = new Random();

        public void Init()
        {
            Console.WriteLine("Combien Voulez vous de soldat");
            var SumOfSoldiers = int.Parse(Console.ReadLine());
            for (var i = 0; i < SumOfSoldiers; i++)
            {
                var Rebel = new Rebels();
                var Stormtrooper = new Stormtroopers();
                _rebels.Add(Rebel);
                _stormtroopers.Add(Stormtrooper);
            }
        }

        public void SeparateLineConsole() => Console.WriteLine("".PadRight(100, '-'));
        
        public Soldiers GetSoldierAlive(HashSet<Soldiers> soldiers) => soldiers.FirstOrDefault(item => item.IsAlive);

        public void StartWar()
        {
            Init();
            var HeroRebel = HeroesManagerServices.GetHero(_rebels);
            var HeroStormtrooper = HeroesManagerServices.GetHero(_stormtroopers);

            var TeamFav = FavsManagersServices.GetFavs(_rebels, _stormtroopers);
            Console.WriteLine($"Voici l'équipe favorite de la bataille : {TeamFav}");

            var WarOver = false;
            while (!WarOver)
            {
                var CurrentRebel = GetSoldierAlive(_rebels);
                var CurrentStormtrooper = GetSoldierAlive(_stormtroopers);
                if (CurrentRebel != null && CurrentStormtrooper != null)
                {
                    var ChooseWhoAttack = _random.Next(1, 10);
                    if (ChooseWhoAttack % 2 == 0)
                    {
                        SeparateLineConsole();

                        CurrentRebel.Attack(CurrentStormtrooper);
                        Console.WriteLine(
                            $"\nle soldat Rebel au matricule : {CurrentRebel.Matricule} Attack est inflige : {CurrentRebel.Damage} au Stormtrooper : {CurrentStormtrooper.Matricule} Santé restante : {CurrentStormtrooper.Health} ");

                        if (CurrentStormtrooper.Health <= 0)
                        {
                            if (HeroStormtrooper == CurrentStormtrooper)
                                Console.WriteLine(
                                    $"\nle Heros des Stormtrooper au matricule {CurrentStormtrooper.Matricule} est mort ");

                            else
                                Console.WriteLine(
                                    $"\nle soldat Stormtrooper au matricule {CurrentStormtrooper.Matricule} est mort ");
                            CurrentStormtrooper.IsAlive = false;
                        }

                        SeparateLineConsole();
                    }
                    else
                    {
                        SeparateLineConsole();
                        CurrentStormtrooper.Attack(CurrentRebel);
                        Console.WriteLine(
                            $"\nle soldat Stormtrooper au matricule : {CurrentStormtrooper.Matricule} Attack est inflige : {CurrentStormtrooper.Damage} au Stormtrooper : {CurrentRebel.Matricule} Santé restante : {CurrentRebel.Health} ");
                        if (CurrentRebel.Health <= 0)
                        {
                            if (HeroRebel == CurrentRebel)
                                Console.WriteLine(
                                    $"\nle Heros des Rebel au matricule {CurrentRebel.Matricule} est mort ");

                            else
                                Console.WriteLine($"\nle soldat Rebel au matricule {CurrentRebel.Matricule} est mort ");
                            CurrentRebel.IsAlive = false;
                        }

                        SeparateLineConsole();
                    }
                }
                else
                {
                    if (CurrentStormtrooper != null)
                    {
                        SeparateLineConsole();
                        Console.WriteLine("Stormtrooper à gagné");
                        if (TeamFav.Equals(CurrentStormtrooper.GetTypeTeam()))
                            Console.WriteLine("\nIl était le favorie");
                        else
                            Console.WriteLine("il n'était pas le favorie");
                    }   
                    else
                    {
                        SeparateLineConsole();
                        Console.WriteLine("Rebel à gagné");
                        if (TeamFav.Equals(CurrentRebel.GetTypeTeam()))
                            Console.WriteLine("\nIl était le favorie");
                        else
                            Console.WriteLine("il n'était pas le favorie");
                    }

                    Console.WriteLine("\nGuerre terminé ");
                    WarOver = true;
                }
            }
        }
    }
}