using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ITEXIATesting
{
    [TestFixture]
    class LoginTest : BaseFunctionality
    {

        public static dynamic htmlReporter = new ExtentHtmlReporter(@"G:\\ExtentReport.html");
        public static dynamic extent = new ExtentReports();

        /// <summary>
        /// Method : Valid login Test
        /// Description: It passes the valid login details to system and check 
        /// if the system has successfully logged in
        /// </summary>
        [Test]
        public void ValidLoginTest()
        {
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Operating System:", "Windows 10");
            extent.AddSystemInfo("Browser", "Google Chrome");
            var test = extent.CreateTest("Valid Login TestCase");
            try
            {
                test.Log(Status.Info, "Step 1: Passing the correct User Values to Login Function");
                LoginFunctionality("", ""); //Provide Login & Password
                Assert.AreEqual(driver.Url, ""); //Provide URL Here
                test.Log(Status.Pass, "Status: User Logged In Successfully");
                extent.Flush();
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "User Logging Failed");
                test.Log(Status.Info, ex.Message);
                extent.Flush();
            }
        }

        /// <summary>
        /// Method : InValid login Test
        /// Description: It passes the invalid login details to system and check 
        /// if the system has stopped the user to login
        /// </summary>
        [Test]
        public void InValidLoginTest()
        {
            extent.AttachReporter(htmlReporter);
            var test = extent.CreateTest("InValid Login TestCase");
            try
            {
                test.Log(Status.Info, "Step 1: Passing the Incorrect User Values to Login Function");
                LoginFunctionality("", ""); //Provide Login & Password
                Assert.AreEqual(driver.Url, ""); //Provide URL Here
                test.Log(Status.Pass, "Status: User Loggin Denied Successfully");
                extent.Flush();
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "User Logging Passed");
                test.Log(Status.Info, ex.Message);
                extent.Flush();
            }
        }

        /// <summary>
        /// Method: LoginFunctionality
        /// Description: Function to pass UserID and Password to login to the system
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        public void LoginFunctionality(string UserId, string Password)
        {
            driver.Url = ""; //Provide URL Here
            driver.FindElement(By.Id("UserLogin_username")).SendKeys(UserId);
            driver.FindElement(By.Id("UserLogin_password")).SendKeys(Password);
            driver.FindElement(By.Name("yt0")).Click();
        }

    }
}
