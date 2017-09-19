using eRecruit.Library;
using eRecruit.Library.Excel;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Tests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public class _04_CreateGlobalQuestionsTests<TWebDriver> where TWebDriver : IWebDriver, new()
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.Priority(3)]
        public void CreateGlobalQuestions()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Create Global Questions");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkGlobalQuestions();
            _04_GlobalQtnListPage GlbQtnListPage = new _04_GlobalQtnListPage(_driver);
            GlbQtnListPage.CreateNewGlbQtn();
            _04_CreateGlobalQtnPage ManGlbQtnPage = new _04_CreateGlobalQtnPage(_driver);
            ManGlbQtnPage.CreateQuestions(_driver, "GlobalQuestionsData", "GlobalQuestion", "Execute", "Yes");
            Logger.log.Info("Created Global Questions");
            ExtentReport.test.Log(LogStatus.Pass, "Created Global Questions");
        }

        [Test, Order(2), Author("Vinodh Kumar T")]
        public void CreateGlobalQuestionWithOptions()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Add Global Questions with Options");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkGlobalQuestions();
            _04_GlobalQtnListPage GlbQtnListPage = new _04_GlobalQtnListPage(_driver);
            GlbQtnListPage.CreateNewGlbQtn();
            CreateGlobalQueWithOptionsPage GlbQtnPage = new CreateGlobalQueWithOptionsPage(_driver);
            GlbQtnPage.CreateQuestionWithOptions(_driver);
            Logger.log.Info("Created new Global Question with Options");
            ExtentReport.test.Log(LogStatus.Pass, "Created new Global Question with Options");
        }

        [Test, Order(3), Author("Vinodh Kumar T")]
        public void EditGlobalQuestions()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Edit Global Questions");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkGlobalQuestions();
            _04_GlobalQtnListPage GlbQtnListPage = new _04_GlobalQtnListPage(_driver);
            GlbQtnListPage.CreateNewGlbQtn();
            Edit_Delete_GlobalQtnPage EditGlbQtnPage = new Edit_Delete_GlobalQtnPage(_driver);
            EditGlbQtnPage.EditGlobalQuestion(_driver, "GlobalQuestionsData", "Edit_GlobalQuestion", "Execute", "Yes");
            Logger.log.Info("Edited Global Questions");
            ExtentReport.test.Log(LogStatus.Pass, "Edited Global Questions");
        }

        [Test, Order(4), Author("Vinodh Kumar T")]
        public void DeleteGlobalQuestions()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Delete Global Questions");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkGlobalQuestions();
            Edit_Delete_GlobalQtnPage DeleteGlbQtnPage = new Edit_Delete_GlobalQtnPage(_driver);
            DeleteGlbQtnPage.DeleteGlobalQuestions(_driver, "GlobalQuestionsData", "Delete_GlobalQuestion");
            Logger.log.Info("Deleted Global Questions");
            ExtentReport.test.Log(LogStatus.Pass, "Deleted Global Questions");
        }



        #region ******* Search Test Cases
        /*
        /// <summary>
        /// Search Related Test Cases
        /// </summary>        

        [Test, Order(4)]
        [Ignore("")]
        //--- Test Case -- Search Keyword, Reference Text, Question Text, Question Type, Question Created Date, Question Active ------------
        // [TestCase("Auto_ ", "Auto_Test01", "Test", "Multiple Choice", "13-Jul-2017", "Yes")]
        [TestCase("Auto_Test01", "Auto_Test01", "Test", "Free Text", "20-Jul-2017", "Yes")]
        public void SearchGlobalQuestions(string SearchKeyword, string ReferenceText, string QueText, string QueType, string Date, string Active)
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Search Global Questions with Active Filter");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkGlobalQuestions();
            _04_GlobalQtnListPage GlbQtnListPage = new _04_GlobalQtnListPage(_driver);
            GlbQtnListPage.SearchKeyword(SearchKeyword);
            GlbQtnListPage.Search();
            ArrayList list = GlbQtnListPage.GlobalQueElementResults(_driver, ReferenceText, QueText, QueType, Date, Active);
            if (list != null)
            {
                Assert.AreEqual(ReferenceText, list[0].ToString());
                Assert.AreEqual(QueText, list[1].ToString());
                Assert.AreEqual(QueType, list[2].ToString());
                Logger.log.Info("Question Details: " + "..Reference Text-- " + list[0].ToString() + "..Question Text-- " + list[1].ToString() + "..Question Type-- " + list[2].ToString() + "..Question Created-- " + list[3].ToString() + "..Question Active-- " + list[4].ToString());
                ExtentReport.test.Log(LogStatus.Pass, "..Question Details: " + "..Reference Text-- " + list[0].ToString() + "..Quetion Text-- " + list[1].ToString() + "..Question Type-- " + list[2].ToString() + "..Question Created-- " + list[3].ToString() + "..Question Active-- " + list[4].ToString());
                Logger.log.Info("Searched Global Question with Active Filter");
                ExtentReport.test.Log(LogStatus.Pass, "Searched Global Question with Active Filter");
            }
            else
            {
                Logger.log.Info("No results found.. Search Global Question with Active Filter Failed");
                ExtentReport.test.Log(LogStatus.Fail, "No results found.. Search Global Question with Active Filter Failed ..");
            }

        }

        [Test, Order(5)]
        [Ignore("")]
        //--- Test Case -- Search Keyword, Type Filter, Reference Text, Question Text, Question Type, Question Created Date, Question Active ------------
        // [TestCase("Auto_Test01 ", "Multiple Choice", "Auto_Test01", "Test", "Multiple Choice", "13-Jul-2017", "Yes")]
        [TestCase("Auto_Test01", "Free Text", "Auto_Test01", "Test", "Free Text", "20-Jul-2017", "Yes")]
        public void SearchGlobalQuestions_FilterByType(string SearchKeyword, string TypeFilter, string ReferenceText, string QueText, string QueType, string Date, string Active)
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Search Global Questions - Filter By Type");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkGlobalQuestions();
            _04_GlobalQtnListPage GlbQtnListPage = new _04_GlobalQtnListPage(_driver);
            GlbQtnListPage.SearchKeyword(SearchKeyword);
            GlbQtnListPage.Search();
            BaseMethods.DdlSelectByText(GlbQtnListPage.eleDdlType, TypeFilter);
            BaseMethods.SleepTimeOut(2000);
            ArrayList list = GlbQtnListPage.GlobalQueElementResults(_driver, ReferenceText, QueText, QueType, Date, Active);
            if (list != null)
            {
                Assert.AreEqual(ReferenceText, list[0].ToString());
                Assert.AreEqual(QueText, list[1].ToString());
                Assert.AreEqual(QueType, list[2].ToString());
                Logger.log.Info("Question Details: " + "..Reference Text-- " + list[0].ToString() + "..Question Text-- " + list[1].ToString() + "..Question Type-- " + list[2].ToString() + "..Question Created-- " + list[3].ToString() + "..Question Active-- " + list[4].ToString());
                ExtentReport.test.Log(LogStatus.Pass, "..Question Details: " + "..Reference Text-- " + list[0].ToString() + "..Quetion Text-- " + list[1].ToString() + "..Question Type-- " + list[2].ToString() + "..Question Created-- " + list[3].ToString() + "..Question Active-- " + list[4].ToString());
                Logger.log.Info("Searched Global Question with Type Filter");
                ExtentReport.test.Log(LogStatus.Pass, "Searched Global Question with Type Filter");
            }
            else
            {
                Logger.log.Info("No results found.. Search Global Question with Type Filter Failed");
                ExtentReport.test.Log(LogStatus.Fail, "No results found.. Search Global Question with Type Filter Failed");
            }

        }

        [Test, Order(6)]
        [Ignore("")]
        // --- Test Case -- Search Keyword, Active Filter, Reference Text, Question Text, Question Type, Question Created Date, Question Active ------------
        // [TestCase("Auto_Test01 ", "All", "Auto_Test01", "Test", "Multiple Choice", "13-Jul-2017", "Yes")]
        [TestCase("Auto_Test01", "All", "Auto_Test01", "Test", "Free Text", "20-Jul-2017", "Yes")]
        public void SearchGlobalQuestions_FilterByActive(string SearchKeyword, string ActiveFilter, string ReferenceText, string QueText, string QueType, string Date, string Active)
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Search Global Questions with IsActive Filter");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkGlobalQuestions();
            _04_GlobalQtnListPage GlbQtnListPage = new _04_GlobalQtnListPage(_driver);
            GlbQtnListPage.SearchKeyword(SearchKeyword);
            GlbQtnListPage.Search();
            BaseMethods.DdlSelectByText(GlbQtnListPage.eleDdlIsActive, ActiveFilter);
            BaseMethods.SleepTimeOut(2000);
            ArrayList list = GlbQtnListPage.GlobalQueElementResults(_driver, ReferenceText, QueText, QueType, Date, Active);
            if (list != null)
            {
                Assert.AreEqual(ReferenceText, list[0].ToString());
                Assert.AreEqual(QueText, list[1].ToString());
                Assert.AreEqual(QueType, list[2].ToString());
                Logger.log.Info("Question Details: " + "..Reference Text-- " + list[0].ToString() + "..Question Text-- " + list[1].ToString() + "..Question Type-- " + list[2].ToString() + "..Question Created-- " + list[3].ToString() + "..Question Active-- " + list[4].ToString());
                ExtentReport.test.Log(LogStatus.Pass, "..Question Details: " + "..Reference Text-- " + list[0].ToString() + "..Quetion Text-- " + list[1].ToString() + "..Question Type-- " + list[2].ToString() + "..Question Created-- " + list[3].ToString() + "..Question Active-- " + list[4].ToString());
                Logger.log.Info("Searched Global Question with Active Filter");
                ExtentReport.test.Log(LogStatus.Pass, "Searched Global Question with Active Filter");
            }
            else
            {
                Logger.log.Info("No results found.. Search Global Question with Active Filter Failed");
                ExtentReport.test.Log(LogStatus.Fail, "No results found.. Search Global Question with Active Filter Failed..");
            }

        }
        */
        #endregion



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
