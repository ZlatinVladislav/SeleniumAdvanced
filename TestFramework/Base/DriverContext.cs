namespace TestFramework.Base
{
    public class DriverContext
    {

        public readonly SeleniumDriver _webDriverConfig;

        public DriverContext(SeleniumDriver webDriverConfig)
        {
            _webDriverConfig = webDriverConfig;
        }


        public void GoToUrl(string url)
        {
            _webDriverConfig.Driver.Url = url;
        }


        public static Browser Browser { get; set; }

    }
}
