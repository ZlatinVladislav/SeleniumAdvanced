using System;
using System.IO;
using TestFramework.Base;
using Microsoft.Extensions.Configuration;

namespace TestFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = builder.Build();


            Settings.TimeOut=configurationRoot.GetSection("settings").Get<TestSettings>().TimeOut;
            Settings.AUT = configurationRoot.GetSection("settings").Get<TestSettings>().AUT;
            Settings.TestType = configurationRoot.GetSection("settings").Get<TestSettings>().TestType;
            Settings.IsLog = configurationRoot.GetSection("settings").Get<TestSettings>().IsLog;
            //Settings.IsReporting = EATestConfiguration.EASettings.TestSettings["staging"].IsReadOnly;
            Settings.LogPath = configurationRoot.GetSection("settings").Get<TestSettings>().LogPath;
            Settings.AppConnectionString = configurationRoot.GetSection("settings").Get<TestSettings>().AUTConnectionString;
            Settings.BrowserType = configurationRoot.GetSection("settings").Get<TestSettings>().Browser;
            Settings.ReportPath = configurationRoot.GetSection("settings").Get<TestSettings>().ReportPath;

        }

    }
}
