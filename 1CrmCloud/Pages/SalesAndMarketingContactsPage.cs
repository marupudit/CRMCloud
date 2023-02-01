using CRMCloud.Base;
using OpenQA.Selenium;

namespace CRMCloud.Pages
{
    public class SalesAndMarketingContactsPage: BasePage
    {
        private readonly ParallelConfig _parallelConfig;
        public SalesAndMarketingContactsPage(ParallelConfig parallelConfig) => _parallelConfig = parallelConfig;
        private By _btnCreateContact => By.XPath("//div[@class='sidebar-item']/a[contains(@href, 'EditView')]");
        private IWebElement _btnContacts => _parallelConfig.Driver.FindElement(By.XPath("//div[@class='sidebar-item']//span[text()='Contacts']"));

        public void ClickLeftMenuLabel(string leftMenuLabelName)
        {
            switch (leftMenuLabelName.ToLower())
            {
                case "create contact":
                    var element=_parallelConfig.Driver.WaitForElementIsVisible(_btnCreateContact);
                    _parallelConfig.Driver.ClickAndWait(element, WaitTime.LongWaitTime);
                    break;
                case "contacts":
                    _parallelConfig.Driver.ClickAndWait(_btnContacts, WaitTime.LongWaitTime);
                    break;
                default:
                    break;
            }
                
        }
    }
}
