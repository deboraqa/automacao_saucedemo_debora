using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Flows
{
    public class LoginFlows
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;

        public LoginFlows(IWebDriver driver)
        {
            this.driver = driver;
            this.loginPage = new LoginPage(driver);
        }

        public void RealizarLogin(string usuario, string senha)
        {
            loginPage.LimparCampos();
            loginPage.PreencherUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarLogin();
        }
    }
}
