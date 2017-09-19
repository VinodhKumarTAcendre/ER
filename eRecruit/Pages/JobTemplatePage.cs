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
    public class JobTemplatePage
    {
        public JobTemplatePage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Add Job Template")]
        private IWebElement elelinkAddJobTemplate { get; set; }

        public void ClickOnAddJobTemplate()
        {
            elelinkAddJobTemplate.Click();
            Logger.log.Info("Clicked on AddJobTemplate");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on AddJobTemplate");
        }


        [FindsBy(How = How.XPath, Using = "//label[Contains(text(),'Job Reference ')]/../../div[2]/input")]
        private IWebElement eleTxtJobReference { get; set; }

        public void JobReference(string Value)
        {
            eleTxtJobReference.SendKeys(Value);
            Logger.log.Info("EnteredJobReference: " + Value);
            ExtentReport.test.Log(LogStatus.Info, "EnteredJobReference: " + Value);
        }

        [FindsBy(How = How.XPath, Using = "//label[Contains(text(),'Job Title ')]/../../div[2]/input")]
        private IWebElement eleTxtJobTitle { get; set; }

        public void JobTitle(string Value)
        {
            eleTxtJobTitle.SendKeys(Value);
            Logger.log.Info("EnteredJobTitle: " + Value);
            ExtentReport.test.Log(LogStatus.Info, "EnteredJobTitle: " + Value);
        }


        [FindsBy(How = How.Name, Using = "action_saveAndContinue")]
        private IWebElement eleBtnSave { get; set; }

        public void SaveButton()
        {
            eleBtnSave.Click();
            Logger.log.Info("clicked on Save Button");
            ExtentReport.test.Log(LogStatus.Info, "clicked on Save Button");
        }


    }
}


