using OpenQA.Selenium;
using SpecflowNetCoreDemo.Drivers;
using SpecflowNetCoreDemo.Utils;

namespace SpecFlowDemoV2.Pages
{
    public class HomePage : BasePage
    {
        private readonly By LoginLink = By.Id("loginLink");

        public HomePage(WebDriverBuilder webDriverBuilder, SeleniumActions seleniumActions) : base(webDriverBuilder, seleniumActions)
        {
        }

        public void ClicarNolinkLogin() => _seleniumActions.Clicar(LoginLink);
    }
}