using TestFramework.Base;
using TechTalk.SpecFlow;
using TestFramework.Helpers;
using TestFramework.Config;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using NUnit.Framework;

namespace AdvanceProject.Hooks
{

    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        private readonly SeleniumDriver _webDriverConfig;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName;


        public HookInitialize(SeleniumDriver webDriverConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(webDriverConfig)
        {
            _webDriverConfig = webDriverConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }



        private static ExtentTest featureName;
        private static AventStack.ExtentReports.ExtentReports extent;
        private static ExtentKlovReporter klov;


        [AfterStep]
        public void AfterEachStep()
        {

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }
            else if(_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {
            //InitializeSettings();
            //Settings.ApplicationCon = Settings.ApplicationCon.DBConnect(Settings.AppConnectionString);

            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(Settings.ReportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new AventStack.ExtentReports.ExtentReports();


            extent.AttachReporter(htmlReporter);
        }


        [BeforeScenario]
        public void Initialize()
        {
            InitializeSettings();
            //Settings.ApplicationCon = Settings.ApplicationCon.DBConnect(Settings.AppConnectionString);

            //Get feature Name
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);

            //Create dynamic scenario name
            _currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }



        [AfterScenario]
        public void TestStop()
        {
            //DriverContext.Driver.Quit();
            //Flush report once test completes
            _webDriverConfig.Driver.Quit();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();

        }


    }
}
