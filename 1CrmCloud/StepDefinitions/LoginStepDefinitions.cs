using System.Data;
using AventStack.ExtentReports.Gherkin.Model;
using CRMCloud.Base;
using CRMCloud.Config;
using CRMCloud.Data;
using CRMCloud.Data.JsonDataTemplate;
using CRMCloud.Pages;
using OpenQA.Selenium;

namespace CRMCloud.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions : BaseStep
    {
        /// <summary>
        /// Creating the mapping between the Gherkin steps and actual automation logic using SpecFlow via regular expression along with assertions
        /// </summary>
        private readonly ParallelConfig _parallelConfig;
        private readonly ScenarioContext _scenarioContext;
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _parallelConfig = scenarioContext.ScenarioContainer.Resolve<ParallelConfig>();
            _scenarioContext = scenarioContext;
        }

        [Given(@"I log in to the 1CRMCould as a admin registered user")]
        public void GivenILogInToTheCRMCouldAsAAdminRegisteredUser()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            _parallelConfig.CurrentPage = new CRMCloudLoginPage(_parallelConfig);
            EnterLoginCredentials();
            SuccessfulLoginToApplication();
        }

        private void EnterLoginCredentials()
        {
            JsonDataConfiguration _jsonDataConfiguration = new JsonDataConfiguration();
            var loginDetails = _jsonDataConfiguration.ConfigureJsonData<LoginCredentails>("LoginCredentails");
            _parallelConfig.CurrentPage.As<CRMCloudLoginPage>().EnterLoginCredentails(loginDetails.UserName, loginDetails.Password);
        }

        private void SuccessfulLoginToApplication()
        {
            _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<CRMCloudLoginPage>().SuccessfulLogin();
        }

        [Given(@"I navigated to ""([^""]*)"" under ""([^""]*)""")]
        public void GivenINavigatedToUnder(string subMenuLabelName, string MainMenuLabelName)
        {
            _parallelConfig.CurrentPage.As<HomeDashBoardPage>().ClickMainMenuLabel(MainMenuLabelName);
            _parallelConfig.CurrentPage.As<HomeDashBoardPage>().ClickSubMenuLabel(subMenuLabelName);
        }

        [When(@"I enter new contact details")]
        public void WhenIEnterNewContactDetails(Table table)
        {
            var dictionary = TableExtension.ToDictionary(table);
            
            _parallelConfig.CurrentPage = new SalesAndMarketingContactsPage(_parallelConfig);
            _parallelConfig.CurrentPage.As<SalesAndMarketingContactsPage>().ClickLeftMenuLabel("Create Contact");
            _parallelConfig.CurrentPage = new SalesAndMarketingCreateContactPage(_parallelConfig);
            _parallelConfig.CurrentPage.As<SalesAndMarketingCreateContactPage>()._txtFirstName.SendKeys(dictionary["First Name"]);
            _parallelConfig.CurrentPage.As<SalesAndMarketingCreateContactPage>()._txtLastName.SendKeys(dictionary["Last Name"]);
            _parallelConfig.CurrentPage.As<SalesAndMarketingCreateContactPage>().SelectBusinessRole(dictionary["Role"]);
            _parallelConfig.CurrentPage.As<SalesAndMarketingCreateContactPage>().SelectCategory(dictionary["Category"]);
        }

        [When(@"I save the contact details")]
        public void WhenISaveTheContactDetails()
        {
            _parallelConfig.CurrentPage.As<SalesAndMarketingCreateContactPage>().ClickSave();
        }

        [Then(@"I verify the contact details created")]
        public void ThenIRecievedContactCreatedConfirmation()
        {
            _parallelConfig.CurrentPage = new HomeDashBoardPage(_parallelConfig);
            GivenINavigatedToUnder("Contacts", "Sales & Marketing");
            //search for cantact and click on the searched name
            //get name to see if it has first name and last name
            //get role to compare it with given role
            //get cateries to compare it with given categories
        }

        [When(@"I find ""([^""]*)"" report")]
        public void WhenIFindProjectProfitabilityReport(string reportName)
        {
            _parallelConfig.CurrentPage = new ReportsAndSettingsReports(_parallelConfig);
            _parallelConfig.CurrentPage=_parallelConfig.CurrentPage.As<ReportsAndSettingsReports>().FindReport(reportName);
        }

        [When(@"I run report")]
        public void WhenIRunReport()
        {
            _parallelConfig.CurrentPage.As<ProjectsReportsPage>().RunReport();
        }

        [Then(@"I verify that results were returned")]
        public void ThenIVerifyThatResultsWereReturned(Table table)
        {
            var dictionary = TableExtension.ToDictionary(table);
            var expectedHeader = dictionary["Table Header"];
            string[] expectedHeaderArray = expectedHeader.Split(',');
            List<string> expectedHeaderList= new List<string>(expectedHeaderArray);

            _parallelConfig.CurrentPage = new ProjectsReportsPage(_parallelConfig);
            List<string> actualHeadersList= _parallelConfig.CurrentPage.As<ProjectsReportsPage>().TableHeader();
            expectedHeaderList.SequenceEqual(actualHeadersList).Should().BeTrue();
        }

        int noOfRecords;

        [When(@"I select first (.*) items in the table")]
        public void WhenISelectFirstItemsInTheTable(int recordNo)
        {
            _parallelConfig.CurrentPage = new ReportsAndSettingsActivityLogs(_parallelConfig);
            _parallelConfig.Driver.WaitForPageLoaded();
            noOfRecords = _parallelConfig.CurrentPage.As<ReportsAndSettingsActivityLogs>().TotalLogs();
            Console.WriteLine("The no of records :" + noOfRecords);
            _parallelConfig.CurrentPage.As<ReportsAndSettingsActivityLogs>().SelectNoOfLogs(recordNo);
        }

        [When(@"I delete the logs")]
        public void WhenIDeleteTheLogs()
        {
            _parallelConfig.CurrentPage.As<ReportsAndSettingsActivityLogs>().deleteLogs(_parallelConfig.Driver);

        }

        [Then(@"I verify logs are deleted")]
        public void ThenIVerifyLogsAreDeleted()
        {
            int noOfRecordsLeft = _parallelConfig.CurrentPage.As<ReportsAndSettingsActivityLogs>().TotalLogs();
            Console.WriteLine("The total records after:"+noOfRecordsLeft);            
            int deletedRecords = noOfRecords - noOfRecordsLeft;
            deletedRecords.Should().Be(3);
        }


    }
}