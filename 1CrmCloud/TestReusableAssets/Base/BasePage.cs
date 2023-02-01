using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using CRMCloud.Constants;

namespace CRMCloud.Base
{
    public abstract class BasePage
    {
        public BasePage()
        {

        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

        public BasePage(IWebDriver webDriver)
        {
            if (WaitForPageToFinishLoading(webDriver) == false)
            {
                throw new Exception("Timed out while waiting for the page to load.");
            }
        }

        private static bool WaitForPageToFinishLoading(IWebDriver webDriver)
        {
            Driver = webDriver;

            IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeoutInSeconds.ExtendedTimeout));
            return wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static IWebDriver Driver { get; set; }
    }
}
