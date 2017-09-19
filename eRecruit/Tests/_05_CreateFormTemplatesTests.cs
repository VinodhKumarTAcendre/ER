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
    public class _05_CreateFormTemplatesTests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Initialize()
        {
            this._driver = new TWebDriver();
            ExtentReport.CExtentReport(_driver);
            _01_BrowserClass.LaunchBrowser(_driver);
        }

        // ********************  Create Form Template ****************************

        [Test, Order(1), Author("Vinodh Kumar T")]
        public void Create_ApplicationFormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Create Application Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Application Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Application Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.AddQuestionToStep(_driver, "FormTemplatesData", "AddQuestiontoStep");
            FormTempCreaPage.AddGlobalQuestionToStep(_driver, "FormTemplatesData", "AddGlobalQuestiontoStep");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            Logger.log.Info("Application Form Template is Created with Steps and Local Questions and Global Questions");
            ExtentReport.test.Log(LogStatus.Pass, "Application Form Template is Created with Steps and Local Questions and Global Questions");
        }

        [Test, Order(2), Author("Vinodh Kumar T")]
        public void Create_PreApplicationFormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Create Pre Application Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Pre Application Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Pre Application Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.AddQuestionToStep(_driver, "FormTemplatesData", "AddQuestiontoStep");
            FormTempCreaPage.AddGlobalQuestionToStep(_driver, "FormTemplatesData", "AddGlobalQuestiontoStep");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            Logger.log.Info("Pre Application Form Template is Created with Steps and Local Questions and Global Questions");
            ExtentReport.test.Log(LogStatus.Pass, "Pre Application Form Template is Created with Steps and Local Questions and Global Questions");
        }

        [Test, Order(3), Author("Vinodh Kumar T")]
        public void Create_RequisitionFormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Create Requisition Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Requisition Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Requisition Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.AddQuestionToStep(_driver, "FormTemplatesData", "AddQuestiontoStep");
            FormTempCreaPage.AddGlobalQuestionToStep(_driver, "FormTemplatesData", "AddGlobalQuestiontoStep");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            Logger.log.Info("Requisition Form Template is Created with Steps and Local Questions and Global Questions");
            ExtentReport.test.Log(LogStatus.Pass, "Requisition Form Template is Created with Steps and Local Questions and Global Questions");
        }

        [Test, Order(4), Author("Vinodh Kumar T")]
        public void Create_AssessmentFormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Create Assessment Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Assessment Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Assessment Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.AddQuestionToStep(_driver, "FormTemplatesData", "AddQuestiontoStep");
            FormTempCreaPage.AddGlobalQuestionToStep(_driver, "FormTemplatesData", "AddGlobalQuestiontoStep");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            Logger.log.Info("Assessment Form Template is Created with Steps and Local Questions and Global Questions");
            ExtentReport.test.Log(LogStatus.Pass, "Assessment Form Template is Created with Steps and Local Questions and Global Questions");
        }

        [Test, Order(5), Author("Vinodh Kumar T")]
        public void Create_ApprovalFormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Create Approval Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Approval Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Approval Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.AddQuestionToStep(_driver, "FormTemplatesData", "AddQuestiontoStep");
            FormTempCreaPage.AddGlobalQuestionToStep(_driver, "FormTemplatesData", "AddGlobalQuestiontoStep");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            Logger.log.Info("Approval Form Template is Created with Steps and Local Questions and Global Questions");
            ExtentReport.test.Log(LogStatus.Pass, "Approval Form Template is Created with Steps and Local Questions and Global Questions");
        }

        // ********************************** Edit and Delete Form Template ***********************************

        [Test, Order(6), Author("Vinodh Kumar T")]
        public void Edit_Delete_Application_FormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Edit And Delete Application Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Application Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Application Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.Edit_AddQuestionToStep(_driver);
            FormTempCreaPage.Edit_Delete_FormTemplate(_driver);
            Logger.log.Info("Application Form Template is Edited and Deleted");
            ExtentReport.test.Log(LogStatus.Pass, "Application Form Template is Edited and Deleted");
        }

        [Test, Order(7), Author("Vinodh Kumar T")]
        public void Edit_Delete_PreApplication_FormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Edit And Delete Pre Application Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Pre Application Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Pre Application Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.Edit_AddQuestionToStep(_driver);
            FormTempCreaPage.Edit_Delete_FormTemplate(_driver);
            Logger.log.Info("Pre Application Form Template is Edited and Deleted");
            ExtentReport.test.Log(LogStatus.Pass, "Pre Application Form Template is Edited and Deleted");
        }

        [Test, Order(8), Author("Vinodh Kumar T")]
        public void Edit_Delete_Requisition_FormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Edit And Delete Requisition Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Requisition Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Requisition Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.Edit_AddQuestionToStep(_driver);
            FormTempCreaPage.Edit_Delete_FormTemplate(_driver);
            Logger.log.Info("Requisition Form Template is Edited and Deleted");
            ExtentReport.test.Log(LogStatus.Pass, "Requisition Form Template is Edited and Deleted");
        }

        [Test, Order(9), Author("Vinodh Kumar T")]
        public void Edit_Delete_Assessment_FormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Edit And Delete Assessment Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Assessment Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Assessment Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.Edit_AddQuestionToStep(_driver);
            FormTempCreaPage.Edit_Delete_FormTemplate(_driver);
            Logger.log.Info("Assessment Form Template is Edited and Deleted");
            ExtentReport.test.Log(LogStatus.Pass, "Assessment Form Template is Edited and Deleted");
        }

        [Test, Order(10), Author("Vinodh Kumar T")]
        public void Edit_Delete_Approval_FormTemplate()
        {
            ExtentReport.test = ExtentReport.extent.StartTest("Edit And Delete Approval Form Template");
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("FormTemplatesData", "FormTemplate", "FormType", "Approval Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            ExtentReport.test.Log(LogStatus.Pass, "Approval Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "FormTemplatesData", "FormTemplateSteps", "FormType");
            FormTempCreaPage.Edit_AddQuestionToStep(_driver);
            FormTempCreaPage.Edit_Delete_FormTemplate(_driver);
            Logger.log.Info("Approval Form Template is Edited and Deleted");
            ExtentReport.test.Log(LogStatus.Pass, "Approval Form Template is Edited and Deleted");
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
