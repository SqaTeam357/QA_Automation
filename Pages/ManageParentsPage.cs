using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace EnrichKidAdminAutomation.Pages
{
    public class ManageParentsPage
    {
        private IWebDriver driver;

        public ManageParentsPage(IWebDriver driver)
        {
            this.driver = driver;
            

        }
        
        public void AddNewParent()
        {
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
                By.CssSelector("div[data-state='open'][class*='bg-black/50']")));

            // Click on Manage Parents
            IWebElement manageParentsMenu = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/div[1]/div/div[2]/nav/ul/li[4]")));
            manageParentsMenu.Click();
            Thread.Sleep(5000);
            Console.WriteLine("Click on Manage Parents");

            // Click on Add New Parent
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[1]/div/button[3]")).Click();
            Console.WriteLine("Click on Add New Parent");
        }

        private string GenerateUniqueEmailWithRandom()
        {
            Random random = new Random();
            int randomNumber = random.Next(1000, 99999);
            return $"adnan_{randomNumber}@yopmail.com";
        }

        public void FillNewParentForm()
        {
            string uniqueEmail = GenerateUniqueEmailWithRandom();

            // First Name
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[1]/div[1]/div/input"))
                  .SendKeys("faraz Ali");

            // Last Name
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[1]/div[2]/div/input"))
                  .SendKeys("Shaikh");

            // Phone Number
               var childPhoneField = driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[3]/div/div[2]/div/div[2]/div[2]/div/input"));
                childPhoneField.Click();
                Thread.Sleep(500);
                foreach (char digit in "1122334455")
                {
    
                    childPhoneField.SendKeys(digit.ToString());
                    Thread.Sleep(100);
                    // mimic human typing for masked field
                }
            // Email Address (using unique generated email)
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[2]/div[2]/div/input"))
                  .SendKeys(uniqueEmail);




            // Location
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[3]/div/div/div/input"))
                  .SendKeys("Karachi, Pakistan");

            // Relationship with Children 
            // First Name
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[3]/div/div[2]/div/div[1]/div[1]/div[1]/input"))
                  .SendKeys("Irfan");

            // Last Name
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[3]/div/div[2]/div/div[1]/div[2]/div[1]/input"))
                  .SendKeys("Ali");


            // Wait for the dropdown to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement relationshipDropdown = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//*[@id='authorized_pickup_relationship_with_child']/div/div[2]")));

            // Click to open the dropdown
            relationshipDropdown.Click();

            // Create an Actions object
            Actions actions = new Actions(driver);

            // Wait for the dropdown options to be visible (optional, if needed)
            Thread.Sleep(1000); // or use WebDriverWait if you have a specific option locator

            // Press Down Arrow key until "Father" is selected (you may need to adjust number of arrows)
            actions
                .SendKeys(Keys.ArrowDown)
                .SendKeys(Keys.ArrowDown)  // adjust if Father is further down
                .SendKeys(Keys.Enter)
                .Perform();

            // Phone Number
           var PhoneField = driver.FindElement(By.CssSelector(@"body > div.bg-gray-100.min-h-screen > div > div.lg\:ml-\[300px\].lg\:px-10.px-6.lg\:w-\[calc\(100\%-300px\)\].w-full.mb-12.min-h-\[calc\(100vh-48px\)\].flex.flex-col > main > div > div > div.p-6 > div > div:nth-child(1) > div > div > div:nth-child(2) > div:nth-child(1) > div > input"));
            PhoneField.Click();
            Thread.Sleep(500);
            foreach (char digit in "1122334455")
            {

                PhoneField.SendKeys(digit.ToString());
                Thread.Sleep(100);
                // mimic human typing for masked field
            }

            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[1]/div[2]/button/span")).Click();

            Console.WriteLine("New parent form filled successfully.");
        }

    }
}