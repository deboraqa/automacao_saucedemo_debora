using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Flows
{
    public class LoginFlows
    {
        #region Page Object and Constructor
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginFlows(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
        }
        #endregion

        public void EfetuarLogin(string username, string password)
        {
            loginPage.PreencherUsuario(username);
            loginPage.PreencherSenha(password);
            loginPage.ClicarLogin(); // Corrigido: método correto da LoginPage
        }
    }
}
