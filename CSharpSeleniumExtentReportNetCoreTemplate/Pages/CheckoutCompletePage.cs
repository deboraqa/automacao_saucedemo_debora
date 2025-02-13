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
            return GetText(tituloPagina);
        }

        public string ObterMensagemDeConfirmacao()
        {
            return GetText(mensagemConfirmacao);
        }
    }
}
