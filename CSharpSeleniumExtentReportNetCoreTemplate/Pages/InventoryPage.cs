using OpenQA.Selenium;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class InventoryPage
    {
        private IWebDriver driver;
        private By addToCartButton = By.ClassName("btn_inventory");
        private By cartButton = By.Id("shopping_cart_container");

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AdicionarProdutoAoCarrinho()
        {
            driver.FindElement(addToCartButton).Click();
        }

        public void AbrirCarrinho()
        {
            driver.FindElement(cartButton).Click();
        }
    }
}
