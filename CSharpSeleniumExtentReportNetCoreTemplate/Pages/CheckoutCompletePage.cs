using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutCompletePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By _backHomeButton = By.CssSelector(".btn.btn_primary.btn_small");

        public CheckoutCompletePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ClicarBackHome()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_backHomeButton)).Click();
        }
    }
}