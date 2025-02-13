//using NUnit.Framework;
//using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
//using CSharpSeleniumExtentReportNetCoreTemplate.Pages;

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

//        [TearDown]
//        public void Finalizar()
//        {
//            driver?.Quit();
//        }
//    }
//}
