using CarRental_BlazorApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTests
{
    internal class UnitTest2
    {
        [SetUp]
        public void Setup()
        {
            DisplayLoginModel loginModel = new DisplayLoginModel();
            loginModel.Username = "test@test";
        }
        [Test]
        public void setUsername()
        {
            DisplayLoginModel loginModel = new DisplayLoginModel();
            loginModel.Username = "test@test";
            Assert.True(loginModel.Username.Equals("test@test"));
        }
        [Test]
        public void setPassword()
        {
            DisplayLoginModel loginModel = new DisplayLoginModel();
            loginModel.Password = "123";
            Assert.True(loginModel.Password.Equals("123"));
        }

    }
}
