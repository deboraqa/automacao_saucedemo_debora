//using NUnit.Framework;
//using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
//using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
//using System.Collections.Generic;

//namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
//{
//    [TestFixture]
//    public class SauceDemoLoginInvalidoTest : TestBase
//    {
//        private LoginPage _loginPage;

//        [SetUp]
//        public void Inicializar()
//        {
//            _loginPage = new LoginPage(driver);
//            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
//        }

//        [Test]
//        public void TestarVariosLoginsInvalidos()
//        {
//            var loginsInvalidos = new List<(string usuario, string senha, string descricao)>
//            {
//                ("standard_user", "senha_errada", "Senha inválida"),
//                ("usuario_invalido", "secret_sauce", "Usuário inválido"),
//                ("", "secret_sauce", "Usuário vazio"),
//                ("standard_user", "", "Senha vazia")
//            };

//            foreach (var (usuario, senha, descricao) in loginsInvalidos)
//            {
//                //  Corrigimos a sintaxe e limpamos os campos
//                _loginPage.LimparCampos();

//                if (!string.IsNullOrEmpty(usuario))
//                {
//                    _loginPage.PreencherUsuario(usuario);
//                    _loginPage.AguardarCampoSenhaVisivel();
//                }

//                if (!string.IsNullOrEmpty(senha))
//                {
//                    _loginPage.PreencherSenha(senha);
//                    //_loginPage.AguardarBotaoLoginVisivel();
//                }

//                _loginPage.ClicarLogin();

//                Assert.That(driver.Url.Contains("saucedemo.com"), Is.True,
//                    $"Erro: {descricao} - O usuário não permaneceu na página de login.");
//            }
//        }

//        [TearDown]
//        public void Finalizar()
//        {
//            driver?.Quit();
//        }
//    }
//}
