using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using AventStack.ExtentReports;

namespace ITEXIATesting
{
    class BaseFunctionality
    {
        internal static IWebDriver driver;
        
        /// <summary>
        /// Initialize everything before test methods
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            //Passing the Chrome Driver .exe file to Selenium
            driver = new ChromeDriver("C://ChromeDriver");
            //Implicitly specifying the wait time so that it can wait for the element to be loaded on screen
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        /// <summary>
        /// Destroy everything after testing
        /// </summary>
        [TearDown]
        public void destroy()
        {
            //Calling a report generation method at the end of all tests
            //var extent = new ExtentReports();
            //Exiting the driver after performing tests
            driver.Quit();
        }

    }
}
