using System;
using System.Threading;
using AutoFramework.Base;
using AutoFramework.Config;
using AutoFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;using OpenQA.Selenium.Firefox;
using TestFramework.Pages;
//using OpenQA.Selenium.Chrome;

namespace TestFramework
{
    [TestClass]
    public class UnitTest1: Base
    {
        //string url = "https://www.freecrm.com/index.html";
        //private IWebDriver _driver;
               

        [TestMethod]
        public void TestLogin()
        {
            TestInitializeHook.InitializeSettings();
            string filename = Environment.CurrentDirectory.ToString() + @"\Data\Testdata.xlsx";
            ExcelHelpers.PopulateInCollection(filename);
                        
            LogHelpers.WriteLog("Login");
            CurrentPage =GetInstance<LoginPage>().Login(ExcelHelpers.ReadData(1,"UserName"), ExcelHelpers.ReadData(1, "Password"));

            LogHelpers.WriteLog("Navigate To NewCompany page");
            CurrentPage.As<HomePage>().NavigateToNewCompany();
        }

       
    }
}
