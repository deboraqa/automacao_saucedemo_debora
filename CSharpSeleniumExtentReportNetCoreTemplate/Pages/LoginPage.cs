using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class LoginPage : PageBase
    {
        private By usernameField = By.Id("user-name");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("login-button");
        private By errorMessage = By.ClassName("error-message-container");
        private By profileIcon = By.ClassName("bm-burger-button");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void PreencherUsuario(string usuario)
        {
            SendKeys(usernameField, usuario);
        }

        public void PreencherSenha(string senha)
        {
            SendKeys(passwordField, senha);
        }

        public void ClicarLogin()
        {
            Click(loginButton);
        }

        public string ObterMensagemDeErro()
        {
            return GetText(errorMessage);
        }

        public bool ValidarUsuarioLogado()
        {
            return ElementoExiste(profileIcon);
        }
    }
}
