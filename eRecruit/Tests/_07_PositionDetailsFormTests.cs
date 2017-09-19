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
    public class _07_PositionDetailsFormTests<TWebDriver> where TWebDriver : IWebDriver, new()
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
        public void _01_Create_PositionDetailsForm()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Position Details Form - Add Steps, Local & Global Questions");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkSystemForms();
            SysConPage.LinkPositionDetails();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            FormTempCreaPage.CreateMultipleSteps(_driver, "PositionDetailsFormData", "PositionDetailsSteps", "Execute");
            FormTempCreaPage.AddQuestionToStep(_driver, "PositionDetailsFormData", "AddQuestiontoStep");
            FormTempCreaPage.AddGlobalQuestionToStep(_driver, "PositionDetailsFormData", "AddGlobalQuestiontoStep");
            Logger.log.Info("'Position Details Form' is successfully created Steps, Local and Global Questions");
            ExtentReport.test.Log(LogStatus.Pass, "'Position Details Form' is successfully created Steps, Local and Global Questions");
        }

        [Test, Order(2), Author("Vinodh Kumar T")]
        public void _02_Edit_PositionDetailsForm()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Edit Position Details Form");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkSystemForms();
            SysConPage.LinkPositionDetails();
            _07_PositionDetailsFormPage Pdf = new _07_PositionDetailsFormPage(_driver);
            Pdf.Edit_PositionDetailsForm();
            Logger.log.Info("'Position Details Form' Edit and Delete Operation completed successfully");
            ExtentReport.test.Log(LogStatus.Pass, "'Position Details Form' Edit and Delete Operation completed successfully");
        }

        [Test, Order(3), Author("Vinodh Kumar T")]
        public void _04_PositionDetailsPreview()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Position Details Form - Preview");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkSystemForms();
            SysConPage.LinkPositionDetails();
            _06_UserDetailsFormPage UserForm = new _06_UserDetailsFormPage(_driver);
            UserForm.PreviewUserDetailsForm();
            Logger.log.Info("'Position Details Form' Preview Completed Successfully");
            ExtentReport.test.Log(LogStatus.Pass, "'Position Details Form' Preview Completed Successfully");
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
