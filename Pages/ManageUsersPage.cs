using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.IndexedDB;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace EnrichKidAdminAutomation.Pages
{
    public class ManageUsersPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ManageUsersPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ManageUsers()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/nav/ul/li[2]")).Click();
            Console.WriteLine("Click on Manage Users");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/nav/ul/li[2]/div/ul/li[1]/button")).Click();
            Console.WriteLine("Click to Users");
            Thread.Sleep(2000); // Wait for the page to load
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[1]/div/button[3]/span")).Click();
            Console.WriteLine("Click on Add New User button");
        }
        private string GenerateUniqueEmailWithRandom()
        {
            Random random = new Random();
            int randomNumber = random.Next(1000, 99999);
            return $"adnan_{randomNumber}@yopmail.com";
        }

        public void AddnewUser()
        {
            string uniqueEmail = GenerateUniqueEmailWithRandom();
            driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[1]/div[1]/div/div/input")).SendKeys("Adnan");
            driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[1]/div[2]/div/div/input")).SendKeys("Ali");
            driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[2]/div[1]/div/div/input")).SendKeys(uniqueEmail);
            // driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[2]/div[2]/div/div/input")).SendKeys("1122334455");
            var phoneField = driver.FindElement(By.CssSelector("input[placeholder='(000) 000-0000']"));
            phoneField.Click();
            Thread.Sleep(500);
            foreach (char digit in "1122334455")
            {

                phoneField.SendKeys(digit.ToString());
                Thread.Sleep(100);
                // mimic human typing for masked field
            }
            driver.FindElement(By.CssSelector("#roleID > div > div.px-4.py-2.py-1.flex.items-start.gap-2.justify-start.css-14oxtc6")).Click();
            Thread.Sleep(1000); // Let the dropdown open

            // Step 2: Select the role by visible text "Manage Payments"
            driver.FindElement(By.XPath("//div[contains(text(), 'Manage Vendors')]")).Click();
            driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[4]/button")).Click();
            Console.WriteLine("User added with email: " + uniqueEmail);





        }
    }
}