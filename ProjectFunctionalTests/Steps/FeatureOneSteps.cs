using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ProjectFunctionalTests.Steps
{
    [Binding]
    public sealed class FeatureOneSteps
    {
        IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver(@"C:\selenium\");

        [Given(@"I have navigated to the Historic Photo Portal homepage")]
        public void GivenIHaveNavigatedToTheHistoricPhotoPortalHomepage()
        {
            driver.Url = "http://192.168.0.5/historicPhotos/view/userLogin.php";
        }

        [Given(@"I login using the following credentials")]
        public void GivenILoginUsingTheFollowingCredentials(Table userCredentials)
        {
            //driver.FindElement(By.Name("username")).SendKeys(userCredentials)
            foreach(TableRow user in userCredentials.Rows)
            {
                driver.FindElement(By.Name("username")).SendKeys(user["Username"]);
                driver.FindElement(By.Name("password")).SendKeys(user["Password"]);
            }
        }

        [When(@"I click login")]
        public void GivenIClickLogin()
        {
            driver.FindElement(By.Name("login")).Click();
        }

        [Then(@"the welcome message '(.*)' and username '(.*)' are displayed")]
        public void ThenTheWelcomeMessageAndUsernameAreDisplayed(string welcomeMessage, string userName)
        {
            var greeting = driver.FindElement(By.Name("welcomeMessage"));
            var user = driver.FindElement(By.Name("userGreeting"));

            Assert.IsTrue(greeting.Text == welcomeMessage);
            Assert.IsTrue(user.Text == userName);
        }
    }
}
