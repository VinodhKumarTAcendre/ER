﻿using eRecruit.Library.Extent_Reports;
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
    public class _11_RequisitionProcessTemplateTests<TWebDriver> where TWebDriver : IWebDriver, new()
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
        public void CreateRequisitionProcessTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Create Requisition Process Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkRequisitionProcessTemplates();
            _11_RequisitionProcessTemplatePage rpt = new _11_RequisitionProcessTemplatePage(_driver);
            //rpt.CreateRequisitionProcessTemplate("RequisitionProcessTemplateData", "CreateRequisitionProcessTemp", "Execute", "Yes");
            rpt.CreateRequisitionFormTemplate(_driver);
            Logger.log.Info("Created Requisition Process Template");
            ExtentReport.test.Log(LogStatus.Pass, "Created Requisition Process Template");
        }

        [Test, Order(2), Author("Vinodh Kumar T")]
        public void DeleteRequisitionProcessTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Delete Requisition Process Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkRequisitionProcessTemplates();
            _11_RequisitionProcessTemplatePage rpt = new _11_RequisitionProcessTemplatePage(_driver);
            rpt.DeleteRequisitionProcess(_driver);
            Logger.log.Info("Deleted Requisition Process Template");
            ExtentReport.test.Log(LogStatus.Pass, "Deleted Requisition Process Template");
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
