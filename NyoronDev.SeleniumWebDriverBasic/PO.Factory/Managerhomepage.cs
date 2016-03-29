using System;
using System.Reflection;
using CL.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PO.Factory.Contracts;

namespace PO.Factory
{
	/// <summary>
	/// Managerhomepage Page
	/// http://demo.guru99.com/V4/manager/Managerhomepage.php
	/// </summary>
	public class Managerhomepage : IManagerhomepage
	{
		//Properties
		#region .: Properties :.
		 
		//Web Driver
		private IWebDriver _webDriver;

		#endregion

		//Selenium Page Factory Elements
		#region .: Selenium Page Factory Elements

		//ManagerId TD
		[FindsBy(How = How.XPath, Using = "html/body/table/tbody/tr/td/table/tbody/tr[3]/td")]
		private IWebElement _managerIdTd;
	
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
		/// Determines whether [is manager identifier correct] [the specified user].
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns><see cref="User"/></returns>
		/// <exception cref="Exception"></exception>
		public bool IsManagerIdCorrect(User user)
		{
			bool isManagerIdCorrect = false;

			try
			{
				if (_managerIdTd.Text == string.Format(Resources.String.Resource.SELENIUM_ManagerId, user.UserId))
				{
					isManagerIdCorrect = true;
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

			return isManagerIdCorrect;
		}
	
		#endregion
    }
}
