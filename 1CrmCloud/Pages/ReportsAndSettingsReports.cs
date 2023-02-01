using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMCloud.Base;
using OpenQA.Selenium;

namespace CRMCloud.Pages
{
    public class ReportsAndSettingsReports :BasePage
    {
        private readonly ParallelConfig _parallelConfig;
        public ReportsAndSettingsReports(ParallelConfig parallelConfig) => _parallelConfig = parallelConfig;

        public IWebElement _txtSearchField => _parallelConfig.Driver.FindElement(By.XPath("//*[@id='filter_text']"));


        public ProjectsReportsPage FindReport(string reportName)
        {
            _txtSearchField.SendKeys(reportName);

            IWebElement _report = _parallelConfig.Driver.FindElement(By.XPath("//a[text()='Project Profitability']"));
            _parallelConfig.Driver.ClickAndWait(_report, WaitTime.LongWaitTime);
            return new ProjectsReportsPage(_parallelConfig);
        }
    }
}
