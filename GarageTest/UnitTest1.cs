using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageProject;
using System.Linq; 

namespace GarageTest
{
    [TestClass]
    public class UnitTest1
    {
        const int garageSize = 17;

        [TestMethod]
        public void ConstructedGarageExists()
        {
            var gar = new Garage<Vehicle>(garageSize);

            Assert.IsNotNull(gar);
        }

        [TestMethod]
        public void Garage_CreateGarageWith17Spots_ShouldPass()
        {
            var gar = new Garage<Vehicle>(garageSize);

            int expected = garageSize;
            int actual = gar.Capacity;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CountIs0()
        {
            var gar = new Garage<Vehicle>(garageSize);

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

            Assert.IsNotNull(testResult);
            
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
        public void EnumeratorIsNotNull()
        {
            var gar = new Garage<Vehicle>(17);
            var vehicl = new Vehicle("ABR", "Red",  4);
            gar.AddVehicle(vehicl);

            var enumerator = gar.GetEnumerator(); 

            Assert.AreNotEqual(enumerator, null);
        }

        [TestMethod]
        public void EnumeratorMoveNextIsTrue()
        {
            var gar = new Garage<Vehicle>(17);
            var vehicl = new Vehicle("ABR", "Red", 4);
            gar.AddVehicle(vehicl);

            var enumerator = gar.GetEnumerator();

            var myBool = enumerator.MoveNext();

            Assert.AreEqual(myBool, true);
        }

        [TestMethod]
        public void EnumeratorMoveNextIsFalse()
        {
            var gar = new Garage<Vehicle>(17);
            var vehicl = new Vehicle("ABR", "Red", 4);
            gar.AddVehicle(vehicl);

            var enumerator = gar.GetEnumerator();

            var myBool = enumerator.MoveNext();
            myBool = enumerator.MoveNext();

            Assert.AreEqual(myBool, false);
        }


    }
}
