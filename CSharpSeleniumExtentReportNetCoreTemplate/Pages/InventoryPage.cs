using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;

        private readonly By _menuButton = By.Id("react-burger-menu-btn");
        private readonly By _logoutButton = By.Id("logout_sidebar_link");
        private readonly By _addToCartButton = By.CssSelector(".btn_inventory");
        private readonly By _cartButton = By.CssSelector(".shopping_cart_link");

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AbrirMenu()
        {
            FluentWait().Until(d => d.FindElement(_menuButton)).Click();
        }

        public void ClicarLogout()
        {
            FluentWait().Until(d => d.FindElement(_logoutButton)).Click();
        }

        public void AdicionarProdutoAoCarrinho()
        {
            FluentWait().Until(d => d.FindElement(_addToCartButton)).Click();
        }

        public void ClicarCarrinho()
        {
            FluentWait().Until(d => d.FindElement(_cartButton)).Click();
        }

        public bool EstaNaPaginaDeInventario()
        {
            return _driver.Url.Contains("/inventory.html");
        }

        private WebDriverWait FluentWait()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotInteractableException));
            return wait;
        }
    }
}
