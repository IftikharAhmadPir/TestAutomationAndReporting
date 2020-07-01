using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;


namespace ITEXIATesting
{
    [TestFixture]
    class FilterTask : BaseFunctionality
    {
        /// <summary>
        /// Method: Filterwith100Input
        /// Description: This method pass value 100 to cost center field and
        /// check if it returns 64 assets
        /// </summary>
        [Test]
        public void Filterwith100Input()
        {
            LoginTest.extent.AttachReporter(LoginTest.htmlReporter);
            var test = LoginTest.extent.CreateTest("Filter with 100 input Test");
            try
            {
                LoginTest LT = new LoginTest();
                LT.LoginFunctionality("", ""); //Provide Login & Password
                test.Log(Status.Info, "Step 1: Logging into the System");
                if (driver.Url == "") //Provide URL Here
                    driver.Url = ""; //Provide URL Here

                test.Log(Status.Info, "Step 2: Checking if the login was successfull, Then jump to Asset Page");

                driver.FindElement(By.Id("CustomerAsset_s_00_value")).Click();
                test.Log(Status.Info, "Step 3: Clicked on Cost Center Field");
                driver.FindElement(By.Id("CustomerAsset_s_00_value")).SendKeys("100");
                test.Log(Status.Info, "Step 4: Entered Value 100 in Cost Center Field");
                driver.FindElement(By.Name("CustomerAsset_s_00_operator_0")).Click();
                test.Log(Status.Info, "Step 5: Clicked on Contain Button");
                System.Threading.Thread.Sleep(2000);
                test.Log(Status.Info, "Result:" + driver.FindElement(By.ClassName("summary")).Text);
                Assert.AreEqual(driver.FindElement(By.ClassName("summary")).Text, "1-50 of 64 Assets.");
                test.Log(Status.Pass, "Successfully got 64 Assets");
                LoginTest.extent.Flush();
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Test Failed, See the reason in next line");
                test.Log(Status.Info, "Exception Message:" + ex.Message);
                LoginTest.extent.Flush();
            }
        }

        /// <summary>
        /// Method: Filterwith200Input
        /// Description: This method pass value 200 to cost center field and
        /// check if it should not returns 64 assets
        /// </summary>
        [Test]
        public void Filterwith200Input()
        {
            LoginTest.extent.AttachReporter(LoginTest.htmlReporter);
            var test = LoginTest.extent.CreateTest("Filter with 200 Test");
            try
            {
                LoginTest LT = new LoginTest();
                LT.LoginFunctionality("", ""); //Provide Login & Password
                test.Log(Status.Info, "Step 1: Logging into the System");
                if (driver.Url == "") //Provide URL Here
                    driver.Url = ""; //Provide URL Here

                test.Log(Status.Info, "Step 2: Checking if the login was successfull, Then jump to Asset Page");

                driver.FindElement(By.Id("CustomerAsset_s_00_value")).Click();
                test.Log(Status.Info, "Step 3: Clicked on Cost Center Field");
                driver.FindElement(By.Id("CustomerAsset_s_00_value")).SendKeys("200");
                test.Log(Status.Info, "Step 4: Entered Value 200 in Cost Center Field");
                driver.FindElement(By.Name("CustomerAsset_s_00_operator_0")).Click();
                test.Log(Status.Info, "Step 5: Clicked on Contain Button");
                test.Log(Status.Info, "Result:" + driver.FindElement(By.ClassName("summary")).Text);
                Assert.AreNotEqual(driver.FindElement(By.ClassName("summary")).Text, "1-50 of 64 assets.");
                test.Log(Status.Pass, "Successfully didn't get 64 Assets");
                LoginTest.extent.Flush();
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Test Failed, See the reason in next line");
                test.Log(Status.Info, "Exception Message:" + ex.Message);
                LoginTest.extent.Flush();
            }
        }


        /// <summary>
        /// Method: Filterwith200Input
        /// Description: This method pass value 200 to cost center field and
        /// check if it should not returns 64 assets
        /// </summary>
        [Test]
        public void Filterwith200InputAndWrongResult()
        {
            LoginTest.extent.AttachReporter(LoginTest.htmlReporter);
            var test = LoginTest.extent.CreateTest("Filter with 200 Test with Wrong Result");
            try
            {
                LoginTest LT = new LoginTest();
                LT.LoginFunctionality("", ""); //Provide Login & Password
                test.Log(Status.Info, "Step 1: Logging into the System");
                if (driver.Url == "") //Provide URL Here
                    driver.Url = "";//Provide URL Here

                test.Log(Status.Info, "Step 2: Checking if the login was successfull, Then jump to Asset Page");

                driver.FindElement(By.Id("CustomerAsset_s_00_value")).Click();
                test.Log(Status.Info, "Step 3: Clicked on Cost Center Field");
                driver.FindElement(By.Id("CustomerAsset_s_00_value")).SendKeys("200");
                test.Log(Status.Info, "Step 4: Entered Value 200 in Cost Center Field");
                driver.FindElement(By.Name("CustomerAsset_s_00_operator_0")).Click();
                test.Log(Status.Info, "Step 5: Clicked on Contain Button");
                test.Log(Status.Info, "Result:" + driver.FindElement(By.ClassName("summary")).Text);
                Assert.AreEqual(driver.FindElement(By.ClassName("summary")).Text, "1-50 of 64 assets.");
                test.Log(Status.Pass, "Successfully didn't get 64 Assets");
                LoginTest.extent.Flush();
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Test Failed, See the reason in next line");
                test.Log(Status.Info, "Exception Message:" + ex.Message);
                LoginTest.extent.Flush();
            }
        }
    }
}
