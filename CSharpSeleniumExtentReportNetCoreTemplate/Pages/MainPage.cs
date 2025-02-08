using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class MainPage : PageBase
    {
        public MainPage(IWebDriver driver) : base(driver) { } // ✅ Agora passa driver corretamente

        private By welcomeMessage = By.Id("welcome");
        private By logoutButton = By.Id("logout");

        public string ObterMensagemDeBoasVindas()
        {
            return GetText(welcomeMessage);
        }

        public void ClicarSair()
        {
            Click(logoutButton);
        }
    }
}
