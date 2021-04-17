using StarsWars.Services.Services;
using System;

namespace StarsWars
{
    public class Program
    {
        static void Main(string[] args)
        {
            WarServices War = new WarServices();
            War.StartWar();
        }
    }
}
