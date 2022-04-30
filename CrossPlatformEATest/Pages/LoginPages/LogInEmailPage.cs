using TestFramework.Base;
using TestFramework.Extensions;
using OpenQA.Selenium;

namespace AdvanceProject.Pages
{
    internal class LogInEmailPage : BasePage
    {
        public LogInEmailPage(SeleniumDriver seleniumDriver) : base(seleniumDriver)
        {
        }

        IWebElement Email => seleniumDriver.Driver.FindElement("//input[@type='email']");
        IWebElement SubmitButton => seleniumDriver.Driver.FindElement("//input[@type='submit']");

        public LogInEmailPage InputEmail(string email)
        {
            Email.FindAndSetText(email);
            return new LogInEmailPage(seleniumDriver);
        }

        public LogInPasswordPage PressNextButton()
        {
            SubmitButton.FindAndClick();
            return new LogInPasswordPage(seleniumDriver);
        }
    }
}
