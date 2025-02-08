using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;

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
        private WebDriverWait wait;

        [SetUp]
        public void Inicializar()
        {
            if (driver == null)
            {
                throw new NullReferenceException("O WebDriver não foi inicializado corretamente.");
            }

            inventoryPage = new InventoryPage(driver);
            cartPage = new CartPage(driver);
            checkoutStepOnePage = new CheckoutStepOnePage(driver);
            checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FinalizarCompraComSucesso()
        {
            // Realizar Login
            inventoryPage.PreencherUsuario("standard_user");
            AguardarElementoVisivel(By.Id("password"));
            inventoryPage.PreencherSenha("secret_sauce");
            AguardarElementoVisivel(By.Id("login-button"));
            inventoryPage.ClicarLogin();
            AguardarMudancaDeUrl("inventory.html");

            // Adicionar produto ao carrinho
            inventoryPage.AdicionarProdutoAoCarrinho();
            inventoryPage.ClicarCarrinho();
            AguardarMudancaDeUrl("cart.html");

            // ✅ Validar título da página do carrinho
            Assert.That(cartPage.ObterTituloPagina(), Is.EqualTo("Your Cart"),
                "O título da página do carrinho não está correto.");

            // Iniciar checkout
            cartPage.ClicarCheckout();
            AguardarMudancaDeUrl("checkout-step-one.html");

            // ✅ Validar título da página Checkout Step One
            Assert.That(checkoutStepOnePage.ObterTituloPagina(), Is.EqualTo("Checkout: Your Information"),
                "O título da página de informações do checkout não está correto.");

            // Preencher informações do cliente
            checkoutStepOnePage.PreencherInformacoesCliente("Debora", "Silva", "30170-040");
            checkoutStepOnePage.ClicarContinuar();
            AguardarMudancaDeUrl("checkout-step-two.html");

            // ✅ Validar título da página Checkout Step Two
            Assert.That(checkoutStepTwoPage.ObterTituloPagina(), Is.EqualTo("Checkout: Overview"),
                "O título da página de resumo do checkout não está correto.");

            // Finalizar compra
            checkoutStepTwoPage.ClicarFinalizar();
            AguardarMudancaDeUrl("checkout-complete.html");

            // ✅ Validar título da página de confirmação do checkout
            Assert.That(checkoutCompletePage.ObterTituloPagina(), Is.EqualTo("Checkout: Complete!"),
                "O título da página de finalização do checkout não está correto.");

            // ✅ Validar mensagem de confirmação
            Assert.That(checkoutCompletePage.ObterMensagemDeConfirmacao(), Is.EqualTo("Thank you for your order!"),
                "A mensagem de confirmação do pedido não está correta.");
        }

        private void AguardarElementoVisivel(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        private void AguardarMudancaDeUrl(string urlParcial)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(urlParcial));
        }
    }
}
