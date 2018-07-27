using AutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestFramework
{   [Binding]
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize():base(BrowserType.Firefox)
        {
            InitializeSettings();
           
        }
        [BeforeFeature]
        public static void TestSetup()
        {
            HookInitialize init = new HookInitialize();
        }

        [AfterFeature]
        public static void TestTearDown()
        {
            DriverContext.Driver.Quit();
        }
    }
}
