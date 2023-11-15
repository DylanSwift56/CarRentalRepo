using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTests
{
    internal class UnitTest3
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
        public async Task SuccessfulLoginNavigatesToAdminDashboard()
        {
            loginModel.Username = "admin";
            loginModel.Password = "admin";
            var fakeNavigation = new FakeNavigation(); 

            await OnLogin(fakeNavigation);

            Assert.AreEqual("/admin/dashboard", fakeNavigation.NavigatedTo); 
            Assert.IsNull(errorMessage);
        }

        [Test]
        public async Task FailedLoginShowsErrorMessageAndClearsFields()
        {
            loginModel.Username = "invalidUser";
            loginModel.Password = "wrongPassword";
            var fakeNavigation = new FakeNavigation(); 

            
            await OnLogin(fakeNavigation);

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
        private async Task OnLogin(FakeNavigation navigation)
        {
            if (loginModel.Username == "admin" && loginModel.Password == "admin")
            {
                navigation.NavigateTo("/admin/dashboard");
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
