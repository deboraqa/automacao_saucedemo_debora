using OpenQA.Selenium;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutStepTwoPage
    {
        private IWebDriver driver;
        private By finishButton = By.ClassName("btn_action");

        public CheckoutStepTwoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClicarFinalizar()
        {
            driver.FindElement(finishButton).Click();
        }
    }
}
