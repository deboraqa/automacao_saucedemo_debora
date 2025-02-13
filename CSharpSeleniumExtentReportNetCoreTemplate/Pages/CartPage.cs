using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CartPage : PageBase
    {
        private By checkoutButton = By.Id("checkout");
        private By tituloPagina = By.ClassName("title");
        private By produtoNoCarrinho = By.ClassName("inventory_item_name");

        public CartPage(IWebDriver driver) : base(driver) { }

        public void ClicarCheckout()
        {
            Click(checkoutButton);
        }

        public string ObterTituloPagina()
        {
            return GetText(tituloPagina);
        }

        public bool VerificarProdutoNoCarrinho()
        {
            return driver.FindElements(produtoNoCarrinho).Count > 0;
        }
    }
}
