using AutoFramework.Base;
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

            XPathItem aut;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem buildname;
            XPathItem logPath;
            XPathItem timeout;
            XPathItem driverpath;
            XPathItem browsertype;

            string strFilename = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";

            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("AutoFramework/RunSettings/AUT");
            buildname = navigator.SelectSingleNode("AutoFramework/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("AutoFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("AutoFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("AutoFramework/RunSettings/IsReport");
            logPath = navigator.SelectSingleNode("AutoFramework/RunSettings/LogPath");
            timeout = navigator.SelectSingleNode("AutoFramework/RunSettings/TimeOut");
            driverpath= navigator.SelectSingleNode("AutoFramework/RunSettings/DriverPath");
            browsertype= navigator.SelectSingleNode("AutoFramework/RunSettings/Browser");
            //Set XML Details in the property to be used accross framework
            Settings.Url = aut.Value.ToString();
            Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReporting = isreport.Value.ToString(); 
            Settings.LogPath = logPath.Value.ToString();
            Settings.Timeout = int.Parse(timeout.Value);
            Settings.DriverPath = driverpath.Value.ToString();
            if (browsertype.Value.ToString()== "Firefox")
            Settings.BrowserType = BrowserType.Firefox;
        }
    }
}
