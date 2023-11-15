using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTests
{
    internal class UnitTest6
    {
        [SetUp]
        public void Setup()
        {
            DisplayRentalModel rent = new DisplayRentalModel();
            rent.Rental_ID = "USER1";
        }
        [Test]
        public void setRentalID()
        {
            DisplayRentalModel rent = new DisplayRentalModel();
            rent.Rental_ID = "USER1";
            Assert.True(rent.Rental_ID.Equals("USER1"));
        }
        [Test]
        public void setStatus()
        {
            DisplayRentalModel rent = new DisplayRentalModel();
            rent.Status = 'A';
            Assert.True(rent.Status.Equals('A'));
        }
        [Test]
        public void setCarReg()
        {
            DisplayRentalModel rent = new DisplayRentalModel();
            rent.CarRegistration = "V23";
            Assert.True(rent.CarRegistration.Equals("V23"));
        }
        [Test]
        public void setStartDate()
        {
            DisplayRentalModel rent = new DisplayRentalModel();
            rent.StartDate = new DateTime(2023,2,5);
            Assert.True(rent.StartDate.Equals(new DateTime(2023,2,5)));
        }
        [Test]
        public void setEndDate()
        {
            DisplayRentalModel rent = new DisplayRentalModel();
            rent.EndDate = new DateTime(2023, 3, 5);
            Assert.True(rent.EndDate.Equals(new DateTime(2023, 3, 5)));
        }
        [Test]
        public void setPickUpDate()
        {
            DisplayRentalModel rent = new DisplayRentalModel();
            rent.PickUpDate = new DateTime(2023, 2, 5);
            Assert.True(rent.PickUpDate.Equals(new DateTime(2023, 2, 5)));
        }
        [Test]
        public void setReturnDate()
        {
            DisplayRentalModel rent = new DisplayRentalModel();
            rent.ReturnDate = new DateTime(2023, 3, 5);
            Assert.True(rent.ReturnDate.Equals(new DateTime(2023, 3, 5)));
        }
        [Test]
        public void setClientID() {
            DisplayRentalModel rent = new DisplayRentalModel();
            rent.Client_ID = 2;
            Assert.True(rent.Client_ID.Equals(2));
        }


    }
}
