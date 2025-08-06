using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace EnrichKidAdminAutomation.Pages
{
    public class ManageVendorsPage
    {
        private IWebDriver driver;

        public ManageVendorsPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void AddNewVendor()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
            By.CssSelector("div[data-state='open'][class*='bg-black/50']")));

            IWebElement manageVendorsMenu = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/div[1]/div/div[2]/nav/ul/li[3]")));

            manageVendorsMenu.Click();
             Thread.Sleep(5000); 
            Console.WriteLine("Click on Manage Vendors");


            // Click on Add New Vendor
            Thread.Sleep(2000); 
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[1]/div/button[3]")).Click();
            Console.WriteLine("Click on Add New Vendor");
        }

          private string GenerateUniqueEmailWithRandom()
        {
            Random random = new Random();
            int randomNumber = random.Next(1000, 99999);
            return $"adnan_{randomNumber}@yopmail.com";
        }

        public void FillNewVendorForm()
        {
            string uniqueEmail = GenerateUniqueEmailWithRandom();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[1]/div[1]/div/input")).SendKeys("testing Business");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[2]/div[1]/div/input")).SendKeys("Adnan");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[2]/div[2]/div/input")).SendKeys("Ali");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[3]/div[1]/div/input")).SendKeys(uniqueEmail);
           // driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[3]/div[2]/div/input")).SendKeys("1122334455");
            var phoneField = driver.FindElement(By.CssSelector(@"body > div.bg-gray-100.min-h-screen > div > div.lg\:ml-\[300px\].lg\:px-10.px-6.lg\:w-\[calc\(100\%-300px\)\].w-full.mb-12.min-h-\[calc\(100vh-48px\)\].flex.flex-col > main > div > div > div.p-6 > div > div:nth-child(1) > div > div > div:nth-child(3) > div:nth-child(2) > div > input"));
            phoneField.Click();
            Thread.Sleep(500);
            foreach (char digit in "1122334455")
            {

                phoneField.SendKeys(digit.ToString());
                Thread.Sleep(100);
                // mimic human typing for masked field
            }
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div/div[1]/div/div/div[4]/div/div/div/input")).SendKeys("47 W 13th St, New York, NY 10011, USA");
            driver.FindElement(By.CssSelector("#vendor_subscription > div > div.px-4.py-2.py-1.flex.items-start.gap-2.justify-start.css-14oxtc6")).Click();
            Thread.Sleep(1000); // Let the dropdown open

            // Step 2: Select the role by visible text "Listing Only"
            driver.FindElement(By.XPath("//div[contains(text(), 'Program Listing Only')]")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[1]/div[2]/button/span")).Click();
            Console.WriteLine("User added with email: " + uniqueEmail);
        }

    }
}