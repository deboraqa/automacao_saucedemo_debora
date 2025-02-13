using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutStepTwoPage : PageBase
    {
        private By tituloPagina = By.ClassName("title");
        private By finalizarButton = By.Id("finish");
        private By totalPedido = By.ClassName("summary_total_label");

        public CheckoutStepTwoPage(IWebDriver driver) : base(driver) { }

        public string ObterTituloPagina()
        {
            return GetText(tituloPagina);
        }

        public void ClicarFinalizar()
        {
            Click(finalizarButton);
        }

        public string ObterTotalPedido()
        {
            string totalTexto = GetText(totalPedido);
            return totalTexto.Replace("Total: ", "").Trim(); // 🔧 Remove o prefixo "Total: "
        }
    }
}
