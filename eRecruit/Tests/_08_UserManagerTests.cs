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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eRecruit.Tests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(EdgeDriver))]
    class _08_UserManagerTests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Initialize()
        {
            this._driver = new TWebDriver();
            ExtentReport.CExtentReport(_driver);
            _01_BrowserClass.LaunchBrowser(_driver);
        }

        [Test, Order(1), Author("Vinodh Kumar T")]
        public void CreateUser()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Create User");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkUserManager();
            _08_UserManagerPage UM = new _08_UserManagerPage(_driver);
            UM.CreateUser("UserManagerData", "UserDetails");
            Logger.log.Info("Users are Created Successfully with all the Configurations");
            ExtentReport.test.Log(LogStatus.Pass, "Users are Created Successfully with all the Configurations");
        }

        [Test, Order(2), Author("Vinodh Kumar T")]
        public void ChangeUsername()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Change Username - User");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkUserManager();
            _08_UserManagerPage UM = new _08_UserManagerPage(_driver);
            UM.ChangeUsername("UserManagerData", "ChangeUsername");
            Logger.log.Info("Username's Changed Successfully");
            ExtentReport.test.Log(LogStatus.Pass, "Username's Changed Successfully");
        }

        [Test, Order(3), Author("Vinodh Kumar T")]
        public void ChangePassword()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Change Username - User");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkUserManager();
            _08_UserManagerPage UM = new _08_UserManagerPage(_driver);
            UM.ChangePassword("UserManagerData", "ChangePassword");
            Logger.log.Info("Password's Changed Successfully");
            ExtentReport.test.Log(LogStatus.Pass, "Password's Changed Successfully");
        }

        [Test, Order(4), Author("Vinodh Kumar T")]
        public void SendEmail()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Send Emails - User");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkUserManager();
            _08_UserManagerPage UM = new _08_UserManagerPage(_driver);
            UM.SendEmail("UserManagerData", "SendEmail");
            Logger.log.Info("Email's Sent Successfully");
            ExtentReport.test.Log(LogStatus.Pass, "Email's Sent Successfully");
        }

        [Test, Order(5), Author("Vinodh Kumar T")]
        public void UserStatus()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Change User Status");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkUserManager();
            _08_UserManagerPage UM = new _08_UserManagerPage(_driver);
            UM.ChangeUserStatus("UserManagerData", "UserStatus");
            Logger.log.Info("User's Status changed Successfully");
            ExtentReport.test.Log(LogStatus.Pass, "User's Status changed Successfully");
        }

        [Test, Order(6), Author("Vinodh Kumar T")]
        public void ImpersonateUser()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Change User Status");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkUserManager();
            _08_UserManagerPage UM = new _08_UserManagerPage(_driver);
            UM.ImpersonateUser("UserManagerData", "ImpersonateUser");
            Logger.log.Info("Impersonate User's done Successfully");
            ExtentReport.test.Log(LogStatus.Pass, "Impersonate User's done Successfully");
        }

        [TearDown]
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
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _driver.Quit();
            ExtentReport.extent.Flush();
            ExtentReport.extent.Close();
        }
    }
}


