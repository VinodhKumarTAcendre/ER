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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Tests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public class _06_UserDetailsFormTests<TWebDriver> where TWebDriver : IWebDriver, new()
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
        public void _01_UserDetailsLocalQue()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("User Details Form - Add Local Questions");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkSystemForms();
            SysConPage.LinkUserDetails();
            _06_UserDetailsFormPage UdForm = new _06_UserDetailsFormPage(_driver);
            UdForm.AddLocalQuestion("UserDetailsFormData", "AddQuestiontoStep");
            Logger.log.Info("Local Questions added successfully to 'User Details Form'");
            ExtentReport.test.Log(LogStatus.Pass, "Local Questions added successfully to 'User Details Form'");
        }

        [Test, Order(2), Author("Vinodh Kumar T")]
        public void _02_UserDetailsGlobalQue()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("User Details Form - Add Global Questions");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkSystemForms();
            SysConPage.LinkUserDetails();
            _06_UserDetailsFormPage UserForm = new _06_UserDetailsFormPage(_driver);
            UserForm.AddGlobalQuestion("UserDetailsFormData", "AddGlobalQuestiontoStep");
            Logger.log.Info("Global Questions added successfully to 'User Details Form'");
            ExtentReport.test.Log(LogStatus.Pass, "Global Questions added successfully to 'User Details Form'");
        }

        [Test, Order(3), Author("Vinodh Kumar T")]
        public void _03_UserDetailsEditGlobalQue()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("User Details Form - Edit Questions");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkSystemForms();
            SysConPage.LinkUserDetails();
            _06_UserDetailsFormPage UserForm = new _06_UserDetailsFormPage(_driver);
            UserForm.EditQuestion("UserDetailsFormData", "EditQuestions");
            Logger.log.Info("'User Details Form' questions edited successfully");
            ExtentReport.test.Log(LogStatus.Pass, "'User Details Form' questions edited successfully");
        }

        [Test, Order(4), Author("Vinodh Kumar T")]
        public void _04_UserDetailsDeleteQue()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("User Details Form - Delete Questions");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkSystemForms();
            SysConPage.LinkUserDetails();
            _06_UserDetailsFormPage UserForm = new _06_UserDetailsFormPage(_driver);
            UserForm.DeleteQuestion("UserDetailsFormData", "DeleteQuestions");
            Logger.log.Info("Successfully Deleted added Questions from User Details Form'");
            ExtentReport.test.Log(LogStatus.Pass, "Successfully Deleted added Questions from User Details Form'");
        }

        [Test, Order(5), Author("Vinodh Kumar T")]
        public void _05_UserDetailsPreview()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("User Details Form - Preview");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkSystemForms();
            SysConPage.LinkUserDetails();
            _06_UserDetailsFormPage UserForm = new _06_UserDetailsFormPage(_driver);
            UserForm.PreviewUserDetailsForm();
            Logger.log.Info("'User Details Form' Preview Completed Successfully");
            ExtentReport.test.Log(LogStatus.Pass, "'User Details Form' Preview Completed Successfully");
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
