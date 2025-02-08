using System; // Adicionado para Exception
using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutStepTwoPage : PageBase
    {
        private By tituloPagina = By.ClassName("title");
        private By finalizarButton = By.Id("finish");

        public CheckoutStepTwoPage(IWebDriver driver) : base(driver) { }

        public string ObterTituloPagina()
        {
            return driver.FindElement(tituloPagina).Text;
        }

        public void ValidarTituloPagina()
        {
            string titulo = ObterTituloPagina();
            if (titulo != "Checkout: Overview")
            {
                throw new Exception($"Erro: Título da página Checkout Step Two incorreto! Esperado: 'Checkout: Overview', Obtido: '{titulo}'");
            }
        }

        public void ClicarFinalizar()
        {
            driver.FindElement(finalizarButton).Click();
        }
    }
}
