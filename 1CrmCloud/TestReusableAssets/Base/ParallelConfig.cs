using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace CRMCloud.Base
{
    public class ParallelConfig
    {
        public IWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }

        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }

    }
}
