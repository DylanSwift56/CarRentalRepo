using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental_BlazorApp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CarTests
{
    //Before Running automated tests you must click debug at the top of the screen and click run without debugging because an instance of the app needs to running on localhost first before running test
    public class AutomatedTests
    {
        private readonly IWebDriver driver;

        public AutomatedTests() => driver = new ChromeDriver();

        [Test]
        public void NavigateToAdminLoginCheckURL() {
            driver.Navigate().GoToUrl("https://car-rental-new.azurewebsites.net/admin/login");

            Assert.AreEqual("https://car-rental-new.azurewebsites.net/admin/login", driver.Url);
        }

        [Test]
        public void NavigateToRentalsCheckURL()
        {
            driver.Navigate().GoToUrl("https://car-rental-new.azurewebsites.net/rent");

            Assert.AreEqual("https://car-rental-new.azurewebsites.net/rent", driver.Url);
        }

        [Test]
        public void TestIncorrectLoginDetailsEntered()
        {
            driver.Navigate().GoToUrl("https://car-rental-new.azurewebsites.net/login");

            Thread.Sleep(2000);

            //Types random into email
            driver.FindElement(By.Id("email")).SendKeys("Random");

            Thread.Sleep(2000);

            //Type random into password
            driver.FindElement(By.Id("password")).SendKeys("Random");

            Thread.Sleep(2000);

            //Clicks submit button
            driver.FindElement(By.Id("submit")).Click();

            //Wait for error message to pop up
            Thread.Sleep(2000);

            //Checks error message did pop up
            var errorMessage = driver.FindElement(By.ClassName("alert")).Text;
            Assert.That(errorMessage, Is.EqualTo("Invalid username or password. Please try again."));
        }
    }
}
