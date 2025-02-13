using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
        private readonly By _loginLogo = By.CssSelector(".login_logo");

        // ? Construtor seguro
        public LoginPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver), "WebDriver não pode ser nulo.");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
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

        public void LimparCampos()
        {
            _driver.FindElement(_usernameField).Clear();
            _driver.FindElement(_passwordField).Clear();
        }

        public void AguardarCampoSenhaVisivel()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_passwordField));
        }

        public void AguardarBotaoLoginVisivel()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_loginButton));
        }

        public bool EstaNaPaginaDeLogin()
        {
            try
            {
                bool urlValida = _driver.Url.Equals("https://www.saucedemo.com/");
                bool logoVisivel = _driver.FindElement(_loginLogo).Displayed;
                bool tituloCorreto = _driver.FindElement(_loginLogo).Text.Trim() == "Swag Labs";

                return urlValida || (logoVisivel && tituloCorreto);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
