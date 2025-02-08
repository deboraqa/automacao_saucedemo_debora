using System; // Adicionado para Exception
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
            return driver.FindElement(tituloPagina).Text;
        }

        public void ValidarTituloPagina()
        {
            string titulo = ObterTituloPagina();
            if (titulo != "Checkout: Your Information")
            {
                throw new Exception($"Erro: Título da página Checkout Step One incorreto! Esperado: 'Checkout: Your Information', Obtido: '{titulo}'");
            }
        }

        public void PreencherInformacoesCliente(string nome, string sobrenome, string cep)
        {
            driver.FindElement(nomeField).Clear();
            driver.FindElement(nomeField).SendKeys(nome);

            driver.FindElement(sobrenomeField).Clear();
            driver.FindElement(sobrenomeField).SendKeys(sobrenome);

            driver.FindElement(cepField).Clear();
            driver.FindElement(cepField).SendKeys(cep);
        }

        public void ClicarContinuar()
        {
            driver.FindElement(continuarButton).Click();
        }
    }
}
