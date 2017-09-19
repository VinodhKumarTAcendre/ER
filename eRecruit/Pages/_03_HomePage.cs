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
    public class _03_HomePage
    {
        IWebDriver _driver;

        public _03_HomePage(IWebDriver browser)
        {
            this._driver = browser;
            PageFactory.InitElements(_driver, this);
        }

        // *** Menu WebElements
        #region Menu WebElements

        [FindsBy(How = How.XPath, Using = "//li[@id='home']/a")]
        private IWebElement eleHomeHeaderLink { get; set; }
        public void HomeHeader()
        {
            eleHomeHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'Home' link in the Home Page Menu");
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='tasks']/a")]
        private IWebElement eleTasksHeaderLink { get; set; }
        public void TasksHeader()
        {
            eleTasksHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'Tasks' link in the Home Page Menu");
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='talent']/a")]
        private IWebElement eleTalentHeaderLink { get; set; }
        public void TalentHeader()
        {
            eleTalentHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'Talent' link in the Home Page Menu");
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='requisitions']/a")]
        private IWebElement eleRequisitionHeaderLink { get; set; }
        public void RequisitionHeader()
        {
            eleRequisitionHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'Requisition' link in the Home Page Menu");
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='jobs']/a")]
        private IWebElement elejobsHeaderLink { get; set; }
        public void JobsHeader()
        {
            elejobsHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'Jobs' link in the Home Page Menu");
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='scheduler']/a")]
        private IWebElement eleSchedulerHeaderLink { get; set; }
        public void SchedulerHeader()
        {
            eleSchedulerHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'Scheduler' link in the Home Page Menu");
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='sharedfiles']/a")]
        private IWebElement eleFilesHeaderLink { get; set; }
        public void FilesHeader()
        {
            eleFilesHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'Files' link in the Home Page Menu");
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='reports']/a")]
        private IWebElement eleAnalyticsHeaderLink { get; set; }
        public void AnalyticsHeader()
        {
            eleAnalyticsHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'Analytics' link in the Home Page Menu");
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='system']/a")]
        private IWebElement eleSystemHeaderLink { get; set; }
        public void SystemHeader()
        {
            eleSystemHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'System' link in the Home Page Menu");
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='notifications']/a")]
        private IWebElement eleMessagesHeaderLink { get; set; }
        public void MessagesHeader()
        {
            eleMessagesHeaderLink.Click();
            BaseMethods.InfoLogger("Clicked on 'Messages' link in the Home Page Menu");
        }
        
        #endregion

        /// <summary>
        /// DashBoard Element
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Dashboard')]")]
        private IWebElement eleDashboardIcon { get; set; }
        public string DashBoardValue()
        {
            string value = eleDashboardIcon.Text;
            Logger.log.Info("Dashboard Value is: " + value);
            ExtentReport.test.Log(LogStatus.Info, "Dashboard Value is: " + value);
            Console.WriteLine("Dashboard Value is: " + value);
            return value;
        }

        /// <summary>
        /// Job Radio Button
        /// </summary>
        [FindsBy(How = How.Id, Using = "radio_job")]
        private IWebElement eleJobRadio { get; set; }
        public void JobRadioButton()
        {
            eleJobRadio.Click();
            Logger.log.Info("Cliked on Job Radio Button");
            ExtentReport.test.Log(LogStatus.Info, "Cliked on Job Radio Button");
            Console.WriteLine("Cliked on Job Radio Button");
        }

        /// <summary>
        /// Candidate Radio Button
        /// </summary>
        [FindsBy(How = How.Id, Using = "radio_candidate")]
        private IWebElement eleCandidateRadio { get; set; }
        public void CandidateRadioButton()
        {
            eleCandidateRadio.Click();
            Logger.log.Info("Cliked on Candidate Radio Button");
            ExtentReport.test.Log(LogStatus.Info, "Cliked on Candidate Radio Button");
            Console.WriteLine("Cliked on Candidate Radio Button");
        }

        /// <summary>
        /// Job Search Text Box
        /// </summary>
        [FindsBy(How = How.Name, Using = "Keywords")]
        private IWebElement eleJobSearchTxt { get; set; }
        public void JobKeywordSearch(string _Keyword)
        {
            eleJobSearchTxt.SendKeys(_Keyword);
            Logger.log.Info(_Keyword + " -- entered in Job Keyword Search Text Field");
            ExtentReport.test.Log(LogStatus.Info, "Entered " + _Keyword + " in Job Keyword Search Text Field");
            Console.WriteLine("Entered " + _Keyword + " in Job Keyword Search Text Field");
        }

        /// <summary>
        /// Candidate Search Text Box
        /// </summary>
        [FindsBy(How = How.Id, Using = "CandidateSearchText")]
        private IWebElement eleCandidateSearchTxt { get; set; }
        public void CandidateKeywordSearch(string _Keyword)
        {
            eleCandidateSearchTxt.SendKeys(_Keyword);
            Logger.log.Info(_Keyword + " -- entered in Candidate Keyword Search Text Field");
            ExtentReport.test.Log(LogStatus.Info, "Entered " + _Keyword + " in Candidate Keyword Search Text Field");
            Console.WriteLine("Entered " + _Keyword + " in Candidate Keyword Search Text Field");
        }

        /// <summary>
        /// Job Search Button in Home Page
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//div[@id='jobSearch']/form/input[8]")]
        private IWebElement eleJobSearchBtn { get; set; }
        public void JobSearch()
        {
            eleJobSearchBtn.Click();
            Logger.log.Info("Clicked on Search Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Search Button");
            Console.WriteLine("Clicked on Search Button");
        }

        /// <summary>
        /// Candidate Search Button in Home Page
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//div[@id='candidateSearch']/form/input[6]")]
        private IWebElement eleCandidateSearchBtn { get; set; }
        public void CandidateSearch()
        {
            eleCandidateSearchBtn.Click();
            Logger.log.Info("Cliked on Search Button");
            ExtentReport.test.Log(LogStatus.Info, "Cliked on Search Button");
            Console.WriteLine("Cliked on Search Button");
        }
    }
}
