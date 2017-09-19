using eRecruit.Library;
using eRecruit.Library.Extent_Reports;
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
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Tests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public class _03_HomePageTests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Initialize()
        {
            this._driver = new TWebDriver();
            ExtentReport.CExtentReport(_driver);
            _01_BrowserClass.LaunchBrowser(_driver);
        }

        [Test,Order(1),Author("Vinodh Kumar T")]
        [Ignore("")]
        public void HomePageVerification()
        {
            _03_HomePage HP = new _03_HomePage(_driver);
            ExtentReport.test = ExtentReport.extent.StartTest("Home Page Verification");
            BaseMethods.InfoLogger("Home Page Assertion Started");
            string DashboardExpectedValue = "Dashboard";
            string DashboardActualValue = HP.DashBoardValue();
            Assert.AreEqual(DashboardExpectedValue, DashboardActualValue, "Assert Pass");
            ExtentReport.test.Log(LogStatus.Pass, "DashBoard Assertion Passed");
        }

        [Test, Order(2), Author("Vinodh Kumar T")]
        [Ignore("")]
        public void HomePage_JobSearch()
        {
            BaseMethods.SleepTimeOut(10000);
            _03_HomePage HP = new _03_HomePage(_driver);
            ExtentReport.test = ExtentReport.extent.StartTest("Home Page Job Search");
            BaseMethods.InfoLogger("Selecting Job Search Option Started");
            BaseMethods.SleepTimeOut(5000);
            BaseMethods.InfoLogger("Clicked on Job Radio Button");
            BaseMethods.SleepTimeOut(5000);
            HP.JobKeywordSearch("Test");
            BaseMethods.InfoLogger("Entered value in Seacrh Text Field");
            BaseMethods.SleepTimeOut(5000);
            HP.JobSearch();
            ExtentReport.test.Log(LogStatus.Pass, "Selecting Job Search Option Executed");
            BaseMethods.Navigate_Back(_driver);
        }

        [Test, Order(3), Author("Vinodh Kumar T")]
        [Ignore("")]
        public void HomePage_CandidateSearch()
        {
            BaseMethods.SleepTimeOut(10000);
            _03_HomePage HP = new _03_HomePage(_driver);
            ExtentReport.test = ExtentReport.extent.StartTest("Home Page Candidate Search");
            BaseMethods.InfoLogger("Selecting Candidate Search Option Started");
            BaseMethods.SleepTimeOut(5000);
            HP.CandidateRadioButton();
            BaseMethods.InfoLogger("Clicked on Candidate Radio Button");
            BaseMethods.SleepTimeOut(5000);
            HP.CandidateKeywordSearch("Test");
            BaseMethods.InfoLogger("Entred value in Seacrh Text Field");
            BaseMethods.SleepTimeOut(5000);
            HP.CandidateSearch();
            BaseMethods.InfoLogger("Clicked on Search Button");
            ExtentReport.test.Log(LogStatus.Pass, "Selecting Candidate Search Option Executed");
            BaseMethods.Navigate_Back(_driver);
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
        }

        [OneTimeTearDown]
        [Ignore("")]
        public void CleanUp()
        {
            _driver.Quit();
            ExtentReport.extent.Flush();
            ExtentReport.extent.Close();
        }
    }
}
