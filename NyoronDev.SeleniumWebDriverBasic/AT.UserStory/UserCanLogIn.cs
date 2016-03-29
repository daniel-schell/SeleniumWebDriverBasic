using System;
using Autofac;
using CL.Autofac;
using CL.Entities;
using CL.SetUpWebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PO.Factory.Contracts;
using TechTalk.SpecFlow;

namespace AT.UserStory
{
    [Binding]
    public class UserCanLogIn
    {
        //Properties
        #region .: Properties :.

        private static IWebDriver _webDriver;
        private IIndex _indexPage;
        private IManagerhomepage _managerhomepage;

        private static User _user;

        #endregion

        [Given(@"I open web page")]
        public void GivenIOpenWebPage()
        {
            _user = new User();

            _webDriver = SetUpWebDriver.SetUpFireFoxWebDriver();

            if (_webDriver != null)
            {
                _webDriver.Manage().Cookies.DeleteAllCookies();
                _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                _webDriver.Navigate().GoToUrl(Resources.String.Resource.URL_Index);

                _indexPage = Container.BuildContainer.Resolve<IIndex>();
                _indexPage.SetWebDriver(_webDriver);
                PageFactory.InitElements(_webDriver, _indexPage);

                _managerhomepage = Container.BuildContainer.Resolve<IManagerhomepage>();
                _managerhomepage.SetWebDriver(_webDriver);
                PageFactory.InitElements(_webDriver, _managerhomepage);
            }
        }
        
        [When(@"I put a ""(.*)"" UserId")]
        public void WhenIPutAUserId(string userId)
        {
            _user.UserId = userId;
        }
        
        [When(@"I put a ""(.*)"" Password")]
        public void WhenIPutAPassword(string password)
        {
            _user.Password = password;
        }
        
        [Then(@"I can log in")]
        public void ThenICanLogIn()
        {
            //Login
            _indexPage.LogInUser(_user);

            //Click Login button
            _indexPage.ClickLogin();

            //Check the user manager id
            Assert.IsTrue(_managerhomepage.IsManagerIdCorrect(_user));
            _webDriver.Quit();
        }
    }
}
