using TestFramework.Base;
using TestFramework.Extensions;
using OpenQA.Selenium;

namespace AdvanceProject.Pages
{
    internal class LogInPasswordPage : BasePage
    {

        public LogInPasswordPage(SeleniumDriver seleniumDriver) : base(seleniumDriver)
        {
        }
        IWebElement Password => seleniumDriver.Driver.FindElement("//input[@type='password']");
        IWebElement SubmitButton => seleniumDriver.Driver.FindElement("//input[@type='submit']");

        public LogInPasswordPage InputPassword(string password)
        {
            Password.FindAndSetText(password);
            return new LogInPasswordPage(seleniumDriver);
        }
        public LogInQuestinPage PressNextButton()
        {
            SubmitButton.FindAndClick();
            return new LogInQuestinPage(seleniumDriver);
        }
    }
}
