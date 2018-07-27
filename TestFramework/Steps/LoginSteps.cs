using AutoFramework.Base;
using TechTalk.SpecFlow;
using TestFramework.Pages;
using TechTalk.SpecFlow.Assist;
using AutoFramework.Helpers;

namespace TestFramework.Steps
{
    [Binding]
    public sealed class LoginSteps:BaseStep
    {
        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NavigateToSite();
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            CurrentPage = GetInstance<LoginPage>().CheckLoginPageLoaded();
        }

        [When(@"I enter userName and password and click login")]
        public void WhenIEnterUserNameAndPasswordAndClickLogin(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            CurrentPage = GetInstance<LoginPage>().Login(data.UserName, data.Password);
        }

        [Then(@"I should Navigated to Home page")]
        public void ThenIShouldNavigatedToHomePage()
        {
            if (CurrentPage.As<HomePage>().CheckHomepageLoaded().Contains("Devdeep Parida"))
            {
                System.Console.WriteLine("Login Sucess");
            }else
            {
                System.Console.WriteLine("UnSucess Login ");
            }
        }

    }
}
