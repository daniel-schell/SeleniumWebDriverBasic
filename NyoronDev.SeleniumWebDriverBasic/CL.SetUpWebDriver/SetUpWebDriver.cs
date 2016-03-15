using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CL.SetUpWebDriver
{
    /// <summary>
    /// Selenium Web Driver SetUp Class
    /// </summary>
    public static class SetUpWebDriver
    {
        /// <summary>
        /// Sets up fire fox web driver.
        /// </summary>
        /// <returns><see cref="IWebDriver"/></returns>
        public static IWebDriver SetUpFireFoxWebDriver()
        {
            FirefoxProfile firefoxProfile = new FirefoxProfile();

            return new FirefoxDriver(new FirefoxBinary(), firefoxProfile, TimeSpan.FromSeconds(10));
        }
    }
}
