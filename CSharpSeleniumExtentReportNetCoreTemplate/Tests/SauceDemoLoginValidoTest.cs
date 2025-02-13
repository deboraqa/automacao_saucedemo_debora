//using NUnit.Framework;
//using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
//using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium;
//using SeleniumExtras.WaitHelpers;
//using System;

//namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
//{
//    [TestFixture]
//    public class SauceDemoLoginValidoTest : TestBase
//    {
//        private LoginPage _loginPage;

//        [SetUp]
//        public void Inicializar()
//        {
//            _loginPage = new LoginPage(driver);
//            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
//        }

//        [Test]
//        public void DeveFazerLoginComSucesso()
//        {
//            // Aguarda 2 segundos para visualização antes de preencher
//            EsperarVisibilidade(2);
//            _loginPage.PreencherUsuario("standard_user");

//            EsperarVisibilidade(2);
//            _loginPage.AguardarCampoSenhaVisivel();
//            _loginPage.PreencherSenha("secret_sauce");

//            EsperarVisibilidade(2);
//            _loginPage.AguardarBotaoLoginVisivel();
//            _loginPage.ClicarLogin();

//            // Aguarda 3 segundos para visualizar a mudança de página
//            EsperarVisibilidade(3);
//            Assert.That(driver.Url, Does.Contain("/inventory.html"),
//                "Erro: O usuário não foi direcionado para a página de inventário.");
//        }

//        [Test]
//        public void DeveVerificarElementosPaginaDeInventario()
//        {
//            _loginPage.PreencherUsuario("standard_user");
//            _loginPage.PreencherSenha("secret_sauce");
//            _loginPage.ClicarLogin();

//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            wait.Until(ExpectedConditions.UrlContains("/inventory.html"));

//            Assert.That(driver.Url, Does.Contain("/inventory.html"), "Erro: Página de inventário não carregada.");
//            IWebElement titulo = driver.FindElement(By.ClassName("app_logo"));
//            Assert.That(titulo.Text, Is.EqualTo("Swag Labs"), "Erro: O título da página não é 'Swag Labs'.");
//            Assert.That(driver.FindElement(By.Id("react-burger-menu-btn")).Displayed, "Erro: Menu lateral não está visível.");
//        }

//        [Test]
//        public void DeveVerificarPersistenciaDeSessao()
//        {
//            _loginPage.PreencherUsuario("standard_user");
//            _loginPage.PreencherSenha("secret_sauce");
//            _loginPage.ClicarLogin();

//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            wait.Until(ExpectedConditions.UrlContains("/inventory.html"));
//            Assert.That(driver.Url, Does.Contain("/inventory.html"), "Erro: Login não foi bem-sucedido.");

//            driver.Quit(); // Fecha o navegador

//            driver = new ChromeDriver(); // Reabre o navegador
//            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");

//            // Verifica se a sessão foi mantida
//            Assert.That(driver.Url, Does.Contain("/inventory.html"), "Erro: Sessão não persistiu.");
//            Assert.That(driver.FindElement(By.ClassName("app_logo")).Text, Is.EqualTo("Swag Labs"), "Erro: O título não é 'Swag Labs'.");
//        }

//        [TearDown]
//        public void Finalizar()
//        {
//            driver?.Quit();
//        }
//    }
//}
