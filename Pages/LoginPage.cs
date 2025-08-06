using OpenQA.Selenium;

namespace EnrichKidAdminAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string email, string password)
        {
            driver.Navigate().GoToUrl("https://enrichkid.ca/login");

            driver.FindElement(By.XPath("/html/body/section/div/div/div/form/div/div[1]/div/input")).SendKeys(email);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/form/div/div[2]/div/input")).SendKeys(password);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/form/div/button")).Click();

            Console.WriteLine("Login attempted with email: " + email);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);



           

        }
    }
}
