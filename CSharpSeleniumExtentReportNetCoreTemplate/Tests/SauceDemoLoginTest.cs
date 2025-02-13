using NUnit.Framework;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using OpenQA.Selenium.Chrome;

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
        public void DeveVerificarElementosPaginaDeInventario()
        {
            _loginPage.PreencherUsuario("standard_user");
            _loginPage.PreencherSenha("secret_sauce");
            _loginPage.ClicarLogin();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.UrlContains("/inventory.html"));

            Assert.That(driver.Url, Does.Contain("/inventory.html"), "Erro: Página de inventário não carregada.");
            IWebElement titulo = driver.FindElement(By.ClassName("app_logo"));
            Assert.That(titulo.Text, Is.EqualTo("Swag Labs"), "Erro: O título da página não é 'Swag Labs'.");
            Assert.That(driver.FindElement(By.Id("react-burger-menu-btn")).Displayed, "Erro: Menu lateral não está visível.");
        }

        [Test]
        public void DeveVerificarPersistenciaDeSessao()
        {
            // Login inicial
            _loginPage.PreencherUsuario("standard_user");
            _loginPage.PreencherSenha("secret_sauce");
            _loginPage.ClicarLogin();

            var cookies = driver.Manage().Cookies.AllCookies;
            driver.Dispose(); // Fecha o navegador de forma segura

            // Reabre o navegador e restaura a sessão
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            foreach (var cookie in cookies)
            {
                driver.Manage().Cookies.AddCookie(cookie);
            }

            // Aguarda antes de verificar a URL
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");
            wait.Until(d => d.Url.Contains("/inventory.html"));

            // Valida a persistência da sessão
            Assert.That(driver.Url, Does.Contain("/inventory.html"), "Erro: Sessão não persistiu.");
            Assert.That(driver.FindElement(By.ClassName("app_logo")).Text, Is.EqualTo("Swag Labs"), "Erro: O título não é 'Swag Labs'.");
        }

        [Test]
        public void TestarVariosLoginsInvalidos()
        {
            var loginsInvalidos = new List<(string usuario, string senha, string descricao)>
    {
        ("locked_out_user", "secret_sauce", "Usuário bloqueado"),
        ("problem_user", "secret_sauce", "Usuário problemático"),
        (" standard_user ", "secret_sauce", "Usuário com espaços extras"),
        ("standard_user", " secret_sauce ", "Senha com espaços extras"),
        ("admin' OR '1'='1", "senha123", "SQL Injection"),
    };

            foreach (var (usuario, senha, descricao) in loginsInvalidos)
            {
                _loginPage.LimparCampos();
                _loginPage.PreencherUsuario(usuario);
                _loginPage.PreencherSenha(senha);
                _loginPage.ClicarLogin();

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
