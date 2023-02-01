using Microsoft.Extensions.Configuration;
using System.IO;

namespace CRMCloud.Config
{
    public class ConfigReader
    {
        private IConfigurationRoot configurationRoot;

        public ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            configurationRoot = builder.Build();
        }

        public void SetFrameworkSettings()
        {
            Settings.AUT = configurationRoot.GetSection("TestSettings").Get<TestSettings>().AUT;
            Settings.BrowserType = configurationRoot.GetSection("TestSettings").Get<TestSettings>().Browser;
            Settings.SeleniumGridUrl = configurationRoot.GetSection("TestSettings").Get<TestSettings>().SeleniumGridUrl;
            Settings.UseDockerGrid = configurationRoot.GetSection("TestSettings").Get<TestSettings>().UseDockerGrid;

            Settings.ExtentReportPath = configurationRoot.GetSection("ExtentReports").Get<TestSettings>().ExtentReportPath;            
        }
    }
}
