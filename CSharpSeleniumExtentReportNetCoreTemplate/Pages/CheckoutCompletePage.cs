using OpenQA.Selenium;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutCompletePage
    {
        private IWebDriver driver;
        private By backHomeButton = By.ClassName("btn_primary");

        public CheckoutCompletePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool ValidarCompraConcluida()
        {
            return driver.Url.Contains("checkout-complete.html");
        }

        public void ClicarBackHome()
        {
            driver.FindElement(backHomeButton).Click();
        }
    }
}
