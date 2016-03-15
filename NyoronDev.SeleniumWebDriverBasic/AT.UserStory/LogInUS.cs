using System;
using Autofac;
using Autofac.Core;
using CL.SetUpWebDriver;
using DF.Users.Entity;
using DF.Users.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using PO.Factory.Contracts;
using Container = CL.Autofac.Container;

namespace AT.UserStory
{
    [TestClass]
    public class LogInUS
    {
        //Properties
        #region .: Properties :.

        private static IWebDriver _webDriver;
        private IIndex _indexPage;
        private static User _user;

        #endregion

        [ClassInitialize]
        public static void SetUpClass(TestContext context)
        {
            _user = UsersValues.GetUser();
        }

        [TestInitialize]
        public void SetUpMethod()
        {
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

        [TestCleanup]
        public void Clean()
        {
            if (_webDriver != null)
            {
                _webDriver.Close();
            }
        }

        [TestMethod]
        [TestCategory("AcceptanceTest")]
        public void UserLogsSuccessfully()
        {
            _indexPage.LogInUser(_user);
            _indexPage.ClickLogin();
        }

        [TestMethod]
        [TestCategory("AcceptanceTest")]
        public void UserNotLogsSuccessfully()
        {
            _indexPage.LogInUser(_user);
            _indexPage.ClickLogin();
        }
    }
}
