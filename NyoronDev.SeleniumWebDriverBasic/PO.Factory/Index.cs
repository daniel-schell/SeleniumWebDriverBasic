using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DF.Users.Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PO.Factory.Contracts;

namespace PO.Factory
{
    /// <summary>
    /// Index Page
    /// http://demo.guru99.com/V4/index.php
    /// </summary>
    public class Index : IIndex
    {
        //Properties
        #region .: Properties :.
		 
        //Web Driver
        private IWebDriver _webDriver;

        #endregion

        //Selenium Page Factory Elements
        #region .: Selenium Page Factory Elements

        //UserId TextBox
        [FindsBy(How = How.Name, Using = "uid")] 
        private IWebElement _userIdTextBox;

        //UserPassword TextBox
        [FindsBy(How = How.Name, Using = "password")] 
        private IWebElement _userPasswordTextBox;

        //Login Button
        [FindsBy(How = How.Name, Using = "btnLogin")] 
        private IWebElement _loginButton;

        #endregion

        //Methods
        #region .: Methods :.

        /// <summary>
        /// Sets the web driver.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        public void SetWebDriver(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        /// <summary>
        /// Logs the in user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.Exception"></exception>
        public void LogInUser(User user)
        {
            try
            {
                //Write the UserId
                _userIdTextBox.SendKeys(user.UserId);

                //Write the UserPassword
                _userPasswordTextBox.SendKeys(user.UserPassword);
            }
            catch (WebDriverException ex)
            {
                throw new Exception(string.Format(Resources.String.Resource.ERROR_WebDriverException_Message, GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Resources.String.Resource.ERROR_Exception_Message, GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message));
            }
        }

        /// <summary>
        /// Clicks the login.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void ClickLogin()
        {
            try
            {
                //Click LoginButton
                _loginButton.Click();
            }
            catch (WebDriverException ex)
            {
                throw new Exception(string.Format(Resources.String.Resource.ERROR_WebDriverException_Message, GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Resources.String.Resource.ERROR_Exception_Message, GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message));
            }
        }

        #endregion

    }
}
