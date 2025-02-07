using OpenQA.Selenium;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutStepOnePage
    {
        private IWebDriver driver;
        private By firstNameField = By.Id("first-name");
        private By lastNameField = By.Id("last-name");
        private By postalCodeField = By.Id("postal-code");
        private By continueButton = By.Id("continue");

        public CheckoutStepOnePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void PreencherInformacoesCliente(string primeiroNome, string ultimoNome, string cep)
        {
            driver.FindElement(firstNameField).SendKeys(primeiroNome);
            driver.FindElement(lastNameField).SendKeys(ultimoNome);
            driver.FindElement(postalCodeField).SendKeys(cep);
        }

        public void ClicarContinuar()
        {
            driver.FindElement(continueButton).Click();
        }
    }
}
