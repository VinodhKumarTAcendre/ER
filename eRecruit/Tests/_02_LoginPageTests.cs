using eRecruit.Library;
using eRecruit.Library.Extent_Reports;
using eRecruit.Library.Log4Net;
using eRecruit.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RelevantCodes.ExtentReports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Tests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public class _02_LoginPageTests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Initialize()
        {
            this._driver = new TWebDriver();
            ExtentReport.CExtentReport(_driver);
            _01_BrowserClass.LaunchBrowser(_driver);
        }

        [Test, Order(1), Author("Vinodh Kumar T"), Category("IE"), Category("Chrome"), Category("Firefox"), Category("Edge")]
        [Ignore("")]
        public void LogintoApplication()
        {
            _02_LoginPage _Login = new _02_LoginPage(_driver);
            ExtentReport.test = ExtentReport.extent.StartTest("Login Page: Login to Application");
            ExtentReport.test.Log(LogStatus.Info, "Login Page Assertion Started");
            string ExpectedValue = "Forgot your Password";
            string ActualValue = _Login.GetLinkText();
            Assert.AreEqual(ExpectedValue, ActualValue, "Assert Pass");
            ExtentReport.test.Log(LogStatus.Pass, "Login Page Assertion Passed");
            Logger.log.Info("Login Page Assert Passed");
            ExtentReport.test.Log(LogStatus.Pass, "Logging into Application with valid UserID and Password");
            Logger.log.Info("Logging into Application with valid UserID and Password");
            ArrayList list = _Login.GetLoginDetails("ER_TESTDATA", "Login", "KeyName", "User");
            string username = list[1].ToString();
            string password = list[2].ToString();
            _Login.Username(username);
            _Login.Password(password);
            _Login.LoginButton();
            ExtentReport.test.Log(LogStatus.Pass, "Login to Application Test Passed");
            Logger.log.Info("Login Test Ended");
        }

        [Test, Order(2), Author("Vinodh Kumar T"), Category("IE"), Category("Chrome"), Category("Firefox"), Category("Edge")]
        [Ignore("")]
        public void ForgotYourPassword()
        {
            string _EmailID = "vinodhkumart09@gmail.com";
            _02_LoginPage _Login = new _02_LoginPage(_driver);
            ExtentReport.test = ExtentReport.extent.StartTest("Login Page: Forgot Your Password");
            ExtentReport.test.Log(LogStatus.Info, "Clicking on Forgot Your Password? link");
            _Login.ForgotPasswordLink();
            _Login.EnterEmailID(_EmailID);
            ExtentReport.test.Log(LogStatus.Info, "Entered Email ID");
            _Login.Reset();
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Reset Button");
            string _ActualEmailID = _Login.VerifyEmailID();
            Assert.AreEqual(_EmailID, _ActualEmailID, "Assert Pass");
            ExtentReport.test.Log(LogStatus.Pass, "Email Id Verification Assertion Passed");
            _Login.BackToLogin();
        }

        [Test, Order(3), Author("Vinodh Kumar T"), Category("IE"), Category("Chrome"), Category("Firefox"), Category("Edge")]
        [Ignore("")]
        public void OnlyUsernameLoginValidation()
        {
            string ExpectedAlertText = "Message :\r\n\r\n- The system was not able to validate the login details supplied.\r\n";
            _02_LoginPage _Login = new _02_LoginPage(_driver);
            ExtentReport.test = ExtentReport.extent.StartTest("Login Page: Only Username Login Validation");
            ArrayList list = _Login.GetLoginDetails("ER_TESTDATA", "Login", "KeyName", "Admin");
            string username = list[1].ToString();
            string password = list[2].ToString();
            _Login.Username(username);
            _Login.Password(password);
            _Login.LoginButton();
            string ActualAlertText = BaseMethods.GetAlertText(_driver);
            Assert.AreEqual(ExpectedAlertText, ActualAlertText, "Assert Pass");
            ExtentReport.test.Log(LogStatus.Pass, "Alert Message is Verified");
        }

        [Test, Order(4), Author("Vinodh Kumar T"), Category("IE"), Category("Chrome"), Category("Firefox"), Category("Edge")]
        [Ignore("")]
        public void InvalidLoginValidation()
        {
            string ExpectedAlertText = "Message :\r\n\r\n- The login details supplied were incorrect.\r\n";
            _02_LoginPage _Login = new _02_LoginPage(_driver);
            ExtentReport.test = ExtentReport.extent.StartTest("Login Page: Invalid Login Validation");
            string username = "AutomationTestUser";
            string password = "Automation";
            _Login.Username(username);
            _Login.Password(password);
            _Login.LoginButton();
            string ActualAlertText = BaseMethods.GetAlertText(_driver);
            Assert.AreEqual(ExpectedAlertText, ActualAlertText, "Assert Pass");
            ExtentReport.test.Log(LogStatus.Pass, "Alert Message is Verified");
        }

        [TearDown]
        [Ignore("")]
        public void GetResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                string screenShotPath = ExtentReport.Capture(_driver);
                ExtentReport.test.Log(LogStatus.Fail, stackTrace + errorMessage);
                ExtentReport.test.Log(LogStatus.Fail, "Please find the Screenshot below: " + ExtentReport.test.AddScreenCapture(screenShotPath));
            }
            ExtentReport.extent.EndTest(ExtentReport.test);
            _driver.Quit();
        }

        [OneTimeTearDown]
        [Ignore("")]
        public void CleanUp()
        {
            ExtentReport.extent.Flush();
            ExtentReport.extent.Close();
        }
    }
}
