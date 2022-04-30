using System;


namespace TestFramework.Base
{
    public class Base
    {

        public readonly SeleniumDriver seleniumDriver;

        public Base(SeleniumDriver seleniumDriverConfig)
        {
            this.seleniumDriver = seleniumDriverConfig;
        }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage) Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
