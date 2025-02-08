using NUnit.Framework;
using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class SauceDemoCheckoutTest : TestBase
    {
        private LoginPage loginPage;
        private InventoryPage inventoryPage;
        private CartPage cartPage;
        private CheckoutStepOnePage checkoutStepOnePage;
        private CheckoutStepTwoPage checkoutStepTwoPage;
        private CheckoutCompletePage checkoutCompletePage;

        [SetUp]
        public void Inicializar()
        {
            if (driver == null)
            {
                throw new NullReferenceException("O WebDriver não foi inicializado corretamente.");
            }

            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            cartPage = new CartPage(driver);
            checkoutStepOnePage = new CheckoutStepOnePage(driver);
            checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WaitForPageToLoad(10);
        }

        [Test]
        public void FinalizarCompraComSucesso()
        {
            loginPage.PreencherUsuario("standard_user");
            loginPage.PreencherSenha("secret_sauce");
            loginPage.ClicarLogin();

            inventoryPage.AdicionarProdutoAoCarrinho();
            inventoryPage.AbrirCarrinho();

            cartPage.ClicarCheckout();

            checkoutStepOnePage.PreencherInformacoesCliente("Débora", "Silva", "30170-040");
            checkoutStepOnePage.ClicarContinuar();

            checkoutStepTwoPage.ClicarFinalizar();
        }

    }
}
