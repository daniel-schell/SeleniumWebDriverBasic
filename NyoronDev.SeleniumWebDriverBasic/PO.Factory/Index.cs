using System;
using System.Reflection;
using CL.Entities;
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
        /// Logs the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="Exception"></exception>
        public void LogInUser(User user)
        {
            try
            {
                //Write the UserId
                _userIdTextBox.SendKeys(user.UserId);

                //Write the UserPassword
                _userPasswordTextBox.SendKeys(user.Password);
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
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Determines whether [is pop up visible].
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        /// <exception cref="Exception"></exception>
        public bool IsPopUpVisible()
        {
            bool isPopUpVisible = false;

            try
            {
                //Check PopUp
                IAlert alertElement = _webDriver.SwitchTo().Alert();

                if (alertElement != null)
                {
                    alertElement.Accept();
                    isPopUpVisible = true;
                }
            }
            catch (WebDriverException ex)
            {
                throw new Exception(string.Format(Resources.String.Resource.ERROR_WebDriverException_Message, GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Resources.String.Resource.ERROR_Exception_Message, GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message));
            }

            return isPopUpVisible;
        }

        #endregion

    }
}
