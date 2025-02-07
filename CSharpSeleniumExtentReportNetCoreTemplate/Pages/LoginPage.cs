using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        // Mapeamento dos elementos
        private By usernameField = By.Id("user-name");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("login-button");
        private By errorMessage = By.ClassName("error-message-container");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Timeout de 10 segundos
        }

        public void PreencherUsuario(string usuario)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(usernameField)).SendKeys(usuario);
        }

        public void PreencherSenha(string senha)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(passwordField)).SendKeys(senha);
        }

        public void ClicarLogin()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(loginButton)).Click();
        }

        // Método adicional para compatibilidade com `LoginFlows.cs`
        public void ClicarEmLogin()
        {
            ClicarLogin(); // Mantém compatibilidade sem alterar `LoginFlows.cs`
        }

        public string ObterMensagemDeErro()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(errorMessage)).Text;
        }
    }
}
