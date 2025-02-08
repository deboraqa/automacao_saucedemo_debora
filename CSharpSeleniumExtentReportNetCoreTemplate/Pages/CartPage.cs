using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CartPage : PageBase
    {
        private By checkoutButton = By.Id("checkout");
        private By productName = By.ClassName("inventory_item_name");

        public CartPage(IWebDriver driver) : base(driver) { }

        public void ClicarCheckout()
        {
            Click(checkoutButton);
        }

        public string ObterNomeProduto()
        {
            return GetText(productName);
        }
    }
}
