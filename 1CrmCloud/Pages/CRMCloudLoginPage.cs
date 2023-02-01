using CRMCloud.Base;
using CRMCloud.Pages;
using OpenQA.Selenium;

namespace CRMCloud.Pages
{
    public class CRMCloudLoginPage:BasePage
    {
        private readonly ParallelConfig _parallelConfig;
        public CRMCloudLoginPage(ParallelConfig parallelConfig) => _parallelConfig = parallelConfig;

        private IWebElement _txtUserName => _parallelConfig.Driver.FindElement(By.Id("login_user"));
        private IWebElement _txtPassword => _parallelConfig.Driver.FindElement(By.Id("login_pass"));

        private IWebElement _btnLogin => _parallelConfig.Driver.FindElement(By.Id("login_button"));

        public void EnterLoginCredentails(string userName, string password)
        {
            _txtUserName.SendKeys(userName);
            _txtPassword.SendKeys(password);
        }

        public void ClickLogin() => _parallelConfig.Driver.ClickAndWait(_btnLogin, WaitTime.LongWaitTime);

        public HomeDashBoardPage SuccessfulLogin()
        {
            _parallelConfig.Driver.ClickAndWait(_btnLogin, WaitTime.LongWaitTime);
            return new HomeDashBoardPage(_parallelConfig);
        }      
    }
}
