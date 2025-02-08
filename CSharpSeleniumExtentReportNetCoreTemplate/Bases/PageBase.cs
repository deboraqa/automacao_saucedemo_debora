using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Bases
{
    public class PageBase
    {
        protected IWebDriver driver;
        private WebDriverWait wait;

        public PageBase(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver), "O WebDriver não pode ser null.");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Click(By by)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(by)).Click();
            PausarExecucao(2); // Pausa de 2 segundos após cada clique
        }

        public void SendKeys(By by, string text)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by)).SendKeys(text);
            PausarExecucao(1); // Pausa de 1 segundo após digitar
        }

        public string GetText(By by)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(by)).Text;
        }

        public void ComboBoxSelectByVisibleText(By by, string text)
        {
            SelectElement select = new SelectElement(wait.Until(ExpectedConditions.ElementIsVisible(by)));
            select.SelectByText(text);
            PausarExecucao(1); // Pausa de 1 segundo após selecionar item
        }

        public bool ElementoExiste(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private void PausarExecucao(int segundos)
        {
            Thread.Sleep(segundos * 1000); // Pausa de X segundos para melhor visualização dos testes
        }
    }
}
