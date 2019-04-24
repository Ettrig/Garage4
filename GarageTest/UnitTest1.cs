using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageProject; 

namespace GarageTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructedGarageExists()
        {
            var gar = new Garage<Vehicle>(17);

            Assert.AreNotEqual(gar, null);
        }

        [TestMethod]
        public void CapacityIs17()
        {
            var gar = new Garage<Vehicle>(17);

            Assert.AreEqual(gar.Capacity, 17);
        }

        [TestMethod]
        public void CountIs0()
        {
            var gar = new Garage<Vehicle>(17);

            Assert.AreEqual(gar.Count, 0);
        }

        [TestMethod]
        public void CountIs1AfterAdd()
        {
            var gar = new Garage<Vehicle>(17);
            var vehicl = new Vehicle("ABC", "Red", 4);

            gar.AddVehicle(vehicl);

            Assert.AreEqual(gar.Count, 1);
        }

        [TestMethod]
        public void CanFindVehicleAbc()
        {
            var gar = new Garage<Vehicle>(17);
            var vehicl = new Vehicle("ABC", "Red", 4);
            gar.AddVehicle(vehicl);

            Vehicle testResult = gar.FindVehicle("ABC"); 

            Assert.AreNotEqual(testResult, null);
        }

        [TestMethod]
        public void CannotFindVehicleABD()
        {
            var gar = new Garage<Vehicle>(17);
            var vehicl = new Vehicle("ABC", "Red", 4);
            gar.AddVehicle(vehicl);

            Vehicle testResult = gar.FindVehicle("ABD");

            Assert.AreEqual(testResult, null);
        }

        [TestMethod]
        public void CountIs0AfterRemove()
        {
            var gar = new Garage<Vehicle>(17);
            var vehicl = new Vehicle("ABC", "Red", 4);
            gar.AddVehicle(vehicl);

            gar.RemoveVehicle("ABC");

            Assert.AreEqual(gar.Count, 0);
        }

        [TestMethod]
        public void CanGetEnumerator()
        {
            var gar = new Garage<Vehicle>(17);
            var vehicl = new Vehicle("ABC", "Red", 4);
            gar.AddVehicle(vehicl);

            var enumerator = gar.GetEnumerator(); 

            Assert.AreNotEqual(enumerator, null);
        }
    }
}
