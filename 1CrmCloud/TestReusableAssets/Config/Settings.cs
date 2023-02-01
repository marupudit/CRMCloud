using CRMCloud.Enums;

namespace CRMCloud.Config
{
    public class Settings
    {
        public static string AUT { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string SeleniumGridUrl { get; set; }
        public static bool UseDockerGrid { get; set; }

        public static string ExtentReportPath { get; set; }

    }
}
