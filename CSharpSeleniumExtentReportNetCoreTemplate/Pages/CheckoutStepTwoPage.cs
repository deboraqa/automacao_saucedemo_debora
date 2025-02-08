using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CheckoutStepTwoPage : PageBase
    {
        private By finishButton = By.Id("finish");

        public CheckoutStepTwoPage(IWebDriver driver) : base(driver) { }

        public void ClicarFinalizar()
        {
            Click(finishButton);
        }
    }
}
