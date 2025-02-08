using System; // Adicionado para Exception
using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutCompletePage : PageBase
    {
        private By tituloPagina = By.ClassName("title");
        private By mensagemConfirmacao = By.ClassName("complete-header");

        public CheckoutCompletePage(IWebDriver driver) : base(driver) { }

        public string ObterTituloPagina()
        {
            return driver.FindElement(tituloPagina).Text;
        }

        public void ValidarTituloPagina()
        {
            string titulo = ObterTituloPagina();
            if (titulo != "Checkout: Complete!")
            {
                throw new Exception($"Erro: Título da página Checkout Complete incorreto! Esperado: 'Checkout: Complete!', Obtido: '{titulo}'");
            }
        }

        public string ObterMensagemDeConfirmacao()
        {
            return driver.FindElement(mensagemConfirmacao).Text;
        }
    }
}
