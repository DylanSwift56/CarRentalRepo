using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTests
{
    internal class UnitTest5
    {
        [SetUp]
        public void Setup()
        {
            DisplayCarType car = new DisplayCarType();
            car.CarType = "Jeep";
        }
        [Test]
        public void setCarType()
        {
            DisplayCarType car = new DisplayCarType();
            car.CarType = "Jeep";
            Assert.True(car.CarType.Equals("Jeep"));
        }
        [Test]
        public void setDescription()
        {
            DisplayCarType car = new DisplayCarType();
            car.Description = "two seater";
            Assert.True(car.Description.Equals("two seater"));
        }
    }
}
