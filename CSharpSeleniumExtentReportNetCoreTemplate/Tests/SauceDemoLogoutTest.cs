//using NUnit.Framework;
//using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
//using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
//using System;

//namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
//{
//    [TestFixture]
//    public class SauceDemoLogoutTest : TestBase
//    {
//        private LoginPage _loginPage;
//        private InventoryPage _inventoryPage;

//        [SetUp]
//        public void Inicializar()
//        {
//            // Inicializa as páginas com o driver já configurado em TestBase
//            _loginPage = new LoginPage(driver);
//            _inventoryPage = new InventoryPage(driver);
//            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
//        }

//        [Test]
//        public void DeveFazerLogoutComSucesso()
//        {
//            // Efetua o login com credenciais válidas
//            _loginPage.PreencherUsuario("standard_user");
//            _loginPage.PreencherSenha("secret_sauce");
//            _loginPage.ClicarLogin();

//            // Aguarda que a página de inventário seja carregada e valida
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            wait.Until(ExpectedConditions.UrlContains("/inventory.html"));
//            Assert.That(driver.Url, Does.Contain("/inventory.html"),
//                "Erro: O usuário não foi direcionado para a página de inventário.");

//            // Clica no botão do menu (burger menu)
//            IWebElement burgerMenu = driver.FindElement(By.Id("react-burger-menu-btn"));
//            burgerMenu.Click();

//            // Aguarda que o botão de logout esteja visível no menu
//            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("logout_sidebar_link")));

//            // Valida que o botão de logout tem o texto 'logout'
//            IWebElement logoutButton = driver.FindElement(By.Id("logout_sidebar_link"));
//            string logoutText = logoutButton.Text.ToLower().Trim();
//            Assert.That(logoutText, Is.EqualTo("logout"),
//                "Erro: O botão 'logout' não possui o texto correto.");

//            // Clica no botão de logout
//            logoutButton.Click();

//            // Aguarda o redirecionamento para a página inicial de login
//            wait.Until(ExpectedConditions.UrlToBe("https://www.saucedemo.com/"));

//            // Valida que o usuário foi redirecionado para a página de login
//            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"),
//                "Erro: O usuário não foi redirecionado para a página inicial após logout.");
//        }

//        [TearDown]
//        public void Finalizar()
//        {
//            driver?.Quit();
//        }
//    }
//}
