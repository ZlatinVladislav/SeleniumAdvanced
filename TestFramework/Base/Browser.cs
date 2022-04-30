namespace TestFramework.Base
{
    public class Browser
    {
        private readonly DriverContext _driverContext;

        public Browser(DriverContext driver)
        {
            _driverContext = driver;
        }

        public BrowserType Type { get; set; }

    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
