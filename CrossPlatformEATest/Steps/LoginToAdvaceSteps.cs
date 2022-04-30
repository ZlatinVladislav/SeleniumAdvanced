using TestFramework.Base;
using AdvanceProject.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestFramework.Config;
using System.Threading;

namespace AdvanceProject.Steps
{
    [Binding]
    
    public class LoginToAdvaceSteps : Base
    {
        private readonly SeleniumDriver _seleniumDriver;

        public LoginToAdvaceSteps(SeleniumDriver seleniumDriver) : base(seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;       
            _seleniumDriver.CurrentPage = new LogInStartPage(_seleniumDriver);
        }

        [Given(@"i am on Advance login page\.")]
        public void GivenIAmOnAdvanceLoginPage_()
        {
            _seleniumDriver.CurrentPage = new LogInStartPage(_seleniumDriver);
        }

        [When(@"i click login button")]
        public void WhenIClickLoginButton()
        {
            _seleniumDriver.CurrentPage = _seleniumDriver.CurrentPage.As<LogInStartPage>().PressLoginButton();
        }
        
        [When(@"i write email")]
        public void WhenIWriteEmail(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _seleniumDriver.CurrentPage.As<LogInEmailPage>().InputEmail(data.email);
          
        }
        
        [When(@"i press next button on email page")]
        public void WhenIPressNextButtonOnEmailPage()
        {
            _seleniumDriver.CurrentPage = _seleniumDriver.CurrentPage.As<LogInEmailPage>().PressNextButton();
        }
        
        [When(@"i write password")]
        public void WhenIWritePassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _seleniumDriver.CurrentPage.As<LogInPasswordPage>().InputPassword(data.password);
        }
        
        [When(@"i press next button on password page")]
        public void WhenIPressNextButtonOnPasswordPage()
        {
          
            _seleniumDriver.CurrentPage = _seleniumDriver.CurrentPage.As<LogInPasswordPage>().PressNextButton();
        }
        
        [When(@"i press next button on question page")]
        public void WhenIPressNextButtonOnQuestionPage()
        {
            _seleniumDriver.CurrentPage = _seleniumDriver.CurrentPage.As<LogInQuestinPage>().PressNextButton();
        }
        
        [Then(@"i can see header of application")]
        public void ThenICanSeeHeaderOfApplication()
        {
            _seleniumDriver.CurrentPage = _seleniumDriver.CurrentPage.As<OverviewPage>().CheckLogInIsSuccessful();
        }
    }
}
//private readonly ScenarioContext scenarioContext;
//private readonly AreaBreakdownViewCardPage page;

//public AreaBreakdownViewCardSteps(ScenarioContext scenarioContext)
//{
//    this.scenarioContext = scenarioContext;
//    var driverContext = this.scenarioContext.Get<DriverContext>("DriverContext");
//    this.page = new AreaBreakdownViewCardPage(driverContext);
//}
//[Binding]
//public class CommonTenancySteps
//{
   
//    private readonly CommonTenancyPage page;
//    private readonly ScenarioContext scenarioContext;

//    public CommonTenancySteps(ScenarioContext scenarioContext)
//    {
//        this.scenarioContext = scenarioContext;
//        var driverContext = this.scenarioContext.Get<DriverContext>("DriverContext");
//        this.page = new CommonTenancyPage(driverContext);
//    }

//    [When(@"User clicks add area breakdown button on area breakdown card on create tenancy page")]