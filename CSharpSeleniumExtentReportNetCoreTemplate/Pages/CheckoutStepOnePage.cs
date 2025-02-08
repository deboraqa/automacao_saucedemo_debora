using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutStepOnePage : PageBase
    {
        private By firstNameField = By.Id("first-name");
        private By lastNameField = By.Id("last-name");
        private By postalCodeField = By.Id("postal-code");
        private By continueButton = By.Id("continue");

        public CheckoutStepOnePage(IWebDriver driver) : base(driver) { }

        public void PreencherInformacoesCliente(string nome, string sobrenome, string cep)
        {
            SendKeys(firstNameField, nome);
            SendKeys(lastNameField, sobrenome);
            SendKeys(postalCodeField, cep);
        }

        public void ClicarContinuar()
        {
            Click(continueButton);
        }
    }
}
