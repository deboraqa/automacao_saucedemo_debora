using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutStepOnePage : PageBase
    {
        private By tituloPagina = By.ClassName("title");
        private By nomeField = By.Id("first-name");
        private By sobrenomeField = By.Id("last-name");
        private By cepField = By.Id("postal-code");
        private By continuarButton = By.Id("continue");

        public CheckoutStepOnePage(IWebDriver driver) : base(driver) { }

        public string ObterTituloPagina()
        {
            return GetText(tituloPagina);
        }

        public void PreencherInformacoesCliente(string nome, string sobrenome, string cep)
        {
            SendKeys(nomeField, nome);
            SendKeys(sobrenomeField, sobrenome);
            SendKeys(cepField, cep);
        }

        public void ClicarContinuar()
        {
            Click(continuarButton);
        }
    }
}
