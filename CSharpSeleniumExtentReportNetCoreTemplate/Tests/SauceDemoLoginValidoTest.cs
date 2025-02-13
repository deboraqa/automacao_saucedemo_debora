using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class SauceDemoLoginValidoTest : TestBase
    {
        private LoginPage loginPage;
        private WebDriverWait wait;

        [SetUp]
        public void Inicializar()
        {
            loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginComCredenciaisValidas()
        {
            loginPage.PreencherUsuario("standard_user");
            loginPage.AguardarCampoSenhaVisivel();
            loginPage.PreencherSenha("secret_sauce");
            loginPage.AguardarBotaoLoginVisivel();
            loginPage.ClicarLogin(); // ❌ Não chamamos `AguardarMensagemDeErro()`

            // ✅ Valida que o login foi bem-sucedido
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"),
                "Erro: O usuário não foi redirecionado corretamente para a página de inventário.");
        }

        [TearDown]
        public void Finalizar()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
