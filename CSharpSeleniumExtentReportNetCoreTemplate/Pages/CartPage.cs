using System; // Adicionado para Exception
using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CartPage : PageBase
    {
        private By checkoutButton = By.Id("checkout");
        private By tituloPagina = By.ClassName("title");

        public CartPage(IWebDriver driver) : base(driver) { }

        public void ClicarCheckout()
        {
            Click(checkoutButton);
        }

        public string ObterTituloPagina()
        {
            return driver.FindElement(tituloPagina).Text;
        }

        public void ValidarTituloPagina()
        {
            string titulo = ObterTituloPagina();
            if (titulo != "Your Cart")
            {
                throw new Exception($"Erro: Título da página do carrinho incorreto! Esperado: 'Your Cart', Obtido: '{titulo}'");
            }
        }
    }
}
