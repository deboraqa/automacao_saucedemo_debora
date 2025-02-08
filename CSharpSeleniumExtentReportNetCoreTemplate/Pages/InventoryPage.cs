using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class InventoryPage : PageBase
    {
        private By firstProductAddButton = By.CssSelector(".inventory_item button");
        private By cartIcon = By.Id("shopping_cart_container");

        public InventoryPage(IWebDriver driver) : base(driver) { }

        public void AdicionarProdutoAoCarrinho()
        {
            Click(firstProductAddButton);
        }

        public void AbrirCarrinho()
        {
            Click(cartIcon);
        }
    }
}
