using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Bases
{
    public abstract class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver = null;
        }

        // Método de espera que aguarda até que o tempo especificado tenha decorrido
        protected void EsperarVisibilidade(int segundos)
        {
            // Armazena o tempo de início
            DateTime startTime = DateTime.Now;
            // Cria um WebDriverWait com timeout igual aos segundos desejados
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(segundos));
            // Aguarda até que o tempo atual seja igual ou superior ao tempo de início + segundos
            wait.Until(d => DateTime.Now >= startTime.AddSeconds(segundos));
        }
    }
}
