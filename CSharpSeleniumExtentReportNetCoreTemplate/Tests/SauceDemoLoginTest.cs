using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;
using System.Collections.Generic;

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
        public void TestarVariosLoginsInvalidos()
        {
            var loginsInvalidos = new List<(string usuario, string senha, string mensagemEsperada)>
            {
                ("usuario_invalido", "secret_sauce", "Epic sadface: Username and password do not match any user in this service"),
                ("standard_user", "senha_errada", "Epic sadface: Username and password do not match any user in this service"),
                ("", "secret_sauce", "Epic sadface: Username is required"),
                ("standard_user", "", "Epic sadface: Password is required")
            };

            foreach (var (usuario, senha, mensagemEsperada) in loginsInvalidos)
            {
                // ✅ Limpa os campos antes do próximo teste
                loginPage.LimparCampos();

                if (!string.IsNullOrEmpty(usuario))
                {
                    loginPage.PreencherUsuario(usuario);
                    AguardarElementoVisivel(By.Id("password"));
                }

                if (!string.IsNullOrEmpty(senha))
                {
                    loginPage.PreencherSenha(senha);
                    AguardarElementoVisivel(By.Id("login-button"));
                }

                loginPage.ClicarLogin();

                // ✅ Aguarda a mensagem de erro antes de validar
                bool erroVisivel = AguardarMensagemDeErro();
                Assert.That(erroVisivel, Is.True, $"A mensagem de erro não apareceu para login '{usuario}'.");

                // ✅ Verifica se a mensagem de erro está correta
                string mensagemErro = loginPage.ObterMensagemDeErro();
                Assert.That(mensagemErro, Is.EqualTo(mensagemEsperada),
                    $"Mensagem de erro incorreta ao tentar login com usuário: '{usuario}' e senha: '{senha}'.");

                // ✅ Valida que a URL não mudou após um login inválido
                Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"),
                    "A URL não deveria mudar após um login inválido.");
            }

            // ✅ Encerra o navegador após os testes de login inválido
            driver.Quit();
        }

        private void AguardarElementoVisivel(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        private bool AguardarMensagemDeErro()
        {
            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("error-message-container"))).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
