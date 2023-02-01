using Newtonsoft.Json;
using CRMCloud.Enums;

namespace CRMCloud.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("aut")]
        public string AUT { get; set; }

        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }

        [JsonProperty("seleniumGridUrl")]
        public string SeleniumGridUrl { get; set; }

        [JsonProperty("useDockerGrid")]
        public bool UseDockerGrid { get; set; }       

        [JsonProperty("extentReportPath")]
        public string ExtentReportPath { get; set; }  
        

    }
}
