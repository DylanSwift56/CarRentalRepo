using CarRental_BlazorApp.Pages;
using DataAccessLibrary;
using Moq;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CarTests
{
    internal class UnitTest2
    {
        private DisplayLoginModel loginModel;
        private string errorMessage;

        [SetUp]
        public void Setup()
        {
            loginModel = new DisplayLoginModel();
            errorMessage = null;
        }

        [Test]
        public async Task SuccessfulLoginNavigatesToRent()
        {
            loginModel.Username = "validUsername";
            loginModel.Password = "validPassword";
            var fakeNavigation = new FakeNavigation();

            var mockDbClients = new Mock<ClientData>(); 
            mockDbClients.Setup(db => db.CheckCredentials(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);

            var login = new UserLogin(mockDbClients.Object); 

            await login.LoginUser(loginModel, fakeNavigation);

            Assert.AreEqual("/rent", fakeNavigation.NavigatedTo);
            Assert.IsNull(errorMessage);
        }

        [Test]
        public async Task FailedLoginShowsErrorMessageAndClearsFields()
        {
            loginModel.Username = "invalidUser";
            loginModel.Password = "wrongPassword";
            var fakeNavigation = new FakeNavigation();

            var mockDbClients = new Mock<ClientData>(); 
            mockDbClients.Setup(db => db.CheckCredentials(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(false);

            var login = new UserLogin(mockDbClients.Object); 
            await login.LoginUser(loginModel, fakeNavigation);

            Assert.IsNull(fakeNavigation.NavigatedTo);
            Assert.IsNotNull(errorMessage);
            Assert.AreEqual("Invalid username or password. Please try again.", errorMessage);
            Assert.AreEqual(string.Empty, loginModel.Username);
            Assert.AreEqual(string.Empty, loginModel.Password);
        }

        private class FakeNavigation
        {
            public string NavigatedTo { get; private set; }

            public void NavigateTo(string path)
            {
                NavigatedTo = path;
            }
        }
        private class ClientData
        {
            public virtual Task<bool> CheckCredentials(string username, string password)
            {
                return Task.FromResult(username == "validUsername" && password == "validPassword");
            }
        }

        private class UserLogin
        {
            private readonly ClientData _db;
            private string errorMessage;

            public UserLogin(ClientData db)
            {
                _db = db;
            }

            public async Task LoginUser(DisplayLoginModel loginModel, FakeNavigation navigation)
            {
                if (await _db.CheckCredentials(loginModel.Username, loginModel.Password))
                {
                    navigation.NavigateTo("/rent");
                }
                else
                {
                    errorMessage = "Invalid username or password. Please try again.";
                    loginModel.Password = string.Empty;
                    loginModel.Username = string.Empty;
                }
            }
        }
    }
}
