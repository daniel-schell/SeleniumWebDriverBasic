using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DF.Users.Entity;
using OpenQA.Selenium;

namespace PO.Factory.Contracts
{
    /// <summary>
    /// Interface IIndex 
    /// http://demo.guru99.com/V4/index.php
    /// </summary>
    public interface IIndex
    {
        void SetWebDriver(IWebDriver webDriver);

        void LogInUser(User user);

        void ClickLogin();
    }
}
