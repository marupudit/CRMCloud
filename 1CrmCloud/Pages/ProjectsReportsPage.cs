using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMCloud.Base;
using OpenQA.Selenium;

namespace CRMCloud.Pages
{
    public class ProjectsReportsPage : BasePage
    {
        private readonly ParallelConfig _parallelConfig;
        public ProjectsReportsPage(ParallelConfig parallelConfig) => _parallelConfig = parallelConfig;

        public IWebElement _btnRunReport => _parallelConfig.Driver.FindElement(By.XPath("//button[contains(@id, 'FilterForm_applyButton')]"));

        string _tableHeaders = "//tr[@class='listHead']/th//*[text()]";
        public void RunReport()
        {
            _parallelConfig.Driver.ClickAndWait(_btnRunReport);
        }

        public List<string> TableHeader()
        {
            List<string> headers = new List<string>();
            var xx = _parallelConfig.Driver.FindElements(By.XPath(_tableHeaders));
            foreach(IWebElement x in xx)
            {
                headers.Add(x.Text);
            }
            return headers;
        }
    }
}
