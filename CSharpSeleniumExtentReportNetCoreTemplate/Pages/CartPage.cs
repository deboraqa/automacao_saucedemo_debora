using OpenQA.Selenium;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CartPage
    {
        private IWebDriver driver;
        private By checkoutButton = By.Id("checkout");

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClicarCheckout()
        {
            driver.FindElement(checkoutButton).Click();
        }
    }
}
