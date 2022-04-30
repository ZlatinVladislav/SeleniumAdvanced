using TestFramework.Base;
using TestFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AdvanceProject.Pages
{
    internal class OverviewPage : BasePage
    {
        public OverviewPage(SeleniumDriver seleniumDriver) : base(seleniumDriver)
        {
        }

        IWebElement header => seleniumDriver.Driver.FindElement("block-header",How.Id);

        internal OverviewPage CheckLogInIsSuccessful()
        {
            header.AssertElementPresent();
            return new OverviewPage(seleniumDriver);
        }
    }
}
