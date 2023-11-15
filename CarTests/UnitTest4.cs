using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTests
{
    internal class UnitTest4
    {
        [SetUp]
        public void Setup()
        {
            DisplayClientModel clientModel = new DisplayClientModel();
            clientModel.Name = "John";
        }
        [Test]
        public void setName()
        {
            DisplayClientModel clientModel = new DisplayClientModel();
            clientModel.Name = "John";
            Assert.True(clientModel.Name.Equals("Name"));
        }
        [Test]
        public void setPhone()
        {
            DisplayClientModel clientModel = new DisplayClientModel();
            clientModel.Phone = "08xxxxx";
            Assert.True(clientModel.Phone.Equals("08xxxxx"));
        }
        [Test]
        public void setEmail()
        {
            DisplayClientModel clientModel = new DisplayClientModel();
            clientModel.Email = "John@test";
            Assert.True(clientModel.Email.Equals("John@test"));
        }
        [Test]
        public void setPassword()
        {
            DisplayClientModel clientModel = new DisplayClientModel();
            clientModel.Password = "123";
            Assert.True(clientModel.Password.Equals("123"));
        }
        [Test]
        public void setCompany()
        {
            DisplayClientModel clientModel = new DisplayClientModel();
            clientModel.Company = "Micro";
            Assert.True(clientModel.Company.Equals("123"));
        }
        [Test]
        public void setLicenceType()
        {
            DisplayClientModel clientModel = new DisplayClientModel();
            clientModel.LicenceType = "VX23";
            Assert.True(clientModel.LicenceType.Equals("VX23"));
        }
        [Test]
        public void setClientID()
        {
            DisplayClientModel clientModel = new DisplayClientModel();
            clientModel.Client_id = 1;
            Assert.True(clientModel.Client_id.Equals(1));
        }



    }
}
