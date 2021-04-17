using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarsWars.Service
{
    public class WarServices
    {
        HashSet<Soldiers> Rebels = new HashSet<Soldiers>();
        HashSet<Soldiers> Stormtroopers = new HashSet<Soldiers>();
        Random random = new Random();


        public void Init()
        {
            Console.WriteLine("Combien Voulez vous de soldat");
            int SumOfSoldiers = int.Parse(Console.ReadLine());
            for (int i = 0; i < SumOfSoldiers; i++)
            {
                Rebels Rebel = new Rebels();
                Stormtroopers Stormtrooper = new Stormtroopers();
                Rebels.Add(Rebel);
                Stormtroopers.Add(Stormtrooper);

            }
        }

        public void SeparateLineConsole()
        {
            Console.WriteLine(("").PadRight(100, '-'));
        }

        public Soldiers GetRebelsAlive()
        {

            return Rebels.Where(item => item.IsAlive).FirstOrDefault();

        }
        public Soldiers GetStormtrooperAlive()
        {
            return Stormtroopers.Where(item => item.IsAlive).FirstOrDefault();
        }

        public void StartWar()
        {
            Init();
            Soldiers HeroRebel = HeroesManagerServices.GetHero(Rebels);
            Soldiers HeroStormtrooper = HeroesManagerServices.GetHero(Stormtroopers);

            string TeamFav = FavsManagersServices.GetFavs(Rebels, Stormtroopers);
            Console.WriteLine($"Voici l'équipe favorite de la bataille : {TeamFav}");

            bool WarOver = false;
            while (!WarOver)
            {
                Soldiers CurrentRebel = GetRebelsAlive();
                Soldiers CurrentStormtrooper = GetStormtrooperAlive();
                if (CurrentRebel != null && CurrentStormtrooper != null)
                {
                    int chooseWhoAttack = random.Next(1, 10);
                    if (chooseWhoAttack % 2 == 0)
                    {
                        SeparateLineConsole();

                        CurrentRebel.Attack(CurrentStormtrooper);
                        Console.WriteLine($"\nle soldat Rebel au matricule : {CurrentRebel.Matricule} Attack est inflige : {CurrentRebel.Damage} au Stormtrooper : {CurrentStormtrooper.Matricule} Santé restante : {CurrentStormtrooper.Health} ");

                        if (CurrentStormtrooper.Health <= 0)
                        {
                            if (HeroStormtrooper == CurrentStormtrooper)
                                Console.WriteLine($"\nle Heros des Stormtrooper au matricule {CurrentStormtrooper.Matricule} est mort ");

                            else
                                Console.WriteLine($"\nle soldat Stormtrooper au matricule {CurrentStormtrooper.Matricule} est mort ");
                            CurrentStormtrooper.IsAlive = false;
                        }
                        SeparateLineConsole();
                    }
                    else
                    {
                        SeparateLineConsole();
                        CurrentStormtrooper.Attack(CurrentRebel);
                        Console.WriteLine($"\nle soldat Stormtrooper au matricule : {CurrentStormtrooper.Matricule} Attack est inflige : {CurrentStormtrooper.Damage} au Stormtrooper : {CurrentRebel.Matricule} Santé restante : {CurrentRebel.Health} ");
                        if (CurrentRebel.Health <= 0)
                        {
                            if (HeroRebel == CurrentRebel)
                                Console.WriteLine($"\nle Heros des Rebel au matricule {CurrentRebel.Matricule} est mort ");

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
                        Console.WriteLine($"Stormtrooper à gagné");
                        if (TeamFav.Equals(CurrentStormtrooper.GetTypeTeam()))
                        {
                            Console.WriteLine("\nIl était le favorie");
                        }
                        else
                            Console.WriteLine($"il n'était pas le favorie");
                    }
                    else
                    {
                        SeparateLineConsole();
                        Console.WriteLine($"Rebel à gagné");
                        if (TeamFav.Equals(CurrentRebel.GetTypeTeam()))
                        {
                            Console.WriteLine("\nIl était le favorie");
                        }
                        else
                            Console.WriteLine($"il n'était pas le favorie");
                    }
                    Console.WriteLine($"\nGuerre terminé ");
                    WarOver = true;
                }
            }
        }
    }
}
