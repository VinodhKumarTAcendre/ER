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
    public class JobsPage
    {
        IWebDriver _driver;

        public JobsPage(IWebDriver browser)
        {
            this._driver = browser;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Create New Job")]
        private IWebElement eleCreateNewJobLink { get; set; }
        public void LinkCreateNewJob()
        {
            eleCreateNewJobLink.Click();
            Logger.log.Info("Clicked on Create New Job Link");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Create New Job Link");
        }

        [FindsBy(How = How.Name, Using = "Keywords")]
        private IWebElement eleSearchKeyword { get; set; }
        public void TxtSearchKeyword(string Value)
        {
            eleSearchKeyword.SendKeys(Value);
            Logger.log.Info(Value + "Entered in the Keyword Search Box");
            ExtentReport.test.Log(LogStatus.Info, Value + "Entered in the Keyword Search Box");
        }

        [FindsBy(How = How.Name, Using = "btn_Search")]
        private IWebElement eleSearchButton { get; set; }
        public void Search()
        {
            eleSearchButton.Click();
            Logger.log.Info("Clicked on Serach Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Serach Button");
        }

        [FindsBy(How = How.Name, Using = "jcSteps")]
        public IWebElement eleRadioJobCreationType { get; set; }

        [FindsBy(How = How.Name, Using = "btn_Continue")]
        private IWebElement eleContinueButton { get; set; }
        public void Continue()
        {
            eleContinueButton.Click();
            Logger.log.Info("Clicked on Continue Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Continue Button");
        }

        // ************************************************************************************************************
        //                  Job Creation Web Elements
        // ************************************************************************************************************

        // Step 1 : Job Details

        [FindsBy(How = How.Id, Using = "userID_chosen")]
        public IWebElement eleDdlJobOwner { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='cp_field']/input)[1]")]
        private IWebElement eleTxtJobReference { get; set; }
        public void JobReference(string Value, bool Override)
        {
            if (Override == true)
            {
                eleTxtJobReference.Clear();
                eleTxtJobReference.SendKeys(Value);
                Logger.log.Info(Value + "Entered in the Job Reference Text Box");
                ExtentReport.test.Log(LogStatus.Info, Value + "Entered in the Job Reference Text Box");
            }
        }

        [FindsBy(How = How.XPath, Using = "(//div[@class='cp_field']/input)[2]")]
        private IWebElement eleTxtJobTitle { get; set; }
        public void JobTitle(string Value)
        {
            eleTxtJobTitle.SendKeys(Value);
            Logger.log.Info(Value + "Entered in the Job Title Text Box");
            ExtentReport.test.Log(LogStatus.Info, Value + "Entered in the Job Title Text Box");
        }

        [FindsBy(How = How.Id, Using = "action_saveAndContinue")]
        private IWebElement eleSaveContinueButton { get; set; }
        public void SaveandContinue()
        {
            eleSaveContinueButton.Click();
            Logger.log.Info("Clicked on Save and Continue Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Save and Continue Button");
        }

        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement eleCancelButton { get; set; }
        public void Cancel()
        {
            eleCancelButton.Click();
            Logger.log.Info("Clicked on Cancel Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Cancel Button");
        }

        [FindsBy(How = How.XPath, Using = "(//div[@class='cp_field'])[2]/div/a")]
        public IWebElement eleDdlPal_mc_test_parent { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='cp_field']/input")]
        private IWebElement eleTxtRecruitmentSpecialistName { get; set; }
        public void RecruitmentSpecialistName(string Value)
        {
            eleTxtRecruitmentSpecialistName.SendKeys(Value);
            Logger.log.Info(Value + "Entered in the Recruitment Specialist Name Text Box");
            ExtentReport.test.Log(LogStatus.Info, Value + "Entered in the Recruitment Specialist Name Text Box");
        }

        [FindsBy(How = How.Id, Using = "action_submit")]
        private IWebElement eleSubmitButton { get; set; }
        public void Submit()
        {
            eleSubmitButton.Click();
            Logger.log.Info("Clicked on Submit Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Submit Button");
        }

        // Step 2 : Talent Search

        [FindsBy(How = How.Id, Using = "Continue")]
        private IWebElement eleTalentSearchContinueButton { get; set; }
        public void TalentSerachContinue()
        {
            eleTalentSearchContinueButton.Click();
            Logger.log.Info("Clicked on Continue Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Continue Button");
        }

        // Step 3: Sourcing


        [FindsBy(How = How.LinkText, Using = "Manage Candidate Portal Configuration")]
        private IWebElement eleLinkManageCandidatePortalConfiguration { get; set; }
        public void ManageCandidatePortalConfigurationLink()
        {
            eleLinkManageCandidatePortalConfiguration.Click();
            Logger.log.Info("Clicked on Manage Candidate Portal Configuration Link Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Manage Candidate Portal Configuration Link Button");
        }

        [FindsBy(How = How.LinkText, Using = "Manage Job Ads")]
        private IWebElement eleLinkManageJobAds { get; set; }
        public void ManageJobAdsLink()
        {
            eleLinkManageJobAds.Click();
            Logger.log.Info("Clicked on Manage Job Ads Link Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Manage Job Ads Link Button");
        }

        [FindsBy(How = How.LinkText, Using = "Manage Vendors")]
        private IWebElement eleLinkManageVendors { get; set; }
        public void ManageVendorsLink()
        {
            eleLinkManageJobAds.Click();
            Logger.log.Info("Clicked on Manage Vendors Link Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Manage Vendors Link Button");
        }

        // Step 4: Criteria 

        [FindsBy(How = How.XPath, Using = "//input[@name='criteriaID']")]
        private IList<IWebElement> CriteriaSetupCheckBox { get; set; }

        // Weighting --   //form[@id='jobCriteria']/div[1]/table/tbody/tr[1]/td[3]/input

        // Criteria Description -- //form[@id='jobCriteria']/div[1]/table/tbody/tr[1]/td[4]/div/div/div[2]/iframe



        // ************************************************************************************************************


        // ************************************************************************************************************
        //                  Job Creation Methods
        // ************************************************************************************************************


        public void CreateanewJob()
        {
            CreateanewJob();
            BaseMethods.RadioButtonSelectByIndex(_driver, eleRadioJobCreationType, 0);
            // Step 1: Job Details 
            // --- Sub Step 1
            BaseMethods.DdlSelectByText(eleDdlJobOwner, "Administrator, System");
            JobReference("", false);
            JobTitle("Auto_Demo");
            SaveandContinue();
            // --- Sub Step 2
            BaseMethods.DdlSelectByText(eleDdlPal_mc_test_parent, "parent1");
            SaveandContinue();
            // --- Sub Step 3
            RecruitmentSpecialistName("Test");
            SaveandContinue();
            // --- Sub Step 4
            Submit();
            // Step 2: Talent Search
            Continue();
            // Step 3: Sourcing
            SaveandContinue();
        }
    }
}
