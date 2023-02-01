using CRMCloud.Base;
using OpenQA.Selenium;

namespace CRMCloud.Pages
{
    public class HomeDashBoardPage : BasePage
    {
        private readonly ParallelConfig _parallelConfig;
        public HomeDashBoardPage(ParallelConfig parallelConfig) => _parallelConfig = parallelConfig;
        private IWebElement _btnPopUpClose => _parallelConfig.Driver.FindElement(By.XPath("//div[@class='uii uii-cancel uii-lg active-icon dialog-close']"));

        public void AcceptPopUp()
        {
            if (_btnPopUpClose.Displayed)
            {
                _parallelConfig.Driver.ClickAndWait(_btnPopUpClose, WaitTime.LongWaitTime);
            }
        }

        public void ClickMainMenuLabel(string mainMenuLabelName)
        {
            var _mainMenuLabelId = _parallelConfig.Driver.FindElement(By.XPath($"//a[contains(@id,'grouptab')]//div[@class='menu-tab-label'][normalize-space()='{mainMenuLabelName}']"));
            _parallelConfig.Driver.ClickAndWait(_mainMenuLabelId, WaitTime.LongWaitTime);

        }

        public void ClickSubMenuLabel(string subMenuLabelName)
        {
            var _subMenuLabelId = _parallelConfig.Driver.FindElement(By.XPath($"//a[normalize-space()='{subMenuLabelName}']"));
            _parallelConfig.Driver.ClickAndWait(_subMenuLabelId, WaitTime.LongWaitTime);
        }
    }
}
