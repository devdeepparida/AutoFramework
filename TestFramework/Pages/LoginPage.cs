using AutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class LoginPage : BasePage
    {
        [FindsBy(How =How.Name,Using = "username")]
        private IWebElement txtUsername { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement txtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='btn btn-small']")]
        private IWebElement btnSubmit { get; set; }

        public HomePage Login(string UserName, string Password)
        {
            //username and password
            txtUsername.SendKeys(UserName);
            txtPassword.SendKeys(Password);
            //submit button
            Thread.Sleep(5000);
            btnSubmit.Click();
            //return new HomePage();
            return GetInstance<HomePage>();
        }

    }
}
