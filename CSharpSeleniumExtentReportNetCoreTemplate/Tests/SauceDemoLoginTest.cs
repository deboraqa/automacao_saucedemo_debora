using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class SauceDemoLoginTest : TestBase
    {
        private LoginPage loginPage;
        private WebDriverWait wait;

        [SetUp]
        public void Inicializar()
        {
            if (driver == null)
            {
                throw new NullReferenceException("O WebDriver não foi inicializado corretamente.");
            }

            loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginComCredenciaisValidas()
        {
            loginPage.PreencherUsuario("standard_user");
            AguardarElementoVisivel(By.Id("password"));

            loginPage.PreencherSenha("secret_sauce");
            AguardarElementoVisivel(By.Id("login-button"));

            loginPage.ClicarLogin();
            AguardarMudancaDeUrl("inventory.html");

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"),
                "A URL após o login não está correta.");

            Assert.That(loginPage.ValidarUsuarioLogado(), Is.True, "O login não foi realizado com sucesso!");
        }

        [Test]
        public void LoginComUsuarioInvalido()
        {
            loginPage.PreencherUsuario("usuario_invalido");
            AguardarElementoVisivel(By.Id("password"));

            loginPage.PreencherSenha("secret_sauce");
            AguardarElementoVisivel(By.Id("login-button"));

            loginPage.ClicarLogin();
            AguardarElementoVisivel(By.ClassName("error-message-container"));

            string mensagemErro = loginPage.ObterMensagemDeErro();
            Assert.That(mensagemErro, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"),
                "Mensagem de erro incorreta ao tentar login com usuário inválido.");

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"),
                "A URL não deveria mudar após um login inválido.");
        }

        [Test]
        public void LoginComSenhaInvalida()
        {
            loginPage.PreencherUsuario("standard_user");
            AguardarElementoVisivel(By.Id("password"));

            loginPage.PreencherSenha("senha_errada");
            AguardarElementoVisivel(By.Id("login-button"));

            loginPage.ClicarLogin();
            AguardarElementoVisivel(By.ClassName("error-message-container"));

            string mensagemErro = loginPage.ObterMensagemDeErro();
            Assert.That(mensagemErro, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"),
                "Mensagem de erro incorreta ao tentar login com senha inválida.");

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"),
                "A URL não deveria mudar após um login inválido.");
        }

        [Test]
        public void LoginComCamposVazios()
        {
            loginPage.ClicarLogin();
            AguardarElementoVisivel(By.ClassName("error-message-container"));

            string mensagemErro = loginPage.ObterMensagemDeErro();
            Assert.That(mensagemErro, Is.EqualTo("Epic sadface: Username is required"),
                "Mensagem de erro incorreta ao tentar login com campos vazios.");

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"),
                "A URL não deveria mudar após um login inválido.");
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
