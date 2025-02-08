using OpenQA.Selenium;
using CSharpSeleniumExtentReportNetCoreTemplate.Bases;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class InventoryPage : PageBase
    {
        private By usernameField = By.Id("user-name");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("login-button");
        private By carrinhoButton = By.ClassName("shopping_cart_link");
        private By produtoAddCarrinho = By.ClassName("btn_inventory");

        public InventoryPage(IWebDriver driver) : base(driver) { }

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

        public void ClicarCarrinho()
        {
            Click(carrinhoButton);
        }

        public void AdicionarProdutoAoCarrinho()
        {
            Click(produtoAddCarrinho);
        }
    }
}
