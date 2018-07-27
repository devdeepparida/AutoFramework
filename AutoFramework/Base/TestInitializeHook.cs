using AutoFramework.Config;
using AutoFramework.Helpers;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Base
{
    public class TestInitializeHook: Base
    {
        public static void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set log
            LogHelpers.CeateLogFile();

            //Open Browser
            LogHelpers.WriteLog("Opening Browser");
            OpenBrowser(Settings.Url, Settings.BrowserType);
        }
        private static void OpenBrowser(string url, BrowserType browserType = BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    break;
                case BrowserType.Chrome:
                    break;
                case BrowserType.Firefox:
                    LogHelpers.WriteLog("Initialize FireFox Browser");
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@Settings.DriverPath); // location of the geckdriver.exe file
                    DriverContext.Driver = new FirefoxDriver(service);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    LogHelpers.WriteLog("Opened URL:"+url);
                    DriverContext.Browser.GoToUrl(url);
                    break;
                default:
                    DriverContext.Driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(@Settings.DriverPath));
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    DriverContext.Browser.GoToUrl(url);
                    break;
            }
        }
    }
}
