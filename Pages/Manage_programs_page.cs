using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace EnrichKidAdminAutomation.Pages
{
    public class AddNewProgramPage
    {
        private IWebDriver driver;

        public AddNewProgramPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddNewProgram()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // Wait for sidebar to disappear if present
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
                By.CssSelector("div[data-state='open'][class*='bg-black/50']")));

            // Click on "Manage Programs"
            IWebElement manageProgramsMenu = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/div[1]/div/div[2]/nav/ul/li[5]/div/button")));
            manageProgramsMenu.Click();
            Console.WriteLine("Clicked on Manage Programs");

            Thread.Sleep(2000);

            // Click on "Programs" link
            IWebElement programsLink = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/div[1]/div/div[2]/nav/ul/li[5]/div/ul/li[1]/button")));
            programsLink.Click();
            Console.WriteLine("Clicked on Programs link");

            Thread.Sleep(2000);

            // Click on "Add New Program"
            IWebElement addNewProgramBtn = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[1]/div/button[3]")));
            addNewProgramBtn.Click();
            Thread.Sleep(5000);
            Console.WriteLine("Clicked on Add New Program");
        }

        private string GenerateUniqueProgramTitle()
        {
            return "Test Program " + DateTime.Now.ToString("yyyyMM");
        }

        public void FillNewProgramForm()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Actions actions = new Actions(driver);

            string uniqueTitle = GenerateUniqueProgramTitle();

            // Session Type
            driver.FindElement(By.CssSelector("#sessionType > div > div.px-4.py-2.py-1.flex.items-start.gap-2.justify-start.css-14oxtc6")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//div[contains(text(), 'Summer Session')]")).Click();

            // Vendor
            driver.FindElement(By.CssSelector("#vendor > div > div.px-4.py-2.py-1.flex.items-start.gap-2.justify-start.css-14oxtc6")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//div[contains(text(), 'EK BUSINESS 1')]")).Click();

            // Program Category
            wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//label[contains(text(),'Program Category')]/following-sibling::div"))).Click();
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Perform();
            Thread.Sleep(500);

            // Program Title
            driver.FindElement(By.CssSelector("#programTitle")).SendKeys(uniqueTitle);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30000);


            // Program Details
            IWebElement description = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div[1]/div[1]/div/div/div[5]/div/div[2]/div[2]/div")));
            description.Click();
            description.SendKeys("This is a test program created by automation.");


            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div[1]/div[1]/div/div/div[6]/div[2]/div")).Click();
            Thread.Sleep(500);


            driver.FindElement(By.Id("seatsTotal")).SendKeys("10");
            driver.FindElement(By.Id("seatsAvailable")).SendKeys("5");
            driver.FindElement(By.XPath("/html/body/div[5]/p/div[2]/button[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div[1]/div[1]/div/div/div[6]/div[1]")).Click();



            // Start Date
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div[1]/div[1]/div/div/div[7]/div[1]/button")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div/div[2]/div[3]/div[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/button[2]")).Click();
            
            


            // End Date
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/main/div/div/div[2]/div[1]/div[1]/div/div/div[7]/div[1]/button")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div/div[2]/div[3]/div[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/button[2]")).Click();

            // Select Type
            wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//label[contains(text(),'Select Type')]/following-sibling::div"))).Click();
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Perform();

            // Select Days
            wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//label[contains(text(),'Select Days')]/following-sibling::div"))).Click();
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Perform();

            // Select Time
            wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//label[contains(text(),'Select Time')]/following-sibling::div"))).Click();
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Perform();

            // Location
            driver.FindElement(By.XPath("//input[@placeholder='Location']")).SendKeys("Karachi");

            // Postal Code
            driver.FindElement(By.XPath("//input[@placeholder='Postal Code']")).SendKeys("74000");

            // Province/State
            driver.FindElement(By.XPath("//input[@placeholder='Province/State']")).SendKeys("Sindh");

            // Actual Price
            driver.FindElement(By.XPath("//input[@placeholder='Set Actual Price']")).SendKeys("5000");

            // Scroll to bottom and click Save
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(1000);

            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//button[contains(text(),'Save')]")));
            saveBtn.Click();

            Console.WriteLine("Program created with title: " + uniqueTitle);
        }
    }
}
