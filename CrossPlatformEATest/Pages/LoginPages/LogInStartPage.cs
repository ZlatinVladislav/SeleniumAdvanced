using TestFramework.Base;
using TestFramework.Extensions;
using OpenQA.Selenium;

namespace AdvanceProject.Pages
{
    internal class LogInStartPage : BasePage
    {
        
        public LogInStartPage(SeleniumDriver seleniumDriver) : base(seleniumDriver)
        {

        }

        IWebElement SubmitButton => seleniumDriver.Driver.FindElement("//span[contains(text(),'Log In')]");
 
        public LogInEmailPage PressLoginButton()
        {
            SubmitButton.FindAndClick();
            return new LogInEmailPage(seleniumDriver);
        }
    }
}
