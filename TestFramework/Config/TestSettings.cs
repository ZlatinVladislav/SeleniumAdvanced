using TestFramework.Base;
using Newtonsoft.Json;

namespace TestFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("reportPath")]
        public string ReportPath { get; set; }

        [JsonProperty("timeOut")]
        public int TimeOut { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("aut")]
        public string AUT { get; set; }


        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }


        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("isLog")]
        public string IsLog { get; set; }


        [JsonProperty("logPath")]
        public string LogPath { get; set; }

        [JsonProperty("autConnectionString")]
        public string AUTConnectionString { get; set; }
    }
}
