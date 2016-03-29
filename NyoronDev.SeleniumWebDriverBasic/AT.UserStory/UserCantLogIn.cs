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
    public class UserCantLogIn
    {
        //Properties
        #region .: Properties :.

        private static IWebDriver _webDriver;
        private IIndex _indexPage;

        private static User _wrongUser;

        #endregion

        [Given(@"I open web")]
        public void GivenIOpenWeb()
        {
            _wrongUser = new User();

            _webDriver = SetUpWebDriver.SetUpFireFoxWebDriver();

            if (_webDriver != null)
            {
                _webDriver.Manage().Cookies.DeleteAllCookies();
                _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                _webDriver.Navigate().GoToUrl(Resources.String.Resource.URL_Index);

                _indexPage = Container.BuildContainer.Resolve<IIndex>();
                _indexPage.SetWebDriver(_webDriver);
                PageFactory.InitElements(_webDriver, _indexPage);
            }
        }

        [When(@"I put a invalid ""(.*)"" UserId")]
        public void WhenIPutAInvalidUserId(string invalidUserId)
        {
            _wrongUser.UserId = invalidUserId;
        }
        
        [When(@"I put a invalid ""(.*)"" Password")]
        public void WhenIPutAInvalidPassword(string invalidPassword)
        {
            _wrongUser.Password = invalidPassword;
        }
        
        [Then(@"I cant log")]
        public void ThenICantLog()
        {
            //User logs with UserId / Password
            _indexPage.LogInUser(_wrongUser);

            //User click login button
            _indexPage.ClickLogin();

            //User click login button
            Assert.IsTrue(_indexPage.IsPopUpVisible());

            _webDriver.Quit();
        }
    }
}
