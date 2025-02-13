using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class InventoryPage : PageBase
    {
        private By carrinhoButton = By.ClassName("shopping_cart_link");
        private By produtoAddCarrinho = By.ClassName("btn_inventory");

        public InventoryPage(IWebDriver driver) : base(driver) { }

        public void ClicarCarrinho()
        {
            Click(carrinhoButton);
        }

        public void AdicionarProdutoAoCarrinho()
        {
            Click(produtoAddCarrinho);
        }

        public bool CarrinhoVisivel()
        {
            return driver.FindElements(carrinhoButton).Count > 0; // ✅ Substituímos `ElementExists()` por uma verificação manual
        }
    }
}
