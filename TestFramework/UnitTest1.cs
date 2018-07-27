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

        public void OpenBrowser(string url,BrowserType browserType= BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    break;
                case BrowserType.Chrome:
                    break;
                case BrowserType.Firefox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\drivers"); // location of the geckdriver.exe file
                    DriverContext.Driver = new FirefoxDriver(service);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    DriverContext.Browser.GoToUrl(url);
                    break;
                default:
                    DriverContext.Driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(@"D:\drivers"));
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    DriverContext.Browser.GoToUrl(url);
                    break;
            }
        }

        [TestMethod]
        public void TestLogin()
        {
            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\drivers"); // location of the geckdriver.exe file
            //DriverContext.Driver = new FirefoxDriver(service);
            //DriverContext.Driver.Navigate().GoToUrl(url);
            //LoginPage loginPage = new LoginPage();
            //CurrentPage = loginPage.Login("devdeep", "dev#NANCE33");
            //((HomePage)CurrentPage).NavigateToNewCompany();

            ConfigReader.SetFrameworkSettings();
            LogHelpers.CeateLogFile();
            string filename = Environment.CurrentDirectory.ToString() + @"\Data\Testdata.xlsx";
            ExcelHelpers.PopulateInCollection(filename);
            LogHelpers.WriteLog("Open Browser");
            OpenBrowser(Settings.Url,BrowserType.Firefox);
            LogHelpers.WriteLog("Login");
            CurrentPage =GetInstance<LoginPage>().Login(ExcelHelpers.ReadData(1,"UserName"), ExcelHelpers.ReadData(1, "Password"));
            LogHelpers.WriteLog("Navigate To NewCompany page");
            CurrentPage.As<HomePage>().NavigateToNewCompany();
        }

       
    }
}
