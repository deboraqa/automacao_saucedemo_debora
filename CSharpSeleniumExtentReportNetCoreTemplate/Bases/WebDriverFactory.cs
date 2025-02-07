using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;



namespace CSharpSeleniumExtentReportNetCoreTemplate.Bases
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }
    }
}
