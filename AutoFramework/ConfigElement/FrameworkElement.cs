using System.Configuration;

namespace AutoFramework.ConfigElement
{
    public class FrameworkElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired =true)]
        public string Name { get { return (string)base["name"]; } }

        [ConfigurationProperty("aut", IsRequired =true)]
        public string AUT { get { return (string)base["aut"]; } }

        [ConfigurationProperty("browser", IsRequired = true)]
        public string Browser { get { return (string)base["browser"]; } }

        [ConfigurationProperty("testType", IsRequired = true)]
        public string TestType { get { return (string)base["testType"]; } }

        [ConfigurationProperty("isLog", IsRequired = true)]
        public string IsLog { get { return (string)base["isLog"]; } }

        [ConfigurationProperty("logPath", IsRequired = true)]
        public string LogPath { get { return (string)base["logPath"]; } }

        [ConfigurationProperty("timeOut", IsRequired = true)]
        public string TimeOut { get { return (string)base["timeOut"]; } }

        [ConfigurationProperty("driverPath", IsRequired = true)]
        public string DriverPath { get { return (string)base["driverPath"]; } }

    }
}
