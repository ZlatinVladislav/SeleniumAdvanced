using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TestFramework.Base;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace TestFramework.Extensions
{
    public static class WebElementExtensions
    {
        private static WebDriverWait wait = TestInitializeHook.wait;

        public static void FindAndClick(this IWebElement element) => wait.Until(ElementToBeClickable(element)).Click();

        public static void FindAndSetText(this IWebElement element, string text)
        {
            var id = wait.Until(ElementToBeClickable(element));
            id.Clear();
            id.SendKeys(text);
        }

        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }


        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            if (ddl == null) throw new ArgumentNullException(nameof(ddl));
            ddl.SelectByText(value);
        }


        //public static void Hover(this IWebElement element)
        //{
        //    Actions actions = new Actions(DriverContext.Driver);
        //    actions.MoveToElement(element).Perform();
        //}


        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element Not Present exception"));
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
