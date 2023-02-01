using CRMCloud.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using SeleniumExtras.WaitHelpers;

namespace CRMCloud.Pages
{
    public class ReportsAndSettingsActivityLogs : BasePage
    {
        private readonly ParallelConfig _parallelConfig;
        public ReportsAndSettingsActivityLogs(ParallelConfig parallelConfig) => _parallelConfig = parallelConfig;

        public IWebElement _btnActions => _parallelConfig.Driver.FindElement(By.XPath("//button[contains(@id, 'ActionButtonHead')]"));
        public IWebElement _btnActionsDelete => _parallelConfig.Driver.FindElement(By.XPath("//button[contains(@id, 'ActionButtonHead-popup')]//div[text()='Delete']"));
        public IWebElement _delete => _parallelConfig.Driver.FindElement(By.XPath("//div[contains(@id, 'ActionButtonHead-popup')]//div[text()='Delete']"));

        string _xpathLogsCheckBoxes = "//tbody/tr//input[@type='checkbox']";

        string _countTotalLogs ="//div[@class='card-header panel-subheader listview-header']//*[@class='text-number'][2]";
        public int TotalLogs()
        {
            string countTemp= _parallelConfig.Driver.FindElement(By.XPath(_countTotalLogs)).Text;
            return Int32.Parse(countTemp.Replace(",", ""));
        }
        public void SelectNoOfLogs(int noOfLogs)
        {
            Thread.Sleep(3000);
            var checkBoxes = _parallelConfig.Driver.FindElements(By.XPath(_xpathLogsCheckBoxes));
            int no = 0;
            foreach (var checkbox in checkBoxes)
            {
                checkbox.Click();
                no++;
                if(no>=noOfLogs) { break; }
            }
        }

        public void deleteLogs(IWebDriver driver)
        {
            driver.WaitForPageLoaded();
            _parallelConfig.Driver.ClickAndWait(_btnActions, WaitTime.LongWaitTime);
            _parallelConfig.Driver.ClickAndWait(_delete, WaitTime.LongWaitTime);
            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, WaitTime.VeryLongWaitTime);
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = _parallelConfig.Driver.SwitchTo().Alert();
            alert.Accept();
        }

    }
}
