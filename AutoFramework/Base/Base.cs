using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace AutoFramework.Base
{
    public class Base
    {
        public BasePage CurrentPage
        {
            get { return (BasePage)ScenarioContext.Current["currentPage"]; }
            set { ScenarioContext.Current["currentPage"] = value; }
        }
        private IWebDriver _driver;

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                _driver = DriverContext.Driver
            };

            PageFactory.InitElements(DriverContext.Driver, this);
            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage {
            return (TPage)this;
        }
    }
}
