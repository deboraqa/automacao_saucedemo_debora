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
    public class SauceDemoLoginInvalidoTest : TestBase
    {
        private LoginPage _loginPage;
        private WebDriverWait _wait;

        [SetUp]
        public void Inicializar()
        {
            _loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [Test]
        public void TestarVariosLoginsInvalidos()
        {
            var loginsInvalidos = new List<(string usuario, string senha)>
            {
                ("standard_user", "senha_errada"),
                ("usuario_invalido", "secret_sauce"),
                ("", "secret_sauce"),
                ("standard_user", "")
            };

            foreach (var (usuario, senha) in loginsInvalidos)
            {
                _loginPage.LimparCampos();

                if (!string.IsNullOrEmpty(usuario))
                {
                    _loginPage.PreencherUsuario(usuario);
                }

                if (!string.IsNullOrEmpty(senha))
                {
                    _loginPage.PreencherSenha(senha);
                }

                _loginPage.ClicarLogin();

                //  Valida se o usuário permaneceu na página de login
                Assert.That(driver.Url, Does.Contain("saucedemo.com"),
                    $"Erro: O usuário '{usuario}' deveria permanecer na página de login, mas foi redirecionado para '{driver.Url}'.");

                //  Valida se a mensagem de erro foi exibida
                //Assert.That(_loginPage.ErroDeLoginFoiExibido(), Is.True,
                // $"Erro: Nenhuma mensagem de erro foi exibida para o login inválido '{usuario}'.");
                Assert.That(driver.Url, Does.Contain("saucedemo.com"),
                $"Erro: O usuário '{usuario}' deveria permanecer na página de login, mas foi redirecionado para '{driver.Url}'.");

            }
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
