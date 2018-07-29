using AutoFramework.Base;
using AutoFramework.ConfigElement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace AutoFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            Settings.Url = TestConfiguration.EASettings.TestSettings["staging"].AUT;
            //Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = TestConfiguration.EASettings.TestSettings["staging"].TestType;
            Settings.IsLog = TestConfiguration.EASettings.TestSettings["staging"].IsLog;
            //Settings.IsReporting = EATestConfiguration.EASettings.TestSettings["staging"].IsReadOnly;
            Settings.LogPath = TestConfiguration.EASettings.TestSettings["staging"].LogPath;
            //Settings.AppConnectionString = appConnection.Value.ToString();
            Settings.Timeout = int.Parse(TestConfiguration.EASettings.TestSettings["staging"].TimeOut);
            Settings.DriverPath = TestConfiguration.EASettings.TestSettings["staging"].DriverPath;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), TestConfiguration.EASettings.TestSettings["staging"].Browser);
        }
    }
}
