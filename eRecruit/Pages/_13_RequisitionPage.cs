using eRecruit.Library;
using eRecruit.Library.Excel;
using eRecruit.Library.Extent_Reports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Pages
{
    public class _13_RequisitionPage
    {
        static IWebDriver driver;

        public _13_RequisitionPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//a[text()=' Create New Requisition']")]
        private IWebElement elelinkCreateNewRequisition { get; set; }
        public void LinkCreateNewRequisition()
        {
            elelinkCreateNewRequisition.Click();
            BaseMethods.InfoLogger("Clicked on 'Create New Requisition' Link");
        }

        // Search
        [FindsBy(How = How.Name, Using = "Keywords")]
        private IWebElement eleTxtKeywords { get; set; }
        public void TxtKeywords(string Value)
        {
            eleTxtKeywords.Clear();
            eleTxtKeywords.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in the Search Keyword Field");
        }

        [FindsBy(How = How.Name, Using = "btn_Search")]
        private IWebElement eleBtnSearch { get; set; }
        public void Search()
        {
            eleBtnSearch.Click();
            BaseMethods.InfoLogger("Clicked on 'Search' Button");
        }

        [FindsBy(How = How.Id, Using = "UserFilter")]
        private IWebElement eleDdlRaisedByFilter { get; set; }

        [FindsBy(How = How.Id, Using = "TaskStatusID")]
        private IWebElement eleDdlStepStatusFilter { get; set; }

        [FindsBy(How = How.Id, Using = "JobStatusLabelID")]
        private IWebElement eleDdlStatusFilter { get; set; }

        [FindsBy(How = How.Name, Using = "btn_Continue")]
        private IWebElement eleBtnContinue { get; set; }
        public void Continue()
        {
            eleBtnContinue.Click();
            BaseMethods.InfoLogger("Clicked on 'Continue' Button");
        }

        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement eleBtnCancel { get; set; }
        public void Cancel()
        {
            eleBtnCancel.Click();
            BaseMethods.InfoLogger("Clicked on 'Cancel' Button");
        }

        // Create New Requisition
        [FindsBy(How = How.XPath, Using = "//input[@name='rcSteps']")]
        private IList<IWebElement> eleRadioCreateReq { get; set; }
        public void RadioCreateNewReq(string Value)
        {
            if (Value == "Raise an ATR for a new position")
            {
                if (eleRadioCreateReq[0].Displayed)
                {
                    eleRadioCreateReq[0].Click();
                    BaseMethods.InfoLogger(Value + ": is Selected for Create New Requisition by");
                }
            }
            else if (Value == "Raise an ATR for an existing position using the position library")
            {
                if (eleRadioCreateReq[1].Displayed)
                {
                    eleRadioCreateReq[1].Click();
                    BaseMethods.InfoLogger(Value + ": is Selected for Create New Requisition by");
                }
            }
            else
            {
                BaseMethods.InfoLogger("Invalid option is provided for 'Create New Requisition by'");
            }
        }

        #endregion

        [FindsBy(How = How.XPath, Using = "//div[@class='cp_field']")]
        private IList<IWebElement> eleTxtAnswers { get; set; }

        [FindsBy(How = How.Id, Using = "action_save")]
        private IWebElement eleBtnSave { get; set; }
        public void Save()
        {
            eleBtnSave.Click();
            BaseMethods.InfoLogger("Clicked on 'Save' button");
        }

        [FindsBy(How = How.Id, Using = "action_saveAndContinue")]
        private IWebElement eleBtnSavenContinue { get; set; }
        public void SaveAndContinue()
        {
            eleBtnSavenContinue.Click();
            BaseMethods.InfoLogger("Clicked on 'Save and Continue' button");
        }

        [FindsBy(How = How.Id, Using = "action_previewAndSubmit")]
        private IWebElement eleBtnPreviewAndSubmit { get; set; }
        public void PreviewAndSubmit()
        {
            eleBtnPreviewAndSubmit.Click();
            BaseMethods.InfoLogger("Clicked on 'Preview And Submit' button");
        }

        [FindsBy(How = How.Name, Using = "Save and Submit")]
        private IWebElement eleBtnSaveAndSubmit { get; set; }
        public void SaveAndSubmit()
        {
            eleBtnSaveAndSubmit.Click();
            BaseMethods.InfoLogger("Clicked on 'Save And Submit' button");
        }

        #region Methods

        public void CreateNewRequisition(IWebDriver _driver)
        {
            ArrayList ReqList = ExcelData.GetData("RequisitionData", "Requisition");
            LinkCreateNewRequisition();
            RadioCreateNewReq(ReqList[0].ToString());
            if (ReqList[0].ToString() == "Raise an ATR for a new position")
            {
                try
                {
                    IWebElement ele = driver.FindElement(By.XPath("//td[contains(text(),'" + ReqList[1].ToString() + "')]/../td[5]/a"));
                    ele.Click();
                }
                catch (Exception)
                {
                    ExtentReport.test.Log(LogStatus.Error, "Requisition Process Template was not found in the list");
                }
                BaseMethods.ExplicitWait(_driver, "//a[text()='View / Add Recruiter Files']");
                foreach (IWebElement ele in eleTxtAnswers)
                {
                    ele.SendKeys("Answer Entered");
                }
                SaveAndContinue();
                foreach (IWebElement ele in eleTxtAnswers)
                {
                    ele.SendKeys("Answer Entered");
                }
                PreviewAndSubmit();
                SaveAndSubmit();
            }
        }
        #endregion


    }
}
