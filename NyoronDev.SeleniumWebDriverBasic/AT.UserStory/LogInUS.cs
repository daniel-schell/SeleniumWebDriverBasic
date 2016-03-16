using System;
using System.Linq;
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
        private IManagerhomepage _managerhomepage;

        private static User _user;
        private static User _wrongUser;

        #endregion

        /// <summary>
        /// Sets up class.
        /// </summary>
        /// <param name="context">The context.</param>
        [ClassInitialize]
        public static void SetUpClass(TestContext context)
        {
            _user = UsersValues.GetUser();
            _wrongUser = UsersValues.GetUserList().Last();
        }

        /// <summary>
        /// Sets up method.
        /// </summary>
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

                _managerhomepage = Container.BuildContainer.Resolve<IManagerhomepage>();
                _managerhomepage.SetWebDriver(_webDriver);
                PageFactory.InitElements(_webDriver, _managerhomepage);
            }
        }

        /// <summary>
        /// Cleans this instance.
        /// </summary>
        [TestCleanup]
        public void Clean()
        {
            if (_webDriver != null)
            {
                _webDriver.Close();
            }
        }

        /// <summary>
        /// As a User, I want Login successfully and I can access the web.
        /// </summary>
        [TestMethod]
        [TestCategory("AcceptanceTest")]
        public void UserLogsSuccessfully()
        {
            //User logs with UserId / Password
            _indexPage.LogInUser(_user);

            //User click login button
            _indexPage.ClickLogin();

            //Check the user manager id
            Assert.IsTrue(_managerhomepage.IsManagerIdCorrect(_user));
        }

        /// <summary>
        /// As a User, I write the password wrong and I cant go to the web.
        /// </summary>
        [TestMethod]
        [TestCategory("AcceptanceTest")]
        public void UserNotLogsSuccessfully()
        {
            //User logs with UserId / Password  
            _indexPage.LogInUser(_wrongUser);

            //User click login button
            _indexPage.ClickLogin();

            Assert.IsTrue(_indexPage.IsPopUpVisible());
        }

        /// <summary>
        /// As a User, I write the password wrong and I cant go to the web.
        /// As a User, I try again with a correct password and I can go to the web.
        /// </summary>
        [TestMethod]
        [TestCategory("AcceptanceTest")]
        public void UserNotLogsSuccessfullyTryAgainAndLog()
        {
            //User logs with wrong UserId / Password  
            _indexPage.LogInUser(_wrongUser);

            //User click login button
            _indexPage.ClickLogin();

            Assert.IsTrue(_indexPage.IsPopUpVisible());

            //User logs with correct UserId / Password
            _indexPage.LogInUser(_user);

            //User click login button
            _indexPage.ClickLogin();

            //Check the user manager id
            Assert.IsTrue(_managerhomepage.IsManagerIdCorrect(_user));
        }
    }
}
