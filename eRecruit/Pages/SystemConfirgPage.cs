using eRecruit.Library;
using eRecruit.Library.Extent_Reports;
using eRecruit.Library.Log4Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Pages
{
    public class SystemConfirgPage
    {
        IWebDriver driver;
        public SystemConfirgPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='User Manager']")]
        private IWebElement elelnkUserManager { get; set; }
        public void LinkUserManager()
        {
            elelnkUserManager.Click();
            BaseMethods.InfoLogger("Clicked on 'User Manager' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='User Group Manager']")]
        private IWebElement elelnkUserGroupManager { get; set; }
        public void LinkUserGroupManager()
        {
            elelnkUserGroupManager.Click();
            BaseMethods.InfoLogger("Clicked on 'User Group Manager' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Global Questions']")]
        private IWebElement elelnkGlobalQuestions { get; set; }
        public void LinkGlobalQuestions()
        {
            elelnkGlobalQuestions.Click();
            BaseMethods.InfoLogger("Clicked on 'Global Questions' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Form Templates']")]
        private IWebElement elelnkFormTemplates { get; set; }
        public void LinkFormTemplates()
        {
            BaseMethods.ScrollToView(driver, elelnkFormTemplates);
            elelnkFormTemplates.Click();
            BaseMethods.InfoLogger("Clicked on 'Form Templates' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='SI Form Templates']")]
        private IWebElement elelnkSIFormTemplates { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Form Layouts']")]
        private IWebElement elelnkFormLayouts { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='System Forms']")]
        private IWebElement elelnkSystemForms { get; set; }

        public void LinkSystemForms()
        {
            elelnkSystemForms.Click();
            BaseMethods.InfoLogger("Clicked on 'System Form' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='User Details Form']")]
        private IWebElement elelnkUserDetails { get; set; }
        public void LinkUserDetails()
        {
            elelnkUserDetails.Click();
            BaseMethods.InfoLogger("Clicked on 'User Details' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Position Details Form']")]
        private IWebElement elelnkPositionDetails { get; set; }
        public void LinkPositionDetails()
        {
            elelnkPositionDetails.Click();
            Logger.log.Info("Clicked on 'Position Details' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Job Details Form']")]
        private IWebElement elelnkJobDetailsForm { get; set; }
        public void LinkJobDetailsForm()
        {
            elelnkJobDetailsForm.Click();
            BaseMethods.InfoLogger("Clicked on 'Job Details Form' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Configure Roles']")]
        private IWebElement elelnkConfigureRoles { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='View Configuration Log']")]
        private IWebElement elelnkViewConfigLog { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='View Data Deletion Log']")]
        private IWebElement elelnkViewDataDeletionLog { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='User Defined View List']")]
        private IWebElement elelnkUserDefinedViewList { get; set; }
        public void LinkUserDefinedViewList()
        {
            elelnkUserDefinedViewList.Click();
            BaseMethods.InfoLogger("Clicked on 'User Defined View List' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='File Restrictions']")]
        private IWebElement elelnkFileRestrictions { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Email Templates']")]
        private IWebElement elelnkEmailTemplateCreation { get; set; }

        public void LinkEmailTemplateCreation()
        {
            elelnkEmailTemplateCreation.Click();
            BaseMethods.InfoLogger("Clicked on 'Email Template Creation' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Global Help Library']")]
        private IWebElement elelnkGlobalHelpLibrary { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Question Sets']")]
        private IWebElement elelnkQuestionSets { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Configure Product Feedback']")]
        private IWebElement elelnkConfigProductFeedback { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Assessment Process Templates']")]
        private IWebElement elelnkAssessmentProcessTemplates { get; set; }
        public void LinkAssessmentProcessTemplates()
        {
            elelnkAssessmentProcessTemplates.Click();
            BaseMethods.InfoLogger("Clicked on 'Assessment Process Templates' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Requisition Process Templates']")]
        private IWebElement elelnkRequisitionProcessTemplates { get; set; }
        public void LinkRequisitionProcessTemplates()
        {
            elelnkRequisitionProcessTemplates.Click();
            BaseMethods.InfoLogger("Clicked on 'Requisition Process Templates' Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Merge Document Templates']")]
        private IWebElement elelnkMergeDocumentTemplates { get; set; }
        public void LinkMergeDocumentTemplates()
        {
            elelnkMergeDocumentTemplates.Click();
            BaseMethods.InfoLogger("Clicked on 'Merge Document Templates' Link");
        }
    }
}
