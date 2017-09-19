//using eRecruit.Library;
//using eRecruit.Library.Extent_Reports;
//using eRecruit.Library.Log4Net;
//using eRecruit.Pages;
//using NUnit.Framework;
//using NUnit.Framework.Interfaces;
//using OpenQA.Selenium;
//using RelevantCodes.ExtentReports;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace eRecruit.Tests
//{
//    public class RegressionScripts
//    {
//        static IWebDriver _driver;

//        [OneTimeSetUp]
//        public void Initialize()
//        {
//            _driver = _02_LoginPageTests.LoginPageDriver();
//        }

//        [Test, Order(1)]
//        [TestCase("Free Text", "ER_TESTDATA", "GlobalQuestionWithOptions", "SLNO", "1")]
//        //[TestCase("Multiple Choice", "ER_TESTDATA", "GlobalQuestionWithOptions", "SLNO", "2")]
//        //[TestCase("Yes/No", "ER_TESTDATA", "GlobalQuestionWithOptions", "SLNO", "3")]
//        //[TestCase("Date", "ER_TESTDATA", "GlobalQuestionWithOptions", "SLNO", "4")]
//        //[TestCase("Ordered Preference List", "ER_TESTDATA", "GlobalQuestionWithOptions", "SLNO", "5")]
//        //[TestCase("Multi Select", "ER_TESTDATA", "GlobalQuestionWithOptions", "SLNO", "6")]
//        //[TestCase("File Upload", "ER_TESTDATA", "GlobalQuestionWithOptions", "SLNO", "7")]
//        //[TestCase("Group Question", "ER_TESTDATA", "GlobalQuestionWithOptions", "SLNO", "8")]
//        //[TestCase("Label", "ER_TESTDATA", "GlobalQuestionWithOptions", "SLNO", "9")]
//        public void CreateGlobalQuestionWithOptions(string TestName, string ConfigKey, string SheetName, string ConditionKey, string Condition)
//        {
//            ExtentReport.test = ExtentReport.extent.StartTest("Add GQ with Options: " + TestName);
//            _03_HomePage HP = new _03_HomePage(_driver);
//            HP.SystemHeader();
//            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
//            SysConPage.LinkGlobalQuestions();
//            _04_GlobalQtnListPage GlbQtnListPage = new _04_GlobalQtnListPage(_driver);
//            GlbQtnListPage.CreateNewGlbQtn();
//            CreateGlobalQueWithOptionsPage GlbQtnPage = new CreateGlobalQueWithOptionsPage(_driver);
//            GlbQtnPage.CreateQuestionWithOptions(_driver, ConfigKey, SheetName, ConditionKey, Condition);
//            Logger.log.Info("Created new Global Question with Options");
//            ExtentReport.test.Log(LogStatus.Pass, "Created new Global Question with Options");
//        }

//        [Test, Order(2)]
//        [TestCase("Application Form")]
//        public void CreateMultipleFormTemplate_GlobalQue(string TestFormName)
//        {
//            ExtentReport.test = ExtentReport.extent.StartTest("Create Form Templates - Multiple Global Question");
//            _03_HomePage HP = new _03_HomePage(_driver);
//            HP.SystemHeader();
//            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
//            SysConPage.LinkFormTemplates();
//            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
//            FormTempPage.AddNewFormTemplate();
//            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
//            ArrayList list = FormTempCreaPage.GetFormDetails(TestFormName);
//            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
//            FormTempCreaPage.FormName(list[1].ToString());
//            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
//            FormTempCreaPage.SaveFormTemplate();
//            ExtentReport.test.Log(LogStatus.Pass, "Form Template Created");
//            FormTempCreaPage.CreateMultipleSteps(_driver);
//            FormTempCreaPage.AddGlobalQuestionToStep(_driver);
//            FormTempCreaPage.AddQuestionToStep(_driver);
//            Logger.log.Info("Form Template Created with Multiple Steps and Global Questions");
//            ExtentReport.test.Log(LogStatus.Pass, "Form Template Created with Multiple Steps and Global Questions");
//        }

//        [Test, Order(3)]
//        public void AddMultipleGlobalQuestionUserDetailsForm()
//        {
//            ExtentReport.test = ExtentReport.extent.StartTest("Create User Details Form");
//            _03_HomePage HP = new _03_HomePage(_driver);
//            HP.SystemHeader();
//            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
//            SysConPage.LinkSystemForms();
//            SysConPage.LinkUserDetails();
//            _06_UserDetailsFormPage UdForm = new _06_UserDetailsFormPage(_driver);
//            UdForm.FormName("User Details Form");
//            UdForm.SaveUserDetailsForm();
//            UdForm.AddGlobalQuestionToForm(_driver);
//            UdForm.AddQuestionToStep(_driver);
//            Logger.log.Info("Create User Details Form Completed");
//            ExtentReport.test.Log(LogStatus.Pass, "Create User Details Form Completed");
//        }

//        [TearDown]
//        public void GetResult()
//        {
//            var status = TestContext.CurrentContext.Result.Outcome.Status;
//            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
//            var errorMessage = TestContext.CurrentContext.Result.Message;

//            if (status == TestStatus.Failed)
//            {
//                string screenShotPath = ExtentReport.Capture(_driver);
//                ExtentReport.test.Log(LogStatus.Fail, stackTrace + errorMessage);
//                ExtentReport.test.Log(LogStatus.Fail, "Please find the Screenshot below: " + ExtentReport.test.AddScreenCapture(screenShotPath));
//            }
//            ExtentReport.extent.EndTest(ExtentReport.test);
//        }

//        [OneTimeTearDown]
//        public void CleanUp()
//        {
//            _driver.Quit();
//            ExtentReport.extent.Flush();
//            ExtentReport.extent.Close();
//        }
//    }
//}
