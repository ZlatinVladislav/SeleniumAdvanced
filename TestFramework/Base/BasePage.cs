using TestFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


namespace TestFramework.Base
{
    public abstract class BasePage : Base
    {
        public BasePage(SeleniumDriver seleniumDriverConfig) : base(seleniumDriverConfig)
        {

        }

        //in case of requiring some methods to page, this class can be omited and be inherited direct from base but maybe some methods just for page will be put
    }
}
