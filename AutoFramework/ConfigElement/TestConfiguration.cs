using System.Configuration;

namespace AutoFramework.ConfigElement
{
    public class TestConfiguration: ConfigurationSection
    {
        private static TestConfiguration _testConfig = (TestConfiguration)ConfigurationManager.GetSection("TestConfiguration");

        public static TestConfiguration EASettings { get { return _testConfig; } }

        [ConfigurationProperty("testSettings")]
        public EAFrameworkElementCollection TestSettings { get { return (EAFrameworkElementCollection)base["testSettings"]; } }

    }
}
