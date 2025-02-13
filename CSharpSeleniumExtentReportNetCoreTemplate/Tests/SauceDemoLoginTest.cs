using NUnit.Framework;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class SauceDemoLoginTest : TestBase
    {
        private LoginPage _loginPage;
        private InventoryPage _inventoryPage;

        [SetUp]
        public void Inicializar()
        {
            // Inicializa as páginas utilizando o driver já configurado em TestBase
            _loginPage = new LoginPage(driver);
            _inventoryPage = new InventoryPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void DeveFazerLoginComSucesso()
        {
            // Teste de login válido
            _loginPage.PreencherUsuario("standard_user");
            _loginPage.AguardarCampoSenhaVisivel();
            _loginPage.PreencherSenha("secret_sauce");
            _loginPage.AguardarBotaoLoginVisivel();
            _loginPage.ClicarLogin();

            // Valida se a URL contém "/inventory.html"
            Assert.That(driver.Url, Does.Contain("/inventory.html"),
                "Erro: O usuário não foi direcionado para a página de inventário após o login válido.");
        }

        [Test]
        public void TestarVariosLoginsInvalidos()
        {
            // Teste de login inválido com diversos cenários
            var loginsInvalidos = new List<(string usuario, string senha, string descricao)>
            {
                ("standard_user", "senha_errada", "Senha inválida"),
                ("usuario_invalido", "secret_sauce", "Usuário inválido"),
                ("", "secret_sauce", "Usuário vazio"),
                ("standard_user", "", "Senha vazia")
            };

            foreach (var (usuario, senha, descricao) in loginsInvalidos)
            {
                _loginPage.LimparCampos();

                if (!string.IsNullOrEmpty(usuario))
                {
                    _loginPage.PreencherUsuario(usuario);
                    _loginPage.AguardarCampoSenhaVisivel();
                }
                if (!string.IsNullOrEmpty(senha))
                {
                    _loginPage.PreencherSenha(senha);
                    _loginPage.AguardarBotaoLoginVisivel();
                }

                _loginPage.ClicarLogin();

                // Valida que o usuário permaneceu na página de login (não foi redirecionado)
                Assert.That(driver.Url.Contains("saucedemo.com"), Is.True,
                    $"Erro: {descricao} - O usuário não permaneceu na página de login.");
            }
        }

        [Test]
        public void DeveFazerLogoutComSucesso()
        {
            // Teste de logout: primeiro efetua login válido, depois realiza logout

            // Efetua login válido
            _loginPage.PreencherUsuario("standard_user");
            _loginPage.PreencherSenha("secret_sauce");
            _loginPage.ClicarLogin();

            // Aguarda que a página de inventário seja carregada
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.UrlContains("/inventory.html"));
            Assert.That(driver.Url, Does.Contain("/inventory.html"),
                "Erro: O usuário não foi direcionado para a página de inventário após o login.");

            // Realiza logout: clica no botão do menu e, em seguida, no botão 'logout'
            IWebElement burgerMenu = driver.FindElement(By.Id("react-burger-menu-btn"));
            burgerMenu.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("logout_sidebar_link")));
            IWebElement logoutButton = driver.FindElement(By.Id("logout_sidebar_link"));
            Assert.That(logoutButton.Text.ToLower().Trim(), Is.EqualTo("logout"),
                "Erro: O botão 'logout' não possui o texto correto.");

            logoutButton.Click();

            // Aguarda que o logout redirecione para a página inicial de login
            wait.Until(ExpectedConditions.UrlToBe("https://www.saucedemo.com/"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"),
                "Erro: O usuário não foi redirecionado para a página inicial após o logout.");
        }

        [TearDown]
        public void Finalizar()
        {
            driver?.Quit();
        }
    }
}
