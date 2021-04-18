using System.Collections.Generic;
using StarsWars.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarsWars.Model.Entities;

namespace StarWars.Service.Tests
{
    [TestClass]
    public class WarServicesTests
    {
        private WarServices _warServices = new WarServices();

        [TestMethod]
        public void CheckIfNumberOfSoldiersIsGood_ThenReturnsTrue()
        {
            bool res = _warServices.Init(9000);
            Assert.IsTrue(res);

        }

        [TestMethod]
        public void CheckIfNumberOfSoldiersIsBad_ThenReturnsFalse()
        {
            bool res = _warServices.Init(110000);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void CheckIfNumberOfSoldiersIsNegative_ThenReturnsFalse()
        {
            bool res = _warServices.Init(-110000);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IfListContainsAliveSoldier_ThenReturnsSoldier()
        {
            Rebel rebel = new Rebel(500, 5, 5, 5, Role.Rebel);
            Rebel rebel2 = new Rebel(250, 3, 8, 8, Role.Rebel);

            rebel.IsAlive = true;
            rebel2.IsAlive = false;

            List<Soldier> rebels = new List<Soldier>()
            {
                rebel,
                rebel2
            };
            ;
            Assert.AreEqual(rebel, _warServices.PickAnAliveSoldier(rebels));

        }

        [TestMethod]
        public void IfListContainsNoAliveSoldier_ThenReturnsNull()
        {
            Rebel rebel = new Rebel(500, 5, 5, 5, Role.Rebel);
            Rebel rebel2 = new Rebel(250, 3, 8, 8, Role.Rebel);

            rebel.IsAlive = false;
            rebel2.IsAlive = false;

            List<Soldier> rebels = new List<Soldier>()
            {
                rebel,
                rebel2
            };
            ;
            Assert.IsNull(_warServices.PickAnAliveSoldier(rebels));
        }
    }
}