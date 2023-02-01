using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using CRMCloud.Config;
using CRMCloud.Enums;
using OpenQA.Selenium.Safari;

namespace CRMCloud.Base
{
    public class TestInitializeHook : Steps
    {
        private readonly ParallelConfig _parallelConfig;

        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        public void InitializePrerequisites()
        {
            OpenBrowser();
        }

        private IWebDriver GetWebDriver()
        {
            return Settings.BrowserType switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Safari => new SafariDriver(),
                _ => new ChromeDriver()
            };
        }
        private void OpenBrowser()
        {
            _parallelConfig.Driver = GetWebDriver();
            _parallelConfig.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _parallelConfig.Driver.Manage().Window.Maximize();
        }
    }
}
