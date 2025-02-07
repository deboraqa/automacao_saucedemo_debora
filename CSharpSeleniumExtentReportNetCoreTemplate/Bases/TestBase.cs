using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Bases
{
    public class TestBase
    {
        protected IWebDriver driver;

        public void WaitForPageToLoad(int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForURLToContain(string partialUrl, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => d.Url.Contains(partialUrl));
        }
    }
}
