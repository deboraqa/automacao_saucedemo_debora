using CSharpSeleniumExtentReportNetCoreTemplate.Pages;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Flows
{
    public class CartFlows
    {
        private CartPage cartPage;

        public CartFlows(CartPage cartPage)
        {
            this.cartPage = cartPage;
        }

        public void FinalizarCompra()
        {
            cartPage.ClicarCheckout();
        }
    }
}
