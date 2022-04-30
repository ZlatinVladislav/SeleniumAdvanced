using TestFramework.Config;
using TestFramework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium;
using TestFramework.Extensions;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Base
{
    public class TestInitializeHook : Steps
    {
        public static WebDriverWait wait { get; set; }
        private readonly SeleniumDriver _webDriverConfig;

        public TestInitializeHook(SeleniumDriver webDriverConfig)
        {
            _webDriverConfig = webDriverConfig;
        }


        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));

            LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(DriverOptions driverOptions)
        {
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    //ToDo: Set the Desired capabilities
                    driverOptions = new InternetExplorerOptions();
                    break;
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalCapability(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);            
                    break;
            }

            _webDriverConfig.Driver = new ChromeDriver();
            _webDriverConfig.Driver.Manage().Window.Maximize();
            TimeSpan timeWait = TimeSpan.FromSeconds(Settings.TimeOut);
            _webDriverConfig.Driver.Manage().Timeouts().ImplicitWait=timeWait;
            _webDriverConfig.Driver.Manage().Timeouts().PageLoad = timeWait;
            _webDriverConfig.Driver.Manage().Timeouts().AsynchronousJavaScript = timeWait;
            
            _webDriverConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            wait = new WebDriverWait(_webDriverConfig.Driver, timeWait);
        }

        public virtual void NaviateSite()
        {
            //DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Opened the browser !!!");
        }


        public DriverOptions GetBrowserOption(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    return new InternetExplorerOptions();
                case BrowserType.FireFox:
                    return new FirefoxOptions();
                case BrowserType.Chrome:
                    return new ChromeOptions();
                default:
                    return new ChromeOptions();
            }
        }
    }
}
