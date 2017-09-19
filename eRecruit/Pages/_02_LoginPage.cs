using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using eRecruit.Library;
using System.Data.OleDb;
using System.Data;
using eRecruit.Library.Log4Net;
using eRecruit.Library.Extent_Reports;
using RelevantCodes.ExtentReports;
using eRecruit.Library.Excel;
using System.Collections;

namespace eRecruit.Pages
{
    public class _02_LoginPage
    {
        IWebDriver _driver;

        public _02_LoginPage(IWebDriver browser)
        {
            this._driver = browser;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement eletxtUsername { get; set; }
        public void Username(string Value)
        {
            eletxtUsername.SendKeys(Value);
            Logger.log.Info(Value + " -- entered in Username Text Field");
            ExtentReport.test.Log(LogStatus.Info, "Entered value in the Username Text Field");
        }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement eletxtPassword { get; set; }
        public void Password(string Value)
        {
            eletxtPassword.SendKeys(Value);
            Logger.log.Info(Value + " -- entered in Password Text Field");
            ExtentReport.test.Log(LogStatus.Info, "Entered value in the Password Text Field");
        }

        [FindsBy(How = How.Name, Using = "btn_Login")]
        public IWebElement elebtnLogin { get; set; }
        public void LoginButton()
        {
            elebtnLogin.Click();
            Logger.log.Info("Clicked on Login Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Login Button");
        }

        [FindsBy(How = How.LinkText, Using = "Forgot your Password?")]
        private IWebElement elelnkFrgtPwd { get; set; }
        public void ForgotPasswordLink()
        {
            elelnkFrgtPwd.Click();
            Logger.log.Info("Clicked on Forgot Password Link");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Forgot Password Link");
        }

        /// *************************************************************************************************
        ///                                     Methods
        /// *************************************************************************************************

        /// <summary>
        /// Gets the Username and Password Details
        /// </summary>
        /// <param name="Key">Mention the Configurtion Key defined in the App.config file</param>
        /// <param name="Sheet">Excel Sheet Name</param>
        /// <param name="Condition">Key value to get the Data from Sheet</param>
        /// <param name="Value">Value to filter/get the Data</param>
        /// <returns>List of Values</returns>
        public ArrayList GetLoginDetails(string Key, string Sheet, string Condition, string Value)
        {
            ArrayList list = ExcelData.GetData(Key, Sheet, Condition, Value);
            return list;
        }

        /// <summary>
        /// Gets Forgot Password Link Text
        /// </summary>
        /// <returns></returns>
        public string GetLinkText()
        {
            return elelnkFrgtPwd.Text;
        }
                
        /// *************************************************************************************************
        ///                                 Forgot Your Password Page
        /// *************************************************************************************************

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement eleEmailIDTxt { get; set; }
        /// <summary>
        /// Email Address Text Field to Reset Password
        /// </summary>
        /// <param name="EmailId">Enter the Email Id</param>
        public void EnterEmailID(string EmailId)
        {
            eleEmailIDTxt.SendKeys(EmailId);
        }

        [FindsBy(How = How.Name, Using = "btn_Reset")]
        private IWebElement eleResetBtn { get; set; }
        /// <summary>
        /// Click on Reset button to Reset Password 
        /// </summary>
        public void Reset()
        {
            eleResetBtn.Click();
        }

        [FindsBy(How = How.Name, Using = "Back_to_Login")]
        private IWebElement eleBacktoLoginBtn { get; set; }
        /// <summary>
        /// Navigate back to Login Page 
        /// </summary>
        public void BackToLogin()
        {
            eleBacktoLoginBtn.Click();
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='field_label_container']/div[1]")]
        private IWebElement eleVerifyEmailLabel { get; set; }
        /// <summary>
        /// Verify the Email Id in Reset Confirmation Page
        /// </summary>
        public string VerifyEmailID()
        {
            return eleVerifyEmailLabel.Text;
        }

    }
}
