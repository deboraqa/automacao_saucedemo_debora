using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutCompletePage : PageBase
    {
        private By mensagemConfirmacao = By.CssSelector(".complete-header");

        public CheckoutCompletePage(IWebDriver driver) : base(driver) { }

        public bool ValidarCompraConcluida()
        {
            return ElementoExiste(mensagemConfirmacao);
        }

        public string ObterMensagemConfirmacao()
        {
            return GetText(mensagemConfirmacao);
        }
    }
}
