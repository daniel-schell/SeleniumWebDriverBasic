using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Entities;
using OpenQA.Selenium;

namespace PO.Factory.Contracts
{
    /// <summary>
    /// Interface IIndex 
    /// http://demo.guru99.com/V4/index.php
    /// </summary>
    public interface IIndex
    {
        // Sets the web driver.
        void SetWebDriver(IWebDriver webDriver);

        // Logs the user.
        void LogInUser(User user);

        // Clicks the login.
        void ClickLogin();

        // Determines whether [is pop up visible].
        bool IsPopUpVisible();
    }
}
