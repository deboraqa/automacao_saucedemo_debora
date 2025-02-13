using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By _usernameField = By.Id("user-name");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _errorMessageContainer = By.ClassName("error-message-container");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void PreencherUsuario(string usuario)
        {
            _driver.FindElement(_usernameField).SendKeys(usuario);
        }

        public void PreencherSenha(string senha)
        {
            _driver.FindElement(_passwordField).SendKeys(senha);
        }

        public void ClicarLogin()
        {
            _driver.FindElement(_loginButton).Click();
        }

        public string ObterMensagemDeErro()
        {
            try
            {
                _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_errorMessageContainer));
                return _driver.FindElement(_errorMessageContainer).Text.Trim();
            }
            catch (NoSuchElementException)
            {
                return "Nenhuma mensagem de erro foi exibida.";
            }
        }

        //  Novo Método: Verifica se a mensagem de erro foi exibida
        public bool ErroDeLoginFoiExibido()
        {
            try
            {
                return _driver.FindElement(_errorMessageContainer).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void LimparCampos()
        {
            _driver.FindElement(_usernameField).Clear();
            _driver.FindElement(_passwordField).Clear();
        }

        public void AguardarCampoSenhaVisivel()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_passwordField));
        }

        public void AguardarBotaoLoginVisivel()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_loginButton));
        }

        public void AguardarErroDeLogin()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_errorMessageContainer));
        }
    }
}
