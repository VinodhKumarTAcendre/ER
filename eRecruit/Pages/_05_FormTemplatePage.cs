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
    public class _05_FormTemplatePage
    {
        public _05_FormTemplatePage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

       // [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Add new Form Template')]")]
        [FindsBy(How = How.LinkText, Using = "Add new Form Template")]
        private IWebElement elelnkCreateForm { get; set; }

        /// <summary>
        /// Create New Form Template Link
        /// </summary>
        public void AddNewFormTemplate()
        {
            //BaseMethods.SleepTimeOut(10000);
            elelnkCreateForm.Click();
            Logger.log.Info("Clicked on Add new Form Template Link");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Add new Form Template Link");
            //BaseMethods.SleepTimeOut(10000);
        }
    }
}