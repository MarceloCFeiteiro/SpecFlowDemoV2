using SpecflowNetCoreDemo.Drivers;
using SpecflowNetCoreDemo.Utils;
using System;

namespace SpecFlowDemoV2.Pages
{
    public class BasePage
    {
        private readonly WebDriverBuilder _webDriverBuilder;
        protected readonly SeleniumActions _seleniumActions;

        public BasePage(WebDriverBuilder webDriverBuilder, SeleniumActions seleniumActions)
        {
            _webDriverBuilder = webDriverBuilder;
            _seleniumActions = seleniumActions;
        }

        public void NavegaParaPagina(string url)
        {
            _webDriverBuilder.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _webDriverBuilder.WebDriver.Navigate().GoToUrl(url);
        }
    }
}