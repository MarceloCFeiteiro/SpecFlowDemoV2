using OpenQA.Selenium;
using SpecflowNetCoreDemo.Drivers;
using SpecflowNetCoreDemo.Utils;

namespace SpecFlowDemoV2.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By LoginField = By.Id("UserName");

        private readonly By PassworField = By.Id("Password");

        private readonly By LoginButton = By.CssSelector(".btn-default");

        private readonly By EmployeeDetaislLink = By.LinkText("Employee Details");

        private readonly By LoginFailedMessageTxt = By.CssSelector(".validation-summary-errors>ul>li");

        public LoginPage(WebDriverBuilder webDriverBuilder, SeleniumActions seleniumActions) : base(webDriverBuilder, seleniumActions)
        {
        }

        public void PreencherCamposLoginPassword(string login, string senha)
        {
            _seleniumActions.EnviarTexto(LoginField, login);
            _seleniumActions.EnviarTexto(PassworField, senha);
        }

        public void ClicarNoBotaoLogin() => _seleniumActions.Clicar(LoginButton);

        public bool ValidaExibicaoLinkEmployeeDetails() => _seleniumActions.ElementoEstaVisivel(EmployeeDetaislLink);

        public string MensagemErro(string mensagem) => _seleniumActions.RetornaTexto(LoginFailedMessageTxt, mensagem);
    }
}