using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EnrichKidAdminAutomation.Base
{
    public class BaseTest
    {
        public IWebDriver driver;
        private bool keepBrowserOpen = false; // Set to false to close browser after test

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://admin.enrichkid.ca/login"); 
        }

        [TearDown]
        public void TearDown()
        {
            if (!keepBrowserOpen && driver != null)
            {
                // Thread.Sleep(000);
                driver.Quit();
                driver.Dispose();

            }
        }
    }
}
