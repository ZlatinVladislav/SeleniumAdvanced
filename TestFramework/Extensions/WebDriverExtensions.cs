using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using TestFramework.Base;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace TestFramework.Extensions
{
    public static class WebDriverExtensions
    {
        private static readonly WebDriverWait _wait = TestInitializeHook.wait;

        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        public static IWebElement FindElement(this IWebDriver webDriver, string element, How how = How.XPath)
        {
            try
            {
                switch (how)
                {
                    case How.Id:
                        _wait.Until(ElementIsVisible(By.Id(element)));
                        if (webDriver.FindElement(By.Id(element)).IsElementPresent())
                        {
                            return webDriver.FindElement(By.Id(element));
                        }
                        break;
                    case How.Name:
                        _wait.Until(ElementIsVisible(By.Name(element)));
                        if (webDriver.FindElement(By.Name(element)).IsElementPresent())
                        {
                            return webDriver.FindElement(By.Name(element));
                        }
                        break;
                    case How.ClassName:
                        _wait.Until(ElementIsVisible(By.ClassName(element)));
                        if (webDriver.FindElement(By.ClassName(element)).IsElementPresent())
                        {
                            return webDriver.FindElement(By.ClassName(element));
                        }
                        break;
                    case How.LinkText:
                        _wait.Until(ElementIsVisible(By.LinkText(element)));
                        if (webDriver.FindElement(By.LinkText(element)).IsElementPresent())
                        {
                            return webDriver.FindElement(By.LinkText(element));
                        }
                        break;
                    case How.PartialLinkText:
                        _wait.Until(ElementIsVisible(By.PartialLinkText(element)));
                        if (webDriver.FindElement(By.PartialLinkText(element)).IsElementPresent())
                        {
                            return webDriver.FindElement(By.PartialLinkText(element));
                        }
                        break;
                    case How.CssSelector:
                        _wait.Until(ElementIsVisible(By.CssSelector(element)));
                        if (webDriver.FindElement(By.CssSelector(element)).IsElementPresent())
                        {
                            return webDriver.FindElement(By.CssSelector(element));
                        }
                        break;

                    default:
                        _wait.Until(ElementIsVisible(By.XPath(element)));
                        if (webDriver.FindElement(By.XPath(element)).IsElementPresent())
                        {
                            return webDriver.FindElement(By.XPath(element));
                        }
                        break;
                }
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException($"Element not found by {how} : {element}");
            }
            return null;
        }
    }
}
