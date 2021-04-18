using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarsWars.Model.Entities;
using StarsWars.Service;

namespace StarWars.Service.Tests
{
    [TestClass]
    public class WarServicesTests
    {
        private WarServices _warServices;
        

        public WarServicesTests()
        {
            _warServices = new WarServices();
        }

        [TestMethod]
        public void CheckUnicityOfMatriculeSoldiersInitTests()
        {
            List<Soldiers> _rebels = new List<Soldiers>();
            List<Soldiers> _stormtroopers = new List<Soldiers>();
            int SumOfSoldiers = 1000000;
            for (var i = 0; i < SumOfSoldiers; i++)
            {
                var Rebel = new Rebels();
                var Stormtrooper = new Stormtroopers();
                _rebels.Add(Rebel);
                _stormtroopers.Add(Stormtrooper);
                Assert.AreNotSame(Rebel.Matricule, Stormtrooper.Matricule);

            }

            
        }
    }

   
}