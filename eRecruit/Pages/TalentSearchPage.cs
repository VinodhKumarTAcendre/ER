using eRecruit.Library.Extent_Reports;
using eRecruit.Library.Log4Net;
using eRecruit.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;


namespace eRecruit.Pages
{
    public class TalentSearchPage
    {
        public TalentSearchPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Name, Using = "Keywords")]
        private IWebElement elebtnTalentKeyWords { get; set; }

        public void KeywordSearch(string Value)
        {
            elebtnTalentKeyWords.SendKeys(Value);
            Logger.log.Info("Entered keyword Name: " + Value);
            ExtentReport.test.Log(LogStatus.Info, "Entered keyword Name: " + Value);
        }


        [FindsBy(How = How.Name, Using = "btn_Search")]
        private IWebElement elebtnsearch { get; set; }

        public void Search()
        {
            elebtnsearch.Click();
            Logger.log.Info("Clicked on Search Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Search Button");
        }


        [FindsBy(How = How.Name, Using = "btnResetTalentSearchCriteria")]
        private IWebElement elebtnClear { get; set; }


        public void Clear()
        {
            elebtnClear.Click();
            Logger.log.Info("Clicked on Search Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Search Button");
        }


        [FindsBy(How = How.LinkText, Using = "Show criteria list")]
        private IWebElement elebtnCriteriaLink { get; set; }

        public void CriteriaLink()
        {
            elebtnCriteriaLink.Click();
            Logger.log.Info("Clicked on CriteriaLink");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on CriteriaLink");
        }

        [FindsBy(How = How.LinkText, Using = "Hide search criteria list")]
        private IWebElement elebtnHidesearchcriterialist { get; set; }

        public void Hidesearchcriterialist()
        {
            elebtnHidesearchcriterialist.Click();
            Logger.log.Info("Clicked on Hide search criteria list");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Hide search criteria list");
        }


        [FindsBy(How = How.LinkText, Using = "Application")]
        private IWebElement elebtnApplication { get; set; }

        public void Application()
        {
            elebtnApplication.Click();
            Logger.log.Info("Clicked on Application");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Application");
        }



        [FindsBy(How = How.LinkText, Using = "Job")]
        private IWebElement elebtnJob { get; set; }

        public void Job()
        {
            elebtnJob.Click();
            Logger.log.Info("Clicked on Job");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Job");
        }

        [FindsBy(How = How.LinkText, Using = "Global Assessment")]
        private IWebElement elebtnGlobalAssessment { get; set; }

        public void GlobalAssessment()
        {
            elebtnGlobalAssessment.Click();
            Logger.log.Info("Clicked on Global Assessment");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Global Assessment");
        }

       [FindsBy(How =How.LinkText, Using = "Saved Searches")]
       private IWebElement elelnkSavedSearch { get; set; }



        public void SavedSearch()
        {
            elelnkSavedSearch.Click();
            Logger.log.Info("Clicked on Saved Search Tab");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Saved Search tab");

        }



        [FindsBy(How =How.LinkText, Using = "Search Templates")]
        private IWebElement elelnkSearchTemplates { get; set; }


        public void serachTemplate()
        {
            elelnkSearchTemplates.Click();
            Logger.log.Info("clicked on Search Tempalte");
            ExtentReport.test.Log(LogStatus.Info, "clicked on Search Template");
        }


        [FindsBy(How = How.Name, Using = "SearchCriteriaFilterKeywords")]
        private IWebElement eleTxtSearchCriteriaFilterKeywords { get; set; }


        public void SearchCriteriaFilterKeywords(string Value)
        {
            eleTxtSearchCriteriaFilterKeywords.SendKeys(Value);
            Logger.log.Info("Entered SearchCriteria Name: " + Value);
            ExtentReport.test.Log(LogStatus.Info, "Entered SearchCriteria Name: " + Value);
        }

        [FindsBy(How = How.XPath, Using = "(//input[@type='button'])[1]")]
        private IWebElement eleBtnFilter { get; set; }


        public void BtnApplyFilter()
        {
            eleBtnFilter.Click();
            Logger.log.Info("Clicked On ApplyFilter");
            ExtentReport.test.Log(LogStatus.Info, "Clicked On ApplyFilter");
        }


        [FindsBy(How = How.LinkText, Using = "View All/Manage")]
        private IWebElement elelnkViewAllManage { get; set; }


        public void ViewAllManage()
        {
            elelnkViewAllManage.Click();
            Logger.log.Info("Clicked On ViewAllManage link");
            ExtentReport.test.Log(LogStatus.Info, "Clicked On ViewAllManage link");
        }


        [FindsBy(How = How.Name, Using = "btnSaveTalentSearch")]
        private IWebElement eleBtnbtnSaveTalentSearch { get; set; }


        public void SaveTalentSearch()
        {
            eleBtnbtnSaveTalentSearch.Click();
            Logger.log.Info("Clicked On SaveTalentSearch");
            ExtentReport.test.Log(LogStatus.Info, "Clicked On SaveTalentSearch");
        }


        [FindsBy(How = How.Name, Using = "Search Templates")]
        private IWebElement eleBtnSearchTemplates { get; set; }


        public void SearchTemplates()
        {
            eleBtnSearchTemplates.Click();
            Logger.log.Info("Clicked On SearchTemplates");
            ExtentReport.test.Log(LogStatus.Info, "Clicked On SearchTemplates");
        }


        [FindsBy(How = How.LinkText, Using = "Start new search")]
        private IWebElement eleBtnStartnewsearch { get; set; }


        public void Startnewsearch()
        {
            eleBtnStartnewsearch.Click();
            Logger.log.Info("Clicked On Startnewsearch");
            ExtentReport.test.Log(LogStatus.Info, "Clicked On Startnewsearch");
        }









    }
}