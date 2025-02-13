using NUnit.Framework;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class SauceDemoCheckoutTest : TestBase
    {
        private LoginPage _loginPage;
        private InventoryPage _inventoryPage;
        private CartPage _cartPage;
        private CheckoutStepOnePage _checkoutStepOnePage;
        private CheckoutStepTwoPage _checkoutStepTwoPage;
        private CheckoutCompletePage _checkoutCompletePage;

        [SetUp]
        public void Inicializar()
        {
            _loginPage = new LoginPage(driver);
            _inventoryPage = new InventoryPage(driver);
            _cartPage = new CartPage(driver);
            _checkoutStepOnePage = new CheckoutStepOnePage(driver);
            _checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            _checkoutCompletePage = new CheckoutCompletePage(driver);

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            FazerLogin("standard_user", "secret_sauce", esperarErro: false);
        }

        [Test]
        public void FinalizarCompraComSucesso()
        {
            _inventoryPage.AdicionarProdutoAoCarrinho();
            _inventoryPage.ClicarCarrinho();
            _cartPage.ClicarCheckout();
            _checkoutStepOnePage.PreencherInformacoesCliente("Debora", "Silva", "30170-040");
            _checkoutStepOnePage.ClicarContinuar();
            _checkoutStepTwoPage.ClicarFinalizar();

            Assert.That(_checkoutCompletePage.ObterMensagemDeConfirmacao(), Is.EqualTo("Thank you for your order!"));
        }

        private void FazerLogin(string usuario, string senha, bool esperarErro)
        {
            _loginPage.PreencherUsuario(usuario);
            _loginPage.AguardarCampoSenhaVisivel();
            _loginPage.PreencherSenha(senha);
            _loginPage.AguardarBotaoLoginVisivel();
            _loginPage.ClicarLogin();

            if (esperarErro)
            {
                _loginPage.AguardarErroDeLogin();
            }
        }
    }
}
