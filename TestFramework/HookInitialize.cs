using AutoFramework.Base;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using TechTalk.SpecFlow;

namespace TestFramework
{   [Binding]
    public class HookInitialize : TestInitializeHook
    {
        private static ExtentTest Featurename;
        private static ExtentTest Scenario;
        private static ExtentReports extent;
        private static KlovReporter klovReports;
        public HookInitialize():base(BrowserType.Firefox)
        {
            InitializeSettings();
           
        }
        [BeforeFeature]
        public static void TestSetup()
        {
            HookInitialize init = new HookInitialize();
        }
        [BeforeTestRun]
        public static void InitReports()
        {
            var htmlReports = new ExtentHtmlReporter(@"D:\\CSharpByDevdeep\\AutoFramework\\TestFramework\\Reports\\ExtentReport.html");
            htmlReports.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

            extent = new ExtentReports();
            //klovReports = new KlovReporter();
            //klovReports.InitMongoDbConnection("localhost", 27017);
            //klovReports.ProjectName = "AutoCrmProj";
            //klovReports.ReportName = "Devdeepp" + DateTime.Now.ToString();
            extent.AttachReporter(htmlReports);

        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            Featurename = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            Scenario = Featurename.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void InsertStepToReports()
        {
            var Steptype = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (Steptype.Equals("Given"))
                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (Steptype.Equals("When"))
                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (Steptype.Equals("Then"))
                    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (Steptype.Equals("And"))
                  Scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else {
                if (Steptype.Equals("Given"))
                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (Steptype.Equals("When"))
                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (Steptype.Equals("Then"))
                    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (Steptype.Equals("And"))
                    Scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
        }

        [AfterFeature]
        public static void TestTearDown()
        {
            extent.Flush();
            DriverContext.Driver.Quit();
        }
    }
}
