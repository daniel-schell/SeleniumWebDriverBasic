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
    /// Interface IManagerhomepage
    /// http://demo.guru99.com/V4/manager/Managerhomepage.php
    /// </summary>
    public interface IManagerhomepage
    {
        // Sets the web driver.
        void SetWebDriver(IWebDriver webDriver);

        // Determines whether [is manager identifier correct] [the specified user].
        bool IsManagerIdCorrect(User user);
    }
}
