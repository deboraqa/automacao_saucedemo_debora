using NUnit.Framework;
using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class SauceDemoLoginTest : TestBase
    {
        private LoginPage loginPage;

        [SetUp]
        public void Inicializar()
        {
            loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WaitForPageToLoad(20);
        }

        [Test]
        public void LoginComCredenciaisValidas()
        {
            loginPage.PreencherUsuario("standard_user");
            loginPage.PreencherSenha("secret_sauce");
            loginPage.ClicarLogin();
            WaitForURLToContain("inventory.html", 20);

            Assert.That(driver.Url.Contains("inventory.html"), Is.True, "Falha ao realizar login!");
        }

        [Test]
        public void LoginComUsuarioInvalido()
        {
            loginPage.PreencherUsuario("usuario_invalido");
            loginPage.PreencherSenha("secret_sauce");
            loginPage.ClicarLogin();

            Assert.That(loginPage.ObterMensagemDeErro(), Is.EqualTo("Epic sadface: Username and password do not match any user in this service"), "Usuário inválido.");
        }
    }
}
