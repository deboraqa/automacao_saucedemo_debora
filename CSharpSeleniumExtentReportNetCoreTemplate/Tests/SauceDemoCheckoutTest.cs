using NUnit.Framework;
using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class SauceDemoCheckoutTest : TestBase
    {
        private InventoryPage inventoryPage;
        private CartPage cartPage;
        private CheckoutStepOnePage checkoutStepOnePage;
        private CheckoutStepTwoPage checkoutStepTwoPage;
        private CheckoutCompletePage checkoutCompletePage;

        [SetUp]
        public void Inicializar()
        {
            inventoryPage = new InventoryPage(driver);
            cartPage = new CartPage(driver);
            checkoutStepOnePage = new CheckoutStepOnePage(driver);
            checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WaitForPageToLoad(20);
        }

        [Test]
        public void FinalizarCompraComSucesso()
        {
            inventoryPage.AdicionarProdutoAoCarrinho();
            inventoryPage.AbrirCarrinho();
            cartPage.ClicarCheckout();
            WaitForURLToContain("cart.html", 10);

            checkoutStepOnePage.PreencherInformacoesCliente("Débora", "Silva", "30170-040");
            checkoutStepOnePage.ClicarContinuar();
            WaitForURLToContain("checkout-step-one.html", 10);

            checkoutStepTwoPage.ClicarFinalizar();
            WaitForURLToContain("checkout-step-two.html", 10);

            Assert.That(checkoutCompletePage.ValidarCompraConcluida(), Is.True, "Erro ao concluir a compra!");
            checkoutCompletePage.ClicarBackHome();
            WaitForURLToContain("inventory.html", 10);
        }
    }
}
