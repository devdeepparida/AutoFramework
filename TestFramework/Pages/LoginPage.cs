using AutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Text;
using System.Threading;
using AutoFramework.Extensions;
using AutoFramework.Helpers;

namespace TestFramework.Pages
{
    class LoginPage : BasePage
    {
        private IWebElement txtUsername => DriverContext.Driver.FindElement(By.Name("username"));

        private IWebElement txtPassword => DriverContext.Driver.FindElement(By.Name("password"));

        private IWebElement btnSubmit => DriverContext.Driver.FindElement(By.XPath("//input[@class='btn btn-small']"));

        public LoginPage CheckLoginPageLoaded()
        {
            DriverContext.Driver.WaitForpageLoaded();
            txtUsername.AssertElementPresent();
            return GetInstance<LoginPage>();
        }

        public HomePage Login(string UserName, string Password)
        {
            //username and password
            txtUsername.AssertElementPresent();
            txtUsername.SendKeys(UserName);
            txtPassword.AssertElementPresent();
            txtPassword.SendKeys(Password);
            //submit button
            Thread.Sleep(5000);
            btnSubmit.Click();
            //return new HomePage();
            return GetInstance<HomePage>();
        }

    }
}
