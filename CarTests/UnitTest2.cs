using Blazored.SessionStorage;
using CarRental_BlazorApp.Pages;
using DataAccessLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTests
{
    internal class UnitTest2
    {
        private DisplayLoginModel loginModel;
        private string errorMessage;
        private Mock<IClientData> _dbClientsMock;
        private Mock<ISessionStorageService> sessionMock;
        private Mock<NavigationManager> navigationMock;


        [SetUp]
        public void Setup()
        {
            loginModel = new DisplayLoginModel();
            errorMessage = null;
            _dbClientsMock = new Mock<IClientData>();
            sessionMock = new Mock<ISessionStorageService>();
            navigationMock = new Mock<NavigationManager>();

        }

        [Test]
        public async Task SuccessfulLoginNavigatesToRentPage()
        {
            loginModel.Username = "validUsername";
            loginModel.Password = "validPassword";

            _dbClientsMock.Setup(db => db.CheckCredentials("validUsername", "validPassword")).ReturnsAsync(true);
            _dbClientsMock.Setup(db => db.GetClientIdByEmail("validUsername")).ReturnsAsync(1); // Assuming 1 is the user ID
            
            var loginUser = new UserLogin();

            await loginUser.LoginUser();
            
            navigationMock.Verify(nav => nav.NavigateTo("/rent",false), Times.Once); // Check if navigated to rent page
            
            sessionMock.Verify(s => s.SetItemAsync("SessionUser", 1,default), Times.Once); // Check if session item is set with the correct user ID
           
            Assert.IsNull(errorMessage); 
        }

        [Test]
        public async Task FailedLoginShowsErrorMessageAndClearsFields()
        {
            loginModel.Username = "invalidUsername";
            loginModel.Password = "invalidPassword";
            _dbClientsMock.Setup(db => db.CheckCredentials("invalidUsername", "invalidPassword")).ReturnsAsync(false);
            var loginUser = new UserLogin();

            await loginUser.LoginUser();

            navigationMock.Verify(nav => nav.NavigateTo(It.IsAny<string>(),false), Times.Never); // Should not navigate for failed login

            sessionMock.Verify(s => s.SetItemAsync("SessionUser", It.IsAny<int>(),default), Times.Never); // Session should not be set for failed login
            
            Assert.IsNotNull(errorMessage); 
            Assert.AreEqual("Invalid username or password. Please try again.", errorMessage); 
            Assert.AreEqual(string.Empty, loginModel.Username); 
            Assert.AreEqual(string.Empty, loginModel.Password); 
        }
    }
    }

