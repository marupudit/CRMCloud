using AventStack.ExtentReports.Model;
using CRMCloud.Base;
using OpenQA.Selenium;

namespace CRMCloud.Pages
{
    public class SalesAndMarketingCreateContactPage:BasePage
    {
        private readonly ParallelConfig _parallelConfig;
        public SalesAndMarketingCreateContactPage(ParallelConfig parallelConfig) => _parallelConfig = parallelConfig;
        public IWebElement _txtFirstName => _parallelConfig.Driver.FindElement(By.XPath("//*[@id='DetailFormfirst_name-input']"));
        public IWebElement _txtLastName => _parallelConfig.Driver.FindElement(By.XPath("//*[@id='DetailFormlast_name-input']"));
        private IWebElement _selBusinessRole => _parallelConfig.Driver.FindElement(By.XPath("//*[@id='DetailFormbusiness_role-input-label']"));
        private IWebElement _selCategory => _parallelConfig.Driver.FindElement(By.XPath("//*[@id='DetailFormcategories-input']"));
        public IWebElement _btnSave => _parallelConfig.Driver.FindElement(By.XPath("DetailForm_save-label"));
        public void SelectBusinessRole(string businessRole)
        {
            _parallelConfig.Driver.MoveToElement(_selBusinessRole);
            _parallelConfig.Driver.ClickAndWait(_selBusinessRole, WaitTime.LongWaitTime);
            var _businessRole = _parallelConfig.Driver.FindElement(By.XPath($"//*[@id='DetailFormbusiness_role-input-popup']//*[text()='Sales']"));
            _parallelConfig.Driver.ClickAndWait(_businessRole, WaitTime.VeryLongWaitTime);
        }

        private void KeysDownOnRole(int times)
        {
            for(int i=1; i<=times; i++)
            {
                _selBusinessRole.SendKeys(Keys.ArrowDown);
            }
            _selBusinessRole.SendKeys(Keys.Enter);
        }

        public void SelectCategory(string category)
        {
            var cat=category.Split(',');
            foreach (var c in cat)
            {
                _parallelConfig.Driver.ClickAndWait(_selCategory, WaitTime.LongWaitTime);
                var _category = _parallelConfig.Driver.FindElement(By.XPath($"//*[text()='{c}']"));
                _parallelConfig.Driver.MoveToElement(_category);
                _parallelConfig.Driver.ClickAndWait(_category, WaitTime.LongWaitTime);
            }            
        }

        public void ClickSave()
        {
            _parallelConfig.Driver.MoveToElement(_btnSave);
            _parallelConfig.Driver.ClickAndWait(_btnSave, WaitTime.LongWaitTime);

        }
    }
}
