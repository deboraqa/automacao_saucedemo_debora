﻿using NUnit.Framework;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using OpenQA.Selenium;

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
            if (driver == null)
            {
                throw new InvalidOperationException("WebDriver não foi inicializado corretamente.");
            }
            _loginPage = new LoginPage(driver);
            _inventoryPage = new InventoryPage(driver);
            _cartPage = new CartPage(driver);
            _checkoutStepOnePage = new CheckoutStepOnePage(driver);
            _checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            _checkoutCompletePage = new CheckoutCompletePage(driver);

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void FinalizarCompraComSucesso()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Efetua login
            _loginPage.PreencherUsuario("standard_user");
            EsperarVisibilidade(5);
            _loginPage.PreencherSenha("secret_sauce");
            EsperarVisibilidade(5);
            _loginPage.ClicarLogin();
            EsperarVisibilidade(5);
            wait.Until(ExpectedConditions.UrlContains("/inventory.html"));

            // Adiciona dois produtos ao carrinho
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();
            EsperarVisibilidade(5);
            Assert.That(driver.FindElement(By.ClassName("shopping_cart_badge")).Text, Is.EqualTo("2"),
                "Erro: Os produtos não foram adicionados corretamente ao carrinho.");

            // Acessa o carrinho
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            wait.Until(ExpectedConditions.UrlContains("/cart.html"));
            _cartPage.ClicarCheckout();
            EsperarVisibilidade(5);

            // Checkout Step One
            _checkoutStepOnePage.PreencherInformacoesCliente("Debora", "Silva", "30170-040");
            EsperarVisibilidade(5);
            _checkoutStepOnePage.ClicarContinuar();
            EsperarVisibilidade(5);

            // Checkout Step Two
            wait.Until(ExpectedConditions.UrlContains("checkout-step-two.html"));
            _checkoutStepTwoPage.ClicarFinalizar();
            EsperarVisibilidade(5);

            // Checkout Complete
            wait.Until(ExpectedConditions.UrlContains("checkout-complete.html"));
            _checkoutCompletePage.ClicarBackHome();
            EsperarVisibilidade(5);

            // Valida redirecionamento para inventário
            wait.Until(ExpectedConditions.UrlContains("/inventory.html"));
            Assert.That(driver.Url, Does.Contain("/inventory.html"),
                "Erro: O usuário não foi redirecionado para a página de inventário após clicar em 'Back Home'.");
        }

        [TearDown]
        public void Finalizar()
        {
            driver?.Quit();
        }
    }
}