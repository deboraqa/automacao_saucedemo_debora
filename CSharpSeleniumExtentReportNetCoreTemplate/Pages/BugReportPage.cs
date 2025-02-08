using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class BugReportPage : PageBase
    {
        private By dropdownSeverity = By.Id("severity");

        public BugReportPage(IWebDriver driver) : base(driver) { }

        public void SelecionarSeveridade(string severidade)
        {
            ComboBoxSelectByVisibleText(dropdownSeverity, severidade);
        }
    }
}
