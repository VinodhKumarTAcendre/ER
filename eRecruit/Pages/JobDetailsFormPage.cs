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
    public class JobDetailsFormPage
    {
        public JobDetailsFormPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Add New Form Step")]
        private IWebElement elelnkAddNewFormStep { get; set; }

        /// <summary>
        /// Create New Form Template Link
        /// </summary>
        public void AddNewFormTemplate()
        {
            
            elelnkAddNewFormStep.Click();
            Logger.log.Info("Clicked on Add New Form Template Link");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Add New Form Template Link");
            
        }

        [FindsBy(How = How.Name, Using = "StepTitle")]
        private IWebElement eletxtStepTitle{ get; set; }

        public void StepTitleJobDetails(string Value)
        {
            eletxtStepTitle.SendKeys(Value);
            Logger.log.Info("Entered step Title: " + Value);
            ExtentReport.test.Log(LogStatus.Info, "Entered step Title: " + Value);
        }


        [FindsBy(How = How.Id, Using = "StepDescription_ifr")]
        private IWebElement eleStepDescription { get; set; }

        public IWebElement StepDescription()
        {
            return eleStepDescription;
        }

        [FindsBy(How = How.Id, Using = "labelWidthType1")]
        private IWebElement eleradioSystemDefault { get; set; }

        public void SystemDefaultQuestionLabelWidth()
        {
            eleradioSystemDefault.Click();
        }

        [FindsBy(How = How.Id, Using = "labelWidthType2")]
        private IWebElement eleradioCustomPixel { get; set; }

        public void CustomPixelQuestionLabelWidth()
        {
            eleradioCustomPixel.Click();
            Logger.log.Info("Question Label Width : Custom Pixel");
            ExtentReport.test.Log(LogStatus.Info, "Question Label Width : Custom Pixel");
        }

        [FindsBy(How = How.Id, Using = "labelWidthType3")]
        private IWebElement eleradioCustomPercentage { get; set; }

        public void CustomPercentageQuestionLabelWidth()
        {
            eleradioCustomPercentage.Click();
            Logger.log.Info("Question Label Width : Custom Percentage");
            ExtentReport.test.Log(LogStatus.Info, "Question Label Width : Custom Percentage");
        }

        [FindsBy(How = How.Name, Using = "btnSubmit")]
        private IWebElement elebtnsave { get; set; }

        /// <summary>
        /// Save Form Step
        /// </summary>
        public void SaveStepdetails()
        {
            elebtnsave.Click();
            Logger.log.Info("Clicked on Save Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Save Button");
        }

    }
}
