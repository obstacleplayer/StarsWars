﻿using System;
using StarsWars.Service;

namespace StarsWars
{
    public class Program
    {
        static void Main(string[] args)
        {
            WarServices war = new WarServices();
            war.StartWar();
        }
    }
}
