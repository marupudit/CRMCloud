using OpenQA.Selenium;
using CRMCloud.Constants;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using System.Threading;
using System.Diagnostics;

namespace CRMCloud.Base
{
    public static class WebElementExtensions
    {

        public static void Click(IWebElement element)
        {
          element.Click();
        }

        public static void ClickAndWait(this IWebDriver driver, IWebElement element, TimeSpan? timeout = null)
        {
            if (timeout == null)
            {
                timeout = TimeSpan.FromSeconds(30);
            }
            Click(element);
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan)timeout;
            driver.WaitForPageLoaded();
        }

        public static IWebElement WaitForElementIsVisible(this IWebDriver driver, By locator, int timeoutInSeconds = TimeoutInSeconds.ControlTimeout)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

        }

        public static void MoveToElement(this IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan)TimeSpan.FromSeconds(5);
        }

        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 10);
            Thread.Sleep(2000);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            LoopingWait(obj, timeOut, execute, stopWatch);

            static void LoopingWait<T>(T obj, int timeOut, Func<T, bool> execute, Stopwatch stopWatch)
            {
                while (stopWatch.ElapsedMilliseconds < timeOut)
                {
                    if (execute(obj))
                    {
                        break;
                    }
                }
            }
        }

    }
}
