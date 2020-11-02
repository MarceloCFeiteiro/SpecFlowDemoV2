using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecflowNetCoreDemo.Drivers
{
    [Binding]
    public class WebDriverBuilder
    {
        private readonly Lazy<IWebDriver> webDriver;

        public IWebDriver WebDriver
        {
            get { return webDriver.Value; }
        }

        public WebDriverBuilder()
        {
            webDriver = BeforeScenario();
        }

        [BeforeScenario]
        public Lazy<IWebDriver> BeforeScenario()
        {
            return new Lazy<IWebDriver>(() => CreateWebDriver());
        }

        [AfterScenario]
        public void Dispose()
        {
            webDriver.Value.Quit();
        }

        private IWebDriver CreateWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--headless");

            return new ChromeDriver(options);
        }
    }
}