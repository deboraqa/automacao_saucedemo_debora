using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Helpers
{
    public class DriverFactory
    {
        private static IWebDriver INSTANCE;

        public static void CreateInstance()
        {
            if (INSTANCE == null)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");

                // Definir o caminho do ChromeDriver
                string driverPath = @"C:\Users\deboraSilva\source\repos\csharp-selenium-nunit-web-tests-main\CSharpSeleniumExtentReportNetCoreTemplate\drivers\";

                // Criar a instância do ChromeDriver
                INSTANCE = new ChromeDriver(driverPath, options);

                // Adicionar espera implícita para cada ação do WebDriver
                INSTANCE.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            }
        }

        public static IWebDriver GetDriver()
        {
            if (INSTANCE == null)
            {
                throw new NullReferenceException("O WebDriver não foi inicializado. Chame 'CreateInstance()' primeiro.");
            }
            return INSTANCE;
        }

        public static void QuitInstance()
        {
            if (INSTANCE != null)
            {
                INSTANCE.Quit();
                INSTANCE.Dispose();
                INSTANCE = null;
            }
        }
    }
}
