using CSharpSeleniumExtentReportNetCoreTemplate.Pages;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Flows
{
    public class LoginFlows
    {
        private LoginPage loginPage;

        public LoginFlows(LoginPage loginPage)
        {
            this.loginPage = loginPage;
        }

        public void EfetuarLogin(string usuario, string senha)
        {
            loginPage.PreencherUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarLogin();
        }
    }
}
