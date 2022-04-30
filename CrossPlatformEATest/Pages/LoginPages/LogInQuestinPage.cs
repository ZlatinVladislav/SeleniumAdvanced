using TestFramework.Base;
using TestFramework.Extensions;
using OpenQA.Selenium;

namespace AdvanceProject.Pages
{
    internal class LogInQuestinPage : BasePage
    {
    
        public LogInQuestinPage(SeleniumDriver seleniumDriver) : base(seleniumDriver)
        {
        }

        IWebElement SubmitButton => seleniumDriver.Driver.FindElement("//input[@type='submit']");

        public OverviewPage PressNextButton()
        {
            SubmitButton.FindAndClick();
            return new OverviewPage(seleniumDriver);
        }
    }
}
