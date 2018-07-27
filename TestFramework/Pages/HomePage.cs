using AutoFramework.Base;
using AutoFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class HomePage: BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='navmenu']/ul/li[3]/a")]
        private IWebElement lnkCompany { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='navmenu']/ul/li[3]/ul/li[1]/a")]
        private IWebElement lnkNewCompany { get; set; }

        [FindsBy(How =How.XPath, Using = "//td[contains(text(),'User: Devdeep Parida')]")]
        private IWebElement lblUserWelcome { get; set; }

        public void NavigateToNewCompany() {
            //Thread.Sleep(2000);
            DriverContext.Driver.WaitForpageLoaded();
            DriverContext.Driver.SwitchTo().Frame(1);
            lnkCompany.MouseHover();
            lnkNewCompany.Click();
        }
        public String CheckHomepageLoaded()
        {
            DriverContext.Driver.WaitForpageLoaded();
            DriverContext.Driver.SwitchTo().Frame(1);
            lblUserWelcome.AssertElementPresent();
            return lblUserWelcome.Text.ToString();
        }

    }
}
