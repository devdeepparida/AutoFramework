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
        public TestInitializeHook(BrowserType browserType)
        {
            InitializeSettings();
            OpenBrowser(browserType);
        }

        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set log
            //LogHelpers.CeateLogFile();
        }
        private static void OpenBrowser( BrowserType browserType = BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    break;
                case BrowserType.Chrome:
                    break;
                case BrowserType.Firefox:
                    //LogHelpers.WriteLog("Initialize FireFox Browser");
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Settings.DriverPath); // location of the geckdriver.exe file
                    DriverContext.Driver = new FirefoxDriver(service);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                default:
                    DriverContext.Driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(Settings.DriverPath));
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }
        public virtual void NavigateToApp() {
            //Open Browser
            //LogHelpers.WriteLog("Opened URL:" + Settings.Url);
            DriverContext.Browser.GoToUrl(Settings.Url);
        }
    }
}
