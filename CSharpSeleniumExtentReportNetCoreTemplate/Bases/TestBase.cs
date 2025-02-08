using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Bases
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            DriverFactory.CreateInstance();
            driver = DriverFactory.GetDriver();

            if (driver == null)
            {
                throw new NullReferenceException("O WebDriver não foi inicializado corretamente.");
            }

            driver.Manage().Window.Maximize();
        }

        public void WaitForPageToLoad(int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForURLToContain(string partialUrl, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => d.Url.Contains(partialUrl));
        }

        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitInstance();
        }
    }
}
